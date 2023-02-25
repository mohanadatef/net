using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Data.TableDb
{
    public class SmsMessage
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Date { get; set; }
    }
}
