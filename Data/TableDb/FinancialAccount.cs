using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Data.TableDb
{
    public class FinancialAccount
    {

        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public double Price { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual ApplicationDbUser User { get; set; }

    }
}
