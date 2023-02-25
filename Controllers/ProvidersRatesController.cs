using KhadimiEssa.Data;
using KhadimiEssa.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Controllers
{
    public class ProvidersRatesController : Controller
    {
        private readonly ApplicationDbContext context;

        public ProvidersRatesController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index(DateTime FromDate, DateTime ToDate,string ProviderId)
        {
            var rates = await context.RateDelget.Where(r => (FromDate != DateTime.MinValue ? r.Date > FromDate : true)
                                                     && (ToDate != DateTime.MinValue ? r.Date < ToDate : true)
                                                     && (!string.IsNullOrEmpty(ProviderId) ? r.FkDeleget == ProviderId : true)).Select(r=>new RateViewModel() { 
                                                        Id = r.Id,
                                                        FkDeleget = r.FkDeleget,
                                                        FkDelegetName = r.Deleget != null ? r.Deleget.user_Name : "",
                                                        FkUser = r.FkUser,
                                                        FkUserName = r.ApplicationDbUser != null ? r.ApplicationDbUser.user_Name : "",
                                                        Rate = r.Rate,
                                                        Date = r.Date,
                                                        OrderId = r.OrderId
                                                     }).ToListAsync();
            return View(rates);
        }
    }
}
