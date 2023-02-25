using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Response.ResponseModel
{
    public class ResponseResendCode
    {
        public int code { get; set; }
        public string userId { get; set; }
        public string phone { get; set; }
    }
}
