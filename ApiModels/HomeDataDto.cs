using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.ApiModels
{
    public class HomeDataDto
    {
        public List<OilStationDto> OilStation { get; set; }
        public List<PaymentMethodDto> PaymentMethods { get; set; }
        public List<CarBrandDto> CarBrands { get; set; }
        public List<PackageDto> packages { get; set; }
        //public List<AvailableTimesDto> availableTimes { get; set; }
        public int CountNotify { get; set; }
        public double DepositPrice { get; set; }
    }
}
