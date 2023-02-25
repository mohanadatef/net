using KhadimiEssa.Helper;
using KhadimiEssa.Models.AuthModel;
using KhadimiEssa.Response.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Interfaces.Auth
{
    public interface IAccountService
    {
        Task<Response<ResponseUserInfo>> RegisterClientAsync(RegisterDto userModel);
        //Task<Response<ResponseDelegetInfo>> RegisterDelegetAsync(RegisterDto userModel);
        Task<Response<dynamic>> ConfirmCodeRegisterAsync(ConfirmCodeDto userModel);
        Task<Response<ResponseResendCode>> ResendCodeAsync(ResendCodeDto userModel);
        Task<dynamic> LoginAsync(int checkType , LoginDto userModel);
        Task<Response<string>> ChangePasswordAsync(string UserId, ChangePasswordDto userModel);
        Task<Response<ResponseForgetPassword>> ForgetPasswordAsync(ForgetPasswordDto userModel);
        Task<Response<string>> ChangePasswordByCodeAsync(ChangePasswordByCodeDto userModel);
        Task<Response<string>> ChangeLanguageAsync(ChangeLanguageDto userModel, string UserId);
        Task<Response<dynamic>> ChangeNotifyAsync(ChangeNotifyDto userModel, string UserId);
        Task<Response<string>> LogoutAsync(LogoutDto userModel, string UserId);
        Task<Response<List<ResponseListOfNotify>>> ListOfNotifyAsync(string UserId, string lang = "ar");
        Task<Response<dynamic>> GetDataOfUser(string UserId, string lang = "ar");
        Task<Response<dynamic>> UpdateAsyncDataUser(UpdateDataUserDto userModel);
        Task<Response<dynamic>> UpdateAsyncDataDelegt(UpdateDataDelegtViewModel userModel);
        Task<bool> RemoveAccount(string userId);


    }
}
