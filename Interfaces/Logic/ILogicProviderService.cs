using KhadimiEssa.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Interfaces.Logic
{
    public interface ILogicProviderService
    {
        Task<List<OrderDto>> ListNewOrders(string lang);

        Task<string> AcceptOrderAsync(int orderId, string lang);
        Task<string> RefuseOrderAsync(int orderId, string lang);

        Task<List<OrderDto>> ListCUrrentOrders(string lang);
        Task<string> FinishOrderAsync(int orderId, string lang);

        Task<List<OrderDto>> ListFinishedOrders(string lang);
        Task<OrderDto> GetOrderDetails(int orderId, string lang);

    }
}
