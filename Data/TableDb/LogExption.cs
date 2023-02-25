using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Data.TableDb
{
    public class LogExption
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ServiceName { get; set; }
        public string Exption { get; set; }
        public DateTime Date { get; set; }
    }
}
