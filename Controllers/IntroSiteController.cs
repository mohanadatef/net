using KhadimiEssa.Data;
using KhadimiEssa.Data.TableDb.IntroductorySite;
using KhadimiEssa.Models.IntroSiteModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static KhadimiEssa.Enums.AllEnums;

namespace KhadimiEssa.Controllers
{
    public class IntroSiteController : Controller
    {

        private readonly ApplicationDbContext _context;
        public IntroSiteController(ApplicationDbContext context)
        {
            _context = context;
        }

        static string BaseUrl = "images/IntroSite/";

        public IActionResult Index()
        {
            string lang = "ar";

            IntroSettingViewModel IntroSetting = _context.IntroSettings.Select(x => new IntroSettingViewModel
            {
                LogoImg = BaseUrl + x.LogoImg,
                Intro = lang == "ar" ? x.IntroAr : x.IntroAr,
                Description = lang == "ar" ? x.DescriptionAr : x.DescriptionEn,
                Img = BaseUrl + x.Img,
                GooglePlayUrl = x.GooglePlayUrl,
                AppleStoreUrl = x.AppleStoreUrl,
                IntroImg1 = BaseUrl + x.IntroImg1,
                IntroImg2 = BaseUrl + x.IntroImg2,
                AboutApp = lang == "ar" ? x.AboutAppAr : x.AboutAppEn,
                AboutDescrioption = lang == "ar" ? x.AboutDescrioptionAr : x.AboutDescrioptionEn,
                AboutAppImg = BaseUrl + x.AboutAppImg,
                VideoUrl = x.VideoUrl,
                FooterDescription = lang == "ar" ? x.FooterDescriptionAr : x.FooterDescriptionEn,
                Address = x.Address,
                Phone = x.Phone,
                Email = x.Email,
                FaceBook = x.FaceBook,
                Twitter = x.Twitter,
                Instagram = x.Instagram,
                Gmail = x.Gmail,
            }).FirstOrDefault();

            List<string> Sliders = _context.AppImgs.Where(x => x.IsActive).Select(x => BaseUrl + x.Img).ToList();

            List<AdventagesViewModel> Adventages = _context.Advantages.Select(a => new AdventagesViewModel
            {
                Img = BaseUrl + a.Img,
                Title = lang == "ar" ? a.TitleAr : a.TitleEn,
                Description = lang == "ar" ? a.DescriptionAr : a.DescriptionEn,
            }).ToList();

            List<CustomerOpinionViewModel> CustomerOpinions = _context.CustomerOpinions.Where(o => o.IsActive).Select(o => new CustomerOpinionViewModel
            {
                Img = BaseUrl + o.Img,
                Name = lang == "ar" ? o.NameAr : o.NameEn,
                Description = lang == "ar" ? o.DescriptionAr : o.DescriptionEn,
                Rate = o.Rate
            }).ToList();

            IntroSiteHomeViewModel model = new IntroSiteHomeViewModel();

            model.IntroSetting = IntroSetting;
            model.Adventages = Adventages;
            model.customerOpinions = CustomerOpinions;
            model.Slider = Sliders;

            return View(model);
        }


        public IActionResult Policy()
        {
            string lang = "ar";
            string Policy = _context.IntroSettings.Select(x => lang == "ar" ? x.PrivacyPolicyAr : x.PrivacyPolicyEn).FirstOrDefault();
            ViewBag.Policy = Policy;
            return View();
        }

        public IActionResult Conditions()
        {
            string lang = "ar";
            string Condition = _context.IntroSettings.Select(x => lang == "ar" ? x.TermsOfUsersAr : x.TermsOfUsersEn).FirstOrDefault();
            ViewBag.Condition = Condition;
            return View();

        }

        public IActionResult SendMessage(SendMessageViewModel model)
        {
            IntroContactUs contactUs = new IntroContactUs
            {
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                Message = model.Msg,
            };

            _context.IntroContactUs.Add(contactUs);
            _context.SaveChanges();

            return View();
        }

    }
}
