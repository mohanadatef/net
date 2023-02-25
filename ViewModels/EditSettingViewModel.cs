using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Models.SettingViewModel
{
    public class EditSettingViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [MinLength(10, ErrorMessage = "ادخل رقم الهاتف صحيح ولا يقل عن 10 أرقام")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [EmailAddress(ErrorMessage = "ادخل البريد الالكترونى بشكل صحيح")]
        public string Email { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string CondtionsArClient { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string CondtionsEnClient { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string CondtionsArDelegt { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string CondtionsEnDelegt { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string AboutUsArClient { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string AboutUsEnClient { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string AboutUsArDelegt { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string AboutUsEnDelegt { get; set; }
        
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string PrivacyArClient { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string PrivacyEnClient { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string PrivacyArDelegt { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string PrivacyEnDelegt { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string SenderName { get; set; } = "test";
        public string UserNameSms { get; set; } = "test";
        public string PasswordSms { get; set; } = "test";
        public string ApplicationId { get; set; }
        public string SenderId { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public double DepositPrice { get; set; }
        public double RateBouns { get; set; }
        public double InvitationBouns { get; set; }
        public double Tax { get; set; }
        public bool IsShowDepositPrice { get; set; }
        public int CountOrderForTime { get; set; }

        //Contacts
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Location { get; set; }

    }
}
