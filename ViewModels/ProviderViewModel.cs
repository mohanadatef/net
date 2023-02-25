using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.ViewModels
{
    public class ProviderViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Img { get; set; }
        public string OilStation { get; set; }
        public bool IsActive { get; set; }
        public DateTime date { get; set; }
    }
}
