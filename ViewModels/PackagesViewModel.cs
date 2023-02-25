using System;
using System.ComponentModel.DataAnnotations;

namespace KhadimiEssa.ViewModels
{
    public class PackagesViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string NameAr { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string NameEn { get; set; }
        public bool IsActive { get; set; }
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public double Price { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string DescriptionAr { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string DescriptionEn { get; set; }
        
    }
}
