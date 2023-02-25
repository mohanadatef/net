using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Helper
{
    public class Response<T>
    {
        public Response()
        {
        }
        public Response(T data, string msg = "")
        {
            Key = 1;
            Msg = msg;
            Data = data;
        }
        //validation key = 0 msg
        public Response(string msg)
        {
            Key = 0;
            Msg = msg;
        }
        public int Key { get; set; }
        public string Msg { get; set; }
        public T Data { get; set; }
    }
}
