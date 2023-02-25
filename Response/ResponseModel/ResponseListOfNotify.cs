using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Response.ResponseModel
{
    public class ResponseListOfNotify
    {
        public int id { get; set; }
        public string text { get; set; }
        public string date { get; set; }
        public int? type { get; set; }
        public int orderId { get; set; }
    }
}
