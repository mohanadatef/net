using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KhadimiEssa.Data;
using KhadimiEssa.Enums;
using KhadimiEssa.Helper;
using static KhadimiEssa.Enums.AllEnums;
using Microsoft.EntityFrameworkCore;

namespace Mudhhil.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var clients = _context.Users.Where(u => u.TypeUser == (int)AllEnums.User_Type.Client).OrderByDescending(x=>x.PublishDate).ToList();
            return View(clients);
        }


        public IActionResult Invitions(string userId)
        {
            var clients = _context.UserInvitations.Where(u => u.UserId == userId).ToList();
            return View(clients);
        }

        public async Task<IActionResult> ChangeState(string id)
        {
            try
            {
                var client = await _context.Users.FindAsync(id);
                if (client.IsActive == true)
                {
                    client.IsActive = false;

                    await HelperMethods.SendNotifyAsync(_context, "تم حظرك من قبل الادمن", "You are Blocked from Admin", id, (int)NotifyTypes.BlockUser);

                    var devices = await _context.DeviceIds.Where(x => x.FkUser == client.Id).ToListAsync();
                    _context.DeviceIds.RemoveRange(devices);
                }
                else
                {
                    client.IsActive = true;
                }

                await _context.SaveChangesAsync();
                return Json(new { key = 1, data = client.IsActive });
            }
            catch (Exception ex)
            {
                return Json(new { key = 0, msg = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return Json(new { key = 1, data = false });
            }

            var userDevicesId = _context.DeviceIds.Where(d=>d.FkUser == user.Id);
            _context.DeviceIds.RemoveRange(userDevicesId);

            user.IsDeleted = true;
            _context.Users.Update(user);
            _context.SaveChanges();

            return Json(new { key = 1, data = true });
        }
    }
}
