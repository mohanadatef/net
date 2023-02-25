using AAITHelper;
using AAITHelper.ModelHelper;
using GeoCoordinatePortable;
using KhadimiEssa.Data;
using KhadimiEssa.Data.TableDb;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static KhadimiEssa.Enums.AllEnums;

namespace KhadimiEssa.Helper
{
    public static class HelperMethods
    {
        //private readonly IUnitOfWork<ApplicationDbUser> _ApplicationDbUser;

        //public HelperMethods(IUnitOfWork<ApplicationDbUser> ApplicationDbUser)
        //{
        //    this._ApplicationDbUser = ApplicationDbUser;

        //}

        //public readonly static string BaisUrlHoste = "https://qurankarim.ip4s.com/";
        public readonly static string BaisUrlHoste = "https://khadamialeisi.ip4s.com/";
        public readonly static string BaisUrlAdvert = BaisUrlHoste + "images/Info/";
        public readonly static string BaisUrlProduct = BaisUrlHoste + "images/Product/";
        public readonly static string BaisUrlCategory = BaisUrlHoste + "images/Category/";
        public readonly static string BaisUrlUser = BaisUrlHoste + "images/Users/";
        public readonly static string BaisUrlCar_form = BaisUrlHoste + "images/Car_form/";
        public readonly static string BaisUrlId_photo = BaisUrlHoste + "images/Id_photo/";
        public readonly static string BaisUrOrder = BaisUrlHoste + "images/Order/";
        public readonly static string BaisUrlSubscribe = BaisUrlHoste + "images/Subscribe/";
        public readonly static string BaisUrlOffer = BaisUrlHoste + "images/Offer/";
        public readonly static string BaisUrlService = BaisUrlHoste + "images/Service/";
        public readonly static string BaisUrlIntroSite = BaisUrlHoste + "images/IntroSite/";
        public readonly static string BaisUrlChatFiles = BaisUrlHoste + "images/ChatFiles/";





        public readonly static string BaisUrlAdvertisment = BaisUrlHoste + "images/ProductA/";
        public readonly static string BaisUrlSocialMedia = BaisUrlHoste + "images/SocialMedia/";


        #region Roles

        public class AuthorizeRolesAttribute : Microsoft.AspNetCore.Authorization.AuthorizeAttribute
        {
            public AuthorizeRolesAttribute(params Enums.AllEnums.Roles[] roles) : base()
            {
                Roles = string.Join(",", roles);
            }

        }


        public static string GetRole(this string role, string lang)
        {
            return role switch
            {
                "AdminBranch" => AAITHelper.HelperMsg.creatMessage(lang, "سوبر ادمن", "AdminBranch"),
                "Admin" => AAITHelper.HelperMsg.creatMessage(lang, "أدمن", "Admin"),
                "Mobile" => AAITHelper.HelperMsg.creatMessage(lang, "موبايل", "Mobile"),

                "Advertisment" => AAITHelper.HelperMsg.creatMessage(lang, "الاعلانات", "Advertisment"),
                "Payments" => AAITHelper.HelperMsg.creatMessage(lang, "الاعلانات", "Payments"),
                "Copons" => AAITHelper.HelperMsg.creatMessage(lang, "الاعلانات", "Copons"),
                "SocialMedia" => AAITHelper.HelperMsg.creatMessage(lang, "مواقع التواصل الاجتماعى", "SocialMedia"),
                "Questions" => AAITHelper.HelperMsg.creatMessage(lang, "الاسئلة", "Questions"),
                "Notifications" => AAITHelper.HelperMsg.creatMessage(lang, "الاشعارات", "Notifications"),
                "SendSmsMsg" => AAITHelper.HelperMsg.creatMessage(lang, "ارسال رسالة sms", "SendSmsMsg"),
                "Chat" => AAITHelper.HelperMsg.creatMessage(lang, "المحادثات", "Chat"),
                "ContactUs" => AAITHelper.HelperMsg.creatMessage(lang, "الشكاوى والمقترحات", "ContactUs"),
                "Setting" => AAITHelper.HelperMsg.creatMessage(lang, "الاعدادات", "Setting"),
                "Rates" => AAITHelper.HelperMsg.creatMessage(lang, "التقييمات", "Rates"),

                _ => role
            };
        }

        #endregion




        public static async Task<bool> SendNotifyAsync(ApplicationDbContext db, string textAr, string textEn, string fkProvider, int stutes, int orderId = 0)
        {
            var user = await db.Users.Where(x => x.Id == fkProvider).FirstOrDefaultAsync();
            if (user.TypeUser == (int)Enums.AllEnums.User_Type.Client)
            {
                NotifyClient notifyClient = new NotifyClient()
                {
                    Date = HelperDate.GetCurrentDate(),
                    FKUser = fkProvider,
                    Show = false,
                    TextAr = textAr,
                    TextEn = textEn,
                    Type = stutes,
                    OrderId = orderId

                };
                await db.NotifyClients.AddAsync(notifyClient);
                await db.SaveChangesAsync();
            }
            else
            {
                NotifyDelegt notifyDelegt = new NotifyDelegt()
                {
                    Date = HelperDate.GetCurrentDate(),
                    FKUser = fkProvider,
                    Show = false,
                    TextAr = textAr,
                    TextEn = textEn,
                    Type = stutes,
                    OrderId = orderId

                };
                await db.NotifyDelegts.AddAsync(notifyDelegt);
                await db.SaveChangesAsync();
            }
            var Fcm = await db.Settings.FirstOrDefaultAsync();

            var AllDeviceids = await db.DeviceIds.Where(x => x.FkUser == fkProvider).Select(x => new DeviceIdModel()
            {
                DeviceId = x.DeviceId_,
                DeviceType = x.DeviceType,
                FkUser = x.FkUser,
                ProjectName = x.ProjectName

            }).ToListAsync();
            HelperFcm.SendPushNotification(Fcm.ApplicationId, Fcm.SenderId, AllDeviceids, null, user.Lang == "ar" ? textAr : textEn, stutes, user.TypeUser, orderId);
            return true;
        }


