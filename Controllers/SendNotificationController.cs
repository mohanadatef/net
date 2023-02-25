using AAITHelper;
using AAITHelper.ModelHelper;
using KhadimiEssa.Data;
using KhadimiEssa.Data.TableDb;
using KhadimiEssa.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static KhadimiEssa.Enums.AllEnums;
using static KhadimiEssa.Helper.HelperMethods;

namespace KhadimiEssa.Controllers
{
    [AuthorizeRoles(Roles.AdminBranch, Roles.Notifications)]
    public class SendNotificationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SendNotificationController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.HistoryNotify.Include(n => n.User);
            return View(await applicationDbContext.ToListAsync());
        }


        public IActionResult SendNotify()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.Users.Where(u => u.IsActive == true && u.TypeUser == (int)User_Type.Client).Select(x => new
            {
                id = x.Id,
                name = x.user_Name
            }).ToListAsync();

            return Ok(new { key = 1, users = users });
        }

        [HttpGet]
        public async Task<IActionResult> GetDeleget()
        {
            var delegets = await _context.Users.Where(u => u.IsActive == true && u.TypeUser == (int)User_Type.deleget).Select(x => new
            {
                id = x.Id,
                name = x.user_Name
            }).ToListAsync();

            return Ok(new { key = 1, delegets = delegets });
        }


        [HttpPost]
        public async Task<IActionResult> Send(string msg, string employees)
        {
            if (employees != null)
            {
                if (employees.Length > 0)
                {
                    var employeeArr = employees.Split(',');
                    List<HistoryNotify> historyNotifies = new List<HistoryNotify>();
                    //List<NotifyClient> notifyClientsList = new List<NotifyClient>();
                    //List<NotifyDelegt> notifyDelegtsList = new List<NotifyDelegt>();
                    foreach (var clientId in employeeArr)
                    {
                        //var user = (await _context.Users.FirstOrDefaultAsync(x => x.Id == clientId));
                        //if (user.TypeUser == (int)User_Type.Client)
                        //{
                        //    NotifyClient notifyClient = new NotifyClient()
                        //    {
                        //        TextAr = msg,
                        //        Show = false,
                        //        FKUser = clientId,
                        //        Date = HelperDate.GetCurrentDate(),
                        //        Type = (int)NotifyTypes.NotiyFromDashBord
                        //    };
                        //    notifyClientsList.Add(notifyClient);
                        //}
                        //else
                        //{
                        //    NotifyDelegt notifyDelegt = new NotifyDelegt()
                        //    {
                        //        TextAr = msg,
                        //        Show = false,
                        //        FKUser = clientId,
                        //        Date = HelperDate.GetCurrentDate(),
                        //        Type = (int)NotifyTypes.NotiyFromDashBord
                        //    };
                        //    notifyDelegtsList.Add(notifyDelegt);
                        //}

                        HistoryNotify notifyObj = new HistoryNotify()
                        {
                            Text = msg,
                            Date = HelperDate.GetCurrentDate(),
                            FKUser = clientId,
                        };
                        historyNotifies.Add(notifyObj);
                        await HelperMethods.SendNotifyAsync(_context, msg, msg, clientId, (int)NotifyTypes.NotiyFromDashBord);
                    }

                    //_context.NotifyClients.AddRange(notifyClientsList);
                    //_context.NotifyDelegts.AddRange(notifyDelegtsList);
                    _context.HistoryNotify.AddRange(historyNotifies);
                    await _context.SaveChangesAsync();
                    //dynamic info = "";
                    //var user_devices = (from historyNotify in historyNotifies
                    //                    join deviceId in _context.DeviceIds on historyNotify.FKUser equals deviceId.FkUser
                    //                    select new DeviceIdModel
                    //                    {
                    //                        DeviceId = deviceId.DeviceId_,
                    //                        DeviceType = deviceId.DeviceType
                    //                    }).ToList();
                    //HelperFcm.SendPushNotification("AAAA_u7Zr64:APA91bFvQqYAReQLKlgUdd9WTtV9U6pYPyRXvbFsvuAqTTAQsPOKfsQ_EHdtxBmtROoqlUlDAf-3DIjzWvz1V4t8i3UVniY1EtGs7AlUsDnojwc1pPlmUvSRJllcBaJ0jIiN81G0rFg9", "1094928936878", user_devices, info, msg, (int)NotifyTypes.NotiyFromDashBord);
                }
            }

            return Ok(new { key = 1, message = "send successfully" });

        }
    }
}