using AAITHelper;
using AAITHelper.Enums;
using AutoMapper.QueryableExtensions;
using KhadimiEssa.ApiModels;
using KhadimiEssa.AutoMapper;
using KhadimiEssa.Data;
using KhadimiEssa.Data.TableDb;
using KhadimiEssa.Helper;
using KhadimiEssa.Interfaces.Auth;
using KhadimiEssa.Interfaces.Logic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using static KhadimiEssa.Enums.AllEnums;
using static KhadimiEssa.Helper.HelperMethods;

namespace KhadimiEssa.Implementation.Logic
{
    public class LogicClientService : ILogicClientService
    {
        private readonly ApplicationDbContext _db;
        private readonly ICurrentUserService _currentUserService;

        public LogicClientService(ApplicationDbContext db, ICurrentUserService currentUserService)

        {
            _db = db;
            _currentUserService = currentUserService;
        }

        public async Task<List<OilStationDto>> GetOilStation(string lang)
        {
            var station = await _db.OilStations.Where(x => x.IsActive).Select(x => new OilStationDto
            {
                id = x.Id,
                name = x.ChangeLangName(lang),
                lat = x.Lat,
                lng = x.Lng,
                location = x.Location
            }).ToListAsync();

            return station;

        }

        public async Task<List<AvailableTimesDto>> ListAvailableTimes(string day, string lang)
        {
            var dayDate = HelperDate.ConvertFromStringToDate(day, "dd/MM/yyyy");
            var dateNow = HelperDate.GetCurrentDate();

            dateNow = dateNow.AddHours(1);
            dateNow = dateNow.AddMinutes(-10);

            int countOrderTime = await _db.Settings.Select(x => x.CountOrderForTime).FirstOrDefaultAsync();
            var times = await _db.AvailableTimes.Where(x => x.IsActive
                                                   && dayDate.Date >= dateNow.Date
                                                   && (dayDate.Date == dateNow.Date ? x.time.TimeOfDay >= dateNow.TimeOfDay : true))
                                                   //&& (x.Orders.Where(o => o.ExecutionDate.Date == dayDate.Date && x.Id == o.ExecutionTime && (o.Status != orderstutes.finishedorder.ToNumber() || o.Status != orderstutes.Canceledorder.ToNumber() || o.Status != orderstutes.Refusedorder.ToNumber())).Count()) < countOrderTime)
                .Select(x => new AvailableTimesDto
                {
                    id = x.Id,
                    time = x.time.ToString("hh:mm tt")

                }).ToListAsync();

            return times;

        }

        public async Task<List<CarBrandDto>> ListCarBrands(string lang)
        {
            var cars = await _db.CarBrands.Where(x => x.IsActive).Select(x => new CarBrandDto
            {
                id = x.Id,
                name = x.ChangeLangName(lang),

            }).ToListAsync();

            return cars;

        }
        public async Task<List<PaymentMethodDto>> ListPaymentMethods(string lang)
        {
            var paymentMethods = await _db.paymentMethods.Where(x => x.IsActive).Select(x => new PaymentMethodDto
            {
                id = x.Id,
                name = x.ChangeLangName(lang),

            }).ToListAsync();

            return paymentMethods;

        }

        public async Task<List<PackageDto>> ListPackages(string lang)
        {
            var packages = await _db.Packages.Where(x => x.IsActive).Select(x => new PackageDto
            {
                id = x.Id,
                name = x.ChangeLangName(lang),
                description = x.ChangeLangDesc(lang),
                price = x.Price

            }).ToListAsync();

            return packages;

        }

        public async Task<int> CountNotify()
        {
            var countNotify = await _db.NotifyClients.Where(x => x.FKUser == _currentUserService.UserId && x.Show == false).CountAsync();

            return countNotify;
        }

        public async Task<double> DepositPrice()
        {
            var depositPrice = await _db.Settings.FirstOrDefaultAsync();

            return depositPrice.IsShowDepositPrice ? depositPrice.DepositPrice : 0;
        }

