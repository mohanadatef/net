using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Data.TableDb
{
    public class NotifyDelegt
    {
        [Key]
        public int Id { get; set; }
        [StringLength(450)]
        public string FKUser { get; set; }
        public string TextAr { get; set; }
        public string TextEn { get; set; }
        public DateTime Date { get; set; }
        public int? Type { get; set; }
        public int OrderId { get; set; }

        public bool? Show { get; set; }
        [ForeignKey(nameof(FKUser))]
        public virtual ApplicationDbUser ApplicationDbUser { get; set; }
    }
}
