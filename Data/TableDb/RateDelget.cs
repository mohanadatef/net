using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Data.TableDb
{
    public class RateDelget
    {
        [Key]
        public int Id { get; set; }

        public string FkDeleget { get; set; }

        public string FkUser { get; set; }
        public DateTime Date { get; set; }
        public int Rate { get; set; } = 0;
        public int OrderId { get; set; } = 0;

        [ForeignKey(nameof(FkUser))]
        [InverseProperty(nameof(Data.ApplicationDbUser.Client))]
        public virtual ApplicationDbUser ApplicationDbUser { get; set; }

        [ForeignKey(nameof(FkDeleget))]
        [InverseProperty(nameof(Data.ApplicationDbUser.Delget))]
        public virtual ApplicationDbUser Deleget { get; set; }
    }
}