        #region Get Available Stations And its Distance
        public async Task<List<AvailableStationDto>> CalculateStationsBydistance(double sLatitude, double sLongitude)
        {
            var allStation = await _db.OilStations.ToListAsync();

            List<AvailableStationDto> AvailableStation = new List<AvailableStationDto>();

            foreach (var station in allStation)
            {
                var RequiredDistance = GetDistance(sLatitude, sLongitude, station.Lat, station.Lng);
                if (RequiredDistance <= station.ServiceScope)
                {
                    AvailableStation.Add(new AvailableStationDto { stationId = station.Id, distance = RequiredDistance });
                }
            }

            return AvailableStation;

        }
        public async Task<int> GetCountStationsAvailable(double Lat, double Lng)
        {
            List<AvailableStationDto> stations = await CalculateStationsBydistance(Lat, Lng);

            return stations.Count();
        }

        #endregion

        public async Task<Response<dynamic>> CheckRequiredDistanceAsync(CheckRequiredDistance checkRequiredDistance)
        {
            try
            {
                int CountStations = await GetCountStationsAvailable(checkRequiredDistance.lat, checkRequiredDistance.lng);
                if (CountStations > 0)
                {
                    return new Response<dynamic>(true, HelperMsg.creatMessage(checkRequiredDistance.lang, "يرجى اتمام الطلب", "please, Complete your order"));
                }

                return new Response<dynamic>(false, HelperMsg.creatMessage(checkRequiredDistance.lang, "عفوا انت خارج نطاق الخدمة", "Sorry you are out of Service Scope"));
            }

            catch (Exception ex)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                LogExption logExption = new LogExption()
                {
                    Date = DateTime.Now,
                    Exption = ex.Message,
                    ServiceName = m.Name,
                    UserId = ""
                };
                await _db.LogExption.AddAsync(logExption);
                await _db.SaveChangesAsync();
                return new Response<dynamic>(HelperMsg.MsgValidation(EnumValidMsg.Auth.SomethingWrong.ToNumber(), checkRequiredDistance.lang));
            }
        }

