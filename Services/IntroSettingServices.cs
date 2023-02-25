using KhadimiEssa.Data;
using KhadimiEssa.Models.IntroSiteModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Services
{
    public interface IIntroSettingServices
    {
        Task<LayoutIntroSiteViewModel> GetSetting(string lang);
    }

    public class IntroSettingServices : IIntroSettingServices
    {
        private readonly ApplicationDbContext _context;
        public IntroSettingServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<LayoutIntroSiteViewModel> GetSetting(string lang = "ar")
        {
            LayoutIntroSiteViewModel model = await _context.IntroSettings.Select(x => new LayoutIntroSiteViewModel
            {
                Intro = lang == "ar" ? x.IntroAr : x.IntroEn,
                Description = lang == "ar" ? x.DescriptionAr : x.DescriptionEn,
                FooterDescription = lang == "ar" ? x.FooterDescriptionAr : x.FooterDescriptionEn,
                IntroImg1 = x.IntroImg1,
                IntroImg2 = x.IntroImg2,
                Address = x.Address,
                Email = x.Email,
                FaceBook = x.FaceBook,
                Gmail = x.Gmail,
                Instagram = x.Instagram,
                Logo = x.LogoImg,
                Phone = x.Phone,
                Twitter = x.Twitter,
                GooglePlayUrl = x.GooglePlayUrl,
                AppleStoreUrl = x.AppleStoreUrl
            }).FirstOrDefaultAsync();

            return model;
        }
    }

}
