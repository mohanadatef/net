using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Data.TableDb
{
    public class Setting
    {
        [Key]
        public int Id { get; set; }
        [MinLength(10)]
        public string Phone { get; set; }
        public string Email { get; set; }

        public string CondtionsArClient { get; set; }
        public string CondtionsEnClient { get; set; }

        public string CondtionsArDelegt { get; set; }
        public string CondtionsEnDelegt { get; set; }

        public string AboutUsArClient { get; set; }
        public string AboutUsEnClient { get; set; }

        public string AboutUsArDelegt { get; set; }
        public string AboutUsEnDelegt { get; set; }

        public string PrivacyArClient { get; set; }
        public string PrivacyEnClient { get; set; }

        public string PrivacyArDelegt { get; set; }
        public string PrivacyEnDelegt { get; set; }


        public string SenderName { get; set; } = "test";
        public string UserNameSms { get; set; } = "test";
        public string PasswordSms { get; set; } = "test";

        public string ApplicationId { get; set; }
        public string SenderId { get; set; }

        //4jawaly mobily elyamam
        public string SmsProvider { get; set; } = "test";


        public double DepositPrice { get; set; }
        public bool IsShowDepositPrice { get; set; }
        public double RateBouns { get; set; }
        public double InvitationBouns { get; set; }
        public double Tax { get; set; }
        public int  CountOrderForTime { get; set; }

        //Contacts
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Location { get; set; }

    }
}
