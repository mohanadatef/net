using KhadimiEssa.Models.ChatModels;
using KhadimiEssa.Models.ChatViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Services
{
    public interface IChatServices
    {
        Task<PushMessegeViewModel> AddNewMessage(NewMessageViewModel model);
        Task<List<ConversationsViewModel>> ListUsersMyChat(string UserId);
        Task<List<MessageTwoUsersViewModel>> GetAllMessageBetweenTwoUser(string ReceiverId, string SenderId, int OrderId, int page_number);
        Task<string> GetReceiverName(string UserId);
        //Task<FcmSettingDto> GetFcmSetting();
        Task<List<string>> GetDevicesId(string UserId);
    }
}
