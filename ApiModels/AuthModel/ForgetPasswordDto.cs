using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Models.AuthModel
{
    public class ForgetPasswordDto
    {
        [Required(ErrorMessage = "من فضلك ادخل رقم الجوال")]
        [Display(Name = "Phone Number")]
        [Phone]
        //[RegularExpression(@"^(009665|9665|\+9665|05|5)(5|0|3|6|4|9|1|8|7)([0-9]{7})$", ErrorMessage = "من فضل ادخل رقم الجوال بشكل صحيح")]
        public string phone { get; set; }

        public string lang { get; set; } = "ar";
    }
}
