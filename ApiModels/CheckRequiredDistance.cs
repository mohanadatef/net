using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.ApiModels
{
    public class CheckRequiredDistance
    {
        public double lat { get; set; }
        public double lng { get; set; }
        public string location { get; set; }
        public string lang { get; set; }
    }
}
