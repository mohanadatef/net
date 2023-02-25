using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Data.TableDb
{
    public class Package : BaseEntity
    {
        public double Price { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Orders> Orders { get; set; } = new HashSet<Orders>();

        public string ChangeLangDesc(string lang = "ar")
        {

            return AAITHelper.HelperMsg.creatMessage(lang, DescriptionAr, DescriptionEn);
        }
    }
}
