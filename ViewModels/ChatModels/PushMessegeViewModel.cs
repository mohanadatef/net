using KhadimiEssa.Models.ChatViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Models.ChatModels
{
    public class PushMessegeViewModel : MessageTwoUsersViewModel
    {
        public int start { get; set; }
        public int position { get; set; }
        public int duration { get; set; }
        public bool play { get; set; } = false;
    }
}
