using AAITHelper;
using AAITHelper.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KhadimiEssa.Data;
using KhadimiEssa.Data.TableDb;
using KhadimiEssa.Helper;
using KhadimiEssa.Interfaces.Auth;
using KhadimiEssa.Models.AuthModel;
using KhadimiEssa.Response.ResponseModel;
using KhadimiEssa.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using static KhadimiEssa.Enums.AllEnums;

namespace KhadimiEssa.Controllers
{
    public class ProviderController : Controller
    {

        private readonly UserManager<ApplicationDbUser> _userManager;
        private readonly ApplicationDbContext db;
        private readonly IAccountService _accountService;
        private readonly IUploadImage _uploadImage;

        public ProviderController(ApplicationDbContext _db, UserManager<ApplicationDbUser> userManager, IAccountService accountService, IUploadImage uploadImage)
        {
            db = _db;
            _userManager = userManager;
            _accountService = accountService;
            _uploadImage = uploadImage;
        }
        public IActionResult Index()
        {
            List<ProviderViewModel> user = db.Users.Where(x => x.TypeUser == (int)User_Type.deleget).Select(x => new ProviderViewModel
            {
                Id = x.Id,
                Name = x.user_Name,
                IsActive = x.IsActive,
                PhoneNumber = x.PhoneNumber,
                Img = x.ImgProfile,
                OilStation = x.OilStation.NameAr,
                date = x.PublishDate
            }).OrderByDescending(x=>x.date).ToList();
            return View(user);
        }

        public IActionResult CreateProvider()
        {
            ViewData["OilStationId"] = new SelectList(db.OilStations.Where(s => s.IsActive), "Id", "NameAr");

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProvider(RegisterDelegetViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    #region ValidateEmailAndPhone
                    string englishPhoneNumber = HelperNumber.ConvertArabicNumberToEnglish(model.phone);
                    if (!englishPhoneNumber.StartsWith("0"))
                    {
                        ModelState.AddModelError("phone", "رقم الجوال يجب ان يبدأ بـ 0 ");
                        ViewData["OilStationId"] = new SelectList(db.OilStations.Where(s => s.IsActive), "Id", "NameAr");

                        return View(model);
                    }
                    bool userWithSamePhoneNumber = await CheckValidatePhoneAsync(englishPhoneNumber);
                    if (userWithSamePhoneNumber)
                    {
                        ModelState.AddModelError("phone", "رقم الجوال مسجل من قبل");
                        ViewData["OilStationId"] = new SelectList(db.OilStations.Where(s => s.IsActive), "Id", "NameAr");

                        return View(model);
                    }

                    if (model.oilStationId == 0)
                    {
                        ModelState.AddModelError("oilStationId", "من فضلك اختر المحطة");
                        ViewData["OilStationId"] = new SelectList(db.OilStations.Where(s => s.IsActive), "Id", "NameAr");

                        return View(model);
                    }
                    //Task<bool> userWithSameEmail = CheckValidateEmailAsync(englishPhoneNumber);
                    //if (userWithSameEmail.Result)
                    //{
                    //    return new Response<ResponseDelegetInfo>(HelperMsg.MsgValidation(EnumValidMsg.Auth.EmailExisting.ToNumber(), userModel.lang));

                    //}
                    #endregion
                    Task<int> code = GenerateCode(1234);
                    #region AddUser
                    var user = new ApplicationDbUser
                    {
                        Email = "",
                        UserName = englishPhoneNumber + HelperNumber.GetRandomNumber() + "@yahoo.com",
                        user_Name = model.userName,

                        ShowPassword = model.password,
                        ImgProfile = model.Img != null ? _uploadImage.Upload(model.Img, (int)FileName.Users) : HelperMethods.BaisUrlHoste + "/images/Users/generic-user.png",
                        IsActive = true,
                        ActiveCode = true,
                        CloseNotify = false,
                        PublishDate = HelperDate.GetCurrentDate(),
                        Code = code.Result,
                        PhoneNumber = englishPhoneNumber,
                        TypeUser = (int)User_Type.deleget,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        OilStationId = model.oilStationId,
                        Lang = model.lang
                    };
                    var result = await _userManager.CreateAsync(user, model.password);
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, "Mobile");
                    }
                    #endregion

                }
                catch (Exception ex)
                {
                    MethodBase m = MethodBase.GetCurrentMethod();
                    LogExption logExption = new LogExption()
                    {
                        Date = DateTime.Now,
                        Exption = ex.Message,
                        ServiceName = m.Name,
                        UserId = ""
                    };
                    await db.LogExption.AddAsync(logExption);
                    await db.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["OilStationId"] = new SelectList(db.OilStations.Where(s => s.IsActive), "Id", "NameAr");

            return View(model);
        }



