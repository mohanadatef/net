using AAITHelper.Enums;
using KhadimiEssa.Data;
using KhadimiEssa.Enums;
using KhadimiEssa.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using static KhadimiEssa.Enums.AllEnums;

namespace KhadimiEssa.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string date_from = null, string date_to = null, int time = 0)
        {
            DateTime dateFrom = string.IsNullOrEmpty(date_from) ? DateTime.Now : DateTime.ParseExact(date_from, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime dateTo = string.IsNullOrEmpty(date_to) ? DateTime.Now : DateTime.ParseExact(date_to, "yyyy-MM-dd", CultureInfo.InvariantCulture).AddDays(1).AddTicks(-1);
            ViewData["Times"] = new SelectList(_context.AvailableTimes.Where(s => s.IsActive).Select(a => new { Id = a.Id, time = a.time.ToString("hh:mm tt") }), "Id", "time");

            var orders = _context.Orders.Where(x => (!string.IsNullOrEmpty(date_from) ? (x.OrderDate >= dateFrom) : true)
                                                 && (!string.IsNullOrEmpty(date_to) ? (x.OrderDate <= dateTo) : true)
                                                 && (time != 0 ? x.ExecutionTime == time : true))
                .Include(o => o.User)
                .Include(o => o.Provider)
                .Include(o => o.CarBrand)
                .Include(o => o.Availabletime)
                .Include(o => o.OilStation)
                .Include(o=>o.Copon)
                .OrderByDescending(x => x.Id).ToList();

            return View(orders);
        }

        public IActionResult Details(int id)
        {

            var order = _context.Orders.Where(x => x.Id == id)
                .Include(o => o.User)
                .Include(o => o.Provider)
                .Include(o => o.CarBrand)
                .Include(o => o.Availabletime)
                .Include(o => o.Package)
                .OrderByDescending(x => x.Id).FirstOrDefault();

            return View(order);
        }



        [HttpPost]
        public async Task<IActionResult> ChangeState(int? id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order.Status == (int)AllEnums.orderstutes.Neworder)
            {
                order.Status = (int)AllEnums.orderstutes.Refusedorder;
                await _context.SaveChangesAsync();
                await HelperMethods.SendNotifyAsync(_context, "تم رفض الطلب رقم" + order.Id, "Request No. has been refused" + order.Id, order.UserId, orderstutes.CurrentOrder.ToNumber(), order.Id);

                return Json(new { key = 1, data = "تم رفض الطلب" });

            }
            return Json(new { key = 0, data = "لايمكن رفض هذا الطلب" });
        }

    }
}
