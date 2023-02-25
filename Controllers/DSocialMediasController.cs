using KhadimiEssa.Data;
using KhadimiEssa.Data.TableDb;
using KhadimiEssa.Helper;
using KhadimiEssa.Models.SocialMediaViewModel;
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

    [AuthorizeRoles(Roles.AdminBranch, Roles.SocialMedia)]
    public class DSocialMediasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUploadImage _uploadImage;

        public DSocialMediasController(ApplicationDbContext context, IUploadImage uploadImage)
        {
            _context = context;
            _uploadImage = uploadImage;
        }
        // GET: DSocialMedias
        public async Task<IActionResult> Index()
        {
            return View(await _context.SocialMedias.ToListAsync());
        }

        // GET: DSocialMedias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialMedia = await _context.SocialMedias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (socialMedia == null)
            {
                return NotFound();
            }

            return View(socialMedia);
        }

        // GET: DSocialMedias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DSocialMedias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddSocialMediaViewModel socialMedia)
        {
            socialMedia.IsActive = true;
            SocialMedia newadvertisement = new SocialMedia
            {
                Name = socialMedia.Name,
                Url = socialMedia.Url,
                Img = socialMedia.Img != null ? _uploadImage.Upload(socialMedia.Img, (int)FileName.SocialMedia) : "",
                IsActive = socialMedia.IsActive
            };
            _context.Add(newadvertisement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: DSocialMedias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialMedia = await _context.SocialMedias.FindAsync(id);
            if (socialMedia == null)
            {
                return NotFound();
            }

            EditSocialMediaViewModel editSocialMediaViewModel = new EditSocialMediaViewModel
            {
                Id = socialMedia.Id,
                Name = socialMedia.Name,
                Url = socialMedia.Url,
                Img = socialMedia.Img,
                IsActive = socialMedia.IsActive
            };


            return View(editSocialMediaViewModel);
        }

        // POST: DSocialMedias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditSocialMediaViewModel editSocialMediaViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var current = await _context.SocialMedias.FirstOrDefaultAsync(a => a.Id == editSocialMediaViewModel.Id);

                    current.Id = editSocialMediaViewModel.Id;
                    current.Img = editSocialMediaViewModel.ImgFormFile != null ? _uploadImage.Upload(editSocialMediaViewModel.ImgFormFile, (int)FileName.SocialMedia) : current.Img;
                    current.Name = editSocialMediaViewModel.Name;
                    current.Url = editSocialMediaViewModel.Url;
                    current.IsActive = editSocialMediaViewModel.IsActive;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SocialMediaExists(editSocialMediaViewModel.Id))
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
            return View(editSocialMediaViewModel);
        }

        // GET: DSocialMedias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialMedia = await _context.SocialMedias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (socialMedia == null)
            {
                return NotFound();
            }

            return View(socialMedia);
        }

        // POST: DSocialMedias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var socialMedia = await _context.SocialMedias.FindAsync(id);
            _context.SocialMedias.Remove(socialMedia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SocialMediaExists(int id)
        {
            return _context.SocialMedias.Any(e => e.Id == id);
        }




        [HttpPost]
        public async Task<IActionResult> ChangeState(int? id)
        {
            var socialMedia = await _context.SocialMedias.FindAsync(id);

            socialMedia.IsActive = !socialMedia.IsActive;
            await _context.SaveChangesAsync();

            return Json(new { key = 1, data = socialMedia.IsActive });
        }
    }
}
