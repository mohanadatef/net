using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Data.TableDb
{
    public class UserInvitation
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string NewUserId { get; set; }
        public string InvitationCode { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual ApplicationDbUser User { get; set; }
    }
}
