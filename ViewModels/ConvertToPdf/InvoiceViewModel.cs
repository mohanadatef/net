using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Models.ConvertToPdf
{
    public class InvoiceViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = "said";
        public string Description { get; set; } = "فاتوره منتجات";
    }
}
