using KhadimiEssa.Data;
using KhadimiEssa.Data.TableDb;
using KhadimiEssa.Models.ChatModels;
using KhadimiEssa.Models.ChatViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Services
{
    public class ChatServices : IChatServices
    {
        private readonly ApplicationDbContext _context;
        public ChatServices(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<PushMessegeViewModel> AddNewMessage(NewMessageViewModel model)
        {
            try
            {
                Messages newMessage = new Messages
                {
                    SenderId = model.SenderId,
                    ReceiverId = model.ReceiverId,
                    FKOrder = model.OrderId,
                    Text = model.Text,
                    TypeMessage = model.Type,
                    DateSend = DateTime.UtcNow.AddHours(3),
                };

                await _context.Messages.AddAsync(newMessage);
                await _context.SaveChangesAsync();

                return _context.Messages.Where(x => x.Id == newMessage.Id).Select(m => new PushMessegeViewModel
                {
                    Id = m.Id,
                    OrderId = m.FKOrder,
                    Type = m.TypeMessage,
                    SenderId = m.SenderId,
                    ReceiverId = m.ReceiverId,
                    SenderImg = Helper.HelperMethods.BaisUrlHoste + m.Sender.ImgProfile,
                    ReceiverImg = Helper.HelperMethods.BaisUrlHoste + m.Receiver.ImgProfile,
                    Message = m.TypeMessage == (int)Enums.AllEnums.FileTypeChat.text ? m.Text : /*Helper.Helper.BaseUrlHoste +*/ m.Text,
                    duration = m.Duration,
                    Date = m.DateSend.ToString("hh:mm tt")

                }).FirstOrDefault() ?? new PushMessegeViewModel() { };
            }
            catch (Exception ex)
            {

                return new PushMessegeViewModel() { };
            }

        }


        public async Task<List<MessageTwoUsersViewModel>> GetAllMessageBetweenTwoUser(string ReceiverId, string SenderId, int OrderId, int page_number)
        {
            List<MessageTwoUsersViewModel> Messages = await _context.Messages.Include(x => x.Receiver).Include(x => x.Sender).Where(x => x.FKOrder == OrderId).Select(x => new MessageTwoUsersViewModel
            {
                SenderId = x.Sender.user_Name,
                ReceiverId = x.Receiver.user_Name,
                SenderImg = x.Sender.ImgProfile,
                ReceiverImg = x.Receiver.ImgProfile,
                Date = x.DateSend.ToString("dd/MM/yyyy h:mm tt"),
                Message = x.Text,
                Type = x.TypeMessage
            }).OrderByDescending(x => x.Id).ToListAsync();

            return Messages;
        }



        public Task<List<ConversationsViewModel>> ListUsersMyChat(string UserId)
        {
            throw new NotImplementedException();
        }


        public async Task<string> GetReceiverName(string UserId)
        {
            string ReceiverName = await _context.Users.Where(x => x.Id == UserId).Select(x => x.user_Name).FirstOrDefaultAsync();
            return ReceiverName;
        }

        //public async Task<FcmSettingDto> GetFcmSetting()
        //{
        //    return await _context.Settings.Select(x => new FcmSettingDto { ApplicationId = x.ApplicationId, SenderId = x.SenderId }).FirstOrDefaultAsync();
        //}

        public async Task<List<string>> GetDevicesId(string UserId)
        {
            List<string> Devices = await _context.DeviceIds.Where(x => x.FkUser == UserId && x.DeviceId_ != null).Select(x => x.DeviceId_).ToListAsync();
            return Devices;
        }

    }
}
