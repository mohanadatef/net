using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Data.TableDb
{
    public class DeviceId
    {
        [Key]
        public int Id { get; set; }
        public string FkUser { get; set; }
        public string DeviceId_ { get; set; }
        public string ProjectName { get; set; }
        public string DeviceType { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey(nameof(FkUser))]
        [InverseProperty(nameof(ApplicationDbUser.DeviceId))]
        public virtual ApplicationDbUser user { get; set; }
    }
}
