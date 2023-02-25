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
    public class NotesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NotesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Notes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Notes.ToListAsync());
        }

       
        // GET: Notes/Create
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Note note)
        {
            if (ModelState.IsValid)
            {
                note.IsActive = true;
                note.Date = AAITHelper.HelperDate.GetCurrentDate();
                _context.Add(note);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(note);
        }

        // GET: Notes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = await _context.Notes.FindAsync(id);
            if (note == null)
            {
                return NotFound();
            }
            return View(note);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Note note)
        {
            if (id != note.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(note);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoteExists(note.Id))
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
            return View(note);
        }

        // GET: Notes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = await _context.Notes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (note == null)
            {
                return Json(new { key = 1, data = false });
            }

            note.IsDeleted = true;
            _context.Notes.Update(note);
            _context.SaveChanges();

            return Json(new { key = 1, data = true });
        }



        [HttpPost]
        public async Task<IActionResult> ChangeState(int? id)
        {
            var data = await _context.Notes.FindAsync(id);

            data.IsActive = !data.IsActive;
            await _context.SaveChangesAsync();

            return Json(new { key = 1, data = data.IsActive });
        }



        private bool NoteExists(int id)
        {
            return _context.Notes.Any(e => e.Id == id);
        }
    }
}
