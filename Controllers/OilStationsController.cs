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
    public class OilStationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OilStationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OilStations
        public async Task<IActionResult> Index()
        {
            return View(await _context.OilStations.ToListAsync());
        }

   
        public IActionResult Create()
        {

            OilStation oilStation = new OilStation();
            oilStation.Lat = 24.712458;
            oilStation.Lng = 46.672532;
            oilStation.Location = "الرياض 12215، السعودية";// تفتح خريطه

            return View(oilStation);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OilStation oilStation)
        {
            if (ModelState.IsValid)
            {
                oilStation.IsActive = true;
                oilStation.Date = AAITHelper.HelperDate.GetCurrentDate();

                _context.Add(oilStation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oilStation);
        }

        // GET: OilStations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oilStation = await _context.OilStations.FindAsync(id);
            if (oilStation == null)
            {
                return NotFound();
            }
            return View(oilStation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,OilStation oilStation)
        {
            if (id != oilStation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oilStation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OilStationExists(oilStation.Id))
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
            return View(oilStation);
        }

        // GET: OilStations/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var OilStation = await _context.OilStations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (OilStation == null)
            {
                return Json(new { key = 1, data = false });
            }

            OilStation.IsDeleted = true;
            _context.OilStations.Update(OilStation);
            _context.SaveChanges();

            return Json(new { key = 1, data = true });
        }


        [HttpPost]
        public async Task<IActionResult> ChangeState(int? id)
        {
            var data = await _context.OilStations.FindAsync(id);

            data.IsActive = !data.IsActive;
            await _context.SaveChangesAsync();

            return Json(new { key = 1, data = data.IsActive });
        }



        private bool OilStationExists(int id)
        {
            return _context.OilStations.Any(e => e.Id == id);
        }
    }
}
