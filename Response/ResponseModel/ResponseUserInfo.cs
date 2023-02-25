using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Response.ResponseModel
{
    public class ResponseUserInfo
    {
        public string id { get; set; }
        public string userName { get; set; } = "";
        public string email { get; set; } = "";
        public string phone { get; set; } = "";
        public string lang { get; set; } = "ar";
        public bool closeNotify { get; set; } = false;
        public bool status { get; set; }
        public string imgProfile { get; set; } = "";
        public string token { get; set; } = "";
        public DateTime? expiration { get; set; }
        public int typeUser { get; set; }
        public int code { get; set; }
        public string invitationCode { get; set; } = "";

    }
}
