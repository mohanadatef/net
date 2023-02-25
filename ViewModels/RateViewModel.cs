using System;

namespace KhadimiEssa.ViewModels
{
    public class RateViewModel
    {
        public int Id { get; set; }

        public string FkDeleget { get; set; }
        public string FkDelegetName { get; set; }

        public string FkUser { get; set; }
        public string FkUserName { get; set; }
        public DateTime Date { get; set; }
        public int Rate { get; set; } = 0;
        public int OrderId { get; set; } = 0;
    }
}
