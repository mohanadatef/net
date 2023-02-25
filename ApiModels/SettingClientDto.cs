using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.ModelDTO.SettinDTO
{
    public class SettingClientDto
    {
        public string Phone { get; set; }
        public string email { get; set; }
        public double tax { get; set; }
        public double depositPrice { get; set; }
        public bool isShowDepositPrice { get; set; }
        public double rateBouns { get; set; }
        public double invitationBouns { get; set; }
        //public string privacy { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public string location { get; set; }
        public string invititionCode { get; set; }
    }
}
