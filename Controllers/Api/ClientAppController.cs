using AAITHelper;
using AAITHelper.Enums;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using KhadimiEssa.AutoMapper;
using KhadimiEssa.Data;
using KhadimiEssa.Data.TableDb;
using KhadimiEssa.Helper;
using KhadimiEssa.Interfaces.App;
using KhadimiEssa.Interfaces.Auth;
using KhadimiEssa.ModelDTO.AboutUsDTO;
using KhadimiEssa.ModelDTO.CondtionsDTO;
using KhadimiEssa.ModelDTO.ListFavouriteDTO;
using KhadimiEssa.ModelDTO.ListQuestionsDTO;
using KhadimiEssa.ModelDTO.ListSocialMediaDTO;
using KhadimiEssa.ModelDTO.SettinDTO;
using KhadimiEssa.Models.AuthModel;
using KhadimiEssa.PathUrl;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace KhadimiEssa.Controllers.Api
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiExplorerSettings(GroupName = "ClientApp")]
    public class ClientAppController : Controller
    {
        private readonly IAppClientService _appClientService;

        public ClientAppController(IAppClientService appClientService)
        {
            _appClientService = appClientService;
        }


        [HttpPost(ApiRoutes.setting.ListSocialMedia)]
        [AllowAnonymous]
        public async Task<IActionResult> ListSocialMedia(string lang = "ar")
        {
            return Ok(await _appClientService.ListSocialMedia(lang));
        }
        
        [HttpPost(ApiRoutes.setting.Contacts)]
        [AllowAnonymous]
        public async Task<IActionResult> Contacts(string lang = "ar")
        {
            return Ok(await _appClientService.Contacts(lang));
        }


        //[HttpPost(ApiRoutes.setting.ListQuestions)]
        //[AllowAnonymous]
        //public async Task<IActionResult> ListQuestions(string lang = "ar")
        //{
        //    return Ok(await _appClientService.ListQuestions(lang));
        //}
         

        #region ----------contactUs Comment--------------
        //[HttpPost(ApiRoutes.setting.ContactUs)]
        //[AllowAnonymous]
        //public async Task<ActionResult> ContactUsAsync(string lang = "ar")
        //{
        //    try
        //    {
        //        return Json(new
        //        {
        //            key = 1,
        //            Setting = await db.Settings.Select(x => new
        //            {
        //                phone = x.Phone,
        //                instgram = x.Instgram,
        //                twitter = x.Twitter,
        //                youtube = x.Youtube,

        //            }).FirstOrDefaultAsync()


        //        });



        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new
        //        {
        //            key = 0,
        //            msg = ex.Message
        //        });
        //    }

        //} 
        #endregion

        [AllowAnonymous]
        [HttpPost(ApiRoutes.setting.Condtions)]
        public async Task<IActionResult> CondtionsAsync(string lang = "ar")
        {
            return Ok(await _appClientService.CondtionsAsync(lang));
        }

        [HttpPost(ApiRoutes.setting.AboutUs)]
        [AllowAnonymous]
        public async Task<IActionResult> AboutUsAsync(string lang = "ar")
        {
            return Ok(await _appClientService.AboutUsAsync(lang));
        }


         [HttpPost(ApiRoutes.setting.Privacy)]
        [AllowAnonymous]
        public async Task<IActionResult> PrivacyAsync(string lang = "ar")
        {
            return Ok(await _appClientService.PrivacyAsync(lang));
        }

        //[AllowAnonymous]
        [HttpPost(ApiRoutes.setting.GetSetting)]
        public async Task<ActionResult> GetSettingAsync(string lang = "ar")
        {
            return Ok(await _appClientService.GetSettingAsync(lang));
        }
        [AllowAnonymous]
        [HttpPost(ApiRoutes.setting.Addcomplaints)]
        public async Task<IActionResult> Addcomplaints(ContactUsDto contactUsModel, string lang = "ar")
        {
            return Ok(await _appClientService.Addcomplaints(contactUsModel, lang));
        }

        //[AllowAnonymous]
        [HttpPost(ApiRoutes.setting.GetFinanceAsync)]
        public async Task<IActionResult> GetFinanceAsync( string lang = "ar")
        {
            return Ok(await _appClientService.FinanceAsync(lang));
        }

    }
}
