using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Models.ChatViewModel
{
    public class ListMessagesUserViewModel
    {
        public int OrderId { get; set; }
        public int pageNumber { get; set; } = 50;
    }
}
