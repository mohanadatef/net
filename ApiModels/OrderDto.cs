using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.ApiModels
{
    public class OrderDto
    {
        public int id { get; set; }
        public string status { get; set; }
        public string orderDate { get; set; }
        public string userId { get; set; }
        public string userName { get; set; }
        public string userImg { get; set; }
        public string providerId { get; set; }
        public string excutionDate { get; set; }
        public string location { get; set; }
        public string carBrand { get; set; }
        public double price { get; set; }
        public double distance { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public int stutesId { get; set; }
        public string time { get; set; }

        public double packageprice { get; set; }
        public double coponprice { get; set; }
        public double total { get; set; }
        public string phone { get; set; }
        public bool isPaid { get; set; }
        public string payStatus { get; set; }
        public string typePay { get; set; }
        public string package { get; set; }
        public DateTime orderDateTime { get; set; }
        public string Copon { get; set; }
    }
}
