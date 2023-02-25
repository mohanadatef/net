using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Models.CustomerOpinionsViewModel
{
    public class EditCustomerOpinionsViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Img { get; set; }
        [Required(ErrorMessage = "من فضلك اختر الصورة")]
        public string NameAr { get; set; }
        [Required(ErrorMessage = "من فضلك اختر الصورة")]
        public string NameEn { get; set; }
        [Required(ErrorMessage = "من فضلك اختر الصورة")]
        public string DescriptionAr { get; set; }
        [Required(ErrorMessage = "من فضلك اختر الصورة")]
        public string DescriptionEn { get; set; }
        [Required(ErrorMessage = "من فضلك اختر الصورة")]
        public int Rate { get; set; }
        public IFormFile ImgFormFile { get; set; }
        public bool IsActive { get; set; }
    }
}
