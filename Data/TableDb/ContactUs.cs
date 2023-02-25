using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Data.TableDb
{
    public class ContactUs
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string UserName { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Msg { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }

    }
}
