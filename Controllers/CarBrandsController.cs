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
    public class CarBrandsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarBrandsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CarBrands
        public async Task<IActionResult> Index()
        {
            return View(await _context.CarBrands.ToListAsync());
        }


        // GET: CarBrands/Create
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( CarBrand carBrand)
        {
            if (ModelState.IsValid)
            {
                carBrand.IsActive = true;
                carBrand.Date = AAITHelper.HelperDate.GetCurrentDate();

                _context.Add(carBrand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carBrand);
        }

        // GET: CarBrands/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carBrand = await _context.CarBrands.FindAsync(id);
            if (carBrand == null)
            {
                return NotFound();
            }
            return View(carBrand);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,CarBrand carBrand)
        {
            if (id != carBrand.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carBrand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarBrandExists(carBrand.Id))
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
            return View(carBrand);
        }

        // GET: CarBrands/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var CarBrand = await _context.CarBrands
                .FirstOrDefaultAsync(m => m.Id == id);
            if (CarBrand == null)
            {
                return Json(new { key = 1, data = false });
            }

            CarBrand.IsDeleted = true;
            _context.CarBrands.Update(CarBrand);
            _context.SaveChanges();

            return Json(new { key = 1, data = true });
        }



        [HttpPost]
        public async Task<IActionResult> ChangeState(int? id)
        {
            var data = await _context.CarBrands.FindAsync(id);

            data.IsActive = !data.IsActive;
            await _context.SaveChangesAsync();

            return Json(new { key = 1, data = data.IsActive });
        }


        private bool CarBrandExists(int id)
        {
            return _context.CarBrands.Any(e => e.Id == id);
        }
    }
}
