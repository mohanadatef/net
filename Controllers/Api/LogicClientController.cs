using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using KhadimiEssa.ApiModels;
using KhadimiEssa.Data;
using KhadimiEssa.Helper;
using KhadimiEssa.Interfaces.Auth;
using KhadimiEssa.Interfaces.Logic;
using KhadimiEssa.PathUrl;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KhadimiEssa.Controllers.Api
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiExplorerSettings(GroupName = "LogicClient")]

    public class LogicClientController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly ILogicClientService _logicClientService;
        private readonly ICurrentUserService _currentUserService;

        public LogicClientController(ApplicationDbContext _db, ILogicClientService logicClientService, ICurrentUserService currentUserService)

        {
            db = _db;
            _logicClientService = logicClientService;
            _currentUserService = currentUserService;

        }

        [AllowAnonymous]
        [HttpPost(ApiRoutes.LogicUser.ListHomeDataAsync)]
        public async Task<IActionResult> ListHomeDataAsync(string lang = "ar")
        {
            HomeDataDto homeDataDto = new HomeDataDto();
            homeDataDto.OilStation = await _logicClientService.GetOilStation(lang);
            //homeDataDto.availableTimes = await _logicClientService.ListAvailableTimes(lang);
            homeDataDto.CarBrands = await _logicClientService.ListCarBrands(lang);
            homeDataDto.packages = await _logicClientService.ListPackages(lang);
            homeDataDto.CountNotify = await _logicClientService.CountNotify();
            homeDataDto.DepositPrice = await _logicClientService.DepositPrice();
            homeDataDto.PaymentMethods = await _logicClientService.ListPaymentMethods(lang);
            return Ok(new Response<HomeDataDto>(homeDataDto, ""));
        }

        [AllowAnonymous]
        [HttpPost(ApiRoutes.LogicUser.ListAvailableTimes)]
        public async Task<IActionResult> ListAvailableTimes(string day, string lang = "ar")
        {
            return Ok(new Response<List<AvailableTimesDto>>(await _logicClientService.ListAvailableTimes(day, lang), ""));
        }

        [AllowAnonymous]
        [HttpPost(ApiRoutes.LogicUser.CheckRequiredDistanceAsync)]
        public async Task<IActionResult> CheckRequiredDistanceAsync(CheckRequiredDistance checkRequiredDistance)
        {
            return Ok(await _logicClientService.CheckRequiredDistanceAsync(checkRequiredDistance));
        }

        [HttpPost(ApiRoutes.LogicUser.CheckTimeAvailableAsync)]
        public async Task<IActionResult> CheckTimeAvailableAsync(int time, string executionDate,int stationId, string lang)
        {
            var Check = await _logicClientService.CheckTimeAvailableAsync(time, executionDate, stationId, lang);
            if (Check.Item1 == 0)
            {
                return Ok(new Response<string>(Check.Item2));
            }
            else
            {
                return Ok(new Response<int>(Check.Item1, Check.Item2));
            }
        }

        [HttpPost(ApiRoutes.LogicUser.AddOrderAsync)]
        public async Task<IActionResult> AddOrderAsync(AddOrderDto addOrderDto)
        {
            var Check = await _logicClientService.AddOrderAsync(addOrderDto);
            if (Check.Item1 == 0)
            {
                return Ok(new Response<string>(Check.Item2));
            }
            else
            {
                return Ok(new Response<int>(Check.Item1, Check.Item2));
            }
        }

        [HttpPost(ApiRoutes.LogicUser.PayOrderAsync)]
        public async Task<IActionResult> PayOrderAsync(int orderId, int typePay, string lang)
        {
            var check = await _logicClientService.PayOrderAsync(orderId, typePay, lang);
            if (check.Item1 == 0)
            {
                return Ok(new Response<string>(check.Item2));
            }
            else
            {
                return Ok(new Response<int>(check.Item1, check.Item2));
            }
        }

        [HttpPost(ApiRoutes.LogicUser.CancelOrder)]
        public async Task<IActionResult> CancelOrderAsync(int orderId, string lang = "ar")
        {
            return Ok(new Response<string>("", await _logicClientService.CancelOrderAsync(orderId, lang)));
        }

        [HttpPost(ApiRoutes.LogicUser.ListNewOrdersUserAsync)]
        public async Task<IActionResult> ListNewOrdersUserAsync(string lang = "ar")
        {
            return Ok(new Response<List<OrderDto>>(await _logicClientService.ListNewOrders(lang), ""));
        }

        [HttpPost(ApiRoutes.LogicUser.ListCurrentOrdersUserAsync)]
        public async Task<IActionResult> ListCurrentOrdersUserAsync(string lang = "ar")
        {
            return Ok(new Response<List<OrderDto>>(await _logicClientService.ListCUrrentOrders(lang), ""));
        }

        [HttpPost(ApiRoutes.LogicUser.ListFinishedOrdersUserAsync)]
        public async Task<IActionResult> ListFinishedOrdersUserAsync(string lang = "ar")
        {
            return Ok(new Response<List<OrderDto>>(await _logicClientService.ListFinishedOrders(lang), ""));
        }


        [HttpPost(ApiRoutes.LogicUser.GetOrderDetailsUser)]
        public async Task<IActionResult> GetOrderDetails(int orderId, string lang = "ar")
        {
            return Ok(new Response<OrderDto>(await _logicClientService.GetOrderDetails(orderId, lang), ""));
        }
     
        [AllowAnonymous]
        [HttpPost(ApiRoutes.LogicUser.ListNotes)]
        public async Task<IActionResult> ListNotes(string lang = "ar")
        {
            return Ok(new Response<List<NotesDto>>(await _logicClientService.LisNotes(lang), ""));
        }

    }
}