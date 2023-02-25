using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Models.IntroSiteModels
{
    public class IntroSiteHomeViewModel
    {
        public IntroSiteHomeViewModel()
        {
            Adventages = new List<AdventagesViewModel>();
            customerOpinions = new List<CustomerOpinionViewModel>();
            Slider = new List<string>();
        }
        public List<string> Slider { get; set; }
        public IntroSettingViewModel IntroSetting { get; set; }
        public List<AdventagesViewModel> Adventages { get; set; }
        public List<CustomerOpinionViewModel> customerOpinions { get; set; }
    }
}
