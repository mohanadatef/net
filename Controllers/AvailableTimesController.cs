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
    public class AvailableTimesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AvailableTimesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AvailableTimes
        public async Task<IActionResult> Index()
        {
            return View(await _context.AvailableTimes.ToListAsync());
        }

      
        // GET: AvailableTimes/Create
        public IActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AvailableTime availableTime)
        {
            if (ModelState.IsValid)
            {
                availableTime.IsActive = true;
                _context.Add(availableTime);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(availableTime);
        }

        // GET: AvailableTimes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var availableTime = await _context.AvailableTimes.FindAsync(id);
            if (availableTime == null)
            {
                return NotFound();
            }
            return View(availableTime);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AvailableTime availableTime)
        {
            if (id != availableTime.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(availableTime);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvailableTimeExists(availableTime.Id))
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
            return View(availableTime);
        }

        // GET: AvailableTimes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var availableTime = await _context.AvailableTimes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (availableTime == null)
            {
                return NotFound();
            }

            return View(availableTime);
        }

        // POST: AvailableTimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var availableTime = await _context.AvailableTimes.FindAsync(id);
            _context.AvailableTimes.Remove(availableTime);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> ChangeState(int? id)
        {
            var data = await _context.AvailableTimes.FindAsync(id);

            data.IsActive = !data.IsActive;
            await _context.SaveChangesAsync();

            return Json(new { key = 1, data = data.IsActive });
        }

        private bool AvailableTimeExists(int id)
        {
            return _context.AvailableTimes.Any(e => e.Id == id);
        }
    }
}
