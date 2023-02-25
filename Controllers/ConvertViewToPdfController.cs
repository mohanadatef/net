using DinkToPdf;
using DinkToPdf.Contracts;
using KhadimiEssa.Data;
using KhadimiEssa.Models.ConvertToPdf;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Controllers
{
    public class ConvertViewToPdfController : Controller
    {

        private readonly ApplicationDbContext _db;
        //private readonly IGeneratePdf _GeneratePdf;

        private readonly ILogger<HomeController> _logger;
        private readonly IHostingEnvironment _hostingEnvironment;
        private IConverter _converter;
        public ConvertViewToPdfController(IConverter converter, ILogger<HomeController> logger, IHostingEnvironment hostingEnvironment, ApplicationDbContext db)

        {
            _converter = converter;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
            _db = db;
        }


        // هنا الموديل اللى هتبعته للصفحة
        public IActionResult Index(InvoiceViewModel invoiceViewModel)
        {
            return View(invoiceViewModel);
        }


        //دى فانكشن تحويل الصفحه اللى pdf 
        // pagePath like "https://localhost:44392/ConvertViewToPdf/Index" or use Base Uerl like Helper.HelperMethods.BaisUrlHoste+"ConvertViewToPdf/Index
        public string CreatePDF(string pagePath)
        {
            var pdfname = String.Format("{0}.pdf", Guid.NewGuid().ToString());
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = DinkToPdf.Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report",
                Out = Path.Combine(_hostingEnvironment.WebRootPath, "pdf", pdfname)
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,

                //بياخد  لينك اى صفحة لتحويلها ل pdf

                Page = $"{pagePath}"

            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }

            };
            _converter.Convert(pdf);


            return globalSettings.Out;
        }

    }
}
