using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KhadimiEssa.Data.TableDb
{
    public class Orders
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ProviderId { get; set; }
        public int CarBrandId { get; set; }
        public double DepositPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ExecutionDate { get; set; }
        public int ExecutionTime { get; set; }
        public int Status { get; set; }
        public double Distance { get; set; }
        public int TypePay { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Location { get; set; }
        public int PackageId { get; set; }
        public int? CoponId { get; set; }
        public double Total { get; set; }
        public bool IsPaid { get; set; }
        public int StationId { get; set; }
        public int Kilometers { get; set; }


        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(ApplicationDbUser.Orders))]
        public virtual ApplicationDbUser User { get; set; }

        [ForeignKey(nameof(ProviderId))]
        [InverseProperty(nameof(ApplicationDbUser.OrdersP))]
        public virtual ApplicationDbUser Provider { get; set; }

        [ForeignKey(nameof(CarBrandId))]
        public virtual CarBrand CarBrand { get; set; }

        [ForeignKey(nameof(ExecutionTime))]
        [InverseProperty(nameof(AvailableTime.Orders))]
        public virtual AvailableTime Availabletime { get; set; }

        [InverseProperty(nameof(TableDb.Messages.Order))]
        public virtual ICollection<Messages> Messages { get; set; } = new HashSet<Messages>();


        [ForeignKey(nameof(PackageId))]
        public virtual Package Package { get; set; }

        [ForeignKey(nameof(CoponId))]
        public virtual Copon Copon { get; set; }
        
        [ForeignKey(nameof(StationId))]
        public virtual OilStation OilStation { get; set; }

    }
}
