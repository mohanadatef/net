using KhadimiEssa.Data;
using KhadimiEssa.Data.TableDb.IntroductorySite;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Controllers
{
    public class IntroContactUsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IntroContactUsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: IntroContactUs
        public async Task<IActionResult> Index()
        {
            return View(await _context.IntroContactUs.ToListAsync());
        }

    }
}
