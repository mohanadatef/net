using KhadimiEssa.Data;
using KhadimiEssa.Data.TableDb;
using KhadimiEssa.Models.SettingViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static KhadimiEssa.Enums.AllEnums;
using static KhadimiEssa.Helper.HelperMethods;

namespace KhadimiEssa.Controllers
{
    [AuthorizeRoles(Roles.AdminBranch, Roles.Setting)]
    public class DSettingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DSettingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DSettings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Settings.ToListAsync());
        }

        // GET: DSettings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var setting = await _context.Settings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (setting == null)
            {
                return NotFound();
            }

            return View(setting);
        }

        // GET: DSettings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DSettings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Phone,CondtionsArClient,CondtionsEnClient,CondtionsArDelegt,CondtionsEnDelegt,AboutUsArClient,AboutUsEnClient,AboutUsArDelegt,AboutUsEnDelegt,SenderName,UserNameSms,PasswordSms,ApplicationId,SenderId")] Setting setting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(setting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(setting);
        }

        // GET: DSettings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var setting = await _context.Settings.FirstOrDefaultAsync();

            EditSettingViewModel editsetting = new EditSettingViewModel
            {
                Id = setting.Id,
                CondtionsArClient = setting.CondtionsArClient,
                CondtionsEnClient = setting.CondtionsEnClient,
                CondtionsArDelegt = setting.CondtionsArDelegt,
                CondtionsEnDelegt = setting.CondtionsEnDelegt,
                AboutUsArClient = setting.AboutUsArClient,
                AboutUsEnClient = setting.AboutUsEnClient,
                AboutUsArDelegt = setting.AboutUsArDelegt,
                AboutUsEnDelegt = setting.AboutUsEnDelegt,

                PrivacyArClient = setting.AboutUsArClient,
                PrivacyEnClient = setting.AboutUsEnClient,
                PrivacyArDelegt = setting.AboutUsArDelegt,
                PrivacyEnDelegt = setting.AboutUsEnDelegt,

                ApplicationId = setting.ApplicationId,
                SenderName = setting.SenderName,
                PasswordSms = setting.PasswordSms,
                Phone = setting.Phone,
                Email = setting.Email,
                SenderId = setting.SenderId,
                UserNameSms = setting.UserNameSms,

                DepositPrice = setting.DepositPrice,
                InvitationBouns = setting.InvitationBouns,
                RateBouns = setting.RateBouns,
                Tax = setting.Tax,
                IsShowDepositPrice = setting.IsShowDepositPrice,
                //CountOrderForTime = setting.CountOrderForTime,

                Lat = setting.Lat,
                Lng = setting.Lng,
                Location = setting.Location



            };
            if (setting == null)
            {
                return NotFound();
            }
            return View(editsetting);
        }

        // POST: DSettings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditSettingViewModel editSettingViewModel)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Setting setting = await _context.Settings.FindAsync(editSettingViewModel.Id);
                    //setting = new Setting

                    setting.Id = editSettingViewModel.Id;
                    setting.CondtionsArClient = editSettingViewModel.CondtionsArClient;
                    setting.CondtionsEnClient = editSettingViewModel.CondtionsEnClient;
                    setting.CondtionsArDelegt = editSettingViewModel.CondtionsArDelegt;
                    setting.CondtionsEnDelegt = editSettingViewModel.CondtionsEnDelegt;
                    setting.AboutUsArClient = editSettingViewModel.AboutUsArClient;
                    setting.AboutUsEnClient = editSettingViewModel.AboutUsEnClient;
                    setting.AboutUsArDelegt = editSettingViewModel.AboutUsArDelegt;
                    setting.AboutUsEnDelegt = editSettingViewModel.AboutUsEnDelegt;

                    setting.PrivacyArClient = editSettingViewModel.PrivacyArClient;
                    setting.PrivacyEnClient = editSettingViewModel.PrivacyEnClient;
                    setting.PrivacyArDelegt = editSettingViewModel.PrivacyArDelegt;
                    setting.PrivacyEnDelegt = editSettingViewModel.PrivacyEnDelegt;

                    setting.ApplicationId = editSettingViewModel.ApplicationId;
                    setting.SenderName = editSettingViewModel.SenderName;
                    setting.PasswordSms = editSettingViewModel.PasswordSms;
                    setting.Phone = editSettingViewModel.Phone;
                    setting.Email = editSettingViewModel.Email;
                    setting.SenderId = editSettingViewModel.SenderId;
                    setting.UserNameSms = editSettingViewModel.UserNameSms;

                    setting.RateBouns = editSettingViewModel.RateBouns;
                    setting.InvitationBouns = editSettingViewModel.InvitationBouns;
                    setting.DepositPrice = editSettingViewModel.DepositPrice;
                    setting.Tax = editSettingViewModel.Tax;
                    setting.IsShowDepositPrice = editSettingViewModel.IsShowDepositPrice;
                    //setting.CountOrderForTime = editSettingViewModel.CountOrderForTime;

                    setting.Lat = editSettingViewModel.Lat;
                    setting.Lng = editSettingViewModel.Lng;
                    setting.Location = editSettingViewModel.Location;

                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    if (!SettingExists(editSettingViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            return View(editSettingViewModel);
        }

        // GET: DSettings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var setting = await _context.Settings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (setting == null)
            {
                return NotFound();
            }

            return View(setting);
        }

        // POST: DSettings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var setting = await _context.Settings.FindAsync(id);
            _context.Settings.Remove(setting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SettingExists(int id)
        {
            return _context.Settings.Any(e => e.Id == id);
        }
    }
}
