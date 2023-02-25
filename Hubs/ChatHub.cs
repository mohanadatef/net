using KhadimiEssa.Data;
using KhadimiEssa.Data.TableDb;
using KhadimiEssa.Models.ChatModels;
using KhadimiEssa.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KhadimiEssa.Hubs
{
    public class ChatHub : Hub
    {

        private readonly IChatServices _chatServices;
        private readonly ApplicationDbContext _dbContext;
        //public static List<Listgroups> listgroups = new List<Listgroups>();
        static List<ConnectUser> connectUsers = new List<ConnectUser>();

        public ChatHub(IChatServices chatServices, ApplicationDbContext dbContext)
        {
            this._chatServices = chatServices;
            this._dbContext = dbContext;
        }

        //public async Task SendMessage(NewMessageViewModel model)
        public async Task SendMessage(string SenderId, string ReceiverId, string Text, int OrderId, int Type = 0, int Duration = 0)
        {
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

                List<string> ListContext = connectUsers.Where(x => x.FKUser == ReceiverId).Select(x => x.ContextId).ToList();
                if (ListContext.Count > 0)
                {
                    await Clients.Clients(ListContext).SendAsync("receiveMessage", data);
                }
                else
                {
                    List<string> Devices = await _chatServices.GetDevicesId(ReceiverId);
                    string GetSenderName = await _chatServices.GetReceiverName(SenderId);
                    await SendPushNotificationAsync(Devices, SenderId, GetSenderName, 10, OrderId);
                }

            }

        }

        //To Connect in Mobile
        public async Task Connect(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                ConnectUser connect = new ConnectUser
                {
                    FKUser = userId,
                    ContextId = Context.ConnectionId
                };
                connectUsers.Add(connect);
                await Clients.All.SendAsync("connected", true);
            }
        }

        //To DisConnect in Mobile
        public async Task DisConnect(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                List<ConnectUser> Connects = connectUsers.Where(x => x.FKUser == userId).ToList();
                if (Connects.Count > 0)
                {
                    connectUsers.RemoveAll(x => x.FKUser == userId);
                }
                await Clients.All.SendAsync("disconnected", false);
            }
        }

        #region Comments
        ////To Connect in Mobile
        //public async Task Connect(string userId)
        //{
        //    if (!string.IsNullOrEmpty(userId))
        //    {
        //        await Groups.AddToGroupAsync(Context.ConnectionId, userId);
        //        await Clients.All.SendAsync("connected", true);


        //        var listgroupsuser = listgroups.Where(x => x.UserId == userId).FirstOrDefault();
        //        if (listgroupsuser == null)
        //        {
        //            listgroups.Add(new Listgroups() { UserId = userId, qty = 1 });
        //        }
        //        //else
        //        //{
        //        //    if (listgroupsuser.qty < 0)
        //        //    {
        //        //        listgroupsuser.qty = 1;
        //        //    }
        //        //    else
        //        //    {
        //        //        listgroupsuser.qty += 1;
        //        //    }
        //        //}

        //    }

        //}

        ////To DisConnect in Mobile
        //public async Task DisConnect(string userId)
        //{
        //    if (!string.IsNullOrEmpty(userId))
        //    {
        //        await Groups.RemoveFromGroupAsync(Context.ConnectionId, userId);
        //        await Clients.All.SendAsync("disconnected", false);

        //        var listgroupsuser = listgroups.Where(x => x.UserId == userId).FirstOrDefault();
        //        if (listgroupsuser != null)
        //        {
        //            //listgroupsuser.qty -= 1;
        //            listgroups.Remove(listgroupsuser);
        //        }
        //    }
        //}

        //public async Task ConnectWeb(string userId)
        //{
        //    await Groups.AddToGroupAsync(Context.ConnectionId, userId);
        //    await Clients.All.SendAsync("connected", true);
        //}
        #endregion



        public async Task SendPushNotificationAsync(List<string> Devices, string receiverId, string receiverName, int? type = 0, int? orderId = 0)
        {
            try
            {
                var user = await _dbContext.Users.Where(x => x.Id == receiverId).FirstOrDefaultAsync();

                //FcmSettingDto Fcm = await _chatServices.GetFcmSetting();

                foreach (var item in Devices)
                {
                    string applicationID = "AAAA1nWIAiY:APA91bF3RWA1mprCn7JbgjBpi4fqy-s97-2jW51r6RWIat1AgOQkZ3_eAEWivxgWdMS4hT1NGukt9htzKotHBpw9q45OH5014UTMBe0TkPVf_s0PdsMbnCkKo7xEHGAjn68fiNDtScHm";
                    string senderId = "921094849062";
                    string deviceId = item;
                    WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                    tRequest.Method = "post";
                    tRequest.ContentType = "application/json";
                    if (true)
                    {
                        var data = new
                        {
                            to = deviceId,

                            notification = new
                            {
                                body = user.Lang == "ar" ? "لديك رسالة جديدة" : "you have a new message",
                                userType = 1,
                                title = " البترول الذهبى ",
                                sound = "Enabled",
                                priority = "high",
                                type = type,
                                receiverId = receiverId,
                                receiverName = receiverName,
                                orderId = orderId,
                                click_action = "FLUTTER_NOTIFICATION_CLICK"
                            },
                            data = new
                            {
                                body = user.Lang == "ar" ? "لديك رسالة جديدة" : "you have a new message",
                                userType = 1,
                                title = "البترول الذهبى ",
                                sound = "Enabled",
                                priority = "high",
                                type = type,
                                receiverId = receiverId,
                                receiverName = receiverName,
                                orderId = orderId,
                                click_action = "FLUTTER_NOTIFICATION_CLICK"
                            }
                        };
                        var serializer = new JavaScriptSerializer();
                        var json = serializer.Serialize(data);
                        Byte[] byteArray = Encoding.UTF8.GetBytes(json);
                        tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));
                        tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
                        tRequest.ContentLength = byteArray.Length;
                        using (Stream dataStream = tRequest.GetRequestStream())
                        {
                            dataStream.Write(byteArray, 0, byteArray.Length);
                            using (WebResponse tResponse = tRequest.GetResponse())
                            {
                                using (Stream dataStreamResponse = tResponse.GetResponseStream())
                                {
                                    using (StreamReader tReader = new StreamReader(dataStreamResponse))
                                    {
                                        String sResponseFromServer = tReader.ReadToEnd();
                                        string str = sResponseFromServer;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;

            }
        }

    }
}
