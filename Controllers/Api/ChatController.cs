using AAITHelper;
using AAITHelper.Enums;
using KhadimiEssa.Data;
using KhadimiEssa.Data.TableDb;
using KhadimiEssa.Models.ChatViewModel;
using KhadimiEssa.PathUrl;
using KhadimiEssa.Data;
using KhadimiEssa.PathUrl;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static KhadimiEssa.Enums.AllEnums;

namespace KhadimiEssa.Controllers.Api
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiExplorerSettings(GroupName = "ChatApi")]
    public class ChatController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _HostingEnvironment;
        private readonly ApplicationDbContext _dbContext;


        public ChatController(IWebHostEnvironment HostingEnvironment, IConfiguration configuration,
            ApplicationDbContext dbContext)
        {
            this._HostingEnvironment = HostingEnvironment;
            this._configuration = configuration;
            this._dbContext = dbContext;
        }


        [HttpPost(ApiRoutes.Chat.ListChatUsers)]
        public async Task<ActionResult> ListChatUsers(ListChatUsersViewModel model)
        {
            string userId = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

            //var ListUsers = (await _dbContext.Messages.Where(x => x.SenderId == userId || x.ReceiverId == userId)
            //    .OrderByDescending(x => x.Id)
            //    .Select(x => new
            //    {
            //        Id = x.Id,
            //        OrderNumber = x.FK_OrderId,
            //        lastMsg = x.TypeMessage == (int)AllEnums.FileTypeChat.text ? x.Text : "file ...",
            //        //OfferNumber = x.FK_OfferId,
            //        UserId = x.SenderId == userId ? x.ReceiverId : x.SenderId,
            //        UserImg = x.SenderId == userId ? Helper.Helper.BaseUrlHoste + x.Receiver.Img : Helper.Helper.BaseUrlHoste + x.Sender.Img,
            //        UserName = x.SenderId == userId ? x.Receiver.FullName : x.Sender.FullName,
            //        Date = x.DateSend.ToString("dd/MM/yyyy"),
            //    }).ToListAsync()).GroupBy(x => x.OrderNumber).Select(x => x.LastOrDefault()).ToList();

            var ListUsers = await (from order in _dbContext.Orders
                                   where (order.Status != (int)Enums.AllEnums.orderstutes.finishedorder && order.Messages.Where(m => m.SenderId == userId || m.ReceiverId == userId).Any())
                                   let message = order.Messages.OrderByDescending(m => m.Id).FirstOrDefault()
                                   select new
                                   {
                                       Id = message.Id,
                                       OrderNumber = message.FKOrder,
                                       lastMsg = message.TypeMessage == (int)Enums.AllEnums.FileTypeChat.text ? message.Text : "ملف ...",
                                       UserId = message.SenderId == userId ? message.ReceiverId : message.SenderId,
                                       UserImg = message.SenderId == userId ? message.Receiver.ImgProfile : message.Sender.ImgProfile,
                                       UserName = message.SenderId == userId ? message.Receiver.user_Name : message.Sender.user_Name,
                                       Date = message.DateSend.ToString("dd/MM/yyyy")
                                   }).OrderByDescending(o => o.OrderNumber).ToListAsync();

            return Json(new { key = 1, data = ListUsers });

        }

        [HttpPost(ApiRoutes.Chat.ListMessagesUser)]
        public async Task<ActionResult> ListMessagesUser(ListMessagesUserViewModel model)
        {
            string userId = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

            const int maxRows = 50;

            var ListMessages = await _dbContext.Messages.Where(x => x.FKOrder == model.OrderId)
                .OrderByDescending(x => x.Id).Skip((model.pageNumber - 1) * maxRows).Take(maxRows)
               .Select(x => new
               {
                   Id = x.Id,
                   Type = x.TypeMessage,
                   SenderId = x.SenderId,
                   ReceiverId = x.ReceiverId,
                   Message = x.TypeMessage == (int)Enums.AllEnums.FileTypeChat.text ? x.Text : /*Helper.Helper.BaseUrlHoste +*/ x.Text,
                   Date = x.DateSend.ToString("hh:mm tt")
               }).OrderBy(x => x.Id).ToListAsync();

            return Json(new { key = 1, data = ListMessages });

        }


        [HttpPost(ApiRoutes.Chat.DeleteMessagesUser)]
        public async Task<ActionResult> DeleteMessagesUser(int OrderId, string lang = "ar")
        {
            try
            {
                string userId = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

                var ListMessages = await _dbContext.Messages.Where(x => x.FKOrder == OrderId).ToListAsync();
                _dbContext.Messages.RemoveRange(ListMessages);

                await _dbContext.SaveChangesAsync();
                return Json(new { key = 1, msg = "تم الحذف بنجاح" });
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
                await _dbContext.LogExption.AddAsync(logExption);
                await _dbContext.SaveChangesAsync();
                return Json(new { key = 0, msg = HelperMsg.MsgValidation(EnumValidMsg.Auth.SomethingWrong.ToNumber(), lang) });
            }
        }


        [HttpPost(ApiRoutes.Chat.UploadNewFile)]
        public ActionResult UploadFile(IFormFile File)
        {
            string FileName = KhadimiEssa.Helper.HelperMethods.ProcessUploadedFile(_HostingEnvironment, File, "ChatFiles");
            return Json(new { key = 1, data = FileName });
        }




    }
}