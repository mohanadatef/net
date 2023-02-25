using AAITHelper;
using AAITHelper.Enums;
using AutoMapper.QueryableExtensions;
using KhadimiEssa.AutoMapper;
using KhadimiEssa.Data;
using KhadimiEssa.Data.TableDb;
using KhadimiEssa.Helper;
using KhadimiEssa.Interfaces.App;
using KhadimiEssa.ModelDTO.AboutUsDTO;
using KhadimiEssa.ModelDTO.CondtionsDTO;
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
    [ApiExplorerSettings(GroupName = "DelegetApp")]
    //[Route(""+ ApiRoutes.Base + "[action]")]
    public class DelegetAppController : Controller
    {
        private readonly IAppDelegetService _appDelegetService;
        public DelegetAppController(IAppDelegetService appDelegetService)
        {
            _appDelegetService = appDelegetService;
        }

        [AllowAnonymous]
        [HttpPost(ApiRoutes.setting.CondtionsForDelegt)]
        public async Task<IActionResult> CondtionsAsync(string lang = "ar")
        {
            return Ok(await _appDelegetService.CondtionsAsync(lang));
        }

        [HttpPost(ApiRoutes.setting.AboutUsForDelegt)]
        [AllowAnonymous]
        public async Task<IActionResult> AboutUsAsync(string lang = "ar")
        {
            return Ok(await _appDelegetService.AboutUsAsync(lang));
        }

         [HttpPost(ApiRoutes.setting.PrivacyForDelegt)]
        [AllowAnonymous]
        public async Task<IActionResult> PrivacyAsync(string lang = "ar")
        {
            return Ok(await _appDelegetService.PrivacyAsync(lang));
        }

        [AllowAnonymous]
        [HttpPost(ApiRoutes.setting.GetSettingforDeleget)]
        public async Task<IActionResult> GetSettingAsync(string lang = "ar")
        {
            return Ok(await _appDelegetService.GetSettingAsync(lang));
        }
        [AllowAnonymous]
        [HttpPost(ApiRoutes.setting.AddcomplaintsforDeleget)]
        public async Task<IActionResult> Addcomplaints(ContactUsDto contactUsModel, string lang = "ar")
        {
            return Ok(await _appDelegetService.Addcomplaints(contactUsModel, lang));
        }

    }
}
