using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.ApiModels
{
    public class AddOrderDto
    {
        //public string providerId { get; set; }
        public int carBrandId { get; set; }
        public double depositPrice { get; set; }
        public string executionDate { get; set; }
        public int executionTime { get; set; }
        /// <summary>
        /// 1=>cash
        /// 2=>pocket
        /// 3=>online
        /// </summary>
        public int typePay { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public string location { get; set; }
        public int coponId { get; set; }
        public int packageId { get; set; }
        public double total { get; set; }
        public string lang { get; set; }
        public int stationId { get; set; }
        public int kilometers { get; set; }


    }
}
