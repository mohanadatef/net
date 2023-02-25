using KhadimiEssa.Data;
using KhadimiEssa.Data.TableDb;
using KhadimiEssa.Data.TableDb.IntroductorySite;
using KhadimiEssa.Helper;
using KhadimiEssa.Models.CustomerOpinionsViewModel;
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
    public class IntroCustomerOpinionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUploadImage _uploadImage;

        public IntroCustomerOpinionsController(ApplicationDbContext context, IUploadImage uploadImage)
        {
            _context = context;
            _uploadImage = uploadImage;
        }

        // GET: IntroCustomerOpinions
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomerOpinions.ToListAsync());
        }

        // GET: IntroCustomerOpinions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerOpinion = await _context.CustomerOpinions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerOpinion == null)
            {
                return NotFound();
            }

            return View(customerOpinion);
        }

        // GET: IntroCustomerOpinions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IntroCustomerOpinions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddCustomerOpinionsViewModel addCustomerOpinionsViewModel)
        {
            if (ModelState.IsValid)
            {



                //advertisement.IsActive = true;

                CustomerOpinion customerOpinion = new CustomerOpinion
                {
                    NameAr = addCustomerOpinionsViewModel.NameAr,
                    NameEn = addCustomerOpinionsViewModel.NameEn,
                    DescriptionAr = addCustomerOpinionsViewModel.DescriptionAr,
                    DescriptionEn = addCustomerOpinionsViewModel.DescriptionEn,
                    Rate = addCustomerOpinionsViewModel.Rate,
                    Img = _uploadImage.Upload(addCustomerOpinionsViewModel.Img, (int)FileName.IntroSite),
                    IsActive = true
                };

                _context.Add(customerOpinion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(addCustomerOpinionsViewModel);
        }

        // GET: IntroCustomerOpinions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerOpinion = await _context.CustomerOpinions.FindAsync(id);
            if (customerOpinion == null)
            {
                return NotFound();
            }
            return View(customerOpinion);
        }

        // POST: IntroCustomerOpinions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Img,NameAr,NameEn,DescriptionAr,DescriptionEn,Rate,IsActive")] CustomerOpinion customerOpinion)
        {
            if (id != customerOpinion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerOpinion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerOpinionExists(customerOpinion.Id))
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
            return View(customerOpinion);
        }

        // GET: IntroCustomerOpinions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerOpinion = await _context.CustomerOpinions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerOpinion == null)
            {
                return NotFound();
            }

            return View(customerOpinion);
        }

        // POST: IntroCustomerOpinions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customerOpinion = await _context.CustomerOpinions.FindAsync(id);
            _context.CustomerOpinions.Remove(customerOpinion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerOpinionExists(int id)
        {
            return _context.CustomerOpinions.Any(e => e.Id == id);
        }


        [HttpPost]
        public async Task<IActionResult> ChangeState(int? id)
        {
            var customerOpinion = await _context.CustomerOpinions.FindAsync(id);

            customerOpinion.IsActive = !customerOpinion.IsActive;
            await _context.SaveChangesAsync();

            return Json(new { key = 1, data = customerOpinion.IsActive });
        }
    }
}
