using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Data.TableDb.IntroductorySite
{
    public class CustomerOpinion
    {
        [Key]
        public int Id { get; set; }
        public string Img { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public int Rate { get; set; }
        public bool IsActive { get; set; }
    }
}
