using AAITHelper;
using KhadimiEssa.Data;
using KhadimiEssa.Data.TableDb;
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
    [AuthorizeRoles(Roles.AdminBranch, Roles.SendSmsMsg)]
    public class SendSmsMessageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SendSmsMessageController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.Users.Where(u => u.IsActive == true && u.TypeUser == (int)User_Type.Client).Select(x => new
            {
                id = x.Id,
                name = x.user_Name,
                phoneNumber = x.PhoneNumber
            }).ToListAsync();

            return Ok(new { key = 1, users = users });
        }





        [HttpPost]
        public async Task<IActionResult> Send(string smsMsg, string employees)
        {
            //employees = "00966545853212";
            if (employees.Length > 0)
            {
                List<SmsMessage> smsMessages = new List<SmsMessage>();
                var employeeArr = employees.Split(',');
                var GetInfoSms = _context.Settings.FirstOrDefault();
                foreach (var clientPhone in employeeArr)
                {
                    SmsMessage MessageObj = new SmsMessage()
                    {
                        Message = smsMsg,
                        Date = HelperDate.GetCurrentDate(),
                        PhoneNumber = clientPhone

                    };
                    smsMessages.Add(MessageObj);

                    // smsType = 1 => 4jawaly && smsType = 2 => ElYamam && smsType = 3 => ByMobily && smsType = 4 => GmailMail

                    //string ownerPhone = await _context.Users.Where(x => x.PhoneNumber == phone).Select(x => x.user_Name).FirstOrDefaultAsync();
                    //string toEmail = await _context.Users.Where(x => x.PhoneNumber == phone).Select(x => x.Email).FirstOrDefaultAsync();


                    await SmsMessage(smsMsg, clientPhone, GetInfoSms.SenderName, GetInfoSms.UserNameSms, GetInfoSms.PasswordSms, smsType: 1);


                    //SmsMessage(smsMsg, clientPhone, GetInfoSms.UserNameSms, GetInfoSms.PasswordSms, smsType:2);
                    //SmsMessage(smsMsg, clientPhone, GetInfoSms.SenderName, GetInfoSms.PasswordSms, smsType: 3);
                    //SmsMessage(smsMsg, clientPhone, smsType: 4 , fromEmail:"", subject:"");
                }

                await _context.SmsMessages.AddRangeAsync(smsMessages);
                _context.SaveChanges();

            }

            return Ok(new { key = 1, message = "faild" });

        }

        [HttpPost]
        public async Task<IActionResult> SendSms(string smsMsg, string client)
        {
            var currentClient = await _context.Users.SingleOrDefaultAsync(x => x.Id == client);
            var GetInfoSms = _context.Settings.FirstOrDefault();
            if (GetInfoSms != null && client != null)
            {
                if (GetInfoSms.SenderName != "test")
                {
                    string resultSms = await HelperSms.SendMessageBy4jawaly(smsMsg, currentClient.PhoneNumber, GetInfoSms.SenderName, GetInfoSms.UserNameSms, GetInfoSms.PasswordSms);
                    return Ok(new { key = 1, message = "Success" });
                }
            }
            return Ok(new { key = 0, message = "faild" });
        }

    }
}
