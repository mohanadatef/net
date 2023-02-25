using KhadimiEssa.ApiModels;
using KhadimiEssa.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Interfaces.Logic
{
    public interface ILogicClientService
    {
        Task<List<OilStationDto>> GetOilStation(string lang);
        Task<List<AvailableTimesDto>> ListAvailableTimes(string day, string lang);
        Task<List<CarBrandDto>> ListCarBrands(string lang);
        Task<List<PaymentMethodDto>> ListPaymentMethods(string lang);
        Task<List<PackageDto>> ListPackages(string lang);

        Task<int> CountNotify();
        Task<double> DepositPrice();

        Task<Response<dynamic>> CheckRequiredDistanceAsync(CheckRequiredDistance checkRequiredDistance);

        Task<(int, string)> CheckTimeAvailableAsync(int time, string executionDate, int stationId, string lang);

        Task<(int, string)> AddOrderAsync(AddOrderDto addOrderDto);
        Task<(int, string)> PayOrderAsync(int orderId, int typePay, string lang);
        Task<string> CancelOrderAsync(int orderId, string lang);
        Task<List<OrderDto>> ListNewOrders(string lang);
        Task<List<OrderDto>> ListCUrrentOrders(string lang);
        Task<List<OrderDto>> ListFinishedOrders(string lang);
        Task<OrderDto> GetOrderDetails(int orderId, string lang);
        Task<List<NotesDto>> LisNotes(string lang);
    }
}
