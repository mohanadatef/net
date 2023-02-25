using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Models.ChatViewModel
{
    public class MessageTwoUsersViewModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string SenderImg { get; set; }
        public string ReceiverImg { get; set; }
        public string Message { get; set; }
        public string Date { get; set; }
        public int Type { get; set; }
    }
}
