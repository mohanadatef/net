using KhadimiEssa.Data;
using KhadimiEssa.Models;
using KhadimiEssa.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static KhadimiEssa.Enums.AllEnums;

namespace KhadimiEssa.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            var data = (from st in _context.Settings
                        let ordersCount = _context.Orders.Max(o=>o.Id)
                        let contactUsCount = _context.ContactUs.Count()
                        let providersCount = _context.Users.Where(o => o.TypeUser == (int)User_Type.deleget).Count()
                        let usersCount = _context.Users.Where(o => o.TypeUser == (int)User_Type.Client).Count()

                        select new HomeViewModel
                        {
                            ordersCount = ordersCount,
                            contactUsCount = contactUsCount,
                            providersCount = providersCount,
                            usersCount = usersCount,

                        }).FirstOrDefault();



            return View(data);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return Json(returnUrl);
        }

    }
}
