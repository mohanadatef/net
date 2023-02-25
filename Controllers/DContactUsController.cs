using KhadimiEssa.Data;
using KhadimiEssa.Data.TableDb;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static KhadimiEssa.Enums.AllEnums;
using static KhadimiEssa.Helper.HelperMethods;

namespace KhadimiEssa.Controllers
{
    [AuthorizeRoles(Roles.AdminBranch, Roles.ContactUs)]
    public class DContactUsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DContactUsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DContactUs
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContactUs.OrderByDescending(x=>x.Id).ToListAsync());
        }

        // GET: DContactUs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactUs = await _context.ContactUs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactUs == null)
            {
                return NotFound();
            }

            return View(contactUs);
        }

        // GET: DContactUs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DContactUs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Email,Msg,Date")] ContactUs contactUs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactUs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactUs);
        }

        // GET: DContactUs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactUs = await _context.ContactUs.FindAsync(id);
            if (contactUs == null)
            {
                return NotFound();
            }
            return View(contactUs);
        }

        // POST: DContactUs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Email,Msg,Date")] ContactUs contactUs)
        {
            if (id != contactUs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactUs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactUsExists(contactUs.Id))
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
            return View(contactUs);
        }

        // GET: DContactUs/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ContactUs = await _context.ContactUs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ContactUs == null)
            {
                return Json(new { key = 1, data = false });
            }

            ContactUs.IsDeleted = true;
            _context.ContactUs.Update(ContactUs);
            _context.SaveChanges();

            return Json(new { key = 1, data = true });
        }


        private bool ContactUsExists(int id)
        {
            return _context.ContactUs.Any(e => e.Id == id);
        }
    }
}
