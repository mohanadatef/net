using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Models.AuthModel
{
    public class ConfirmCodeDto
    {
        [Required(ErrorMessage = "من فضلك ادخل كود التحقق")]
        public int code { get; set; }
        [Required]
        public string userId { get; set; }
        public string lang { get; set; } = "ar";


    }

}
