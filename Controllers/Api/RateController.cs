using AAITHelper;
using AAITHelper.Enums;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using KhadimiEssa.AutoMapper;
using KhadimiEssa.Data;
using KhadimiEssa.Data.TableDb;
using KhadimiEssa.Helper;
using KhadimiEssa.Interfaces.Auth;
using KhadimiEssa.Models.AutoMapperViewModel;
using KhadimiEssa.PathUrl;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using static KhadimiEssa.Enums.AllEnums;

namespace KhadimiEssa.Controllers.Api
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiExplorerSettings(GroupName = "ClientApp")]
    public class RateController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public RateController(ApplicationDbContext _db, IMapper mapper, ICurrentUserService currentUserService)

        {
            db = _db;
            _mapper = mapper;
            _currentUserService = currentUserService;

        }

        [HttpPost(ApiRoutes.LogicUser.AddRateDeleget)]
        public async Task<ActionResult> AddRateDeleget(string delegetId,int orderId, int rate, string lang = "ar")
        {
            try
            {
                var rateBouns = await db.Settings.FirstOrDefaultAsync();

                //string user_id = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
                var user =await db.Users.FirstOrDefaultAsync(u => u.Id == _currentUserService.UserId);
                var checkrates = await db.RateDelget.Where(x => x.OrderId == orderId).AnyAsync();
                if (checkrates)
                {
                    return Json(new { key = 0, msg =HelperMsg.creatMessage(lang,"لقد قمت بتقيم هذا الطلب من قبل","This order has been rated") });

                }
                RateDelget rateModel = new RateDelget();
                rateModel.Date = DateTime.Now;
                rateModel.FkDeleget = delegetId;
                rateModel.FkUser = _currentUserService.UserId;
                rateModel.Rate = rate;
                rateModel.OrderId = orderId;
                await db.RateDelget.AddAsync(rateModel);
                NotifyDelegt notifyDelegt = new NotifyDelegt
                {
                    FKUser = delegetId,
                    Date = HelperDate.GetCurrentDate(3),
                    TextAr = $"قام العميل {user.user_Name} بتقييمك  ",
                    TextEn = $"The Client {user.user_Name} was rated you",
                    Type = 0,// enum changed 
                    Show = false
                };
                await db.NotifyDelegts.AddAsync(notifyDelegt);

                if (user != null)
                {
                    user.Wallet = user.Wallet + rateBouns.RateBouns;
                    db.Users.Update(user);
                }
               
                await db.SaveChangesAsync();
                //تضاف ع حسب التطبيق
                var chek = await HelperMethods.SendNotifyAsync(db, notifyDelegt.TextAr, notifyDelegt.TextEn, delegetId, NotifyTypes.AddRateToUser.ToNumber());


                return Json(new { key = 1, msg = HelperMsg.MsgValidation(EnumValidMsg.Auth.SendSuccessfully.ToNumber(), lang) });

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
                await db.LogExption.AddAsync(logExption);
                await db.SaveChangesAsync();
                return Json(new { key = 0, msg = HelperMsg.MsgValidation(EnumValidMsg.Auth.SomethingWrong.ToNumber(), lang) });
            }

        }

        [HttpPost(ApiRoutes.LogicDeleget.ListRateUser)]
        public async Task<ActionResult> ListRateDeleget(string lang = "ar")
        {
            try
            {
                //string user_id = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

                var result = db.RateDelget.Where(x => x.FkDeleget == _currentUserService.UserId).ProjectTo<ListRateDelegetDTO>(MappingProfiles.UserProfile(lang)).ToList();


                return Json(new { key = 1, ListRate = result });
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
                await db.LogExption.AddAsync(logExption);
                await db.SaveChangesAsync();
                return Json(new { key = 0, msg = HelperMsg.MsgValidation(EnumValidMsg.Auth.SomethingWrong.ToNumber(), lang) });
            }
        }
    }
}
