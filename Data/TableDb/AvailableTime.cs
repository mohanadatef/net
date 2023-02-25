using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Data.TableDb
{
    public class AvailableTime
    {
        public AvailableTime()
        {
            Orders = new HashSet<Orders>();
        }

        [Key]
        public int Id { get; set; }
        public DateTime time { get; set; }
        public bool IsActive { get; set; }

        [InverseProperty(nameof(TableDb.Orders.Availabletime))]
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