        // time now
        public static DateTime TimeNow()
        {
            TimeZone localZone = TimeZone.CurrentTimeZone;
            DateTime currentDate = DateTime.Now;
            DateTime currentUTC = localZone.ToUniversalTime(currentDate);
            return currentUTC.AddHours(3);
        }




        //-------------------------------------//


        public static string RandomString(int length)
        {
            Random random = new Random();
            string date = DateTime.Now.ToString("yyyyHHmmss");
            //string date = DateTime.Now.ToString("yyyyMMddHHmmss");
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray()) + date;
        }


        public static double GetDistance(double sLatitude, double sLongitude, double eLatitude, double eLongitude)
        {
            try
            {
                var sCoord = new GeoCoordinate(sLatitude, sLongitude);
                var eCoord = new GeoCoordinate(eLatitude, eLongitude);

                double dd = sCoord.GetDistanceTo(eCoord) / 1000;
                double distance = Math.Round(dd, 1, MidpointRounding.ToEven);
                return distance;

            }
            catch (Exception)
            {

                return 10000;
            }
        }


        //-----------------------------------///


        public static async Task<string> SmsMessage(string msg, string phone, string senderName = "", string userNameSms = "", string passwordSms = "", int smsType = 0, string fromEmail = "", string subject = "", string ownerPhone = "", string toEmail = "")
        {

            if (smsType == (int)SmsType.MessageBy4jawaly)
            {
                var response = await HelperSms.SendMessageBy4jawaly(msg, phone, senderName, userNameSms, passwordSms);
                return response;
            }
            if (smsType == (int)SmsType.MessageByElYamam)
            {
                var response = await HelperSms.SendMessageByElYamam(msg, phone, userNameSms, passwordSms);
                return response;

            }
            if (smsType == (int)SmsType.MessageByMobily)
            {
                //string ownerPhone = await _context.Users.Where(x => x.PhoneNumber == phone).Select(x => x.user_Name).FirstOrDefaultAsync();
                var response = HelperSms.SendMessageByMobily(msg, phone, senderName, ownerPhone, passwordSms);
                return response;

            }
            if (smsType == (int)SmsType.GmailMail)
            {

                //string toEmail = await _context.Users.Where(x => x.PhoneNumber == phone).Select(x => x.Email).FirstOrDefaultAsync();

                HelperSms.SendGmailMail(msg, fromEmail, toEmail, subject);
                return "Send Successfully";
            }
            return "faild";

        }


        public static string StutesText(int stutes, string lang = "ar")
        {


            string text = "";
            switch (stutes)
            {
                case (int)orderstutes.Neworder:
                    text = (lang == "ar" ? "طلب جديد" : "New Order");
                    break;
                case (int)orderstutes.CurrentOrder:
                    text = (lang == "ar" ? "طلب حالى " : "Current Order ");
                    break;
                case (int)orderstutes.finishedorder:
                    text = (lang == "ar" ? "تم الانتهاء من الطلب" : "Order Finished");
                    break;
                case (int)orderstutes.Refusedorder:
                    text = (lang == "ar" ? "تم رفض الطلب" : "Order Refused");
                    break;
                    //case (int)order_stutes.client_cancel:
                    //    text = (lang == "ar" ? "تم الغاء الطلب" : "The REFUSE of the request");
                    //    break;

            }
            return text;
        }

        public static string PayStutes(int type, string lang = "ar")
        {

            string text = "";
            switch (type)
            {
                case (int)type_pay.cash:
                    text = (lang == "ar" ? " عند وصول مقدم الخدمة" : "Upon arrival of the service provider ");
                    break;
                case (int)type_pay.pocket:
                    text = (lang == "ar" ? " محفظة " : "pocket");
                    break;
                case (int)type_pay.online:
                    text = (lang == "ar" ? "أون لاين" : "online");
                    break;
              
                    //case (int)order_stutes.client_cancel:
                    //    text = (lang == "ar" ? "تم الغاء الطلب" : "The REFUSE of the request");
                    //    break;

            }
            return text;
        }

        #region Save Image

        public static string ProcessUploadedFile(Microsoft.AspNetCore.Hosting.IWebHostEnvironment HostingEnvironment, Microsoft.AspNetCore.Http.IFormFile Photo = null, string Place = "")
        {
            string uniqueFileName = "Default.png";
            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(HostingEnvironment.WebRootPath, $"images/{Place}");
                uniqueFileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(Photo.FileName).Replace(" ", string.Empty);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
            }
            return Helper.HelperMethods.BaisUrlHoste + $"images/{Place}/" + uniqueFileName;
        }


        #endregion



        #region Get Token

        public static JwtSecurityToken GetToken(IConfiguration _configuration, ApplicationDbUser user)
        {

            var claim = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim("user_id", user.Id),
                    new Claim("type_user", user.TypeUser.ToString())
                };

            var signinKey = new SymmetricSecurityKey(
             Encoding.UTF8.GetBytes(_configuration["Jwt:SigningKey"]));

            int expiryInMinutes = Convert.ToInt32(_configuration["Jwt:ExpiryInMinutes"]);

            var token = new JwtSecurityToken(
              issuer: _configuration["Jwt:Site"],
              audience: _configuration["Jwt:Site"],
              claims: claim,
              expires: DateTime.UtcNow.AddMinutes(expiryInMinutes),
              signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
            );

            return token;
        }

        #endregion
    }
}
