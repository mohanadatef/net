using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.ViewModels
{
    public class SmsSettingModel
    {
        public string SmsProvider { get; set; }

        public string SenderName { get; set; }
        [Required(ErrorMessage = "من فضلك هذا الحقل مطلوب")]
        public string UserNameSms { get; set; }
        [Required(ErrorMessage = "من فضلك هذا الحقل مطلوب")]
        public string PasswordSms { get; set; }

    }
}
