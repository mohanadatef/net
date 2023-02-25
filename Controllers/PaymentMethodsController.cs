using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KhadimiEssa.Data;
using KhadimiEssa.Data.TableDb;

namespace KhadimiEssa.Controllers
{
    public class PaymentMethodsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaymentMethodsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PaymentMethods
        public async Task<IActionResult> Index()
        {
            return View(await _context.paymentMethods.ToListAsync());
        }
       
        // GET: PaymentMethods/Create
        public IActionResult Create()
        {
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PaymentMethod paymentMethod)
        {
            if (ModelState.IsValid)
            {
                paymentMethod.IsActive = true;
                _context.Add(paymentMethod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paymentMethod);
        }

        // GET: PaymentMethods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentMethod = await _context.paymentMethods.FindAsync(id);
            if (paymentMethod == null)
            {
                return NotFound();
            }
            return View(paymentMethod);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,PaymentMethod paymentMethod)
        {
            if (id != paymentMethod.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paymentMethod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentMethodExists(paymentMethod.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(paymentMethod);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentMethod = await _context.paymentMethods
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paymentMethod == null)
            {
                return Json(new { key = 1, data = false });
            }

            paymentMethod.IsDeleted = true;
            _context.paymentMethods.Update(paymentMethod);
            _context.SaveChanges();

            return Json(new { key = 1, data = true });
        }

        [HttpPost]
        public async Task<IActionResult> ChangeState(int? id)
        {

            var data = _context.paymentMethods.Find(id);
            if (data.IsActive == true)
            {
                data.IsActive = false;

            }
            else
            {
                data.IsActive = true;
            }
            await _context.SaveChangesAsync();
            return Ok(new { key = 1, data = data.IsActive });

        }


        private bool PaymentMethodExists(int id)
        {
            return _context.paymentMethods.Any(e => e.Id == id);
        }
    }
}
