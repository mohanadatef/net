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
    [AuthorizeRoles(Roles.AdminBranch, Roles.Questions)]
    public class DQuestionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DQuestionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DQuestions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Questions.ToListAsync());
        }

        // GET: DQuestions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questions = await _context.Questions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (questions == null)
            {
                return NotFound();
            }

            return View(questions);
        }

        // GET: DQuestions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DQuestions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Questions questions)
        {
            if (ModelState.IsValid)
            {
                questions.IsActive = true;
                _context.Add(questions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(questions);
        }

        // GET: DQuestions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questions = await _context.Questions.FindAsync(id);
            if (questions == null)
            {
                return NotFound();
            }
            return View(questions);
        }

        // POST: DQuestions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Questions questions)
        {
            if (id != questions.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(questions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionsExists(questions.Id))
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
            return View(questions);
        }

        // GET: DQuestions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questions = await _context.Questions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (questions == null)
            {
                return NotFound();
            }

            return View(questions);
        }

        // POST: DQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var questions = await _context.Questions.FindAsync(id);
            _context.Questions.Remove(questions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionsExists(int id)
        {
            return _context.Questions.Any(e => e.Id == id);
        }


        [HttpPost]
        public async Task<IActionResult> ChangeState(int? id)
        {
            var question = await _context.Questions.FindAsync(id);

            question.IsActive = !question.IsActive;
            await _context.SaveChangesAsync();

            return Json(new { key = 1, data = question.IsActive });
        }

    }
}
