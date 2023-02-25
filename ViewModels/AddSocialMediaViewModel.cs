using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Models.SocialMediaViewModel
{
    public class AddSocialMediaViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Name { get; set; }
        [Required(ErrorMessage = "من فضلك اختر الصورة")]
        public IFormFile Img { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Url { get; set; }
        public bool IsActive { get; set; }
    }
}
