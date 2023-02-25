using KhadimiEssa.Data;
using KhadimiEssa.Data.TableDb;
using KhadimiEssa.Helper;
using KhadimiEssa.Models.AdvertisementViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static KhadimiEssa.Enums.AllEnums;
using static KhadimiEssa.Helper.HelperMethods;

namespace KhadimiEssa.Controllers
{
    [AuthorizeRoles(Roles.AdminBranch, Roles.Advertisment)]
    public class DProductAController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment HostingEnvironment;

        public DProductAController(ApplicationDbContext context, IWebHostEnvironment HostingEnvironment)
        {
            _context = context;
            this.HostingEnvironment = HostingEnvironment;
        }

        // GET: DProductA
        public async Task<IActionResult> Index()
        {
            return View(await _context.Advertisments.ToListAsync());
        }

        // GET: DProductA/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertisment = await _context.Advertisments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (advertisment == null)
            {
                return NotFound();
            }

            return View(advertisment);
        }

        // GET: DProductA/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DProductA/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddAdvertisementViewModel advertisement)
        {
            if (ModelState.IsValid)
            {

                string uniqueFileName = null;
                if (advertisement.Img != null)
                {
                    string uploadFolder = Path.Combine(HostingEnvironment.WebRootPath, "images\\ProductA");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + advertisement.Img.FileName;
                    string filePath = Path.Combine(uploadFolder, uniqueFileName);

                    await advertisement.Img.CopyToAsync(new FileStream(filePath, FileMode.Create));
                }


                advertisement.IsActive = true;

                Advertisment newadvertisement = new Advertisment
                {
                    TitleAr = advertisement.TitleAr,
                    TitleEn = advertisement.TitleEn,
                    Img = HelperMethods.BaisUrlAdvertisment + uniqueFileName,
                    IsActive = advertisement.IsActive
                };
                _context.Add(newadvertisement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(advertisement);
        }

        // GET: DProductA/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertisment = await _context.Advertisments.FindAsync(id);
            if (advertisment == null)
            {
                return NotFound();
            }

            EditAdvertisementViewModel editAdvertisementViewModel = new EditAdvertisementViewModel
            {
                Id = advertisment.Id,
                TitleAr = advertisment.TitleAr,
                TitleEn = advertisment.TitleEn,
                Img = advertisment.Img,
                IsActive = advertisment.IsActive
            };


            return View(editAdvertisementViewModel);
        }

        // POST: DProductA/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditAdvertisementViewModel editAdvertisementViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var current = await _context.Advertisments.FirstOrDefaultAsync(a => a.Id == editAdvertisementViewModel.Id);

                    string uniqueFileName = null;
                    if (editAdvertisementViewModel.ImgFormFile != null)
                    {
                        string uploadFolder = Path.Combine(HostingEnvironment.WebRootPath, "images\\ProductA");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + editAdvertisementViewModel.ImgFormFile.FileName;
                        string filePath = Path.Combine(uploadFolder, uniqueFileName);

                        await editAdvertisementViewModel.ImgFormFile.CopyToAsync(new FileStream(filePath, FileMode.Create));
                    }


                    current.Id = editAdvertisementViewModel.Id;

                    if (uniqueFileName != null)
                        current.Img = HelperMethods.BaisUrlAdvertisment + uniqueFileName;
                    else
                        current.Img = current.Img;

                    current.TitleAr = editAdvertisementViewModel.TitleAr;
                    current.TitleEn = editAdvertisementViewModel.TitleEn;
                    current.IsActive = editAdvertisementViewModel.IsActive;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdvertismentExists(editAdvertisementViewModel.Id))
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
            return View(editAdvertisementViewModel);
        }

        // GET: DProductA/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertisment = await _context.Advertisments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (advertisment == null)
            {
                return NotFound();
            }

            return View(advertisment);
        }

        // POST: DProductA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var advertisment = await _context.Advertisments.FindAsync(id);
            _context.Advertisments.Remove(advertisment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdvertismentExists(int id)
        {
            return _context.Advertisments.Any(e => e.Id == id);
        }





        [HttpPost]
        public async Task<IActionResult> ChangeState(int? id)
        {
            var category = await _context.Advertisments.FindAsync(id);

            category.IsActive = !category.IsActive;
            await _context.SaveChangesAsync();

            return Json(new { key = 1, data = category.IsActive });
        }


    }
}
