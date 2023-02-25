using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Models.AdvertisementViewModel
{
    public class AddAdvertisementViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "من فضلك اختر الصورة")]
        public string TitleAr { get; set; }
        [Required(ErrorMessage = "من فضلك اختر الصورة")]
        public string TitleEn { get; set; }
        [Required(ErrorMessage = "من فضلك اختر الصورة")]
        public IFormFile Img { get; set; }
        public bool IsActive { get; set; }
        public object ImgFormFile { get; internal set; }
    }
}
