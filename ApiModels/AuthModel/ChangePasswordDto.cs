using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Models.AuthModel
{
    public class ChangePasswordDto
    {
        [Required(ErrorMessage = "من فضلك ادخل كلمة المرور القديمة")]
        [Display(Name = "Old Password")]
        [StringLength(100, ErrorMessage = "يجب ان تزيد كلمة المرور عن 6 ارقام", MinimumLength = 6)]
        [DataType(DataType.Password)]

        public string oldPassword { get; set; }

        [Required(ErrorMessage = "من فضلك ادخل كلمة المرور الجديدة")]
        [Display(Name = "New Password")]
        [StringLength(100, ErrorMessage = "يجب ان تزيد كلمة المرور عن 6 ارقام", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string newPassword { get; set; }

        public string lang { get; set; } = "ar";
    }
}
