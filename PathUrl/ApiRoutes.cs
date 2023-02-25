using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.PathUrl
{
    public class ApiRoutes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;

        public static class LogicDeleget
        {

            public const string ListRateUser = Base + "/ListRateUser";
            public const string AddRateDeleget = Base + "/AddRateDeleget";
            public const string ListNewOrdersAsync = Base + "/ListNewOrdersAsync";
            public const string ListCurrentOrdersAsync = Base + "/ListCurrentOrdersAsync";
            public const string ListFinishedOrdersAsync = Base + "/ListFinishedOrdersAsync";
            public const string AcceptOrderAsync = Base + "/AcceptOrderAsync";
            public const string RefuseOrderAsync = Base + "/RefuseOrderAsync";
            public const string FinishOrderAsync = Base + "/FinishOrderAsync";
            public const string GetOrderDetails = Base + "/GetOrderDetails";

        }
        public static class LogicUser
        {
            public const string UseCopon = Base + "/UseCopon";
            public const string ListRateDeleget = Base + "/ListRateDeleget";
            public const string AddRateDeleget = Base + "/AddRateDeleget";
            public const string ListHomeDataAsync = Base + "/ListHomeDataAsync";
            public const string ListAvailableTimes = Base + "/ListAvailableTimes";
            public const string ListNewOrdersUserAsync = Base + "/ListNewOrdersUserAsync";
            public const string ListCurrentOrdersUserAsync = Base + "/ListCurrentOrdersUserAsync";
            public const string ListFinishedOrdersUserAsync = Base + "/ListFinishedOrdersUserAsync";
            public const string CheckRequiredDistanceAsync = Base + "/CheckRequiredDistanceAsync";
            public const string AddOrderAsync = Base + "/AddOrderAsync";
            public const string PayOrderAsync = Base + "/PayOrderAsync";
            public const string GetOrderDetailsUser = Base + "/GetOrderDetailsUser";
            public const string CancelOrder = Base + "/CancelOrder";
            public const string CheckTimeAvailableAsync = Base + "/CheckTimeAvailableAsync";

            public const string ListNotes = Base + "/ListNotes";

        }
        public static class setting
        {
            public const string GetRegoin = Base + "/GetRegoin";
            public const string GetOffersDashbord = Base + "/GetOffersDashbord";
            public const string GetQAndAnswer = Base + "/GetQAndAnswer";
            public const string CondtionsForDelegt = Base + "/CondtionsForDelegt";
            public const string AboutUsForDelegt = Base + "/AboutUsForDelegt";
            public const string PrivacyForDelegt = Base + "/PrivacyForDelegt";
            public const string Condtions = Base + "/Condtions";
            public const string ContactUs = Base + "/ContactUs";
            public const string AboutUs = Base + "/AboutUs";
            public const string Privacy = Base + "/Privacy";
            public const string GetAdvertsment = Base + "/GetAdvertsment";
            public const string GetSetting = Base + "/GetSetting";
            public const string Addcomplaints = Base + "/Addcomplaints";
            public const string ListSocialMedia = Base + "/ListSocialMedia";
            public const string Contacts = Base + "/Contacts";
            public const string ListQuestions = Base + "/ListQuestions";
            public const string AddFavourite = Base + "/AddFavourite";
            public const string ListFavourite = Base + "/ListFavourite";

            public const string GetQAndAnswerforDeleget = Base + "/GetQAndAnswerforDeleget";
            public const string ContactUsforDeleget = Base + "/ContactUsforDeleget";
            public const string GetSettingforDeleget = Base + "/GetSettingforDeleget";
            public const string AddcomplaintsforDeleget = Base + "/AddcomplaintsforDeleget";

            public const string GetFinanceAsync = Base + "/GetFinanceAsync";
        }

        public static class Identity
        {

            public const string UpdateAsyncDataDelegt = Base + "/UpdateAsyncDataDelegt";
            public const string RegisterClient = Base + "/RegisterClient";
            public const string RegisterDeleget = Base + "/RegisterDeleget";
            public const string RemoveNotiyByIdAsync = Base + "/RemoveNotiyByIdAsync";
            public const string RemoveAllNotiy = Base + "/RemoveAllNotiy";
            public const string UpdateForWebsiteAsyncDataUser = Base + "/UpdateForWebsiteAsyncDataUser";
            // client
            public const string ResendCode = Base + "/ResendCode";
            public const string ListOfNotify = Base + "/ListOfNotify";
            public const string ChangeReciveOrder = Base + "/ChangeReciveOrder";
            public const string UpdateDataUser = Base + "/UpdateDataUser";
            public const string ChangePasswordByCode = Base + "/ChangePasswordByCode";
            public const string Login = Base + "/login";
            public const string ForgetPassword = Base + "/ForgetPassword";
            public const string Register = Base + "/register";
            public const string ListCity = Base + "/ListCity";
            public const string ConfirmCodeRegister = Base + "/ConfirmCodeRegister";
            public const string reset_password = Base + "/reset_password";
            public const string ChangePassward = Base + "/ChangePassward";
            public const string GetDataOfUser = Base + "/GetDataOfUser";
            public const string ConvertloyaltytoWallet = Base + "/ConvertloyaltytoWallet";
            public const string IsActive = Base + "/IsActive";
            public const string RemoveAccount = Base + "/RemoveAccount";

            

            // addtional services from user 




            public const string ChangeLanguage = Base + "/ChangeLanguage";
            public const string ChangeNotify = Base + "/ChangeNotify";
            public const string logout = Base + "/logout";
        }

        public static class Chat
        {
            public const string ListChatUsers = Base + "/ListChatUsers";
            public const string ListMessagesUser = Base + "/ListMessagesUser";
            public const string UploadNewFile = Base + "/UploadNewFile";
            public const string DeleteMessagesUser = Base + "/DeleteMessagesUser";
        }
    }
}
