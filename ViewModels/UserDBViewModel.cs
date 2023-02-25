using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Models.ControllerViewModel
{
    public class UserDBViewModel
    {
        public string id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string fullName { get; set; }
        public string img { get; set; }
        public string lang { get; set; }
        public bool isActive { get; set; }

    }
}
