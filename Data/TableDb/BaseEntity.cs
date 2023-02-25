using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Data.TableDb
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public bool IsActive { get; set; }
        public DateTime Date { get; set; }
        public string ChangeLangName(string lang = "ar")
        {

            return AAITHelper.HelperMsg.creatMessage(lang, NameAr, NameEn);
        }

    }
}
