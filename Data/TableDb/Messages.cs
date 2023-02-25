using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhadimiEssa.Data.TableDb
{
    public class Messages
    {
        [Key]
        public int Id { get; set; }
        public int FKOrder { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string Text { get; set; }
        public DateTime DateSend { get; set; }
        public bool SenderSeen { get; set; }
        public bool ReceiverSeen { get; set; }
        public bool IsDeletedSender { get; set; }
        public bool IsDeletedReceiver { get; set; }
        public int Duration { get; set; }


        public int TypeMessage { get; set; }

        [ForeignKey(nameof(SenderId))]
        [InverseProperty(nameof(ApplicationDbUser.Sender))]
        public virtual ApplicationDbUser Sender { get; set; }
        [ForeignKey(nameof(ReceiverId))]
        [InverseProperty(nameof(ApplicationDbUser.Receiver))]
        public virtual ApplicationDbUser Receiver { get; set; }
        [ForeignKey(nameof(FKOrder))]
        [InverseProperty(nameof(TableDb.Orders.Messages))]
        public virtual Orders Order { get; set; }

    }
}
