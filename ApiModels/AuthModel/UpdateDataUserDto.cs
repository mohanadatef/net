
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Models.AuthModel
{
    public class UpdateDataUserDto
    {
        public string lang { get; set; } = "ar";
        public string userName { get; set; }
        public string email { get; set; }

        public IFormFile imgProfile { get; set; }
        public string phone { get; set; }
    }
    public class UpdateDataDelegtViewModel
    {
        public string lang { get; set; } = "ar";
        public string userName { get; set; }
        public string email { get; set; }
        public IFormFile imgProfile { get; set; }
        public string phone { get; set; }
    }
}
