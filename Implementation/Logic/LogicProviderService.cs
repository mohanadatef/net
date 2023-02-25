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

namespace KhadimiEssa.Implementation.Logic
{
    public class LogicProviderService : ILogicProviderService
    {
        private readonly ApplicationDbContext _db;
        private readonly ICurrentUserService _currentUserService;

        public LogicProviderService(ApplicationDbContext db, ICurrentUserService currentUserService)

        {
            _db = db;
            _currentUserService = currentUserService;
        }


        public async Task<List<OrderDto>> ListNewOrders(string lang)
        {
            var providerStationId = await _db.Users.Where(u => u.Id == _currentUserService.UserId).Select(x => x.OilStationId).FirstOrDefaultAsync();
            var orders = await _db.Orders.Where(o => o.Status == orderstutes.Neworder.ToNumber() && o.StationId == providerStationId)
                                                .ProjectTo<OrderDto>(MappingProfiles.ListProviderOrders(lang))
                                                .OrderByDescending(x => x.id).ToListAsync();

            return orders;

        }

        public async Task<string> AcceptOrderAsync(int orderId, string lang)
        {
            try
            {
                var GetOrder = await _db.Orders.FindAsync(orderId);

                if (GetOrder != null)
                {
                    if (GetOrder.Status == orderstutes.Canceledorder.ToNumber())
                    {
                        return HelperMsg.creatMessage(lang, "تم الغاء هذا الطلب من قبل العميل", "This Order has been canceled");
                    }
                    GetOrder.ProviderId = _currentUserService.UserId;
                    GetOrder.Status = orderstutes.CurrentOrder.ToNumber();
                }
                await _db.SaveChangesAsync();

                var chek = await HelperMethods.SendNotifyAsync(_db, "تم قبول الطلب رقم" + GetOrder.Id, "Request No. has been accepted" + GetOrder.Id, GetOrder.UserId, orderstutes.CurrentOrder.ToNumber(), orderId);
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

        public async Task<string> RefuseOrderAsync(int orderId, string lang)
        {
            try
            {
                var GetOrder = await _db.Orders.FindAsync(orderId);
                if (GetOrder != null)
                {
                    if (GetOrder.Status == orderstutes.Canceledorder.ToNumber())
                    {
                        return HelperMsg.creatMessage(lang, "تم الغاء هذا الطلب من قبل العميل", "This Order has been canceled");
                    }
                    GetOrder.ProviderId = _currentUserService.UserId;

                    GetOrder.Status = orderstutes.Refusedorder.ToNumber();
                }
                await _db.SaveChangesAsync();

                var chek = await HelperMethods.SendNotifyAsync(_db, "تم رفض الطلب رقم" + GetOrder.Id, "Request No. has been refused" + GetOrder.Id, GetOrder.UserId, orderstutes.Refusedorder.ToNumber(), orderId);
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

        public async Task<List<OrderDto>> ListCUrrentOrders(string lang)
        {
            var providerStationId = await _db.Users.Where(u => u.Id == _currentUserService.UserId).Select(x => x.OilStationId).FirstOrDefaultAsync();

            var orders = await _db.Orders.Where(o => o.ProviderId == _currentUserService.UserId
                                                && o.Status == orderstutes.CurrentOrder.ToNumber() && o.StationId == providerStationId)
                                                .ProjectTo<OrderDto>(MappingProfiles.ListProviderOrders(lang))
                                                .OrderByDescending(x => x.id).ToListAsync();

            return orders;
        }

        public async Task<string> FinishOrderAsync(int orderId, string lang)
        {
            try
            {
                var GetOrder = await _db.Orders.FindAsync(orderId);
                if (GetOrder != null)
                {
                    GetOrder.Status = orderstutes.finishedorder.ToNumber();
                }
                await _db.SaveChangesAsync();

                var chek = await HelperMethods.SendNotifyAsync(_db, "تم انهاء الطلب رقم" + GetOrder.Id, "Request No. has been finished" + GetOrder.Id, GetOrder.UserId, orderstutes.finishedorder.ToNumber(), orderId);
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

        public async Task<List<OrderDto>> ListFinishedOrders(string lang)
        {
            var providerStationId = await _db.Users.Where(u => u.Id == _currentUserService.UserId).Select(x => x.OilStationId).FirstOrDefaultAsync();

            var orders = await _db.Orders.Where(o => o.ProviderId == _currentUserService.UserId && o.StationId == providerStationId
                                                && (o.Status == orderstutes.finishedorder.ToNumber()
                                                || o.Status == orderstutes.Refusedorder.ToNumber()))
                                                .ProjectTo<OrderDto>(MappingProfiles.ListProviderOrders(lang))
                                                .OrderByDescending(x => x.id).ToListAsync();

            return orders;
        }

        public async Task<OrderDto> GetOrderDetails(int orderId, string lang)
        {
            var order = await _db.Orders.Where(o => o.Id == orderId)
                                        .ProjectTo<OrderDto>(MappingProfiles.ListProviderOrders(lang)).FirstOrDefaultAsync();
            return order;

        }
    }
}
