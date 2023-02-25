using KhadimiEssa.Data;
using KhadimiEssa.Data.TableDb;
using KhadimiEssa.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static KhadimiEssa.Enums.AllEnums;
using static KhadimiEssa.Helper.HelperMethods;

namespace KhadimiEssa.Controllers
{
    [AuthorizeRoles(Roles.AdminBranch, Roles.Copons)]
    public class CoponsController : Controller
    {
        private readonly UserManager<ApplicationDbUser> _userManager;
        private readonly ApplicationDbContext _context;

        public CoponsController(ApplicationDbContext context, UserManager<ApplicationDbUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var copons = await _context.Copon.Select(cop => new CoponViewModel
            {
                ID = cop.Id,
                Count = cop.Count,
                CoponCode = cop.CoponCode,
                CountUsed = cop.CountUsed,
                Discount = cop.Discount,
                limt_discount = cop.limtDiscount,
                expirdate = cop.Expirdate.ToString("g"),
                IsActive = cop.IsActive
            }).ToListAsync();

            return View(copons);
        }


        // GET: Copons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Copons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCoponViewModel createCoponViewModel)
        {
            if (ModelState.IsValid)
            {
                var checkCopon = _context.Copon.Any(x => x.CoponCode == createCoponViewModel.CoponCode);
                if (!checkCopon)
                {


                    Copon copon = new Copon()
                    {
                        IsActive = true,
                        Date = DateTime.Now,
                        Count = createCoponViewModel.Count,
                        Expirdate = createCoponViewModel.expirdate,
                        CoponCode = createCoponViewModel.CoponCode,
                        CountUsed = createCoponViewModel.CountUsed,
                        Discount = createCoponViewModel.Discount,
                        limtDiscount = createCoponViewModel.limt_discount
                    };

                    _context.Add(copon);

                    string currentUserId = _userManager.GetUserId(User);
                    var name = (from user in _context.Users where user.Id == currentUserId select user.Email).SingleOrDefault();
                    LogExption l = new LogExption
                    {
                        ServiceName = name,
                        Date = DateTime.Now,
                        Exption = "قام المستخدم " + name + "باضافة كوبون " + copon.CoponCode + "فى الوقت " + DateTime.Now
                    };
                    _context.LogExption.Add(l);

                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //ModelState.AddModelError(createCoponViewModel.CoponCode, "هذا الكويون موجود من قبل");
                    ViewBag.message = "هذا الكويون موجود من قبل";
                }
            }
            return View(createCoponViewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var copon = await _context.Copon.FindAsync(id);
            if (copon == null)
            {
                return NotFound();
            }

            CreateCoponViewModel createCoponViewModel = new CreateCoponViewModel()
            {
                Count = copon.Count,
                ID = copon.Id,
                CountUsed = copon.CountUsed,
                Discount = copon.Discount,
                CoponCode = copon.CoponCode,
                IsActive = copon.IsActive,
                expirdate = copon.Expirdate,
                limt_discount = copon.limtDiscount
            };

            return View(createCoponViewModel);
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CreateCoponViewModel createCoponViewModel)
        {
            if (id != createCoponViewModel.ID)
            {
                return NotFound();
            }


            try
            {
                var foundedCopon = await _context.Copon.FindAsync(id);

                foundedCopon.Count = createCoponViewModel.Count;

                foundedCopon.Discount = createCoponViewModel.Discount;
                foundedCopon.IsActive = createCoponViewModel.IsActive;
                foundedCopon.Expirdate = createCoponViewModel.expirdate;
                foundedCopon.limtDiscount = createCoponViewModel.limt_discount;


                _context.Update(foundedCopon);

                string currentUserId = _userManager.GetUserId(User);
                var name = (from user in _context.Users where user.Id == currentUserId select user.Email).SingleOrDefault();
                LogExption l = new LogExption
                {
                    ServiceName = name,
                    Date = DateTime.Now,
                    Exption = "قام المستخدم " + name + "بتعديل كوبون " + foundedCopon.CoponCode + "فى الوقت " + DateTime.Now
                };
                _context.LogExption.Add(l);

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoponExists(createCoponViewModel.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));

            return View(createCoponViewModel);
        }

        // GET: Packages/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Copon = await _context.Copon
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Copon == null)
            {
                return Json(new { key = 1, data = false });
            }

            Copon.IsDeleted = true;
            _context.Copon.Update(Copon);
            _context.SaveChanges();

            return Json(new { key = 1, data = true });
        }

        [HttpPost]
        public async Task<IActionResult> ChangeState(int? id)
        {

            var copon = _context.Copon.Find(id);
            if (copon.IsActive == true)
            {
                copon.IsActive = false;

            }
            else
            {
                copon.IsActive = true;
            }
            await _context.SaveChangesAsync();
            return Ok(new { key = 1, data = copon.IsActive });

        }

        private bool CoponExists(int id)
        {
            return _context.Copon.Any(e => e.Id == id);
        }
    }
}