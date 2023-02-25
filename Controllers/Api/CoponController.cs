using AAITHelper;
using AAITHelper.Enums;
using KhadimiEssa.Data;
using KhadimiEssa.Data.TableDb;
using KhadimiEssa.Helper;
using KhadimiEssa.Interfaces.Auth;
using KhadimiEssa.PathUrl;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace KhadimiEssa.Controllers.Api
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiExplorerSettings(GroupName = "ClientApp")]
    public class CoponController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly ICurrentUserService _currentUserService;

        public CoponController(ApplicationDbContext _db, ICurrentUserService currentUserService)

        {
            db = _db;
            _currentUserService = currentUserService;
        }
        [AllowAnonymous]
        [HttpPost(ApiRoutes.LogicUser.UseCopon)]
        public async Task<ActionResult> UseCopon(string copon, double total, string lang = "ar")
        {
            try
            {
                //string user_id = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
                var currentdate = HelperDate.GetCurrentDate(3);
                var CheckCopon = db.Copon.Where(x => x.CoponCode == copon && x.IsActive).SingleOrDefault();


                if (CheckCopon != null)
                {
                    if (CheckCopon.Expirdate.Date < currentdate.Date)
                    {
                        return Json(new { key = 0, msg = HelperMsg.creatMessage(lang, "عذرا لقد انتهت مده صلاحيه الكوبون", "Sorry, the validity of the coupon has expired") });
                    }
                    if (CheckCopon.Count <= CheckCopon.CountUsed)
                    {
                        return Json(new { key = 0, msg = HelperMsg.creatMessage(lang, "عذرا تم تجاوز الحد الاقصى لااستخدام الكوبون", "Sorry, the maximum use of the coupon has been exceeded") });
                    }
                    var CoponUsedForUser = db.CoponUsed.Where(x => x.FkCopon == CheckCopon.Id && x.FkUser == _currentUserService.UserId).FirstOrDefault();
                    if (CoponUsedForUser != null)
                    {
                        return Json(new { key = 0, msg = HelperMsg.creatMessage(lang, "تم استخدام الكوبون من قبل", "The copon has already been used") });
                    }
                    var value = (CheckCopon.Discount / 100) * total;
                    if (value > CheckCopon.limtDiscount)
                    {
                        value = CheckCopon.limtDiscount;
                        // CheckCopon.CountUsed = CheckCopon.CountUsed + 1;
                        var LastTOTAL = total - value;

                        return Json(new { key = 1, copon_id = CheckCopon.Id, discount = CheckCopon.Discount, lasttotal = Math.Round(LastTOTAL, 2), msg = HelperMsg.creatMessage(lang, "الحد الاقصى لقيمه الخصم هو " + CheckCopon.limtDiscount + "ريال", "The maximum discount value is" + CheckCopon.limtDiscount + "ريال") });
                    }
                    else
                    {

                        var LastTOTAL = total - value;

                        return Json(new { key = 1, copon_id = CheckCopon.Id, discount = CheckCopon.Discount, lasttotal = Math.Round(LastTOTAL, 2), msg = HelperMsg.creatMessage(lang, "تم الخصم بنجاح", "Successfully charged") });
                    }

                    //return Json(new { key = 1, copon_id = CheckCopon.Id, lasttotal = Math.Round(CheckCopon.Discount, 2) });
                }
                else
                {
                    return Json(new { key = 0, msg = HelperMsg.creatMessage(lang, "برجاء التاكد من الكوبون ", "Please make sure of the coupon") });
                }


                #region الكود ده يوضع فى سرفس الاوردر
                //if (orderModel.copon_id != 0)
                //{
                //    var CheckCopon = db.Copon.Where(x => x.ID == orderModel.copon_id && x.IsActive == true && x.fk_branch == branch_id).SingleOrDefault();
                //    if (CheckCopon != null)
                //    {
                //        CoponUsed coponUsed = new CoponUsed()
                //        {

                //            fk_user = user_id,
                //            fk_copon = CheckCopon.ID
                //        };
                //        db.CoponUsed.Add(coponUsed);
                //        CheckCopon.CountUsed += 1;
                //        db.SaveChanges(); 


                //    }
                //}
                #endregion

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