        public IActionResult EditProvider(string id)
        {
            var provider = db.Users.Where(u => u.Id == id).Select(u => new EditDelegetViewModel
            {
                Id = u.Id,
                userName = u.user_Name,
                Img = u.ImgProfile,
                phone = u.PhoneNumber,
                oilStationId = u.OilStationId

            }).FirstOrDefault();
            ViewData["OilStationId"] = new SelectList(db.OilStations.Where(s => s.IsActive), "Id", "NameAr", provider.oilStationId);

            return View(provider);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProvider(EditDelegetViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    #region ValidateEmailAndPhone
                    string englishPhoneNumber = HelperNumber.ConvertArabicNumberToEnglish(model.phone);
                    Task<bool> userWithSamePhoneNumber = CheckValidatePhoneCurrAsync(englishPhoneNumber, model.Id);
                    if (userWithSamePhoneNumber.Result)
                    {
                        ModelState.AddModelError("phone", "رقم الجوال مسجل من قبل");
                        ViewData["OilStationId"] = new SelectList(db.OilStations.Where(s => s.IsActive), "Id", "NameAr", model.oilStationId);

                        return View(model);
                    }


                    if (model.oilStationId == 0)
                    {
                        ModelState.AddModelError("oilStationId", "من فضلك اختر المحطة");
                        ViewData["OilStationId"] = new SelectList(db.OilStations.Where(s => s.IsActive), "Id", "NameAr", model.oilStationId);

                        return View(model);
                    }

                    //Task<bool> userWithSameEmail = CheckValidateEmailAsync(englishPhoneNumber);
                    //if (userWithSameEmail.Result)
                    //{
                    //    return new Response<ResponseDelegetInfo>(HelperMsg.MsgValidation(EnumValidMsg.Auth.EmailExisting.ToNumber(), userModel.lang));

                    //}
                    #endregion
                    //Task<int> code = GenerateCode(1234);
                    #region edit user


                    var user = db.Users.Where(u => u.Id == model.Id).FirstOrDefault();

                    user.ImgProfile = (model.ImgFormFile != null ? (_uploadImage.Upload(model.ImgFormFile, (int)FileName.Users)) : user.ImgProfile);
                    user.user_Name = model.userName;
                    user.PhoneNumber = model.phone;
                    user.OilStationId = model.oilStationId;

                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                    #endregion

                }
                catch (Exception ex)
                {
                    MethodBase m = MethodBase.GetCurrentMethod();
                    LogExption logExption = new LogExption()
                    {
                        Date = DateTime.Now,
                        Exption = ex.Message,
                        ServiceName = m.Name,
                        UserId = ""
                    };
                    await db.LogExption.AddAsync(logExption);
                    await db.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["OilStationId"] = new SelectList(db.OilStations.Where(s => s.IsActive), "Id", "NameAr", model.oilStationId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Provider = await db.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Provider == null)
            {
                return Json(new { key = 1, data = false });
            }

            var userDevicesId = db.DeviceIds.Where(d => d.FkUser == Provider.Id);
            db.DeviceIds.RemoveRange(userDevicesId);

            Provider.IsDeleted = true;
            db.Users.Update(Provider);
            db.SaveChanges();

            return Json(new { key = 1, data = true });
        }




        public async Task<IActionResult> ChangeState(string id)
        {


            var user = db.Users.Find(id);
            if (user.IsActive == true)
            {
                user.IsActive = false;

                //send notification
                await HelperMethods.SendNotifyAsync(db, "تم حظرك من قبل الادمن", "You are Blocked from Admin", id, (int)NotifyTypes.BlockUser);

                var devices = await db.DeviceIds.Where(x => x.FkUser == user.Id).ToListAsync();
                db.DeviceIds.RemoveRange(devices);
            }
            else
            {
                user.IsActive = true;
            }
            await db.SaveChangesAsync();
            return Ok(new { key = 1, data = user.IsActive });

        }



        #region Helper
        private async Task<bool> CheckValidatePhoneAsync(string phone)
        {
            var checkPhone = (await db.Users.FirstOrDefaultAsync(x => x.PhoneNumber == phone));
            return checkPhone != null;
        }


        private async Task<bool> CheckValidatePhoneCurrAsync(string phone, string id)
        {
            var checkPhone = (await db.Users.FirstOrDefaultAsync(x => x.PhoneNumber == phone && x.Id != id));
            return checkPhone != null;
        }

        private async Task<bool> CheckValidateEmailAsync(string email)
        {
            var checkemail = (await db.Users.FirstOrDefaultAsync(x => x.Email == email));
            return checkemail != null;
        }
        private async Task<int> GenerateCode(int currentCode)
        {
            int code = HelperNumber.GetRandomNumber(currentCode);
            var GetInfoSms = await db.Settings.FirstOrDefaultAsync();
            if (GetInfoSms != null)
            {
                if (GetInfoSms.SenderName != "test")
                {
                    code = HelperNumber.GetRandomNumber();
                }
            }
            return code;
        }
        #endregion

    }
}
