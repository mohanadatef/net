using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Enums
{
    public class AllEnums
    {

        public enum FoldersName
        {
            Users = 1,
            ChatFiles = 2,

        }
        public enum BranchsName
        {
            Sel3a = 1,
            HarajAwamer = 2,
            HarajBadr = 7,
            HarajAlmamlaka = 8,
            HarajCars = 9,
            HarajShow = 10,
            HarajFutureGoals = 11
        }
        public enum Fillter_Type
        {
            Near = 1,
            New = 2,
            PriceLow = 3,
            PriceHigh = 4,
            ElmamshLow = 5,
            ElmamshHigh = 6
        }
        public enum Report_Type
        {
            Ads = 1,
            User = 2
        }
        public enum NotifyTypes
        {
            BlockUser = -1,
            AddNewAds = 1,
            EditNewAds = 2,
            AddCommentToAds = 3,
            AddReplyCommentToAds = 4,
            AddCommentToUser = 5,
            AddRateToUser = 6,
            NotiyFromDashBord = 7,
            AddUserFollow = 8
        }
        public enum ChatFrom
        {
            Mobile = 1,
            Web = 2
        }

        public enum LastMessage
        {
            NotLast = 0,
            LastMessage = 1
        }
        public enum FileName
        {
            Category = 1,
            HeaderAdvert = 2,
            AdsInfo = 3,
            BnckTransfer = 4,
            IntroSite = 7,
            Users = 8,
            ChatFiles = 9,
            SocialMedia = 12,

        }
        public enum SearchDate
        {
            _1days = 1,
            _3days = 2,
            _1week = 3,
            _1months = 4
        }
        public enum Type_Follow
        {
            Ads = 1,
            User = 2
        }

        public enum TypeSpecification
        {
            CheckBox = 1,
            Bar = 2,
            DropdownList = 3,
        }



        public enum orderstutes
        {
            Neworder = 1,
            CurrentOrder = 2,
            finishedorder = 3,
            Refusedorder = 4,
            Canceledorder = 5,

        }
        public enum type_pay
        {
            cash = 1,
            pocket = 2,
            online = 3,
        }
        public enum User_Type
        {
            Client = 1,
            deleget = 2,
            AdminBranch = 3,
            Admin = 4
        }


        public enum PlaceFooter
        {
            Tab1 = 1,
            Tab2 = 2,
            Tab3 = 3,
        }
        public enum PackagesTypepay
        {
            receipt = 1

        }

        public enum Roles
        {
            Admin = 0,
            Mobile = 1,
            AdminBranch = 2,
            Advertisment = 3,
            Payments = 4,
            Copons = 5,
            SocialMedia = 6,
            Questions = 7,
            Notifications = 8,
            SendSmsMsg = 9,
            Chat = 10,
            ContactUs = 11,
            Setting = 12,
            Provider = 13,
            OilStations = 14,
            CarBrands = 15,
            Clients = 16,
            Orders = 17,
            AvailableTimes = 18,
            PaymentMethods = 19,
            Packages = 20,
            Notes = 21,
            Rates = 22,
        }

        public enum SmsType
        {
            MessageBy4jawaly = 1,
            MessageByElYamam = 2,
            MessageByMobily = 3,
            GmailMail = 4,
        }

        public enum FileTypeChat
        {
            text = 0,
            img = 1,
            audio = 2,
            file = 3
        }



    }
}