        public async Task<(int, string)> CheckTimeAvailableAsync(int time, string executionDate,int stationId = 1 ,string lang = "ar")
        {
            try
            {
                var executionTime = await _db.AvailableTimes.FindAsync(time);
                string excutionDateTime = HelperDate.GetCurrentDate(3).ToString("dd/MM/yyyy") + " " + executionTime.time.ToString("hh:mm tt");
                var currentDate = HelperDate.GetCurrentDate(3).AddMinutes(50).ToString("dd/MM/yyyy hh:mm tt");
                if (HelperDate.ConvertFromStringToDate(currentDate, "dd/MM/yyyy hh:mm tt") == HelperDate.ConvertFromStringToDate(excutionDateTime, "dd/MM/yyyy hh:mm tt"))
                {
                    return (0, HelperMsg.creatMessage(lang, "عفوا هذا الوقت غير متاح ", "Sorry This time not available"));
                }

                int oldOrders = await _db.Orders.Where(o => o.ExecutionDate.Date == HelperDate.ConvertFromStringToDate(executionDate, "dd/MM/yyyy").Date && o.ExecutionTime == time
                && o.StationId == stationId                                   
                && (o.Status != orderstutes.finishedorder.ToNumber() && o.Status != orderstutes.Canceledorder.ToNumber() && o.Status != orderstutes.Refusedorder.ToNumber())).CountAsync();
                int countOrderTime = (await _db.OilStations.FirstOrDefaultAsync(s=> s.Id == stationId )).CountOrderForTime;
                if (oldOrders >= countOrderTime)
                {
                    return (0, HelperMsg.creatMessage(lang, "عفوا هذا الوقت غير متاح ", "Sorry This time not available"));
                }

                return (1, HelperMsg.creatMessage(lang, "يرجى اتمام الطلب", "please, Complete your order"));

            }
            catch (Exception ex)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                LogExption logExption = new LogExption()
                {
                    Date = DateTime.Now,
                    Exption = ex.Message,
                    ServiceName = m.Name,
                    UserId = ""
                };
                await _db.LogExption.AddAsync(logExption);
                await _db.SaveChangesAsync();
                return (0, HelperMsg.MsgValidation(EnumValidMsg.Auth.SomethingWrong.ToNumber(), lang));
            }
        }


        public async Task<(int, string)> AddOrderAsync(AddOrderDto addOrderDto)
        {
            try
            {
                var CheckOrder = await _db.Orders.AnyAsync(o => o.UserId == _currentUserService.UserId && o.OrderDate.AddMinutes(5) >= HelperDate.GetCurrentDate(3)
                                                        && (o.Status != orderstutes.finishedorder.ToNumber() || o.Status != orderstutes.Canceledorder.ToNumber() || o.Status != orderstutes.Refusedorder.ToNumber()));
                if (CheckOrder)
                {
                    return (0, HelperMsg.creatMessage(addOrderDto.lang, "عفوا هناك طلب معلق", "Sorry there is an pending order"));
                }

                int CountStations = await GetCountStationsAvailable(addOrderDto.lat, addOrderDto.lng);
                if (CountStations == 0)
                {
                    return (0, HelperMsg.creatMessage(addOrderDto.lang, "عفوا انت خارج نطاق الخدمة", "Sorry you are out of Service Scope"));
                }
                var distances = CalculateStationsBydistance(addOrderDto.lat, addOrderDto.lng).Result.OrderBy(x => x.distance).FirstOrDefault();

                //var executionTime = await _db.AvailableTimes.FindAsync(addOrderDto.executionTime);
                //string excutionDateTime = HelperDate.GetCurrentDate(3).ToString("dd/MM/yyyy") + " " + executionTime.time.ToString("hh:mm tt");
                //var currentDate = HelperDate.GetCurrentDate(3).AddMinutes(50).ToString("dd/MM/yyyy hh:mm tt");
                //if (HelperDate.ConvertFromStringToDate(currentDate, "dd/MM/yyyy hh:mm tt") == HelperDate.ConvertFromStringToDate(excutionDateTime, "dd/MM/yyyy hh:mm tt"))
                //{
                //    return (0, HelperMsg.creatMessage(addOrderDto.lang, "عفوا هذا الوقت غير متاح ", "Sorry This time not available"));
                //}

                if (addOrderDto.stationId == 0)
                    addOrderDto.stationId = 1;  

                int oldOrders = await _db.Orders.Where(o => o.ExecutionDate.Date == HelperDate.ConvertFromStringToDate(addOrderDto.executionDate, "dd/MM/yyyy").Date && o.ExecutionTime == addOrderDto.executionTime
                && o.StationId == addOrderDto.stationId
                && (o.Status != orderstutes.finishedorder.ToNumber() && o.Status != orderstutes.Canceledorder.ToNumber() && o.Status != orderstutes.Refusedorder.ToNumber())).CountAsync();
                int countOrderTime = (await _db.OilStations.FirstOrDefaultAsync(s => s.Id == addOrderDto.stationId)).CountOrderForTime;
                if (oldOrders >= countOrderTime)
                {
                    return (0, HelperMsg.creatMessage(addOrderDto.lang, "عفوا هذا الوقت غير متاح ", "Sorry This time not available"));
                }

                if (addOrderDto.coponId != 0)
                {
                    var CheckCopon = _db.Copon.Where(x => x.Id == addOrderDto.coponId && x.IsActive).SingleOrDefault();
                    var currentdate = HelperDate.GetCurrentDate(3);

                    if (CheckCopon != null)
                    {
                        if (CheckCopon.Expirdate.Date < currentdate.Date)
                        {
                            return (0, HelperMsg.creatMessage(addOrderDto.lang, "عذرا لقد انتهت مده صلاحيه الكوبون", "Sorry, the validity of the coupon has expired"));
                        }
                        if (CheckCopon.Count <= CheckCopon.CountUsed)
                        {
                            return (0, HelperMsg.creatMessage(addOrderDto.lang, "عذرا تم تجاوز الحد الاقصى لااستخدام الكوبون", "Sorry, the maximum use of the coupon has been exceeded"));
                        }
                    }
                }

                if (addOrderDto.typePay == type_pay.pocket.ToNumber())
                {

                    var user = await _db.Users.Where(x => x.Id == _currentUserService.UserId).FirstOrDefaultAsync();

                    if (user.Wallet == 0 || (user.Wallet < addOrderDto.total))
                    {
                        return (0, HelperMsg.creatMessage(addOrderDto.lang, "عفوا لايوجد رصيد كافى بالمحفظة", "sorry! There is not enough balance in the wallet "));
                    }
                    user.Wallet = user.Wallet - (addOrderDto.total);
                    _db.Users.Update(user);

                }

                Orders order = new Orders
                {
                    UserId = _currentUserService.UserId,
                    CarBrandId = addOrderDto.carBrandId,
                    DepositPrice = addOrderDto.depositPrice,
                    Distance = distances.distance,
                    StationId = distances.stationId,
                    ExecutionDate = HelperDate.ConvertFromStringToDate(addOrderDto.executionDate, "dd/MM/yyyy"),
                    ExecutionTime = addOrderDto.executionTime,
                    OrderDate = HelperDate.GetCurrentDate(3),
                    TypePay = addOrderDto.typePay,
                    Lat = addOrderDto.lat,
                    Lng = addOrderDto.lng,
                    Location = addOrderDto.location,
                    CoponId = addOrderDto.coponId != 0 ? addOrderDto.coponId : null,
                    PackageId = addOrderDto.packageId,
                    Total = addOrderDto.total,
                    IsPaid = (addOrderDto.typePay == type_pay.pocket.ToNumber() || addOrderDto.typePay == type_pay.cash.ToNumber()) ? true : false,
                    //ProviderId = addOrderDto.providerId,
                    Status = orderstutes.Neworder.ToNumber(),
                    Kilometers = addOrderDto.kilometers
                };
                _db.Orders.Add(order);
                await _db.SaveChangesAsync();

                if (addOrderDto.coponId != 0)
                {
                    var CheckCopon = _db.Copon.Where(x => x.Id == addOrderDto.coponId && x.IsActive == true).SingleOrDefault();
                    if (CheckCopon != null)
                    {
                        CoponUsed coponUsed = new CoponUsed()
                        {
                            FkUser = _currentUserService.UserId,
                            FkCopon = CheckCopon.Id,
                            FkOrder = order.Id
                        };
                        _db.CoponUsed.Add(coponUsed);
                        CheckCopon.CountUsed += 1;
                        _db.SaveChanges();
                    }
                }

                if (order.TypePay != type_pay.online.ToNumber())
                {
                    var providers = _db.Users.Where(x => x.OilStationId == distances.stationId && x.TypeUser == User_Type.deleget.ToNumber()).Select(x => x.Id).ToList();
                    foreach (var item in providers)
                    {
                        _ = await HelperMethods.SendNotifyAsync(_db, "هناك طلب جديد " + order.Id, "There is a new order" + order.Id, item, orderstutes.Neworder.ToNumber(), order.Id);
                    }
                }
                return (order.Id, HelperMsg.MsgValidation(EnumValidMsg.Auth.SendSuccessfully.ToNumber(), addOrderDto.lang));

            }
            catch (Exception ex)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                LogExption logExption = new LogExption()
                {
                    Date = DateTime.Now,
                    Exption = ex.Message,
                    ServiceName = m.Name,
                    UserId = ""
                };
                await _db.LogExption.AddAsync(logExption);
                await _db.SaveChangesAsync();
                return (0, HelperMsg.MsgValidation(EnumValidMsg.Auth.SomethingWrong.ToNumber(), addOrderDto.lang));
            }
        }

        public async Task<(int, string)> PayOrderAsync(int orderId, int typePay, string lang)
        {
            try
            {
                var order = _db.Orders.Find(orderId);

                order.TypePay = typePay;
                order.IsPaid = true;
                _db.Orders.Update(order);

                await _db.SaveChangesAsync();

                var distances = CalculateStationsBydistance(order.Lat, order.Lng).Result.OrderBy(x => x.distance).FirstOrDefault();

                var providers = _db.Users.Where(x => x.OilStationId == distances.stationId && x.TypeUser == User_Type.deleget.ToNumber()).Select(x => x.Id).ToList();
                foreach (var item in providers)
                {
                    _ = await HelperMethods.SendNotifyAsync(_db, "هناك طلب جديد " + order.Id, "There is a new order" + order.Id, item, orderstutes.Neworder.ToNumber(), orderId);
                }
                return (orderId, HelperMsg.MsgValidation(EnumValidMsg.Auth.SendSuccessfully.ToNumber(), lang));

            }
            catch (Exception ex)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                LogExption logExption = new LogExption()
                {
                    Date = DateTime.Now,
                    Exption = ex.Message,
                    ServiceName = m.Name,
                    UserId = ""
                };
                await _db.LogExption.AddAsync(logExption);
                await _db.SaveChangesAsync();
                return (0, HelperMsg.MsgValidation(EnumValidMsg.Auth.SomethingWrong.ToNumber(), lang));
            }
        }

        public async Task<string> CancelOrderAsync(int orderId, string lang)
        {
            try
            {
                Orders GetOrder = await _db.Orders.FindAsync(orderId);
                if (GetOrder != null)
                {
                    GetOrder.Status = orderstutes.Canceledorder.ToNumber();
                    _db.Orders.Update(GetOrder);
                }

                
                ApplicationDbUser user = await _db.Users.FindAsync(GetOrder.UserId);
                if(user.TypeUser == User_Type.Client.ToNumber())
                {
                    user.Wallet += GetOrder.DepositPrice;
                    _db.Users.Update(user);
                }
                

                await _db.SaveChangesAsync();

                return HelperMsg.MsgValidation(EnumValidMsg.Auth.SendSuccessfully.ToNumber(), lang);
            }
            catch (Exception ex)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                LogExption logExption = new LogExption()
                {
                    Date = DateTime.Now,
                    Exption = ex.Message,
                    ServiceName = m.Name,
                    UserId = ""
                };
                await _db.LogExption.AddAsync(logExption);
                await _db.SaveChangesAsync();
                return HelperMsg.MsgValidation(EnumValidMsg.Auth.SomethingWrong.ToNumber(), lang);
            }
        }

        public async Task<List<OrderDto>> ListNewOrders(string lang)
        {
            var orders = await _db.Orders.Where(o => o.UserId == _currentUserService.UserId
                                                && o.Status == orderstutes.Neworder.ToNumber())
                                                .ProjectTo<OrderDto>(MappingProfiles.ListClientOrders(lang))
                                                .OrderByDescending(x => x.id).ToListAsync();

            return orders;

        }

        public async Task<List<OrderDto>> ListCUrrentOrders(string lang)
        {
            var orders = await _db.Orders.Where(o => o.UserId == _currentUserService.UserId
                                                && o.Status == orderstutes.CurrentOrder.ToNumber())
                                                .ProjectTo<OrderDto>(MappingProfiles.ListClientOrders(lang))
                                                .OrderByDescending(x => x.id).ToListAsync();

            return orders;
        }

        public async Task<List<OrderDto>> ListFinishedOrders(string lang)
        {
            var orders = await _db.Orders.Where(o => o.UserId == _currentUserService.UserId 
                                                && (o.Status == orderstutes.finishedorder.ToNumber()
                                                || o.Status == orderstutes.Refusedorder.ToNumber()))
                                                .ProjectTo<OrderDto>(MappingProfiles.ListClientOrders(lang))
                                                .OrderByDescending(x => x.id).ToListAsync();

            return orders;
        }

        public async Task<OrderDto> GetOrderDetails(int orderId, string lang)
        {
            var order = await _db.Orders.Where(o => o.Id == orderId)
                                        .ProjectTo<OrderDto>(MappingProfiles.ListClientOrders(lang)).FirstOrDefaultAsync();
            return order;

        }


        public async Task<List<NotesDto>> LisNotes(string lang)
        {
            var notes = await _db.Notes.Where(n => n.IsActive).Select(x => new NotesDto
            {
                id = x.Id,
                text = x.ChangeLangName(lang)
            }).ToListAsync();

            return notes;
        }

    }
}

