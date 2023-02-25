using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.ApiModels
{
    public class OilStationDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public string location { get; set; }
    }
}
