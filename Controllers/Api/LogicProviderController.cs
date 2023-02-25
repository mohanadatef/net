using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KhadimiEssa.ApiModels;
using KhadimiEssa.Data;
using KhadimiEssa.Helper;
using KhadimiEssa.Interfaces.Logic;
using KhadimiEssa.PathUrl;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KhadimiEssa.Controllers.Api
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiExplorerSettings(GroupName = "LogicProvider")]
    public class LogicProviderController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly ILogicProviderService _logicProviderService;

        public LogicProviderController(ApplicationDbContext _db, ILogicProviderService logicProviderService)

        {
            db = _db;
            _logicProviderService = logicProviderService;

        }



        [HttpPost(ApiRoutes.LogicDeleget.ListNewOrdersAsync)]
        public async Task<IActionResult> ListNewOrdersAsync(string lang = "ar")
        {
            return Ok(new Response<List<OrderDto>>(await _logicProviderService.ListNewOrders(lang), ""));
        }

        [HttpPost(ApiRoutes.LogicDeleget.AcceptOrderAsync)]
        public async Task<IActionResult> AcceptOrderAsync( int orderId, string lang = "ar")
        {
            return Ok(new Response<string>("", await _logicProviderService.AcceptOrderAsync(orderId,lang)));
        }

        [HttpPost(ApiRoutes.LogicDeleget.RefuseOrderAsync)]
        public async Task<IActionResult> RefuseOrderAsync(int orderId, string lang = "ar")
        {
            return Ok(new Response<string>("", await _logicProviderService.RefuseOrderAsync(orderId,lang)));
        }

        [HttpPost(ApiRoutes.LogicDeleget.ListCurrentOrdersAsync)]
        public async Task<IActionResult> ListCurrentOrdersAsync(string lang = "ar")
        {
            return Ok(new Response<List<OrderDto>>(await _logicProviderService.ListCUrrentOrders(lang), ""));
        }

        [HttpPost(ApiRoutes.LogicDeleget.FinishOrderAsync)]
        public async Task<IActionResult> FinishOrderAsync(int orderId, string lang = "ar")
        {
            return Ok(new Response<string>("", await _logicProviderService.FinishOrderAsync(orderId,lang)));
        }


        [HttpPost(ApiRoutes.LogicDeleget.ListFinishedOrdersAsync)]
        public async Task<IActionResult> ListFinishedOrdersAsync(string lang = "ar")
        {
            return Ok(new Response<List<OrderDto>>(await _logicProviderService.ListFinishedOrders(lang), ""));
        } 

        [HttpPost(ApiRoutes.LogicDeleget.GetOrderDetails)]
        public async Task<IActionResult> GetOrderDetails(int orderId,string lang = "ar")
        {
            return Ok(new Response<OrderDto>(await _logicProviderService.GetOrderDetails(orderId,lang), ""));
        }


    }
}
