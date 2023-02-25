
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Models.AuthModel
{
    public class LoginDto
    {

        [Required(ErrorMessage = "من فضلك ادخل رقم الجوال")]
        [Display(Name = "Phone Number")]
        [Phone]
        //[RegularExpression(@"^(009665|9665|\+9665|05|5)(5|0|3|6|4|9|1|8|7)([0-9]{7})$", ErrorMessage = "من فضل ادخل رقم الجوال بشكل صحيح")]
        public string phone { get; set; }

        [Required(ErrorMessage = "من فضلك ادخل كلمة المرور القديمة")]
        [Display(Name = "Password")]
        [StringLength(100, ErrorMessage = "يجب ان تزيد كلمة المرور عن 6 ارقام", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string password { get; set; }

        public string lang { get; set; } = "ar";
        public string deviceType { get; set; }
        public string deviceId { get; set; }
        public string projectName { get; set; } = "البترول الذهبى";

    }
}
