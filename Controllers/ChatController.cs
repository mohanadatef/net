using KhadimiEssa.Data;
using KhadimiEssa.Enums;
using KhadimiEssa.Helper;
using KhadimiEssa.Hubs;
using KhadimiEssa.Models.ChatModels;
using KhadimiEssa.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static KhadimiEssa.Enums.AllEnums;
using static KhadimiEssa.Helper.HelperMethods;

namespace KhadimiEssa.Controllers
{
    [AuthorizeRoles(Roles.AdminBranch, Roles.Chat)]
    public class ChatController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _HostingEnvironment;
        private readonly ApplicationDbContext _dbContext;
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IChatServices _chatServices;

        private readonly IUploadImage _uploadImage;

        public ChatController(IWebHostEnvironment HostingEnvironment, IConfiguration configuration,
            ApplicationDbContext dbContext, IHubContext<ChatHub> hubContext, IChatServices chatServices, IUploadImage uploadImage)
        {
            this._HostingEnvironment = HostingEnvironment;
            this._configuration = configuration;
            this._dbContext = dbContext;
            this._hubContext = hubContext;
            this._chatServices = chatServices;
            _uploadImage = uploadImage;

        }

        public async Task<IActionResult> Users()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            //var ListUsers = (await _dbContext.Messages.Where(x => x.SenderId == userId || x.ReceiverId == userId)
            //        .OrderByDescending(x => x.Id)
            //        .Select(x => new SiteUsersChatViewModel
            //        {
            //            Id = x.Id,
            //            OrderNumber = x.FK_OrderId,
            //            lastMsg = x.TypeMessage == (int)AllEnums.FileTypeChat.text ? x.Text : "file ...",
            //            UserId = x.SenderId == userId ? x.ReceiverId : x.SenderId,
            //            UserImg = x.SenderId == userId ? Helper.Helper.BaseUrlHoste + x.Receiver.Img : Helper.Helper.BaseUrlHoste + x.Sender.Img,
            //            UserName = x.SenderId == userId ? x.Receiver.FullName : x.Sender.FullName,
            //            Date = x.DateSend.ToString("dd/MM/yyyy"),
            //        }).ToListAsync()).GroupBy(x => x.OrderNumber).Select(x => x.LastOrDefault()).ToList();

            var ListUsers = await (from order in _dbContext.Orders
                                   where order.Messages.Where(m => m.SenderId == userId || m.ReceiverId == userId).Any()
                                   let message = order.Messages.OrderByDescending(m => m.Id).FirstOrDefault()
                                   select new SiteUsersChatViewModel
                                   {
                                       Id = message.Id,
                                       OrderNumber = message.FKOrder,
                                       lastMsg = message.TypeMessage == (int)AllEnums.FileTypeChat.text ? message.Text : "file ...",
                                       UserId = message.SenderId == userId ? message.ReceiverId : message.SenderId,
                                       UserImg = message.SenderId == userId ? message.Receiver.ImgProfile : message.Sender.ImgProfile,
                                       UserName = message.SenderId == userId ? message.Receiver.user_Name : message.Sender.user_Name,
                                       Date = message.DateSend.ToString("dd/MM/yyyy")
                                   }).OrderByDescending(o => o.OrderNumber).ToListAsync();

            return View(ListUsers);
        }

        public async Task<IActionResult> Messages(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            ViewBag.id = id;
            string receiverId = await _dbContext.Orders.Where(x => x.Id == id).Select(x => x.UserId == userId ? x.ProviderId : x.UserId).FirstOrDefaultAsync();
            ViewBag.receiverId = receiverId;
            ViewBag.senderId = userId;


            var ListMessages = await _dbContext.Messages.Where(x => x.FKOrder == id)
                .OrderByDescending(x => x.Id)
               .Select(x => new SiteMessagesViewModel
               {
                   id = x.Id,
                   orderNumber = x.FKOrder,
                   type = x.TypeMessage,
                   senderId = x.SenderId,
                   receiverId = x.ReceiverId,
                   senderImg = x.Sender.ImgProfile,
                   receiverImg = x.Receiver.ImgProfile,
                   message = x.TypeMessage == (int)AllEnums.FileTypeChat.text ? x.Text : /*Helper.Helper.BaseUrlHoste +*/ x.Text,
                   date = x.DateSend.ToString("hh:mm tt"),
                   sender = x.SenderId == userId
               }).OrderBy(x => x.id).ToListAsync();

            return View(ListMessages);
        }

        [HttpPost]
        public ActionResult UploadFile(IFormFile file)
        {
            string fileName = _uploadImage.Upload(file, (int)FileName.ChatFiles);
            //ProcessUploadedFile(_HostingEnvironment, file, FoldersName.ChatFiles.ToString());
            return Json(new { key = 1, data = fileName });
        }


        [HttpPost]
        public async Task<IActionResult> SendMessage(string ReceiverId, string Text, int OrderId, int Type = 0, int Duration = 0)
        {
            try
            {

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                string SenderId = userId;
                NewMessageViewModel model = new NewMessageViewModel()
                {
                    SenderId = SenderId,
                    ReceiverId = ReceiverId,
                    Text = Text,
                    OrderId = OrderId,
                    Type = Type,
                    Duration = Duration
                };
                if (!string.IsNullOrEmpty(model.SenderId) && !string.IsNullOrEmpty(model.ReceiverId) && !string.IsNullOrEmpty(model.Text))
                {
                    PushMessegeViewModel data = await _chatServices.AddNewMessage(model);
                    await _hubContext.Clients.Group(ReceiverId).SendAsync("receiveMessage", data);

                    //var listgroupsuser = binafsaj.Hubs.ChatHub.listgroups.Where(x => x.UserId == ReceiverId).Select(x => x.qty).FirstOrDefault();
                    //List<Tuple<string, string>> ListIds = await _dbContext.DeviceIds.Where(x => x.FK_UserID == ReceiverId).Select(x => new Tuple<string, string>(x.DeviceID, x.DeviceType)).ToListAsync(); ;

                    //{
                    //    if (ListIds.Count() != 0 && listgroupsuser <= 0)
                    //    {
                    //        var reciverdata = await _dbContext.Users.Where(x => x.Id == ReceiverId).FirstOrDefaultAsync();
                    //        if (reciverdata != null)
                    //        {
                    //            Helper.Helper.SendPushNotification(device_ids: ListIds, msg: Type == (int)Enums.AllEnums.FileTypeChat.text ? Text : "لديك رسالة جديدة", type: (int)Enums.AllEnums.FcmType.chat, order_id: OrderId, user_id: SenderId, user_name: reciverdata.FullName, user_img: Helper.Helper.BaseUrlHoste + reciverdata.Img,closeNotify:reciverdata.CloseNotification);
                    //        }
                    //    }
                    //}

                    return Ok(new
                    {
                        key = 1,
                        data = data
                    });
                }

                return Ok(new
                {
                    key = 0,
                    msg = "خطأ فى الاتصال"
                });


            }
            catch (Exception)
            {
                return Ok(new
                {
                    key = 0,
                    msg = "خطأ فى الاتصال"
                });

            }
        }





    }
}