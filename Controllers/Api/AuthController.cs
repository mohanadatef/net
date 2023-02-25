using AAITHelper;
using AAITHelper.Enums;
using KhadimiEssa.Data;
using KhadimiEssa.Data.TableDb;
using KhadimiEssa.Enums;
using KhadimiEssa.Helper;
using KhadimiEssa.Interfaces.Auth;
using KhadimiEssa.Models.AuthModel;
using KhadimiEssa.PathUrl;
using KhadimiEssa.Response.ResponseModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static KhadimiEssa.Enums.AllEnums;
using static KhadimiEssa.Helper.HelperMethods;

namespace KhadimiEssa.Controllers.Api
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiExplorerSettings(GroupName = "AuthAPI")]
    public class AuthApiController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly ICurrentUserService _currentUserService;
        private readonly IAccountService _accountService;


        public AuthApiController(ApplicationDbContext _db,
            ICurrentUserService currentUserService, IAccountService accountService)
        {
            db = _db;
            _currentUserService = currentUserService;
            _accountService = accountService;
        }


        #region MainInfo


        [AllowAnonymous]
        [HttpPost(ApiRoutes.Identity.RegisterClient)]
        public async Task<IActionResult> AddAsyncUser(RegisterDto userModel)
        {
            return Ok(await _accountService.RegisterClientAsync(userModel));
        }


        //[AllowAnonymous]
        //[HttpPost(ApiRoutes.Identity.RegisterDeleget)]
        //public async Task<IActionResult> AddAsyncDeleget(RegisterDto userModel)
        //{
        //    return Ok(await _accountService.RegisterDelegetAsync(userModel));
        //}


        [AllowAnonymous]
        [HttpPost(ApiRoutes.Identity.ConfirmCodeRegister)]
        public async Task<IActionResult> ConfirmCodeRegister(ConfirmCodeDto userModel)
        {
            return Ok(await _accountService.ConfirmCodeRegisterAsync(userModel));
        }
        [AllowAnonymous]
        [HttpPost(ApiRoutes.Identity.ResendCode)]
        public async Task<IActionResult> ResendCode(ResendCodeDto userModel)
        {
            return Ok(await _accountService.ResendCodeAsync(userModel));
        }


        [AllowAnonymous]
        [HttpPost(ApiRoutes.Identity.Login)]
        public async Task<IActionResult> Login(int checkType, LoginDto userModel)
        {
            return Ok(await _accountService.LoginAsync(checkType, userModel));
        }

        [HttpPost(ApiRoutes.Identity.GetDataOfUser)]
        public async Task<IActionResult> GetDataOfUser(string lang = "ar")
        {
            return Ok(await _accountService.GetDataOfUser(_currentUserService.UserId, lang));

        }

        [HttpPost(ApiRoutes.Identity.UpdateDataUser)]
        public async Task<IActionResult> UpdateAsyncDataUser(UpdateDataUserDto userModel)
        {
            return Ok(await _accountService.UpdateAsyncDataUser(userModel));
        }
        [HttpPost(ApiRoutes.Identity.UpdateAsyncDataDelegt)]
        public async Task<ActionResult> UpdateAsyncDataDelegt(UpdateDataDelegtViewModel userModel)
        {
            return Ok(await _accountService.UpdateAsyncDataDelegt(userModel));
        }

        [HttpPost(ApiRoutes.Identity.ChangePassward)]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto userModel)
        {
            return Ok(await _accountService.ChangePasswordAsync(_currentUserService.UserId, userModel));
        }

        [AllowAnonymous]
        [HttpPost(ApiRoutes.Identity.ForgetPassword)]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordDto userModel)
        {
            return Ok(await _accountService.ForgetPasswordAsync(userModel));
        }


        [AllowAnonymous]
        [HttpPost(ApiRoutes.Identity.ChangePasswordByCode)]
        public async Task<IActionResult> ChangePasswordByCode(ChangePasswordByCodeDto userModel)
        {
            return Ok(await _accountService.ChangePasswordByCodeAsync(userModel));
        }

        [HttpPost(ApiRoutes.Identity.ChangeLanguage)]
        public async Task<IActionResult> ChangeLanguageAsync(ChangeLanguageDto userModel)
        {
            return Ok(await _accountService.ChangeLanguageAsync(userModel, _currentUserService.UserId));
        }

        [HttpPost(ApiRoutes.Identity.ChangeNotify)]
        public async Task<IActionResult> ChangeNotifyAsync(ChangeNotifyDto userModel)
        {
            return Ok(await _accountService.ChangeNotifyAsync(userModel, _currentUserService.UserId));
        }
        [HttpPost(ApiRoutes.Identity.logout)]
        public async Task<IActionResult> LogoutAsync(LogoutDto userModel)
        {
            return Ok(await _accountService.LogoutAsync(userModel, _currentUserService.UserId));
        }

        /// <summary>
        /// delete account 
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(string), 500)]
        [HttpPost(ApiRoutes.Identity.RemoveAccount)]
        public async Task<IActionResult> RemoveAccount()
        {
            var userId = _currentUserService.UserId;
            var result = await _accountService.RemoveAccount(userId);
            return Ok(new { key=1, msg="تم حذف الحساب بنجاح", data="" });
        }

        #region Notify

        [HttpPost(ApiRoutes.Identity.ListOfNotify)]
        public async Task<IActionResult> GetListOfNotifyAsync(string lang = "ar")
        {
            return Ok(await _accountService.ListOfNotifyAsync(_currentUserService.UserId, lang));
        }

        #endregion

        #endregion

        [HttpPost(ApiRoutes.Identity.IsActive)]
        public async Task<ActionResult> IsActive(string lang = "ar")
        {
            try
            {
                var user = db.Users.Where(x => x.Id == _currentUserService.UserId).SingleOrDefault();

                if (user.IsActive == false && user.ActiveCode == true)
                {
                    var info = await db.DeviceIds.Where(x => x.FkUser == _currentUserService.UserId).ToListAsync();
                    if (info != null)
                    {
                        db.DeviceIds.RemoveRange(info);
                        await db.SaveChangesAsync();
                    }
                    return Json(new
                    {
                        key = 0,
                        data = true,
                        status = "blocked",
                    });
                }
                else
                {
                    return Json(new
                    {
                        key = 1,
                        data = false,
                        status = "Unblocked",
                    });
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    key = 0,
                    msg = ex.Message
                });
            }

        }

        #region HelperMethods
        // not do yet
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ResponseDelegetInfo> GetDelegtInfoAsync(string userId, string lang = "ar", string token = "")
        {

            var UserDB = await db.Users.Where(x => x.Id == userId).Select(x => new ResponseDelegetInfo
            {
                id = x.Id,
                userName = x.user_Name,
                phone = x.PhoneNumber,
                typeUser = x.TypeUser,
                closeNotify = x.CloseNotify,
                email = x.Email,
                imgProfile = x.ImgProfile,
                lang = lang
            }).FirstOrDefaultAsync();

            return UserDB;
        }

        // not do yet
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ResponseUserInfo> GetUserInfoAsync(string userId, string lang = "ar", string token = "")
        {

            var UserDB = await db.Users.Where(x => x.Id == userId).Select(x => new ResponseUserInfo
            {
                id = x.Id,
                userName = x.user_Name,
                phone = x.PhoneNumber,
                typeUser = x.TypeUser,
                closeNotify = x.CloseNotify,
                email = x.Email,
                imgProfile = x.ImgProfile,
                lang = lang

            }).FirstOrDefaultAsync();

            return UserDB;
        }
        #endregion
    }
}
