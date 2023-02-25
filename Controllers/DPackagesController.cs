using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KhadimiEssa.Data;
using KhadimiEssa.Data.TableDb;
using KhadimiEssa.ViewModels;

namespace KhadimiEssa.Controllers
{
    public class DPackagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DPackagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Packages
        public async Task<IActionResult> Index()
        {
            return View(await _context.Packages.ToListAsync());
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PackagesViewModel package)
        {
            if (ModelState.IsValid)
            {
                var PackageToAdd = new Package()
                {
                    NameAr = package.NameAr,
                    NameEn = package.NameEn,
                    DescriptionAr = package.DescriptionAr,
                    DescriptionEn = package.DescriptionEn,
                    Price = package.Price,
                    IsActive = true,
                    Date = DateTime.Now
                };
               
                _context.Add(PackageToAdd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(package);
        }

        // GET: Packages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var package = await _context.Packages.FindAsync(id);
            if (package == null)
            {
                return NotFound();
            }

            var PackageToDisply = new PackagesViewModel()
            {
                Id = package.Id,
                NameAr = package.NameAr,
                NameEn = package.NameEn,
                DescriptionAr = package.DescriptionAr,
                DescriptionEn = package.DescriptionEn,
                Price = package.Price,
            };

            return View(PackageToDisply);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PackagesViewModel package)
        {
            if (id != package.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var PackageToUpdate = new Package()
                    {
                        Id = package.Id,
                        NameAr = package.NameAr,
                        NameEn = package.NameEn,
                        DescriptionAr = package.DescriptionAr,
                        DescriptionEn = package.DescriptionEn,
                        Price = package.Price,
                        IsActive = true,
                        Date = DateTime.Now
                    };
                    _context.Update(PackageToUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PackageExists(package.Id))
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
            return View(package);
        }

        // GET: Packages/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var package = await _context.Packages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (package == null)
            {
                return Json(new { key = 1, data = false });
            }

            package.IsDeleted = true;
            _context.Packages.Update(package);
            _context.SaveChanges();

            return Json(new { key = 1, data = true });
        }




        [HttpPost]
        public async Task<IActionResult> ChangeState(int? id)
        {
            var data = await _context.Packages.FindAsync(id);

            data.IsActive = !data.IsActive;
            await _context.SaveChangesAsync();

            return Json(new { key = 1, data = data.IsActive });
        }

        private bool PackageExists(int id)
        {
            return _context.Packages.Any(e => e.Id == id);
        }
    }
}
