using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Models.ChatModel
{
    public class ListUsersMyChatDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string LastMessage { get; set; }
        public string Date { get; set; }
        public string Image { get; set; }
    }
}
