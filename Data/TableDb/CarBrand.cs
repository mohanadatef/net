using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Data.TableDb
{
    public class CarBrand:BaseEntity
    {
        public CarBrand()
        {
            Orders = new HashSet<Orders>();
        }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
