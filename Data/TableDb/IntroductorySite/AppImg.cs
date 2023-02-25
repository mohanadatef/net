using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Data.TableDb.IntroductorySite
{
    public class AppImg
    {
        [Key]
        public int Id { get; set; }
        public string Img { get; set; }
        public bool IsActive { get; set; }

    }
}
