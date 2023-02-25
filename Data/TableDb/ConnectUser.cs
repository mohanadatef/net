using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Data.TableDb
{
    public class ConnectUser
    {
        [Key]
        public int Id { get; set; }
        public string ContextId { get; set; }
        public DateTime date { get; set; } = DateTime.Now;

        public string FKUser { get; set; }

        [ForeignKey("FKUser")]
        public virtual ApplicationDbUser User { get; set; }
    }
}
