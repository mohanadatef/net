using KhadimiEssa.Data;
using KhadimiEssa.Data.TableDb.IntroductorySite;
using KhadimiEssa.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static KhadimiEssa.Enums.AllEnums;

namespace KhadimiEssa.Controllers
{
    public class IntroSettingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUploadImage _uploadImage;

        public IntroSettingsController(ApplicationDbContext context, IUploadImage uploadImage)
        {
            _context = context;
            _uploadImage = uploadImage;
        }

        // GET: IntroSettings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var introSetting = await _context.IntroSettings.FindAsync(id);
            if (introSetting == null)
            {
                return NotFound();
            }
            return View(introSetting);
        }

        public class IntroSettingImgageDTO
        {
            public IFormFile LogoImgFormFile { get; set; }
            public IFormFile IntroImg1FormFile { get; set; }
            public IFormFile IntroImg2FormFile { get; set; }
            public IFormFile AboutAppImgFormFile { get; set; }
            public IFormFile VideoUrlFormFile { get; set; }
        }
        // POST: IntroSettings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IntroSetting introSetting, IntroSettingImgageDTO introSettingImgageDTO)
        {
            if (id != introSetting.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                IntroSetting oldIntroSetting = _context.IntroSettings.SingleOrDefault(m => m.Id == id);


                oldIntroSetting.LogoImg = introSettingImgageDTO.LogoImgFormFile != null ? _uploadImage.Upload(introSettingImgageDTO.LogoImgFormFile, (int)FileName.IntroSite) : oldIntroSetting.LogoImg;
                oldIntroSetting.IntroImg1 = introSettingImgageDTO.IntroImg1FormFile != null ? _uploadImage.Upload(introSettingImgageDTO.IntroImg1FormFile, (int)FileName.IntroSite) : oldIntroSetting.IntroImg1;
                oldIntroSetting.IntroImg2 = introSettingImgageDTO.IntroImg2FormFile != null ? _uploadImage.Upload(introSettingImgageDTO.IntroImg2FormFile, (int)FileName.IntroSite) : oldIntroSetting.IntroImg2;
                oldIntroSetting.AboutAppImg = introSettingImgageDTO.AboutAppImgFormFile != null ? _uploadImage.Upload(introSettingImgageDTO.AboutAppImgFormFile, (int)FileName.IntroSite) : oldIntroSetting.AboutAppImg;
                oldIntroSetting.VideoUrl = introSettingImgageDTO.VideoUrlFormFile != null ? _uploadImage.Upload(introSettingImgageDTO.VideoUrlFormFile, (int)FileName.IntroSite) : oldIntroSetting.VideoUrl;

                oldIntroSetting.Id = introSetting.Id;

                oldIntroSetting.IntroAr = introSetting.IntroAr;
                oldIntroSetting.IntroEn = introSetting.IntroEn;
                oldIntroSetting.DescriptionAr = introSetting.DescriptionAr;
                oldIntroSetting.DescriptionEn = introSetting.DescriptionEn;

                oldIntroSetting.GooglePlayUrl = introSetting.GooglePlayUrl;
                oldIntroSetting.AppleStoreUrl = introSetting.AppleStoreUrl;

                oldIntroSetting.AboutDescrioptionAr = introSetting.AboutDescrioptionAr;
                oldIntroSetting.AboutDescrioptionEn = introSetting.AboutDescrioptionEn;
                oldIntroSetting.FooterDescriptionAr = introSetting.FooterDescriptionAr;
                oldIntroSetting.FooterDescriptionEn = introSetting.FooterDescriptionEn;

                oldIntroSetting.Address = introSetting.Address;
                oldIntroSetting.Phone = introSetting.Phone;
                oldIntroSetting.Email = introSetting.Email;
                oldIntroSetting.FaceBook = introSetting.FaceBook;
                oldIntroSetting.Twitter = introSetting.Twitter;
                oldIntroSetting.Instagram = introSetting.Instagram;
                oldIntroSetting.Gmail = introSetting.Gmail;


                try
                {
                    _context.Update(oldIntroSetting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IntroSettingExists(introSetting.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("index", "Home");
            }
            return View(introSetting);
        }
        private bool IntroSettingExists(int id)
        {
            return _context.IntroSettings.Any(e => e.Id == id);
        }
    }
}
