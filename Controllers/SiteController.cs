﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Controllers
{
    public class SiteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Chat()
        {
            return View();
        }


    }
}
