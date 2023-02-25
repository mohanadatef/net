using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Data.TableDb
{
    public class OilStation : BaseEntity
    {
        public OilStation()
        {
            Providers = new HashSet<ApplicationDbUser>();
            Orders = new HashSet<Orders>();
        }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Location { get; set; }
        public double ServiceScope { get; set; }
        public bool IsDeleted { get; set; }
        public int CountOrderForTime { get; set; }


        public virtual ICollection<ApplicationDbUser> Providers { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }

    }
}
