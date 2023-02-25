using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Models.AuthModel
{
    public class ResendCodeDto
    {

        public string userId { get; set; }
        public string lang { get; set; } = "ar";
    }
}
