using KhadimiEssa.Data;
using KhadimiEssa.Data.TableDb;
using KhadimiEssa.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using QRCoder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static KhadimiEssa.Enums.AllEnums;
using static KhadimiEssa.Helper.HelperMethods;

namespace KhadimiEssa.Controllers
{
    [AuthorizeRoles(Roles.AdminBranch, Roles.Payments)]
    public class PaymentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private static string checkOutId = "";

        //Testing Cards for credit Card:
        //4111111111111111 05/21 cvv2 123  (Success).
        //5204730000002514 05/22 cvv2 251  (Fail).
        //Mada 5297412484442387 10/22 966

        //لينك فيديو شرح  طريقه الدفع 
        // https://drive.google.com/file/d/1bsqTeKPuS1do-Ii4-iZCc5Oo-V6wYTkz/view

        public PaymentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Payments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Payments.Include(p => p.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // بدأ الطلب بعملية الدفع
        public IActionResult PayRequest(int paymentId)
        {
            var payment = _context.Payments.Include(p => p.User).FirstOrDefault(p => p.Id == paymentId);

            Dictionary<string, dynamic> responseData;
            string data;
            if (payment.IsLive)
            {
                data = "entityId=" + (payment.IsMada ? payment.MadaEntityId : payment.ViMaEntityId) +
                       "&amount=" + "10.00" +
                       "&currency=" + payment.Currency +
                       "&paymentType=" + payment.PaymentType +
                       "&merchantTransactionId=" + Guid.NewGuid().ToString() +
                       "&billing.street1=" + payment.User.Street +
                       "&billing.city=" + payment.User.City +
                       "&billing.state=" + payment.User.State +
                       "&billing.country=" + payment.User.Country + //  Alpha-2 codes : SA
                       "&billing.postcode=" + payment.User.PostCode +
                       "&customer.email=" + payment.User.Email +
                       "&customer.givenName=" + payment.User.user_Name +
                       "&customer.surname=" + payment.User.user_Name;
            }
            else
            {
                data = "entityId=" + (payment.IsMada ? payment.MadaEntityId : payment.ViMaEntityId) +
                       "&amount=" + "10.00" +
                       "&currency=" + payment.Currency +
                       "&paymentType=" + payment.PaymentType +
                      (payment.IsMada ? "&testMode=" + TestMode.INTERNAL : "&testMode=" + TestMode.EXTERNAL) +
                       "&merchantTransactionId=" + Guid.NewGuid().ToString() +
                       "&billing.street1=" + payment.User.Street +
                       "&billing.city=" + payment.User.City +
                       "&billing.state=" + payment.User.State +
                       "&billing.country=" + payment.User.Country + //  Alpha-2 codes
                       "&billing.postcode=" + payment.User.PostCode +
                       "&customer.email=" + payment.User.Email +
                       "&customer.givenName=" + payment.User.user_Name +
                       "&customer.surname=" + payment.User.user_Name;
            }


            string url = payment.IsLive ? payment.LiveCheckoutUrl : payment.TestCheckoutUrl;
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "POST";
            request.Headers["Authorization"] = payment.IsLive ? "Bearer " + payment.LiveAccessToken : "Bearer " + payment.TestAccessToken;
            request.ContentType = "application/x-www-form-urlencoded";
            Stream PostData = request.GetRequestStream();
            PostData.Write(buffer, 0, buffer.Length);
            PostData.Close();
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                responseData = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(reader.ReadToEnd());
                //var s = new JavaScriptSerializer();
                //responseData = s.Deserialize<Dictionary<string, dynamic>>(reader.ReadToEnd());
                reader.Close();
                dataStream.Close();
            }
            var result = responseData;
            checkOutId = responseData["id"];

            ViewBag.Id = checkOutId;
            ViewBag.userId = payment.UserId;
            ViewBag.paymentId = payment.Id;
            ViewBag.isLive = payment.IsLive;

            if (payment.IsMada)
            {
                return View("MadaWebPay");
            }

            return View("WebPay");
        }

        // مرحلة تأكيد الدفع بعد ادخال بيانات الدفع في الفورم
        [HttpGet]
        public async Task<ActionResult> WebSubmit(int paymentId, string userId)
        {
            var payment = await _context.Payments.FindAsync(paymentId);

            if (payment.UserId == userId)
            {
                Dictionary<string, dynamic> responseData;
                string data = "entityId=" + (payment.IsMada ? payment.MadaEntityId : payment.ViMaEntityId);
                string url = (payment.IsLive ? payment.LiveCheckoutUrl : payment.TestCheckoutUrl) + "/" + checkOutId + "/payment?" + data;
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Method = "GET";
                request.Headers["Authorization"] = "Bearer " + (payment.IsLive ? payment.LiveAccessToken : payment.TestAccessToken);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    responseData = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(reader.ReadToEnd());
                    reader.Close();
                    dataStream.Close();
                }

                var resultCode = responseData["result"]["code"].ToString();

                Regex successPattern = new Regex(@"(000\.000\.|000\.100\.1|000\.[36])");
                Regex successManuelPattern = new Regex(@"(000\.400\.0[^3]|000\.400\.100)");

                Match match1 = successPattern.Match(resultCode);
                Match match2 = successManuelPattern.Match(resultCode);


                if (match1.Success || match2.Success)
                {
                    return RedirectToAction("WebSuccess");
                    //return Json(new { key = 1, msg = "تمت العملية بنجاح" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return RedirectToAction("WebFail");
                    //return Json(new { key = 0, msg = "فشلت العملية" }, JsonRequestBehavior.AllowGet);

                }
            }
            else
            {
                ModelState.AddModelError(String.Empty, "تم دفع قيمة الطلب من قبل");
                return RedirectToAction("Index", "Payments");
            }
        }

        public ActionResult WebSuccess()
        {
            return View();
        }
        public ActionResult WebFail()
        {
            return View();
        }

        // GET: Payments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payments
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // GET: Payments/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users.Where(u => u.TypeUser == (int)AllEnums.User_Type.Client), "Id", "user_Name");
            return View();
        }

        // POST: Payments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ViMaEntityId,MadaEntityId,LiveAccessToken,TestAccessToken,PaymentType,Currency,IsLive,IsMada,LiveCheckoutUrl,TestCheckoutUrl,UserId")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(payment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users.Where(u => u.TypeUser == (int)AllEnums.User_Type.Client), "Id", "user_Name", payment.UserId);
            return View(payment);
        }

        // GET: Payments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payments.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users.Where(u => u.TypeUser == (int)AllEnums.User_Type.Client), "Id", "user_Name", payment.UserId);
            return View(payment);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ViMaEntityId,MadaEntityId,LiveAccessToken,TestAccessToken,PaymentType,Currency,IsLive,IsMada,LiveCheckoutUrl,TestCheckoutUrl,UserId")] Payment payment)
        {
            if (id != payment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(payment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentExists(payment.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users.Where(u => u.TypeUser == (int)AllEnums.User_Type.Client), "Id", "user_Name", payment.UserId);
            return View(payment);
        }

        // GET: Payments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payments
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentExists(int id)
        {
            return _context.Payments.Any(e => e.Id == id);
        }
    }
    public static class PaymentMethods

    {
        public static string VISA = "VISA";
        public static string MASTER = "MASTER";
        public static string MADA = "MADA";
    }

    public static class TestMode
    {
        public static string INTERNAL = "INTERNAL";
        public static string EXTERNAL = "EXTERNAL";
    }
}
