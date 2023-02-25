using KhadimiEssa.Data;
using KhadimiEssa.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Controllers
{
    public class SmsSettingsController : Controller
    {

        private readonly ApplicationDbContext db;

        public SmsSettingsController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var setting = db.Settings.FirstOrDefault();

            SmsSettingModel model = new SmsSettingModel()
            {
                SmsProvider = setting.SmsProvider,
                PasswordSms = setting.PasswordSms,
                SenderName = setting.SenderName,
                UserNameSms = setting.UserNameSms
            };


            ViewBag.SmsProvider = setting.SmsProvider;

            return View(model);
        }

        [HttpPost]
        public IActionResult EditSmsSetting([Bind("SmsProvider,SenderName,UserNameSms,PasswordSms,NumberSms")] SmsSettingModel model)
        {
            if (ModelState.IsValid)
            {
                var setting = db.Settings.FirstOrDefault();

                setting.SmsProvider = model.SmsProvider;

                setting.PasswordSms = model.PasswordSms;
                setting.UserNameSms = model.UserNameSms;
                setting.SenderName = model.SenderName;

                db.SaveChanges();
                return Redirect("/Home");
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
