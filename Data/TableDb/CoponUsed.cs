using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Data.TableDb
{
    public class CoponUsed
    {
        [Key]
        public int ID { get; set; }
        public int FkCopon { get; set; }
        public int FkOrder { get; set; }
        public string FkUser { get; set; }
    }
}
