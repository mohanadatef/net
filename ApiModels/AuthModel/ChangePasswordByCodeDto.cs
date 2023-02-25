using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Models.AuthModel
{
    public class ChangePasswordByCodeDto
    {
        public string userId { get; set; }

        [Required(ErrorMessage = "من فضلك ادخل كود التحقق")]
        [Display(Name = "Code")]
        public int code { get; set; }

        [Required(ErrorMessage = "من فضلك ادخل كلمة المرور الجديدة")]
        [Display(Name = "New Password")]
        [StringLength(100, ErrorMessage = "يجب ان تزيد كلمة المرور عن 6 ارقام", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string newPassword { get; set; }

        //[DataType(DataType.Password)]
        //[Display(Name = "Confirm password")]
        //[Compare("newPassword", ErrorMessage = "يرجى التأكد من تطابق كلمتا المرور")]
        //public string confirmPassword { get; set; }

        public string lang { get; set; } = "ar";
    }
}
