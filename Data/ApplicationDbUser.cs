using KhadimiEssa.Data.TableDb;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Data
{
    public class ApplicationDbUser : IdentityUser
    {
        public ApplicationDbUser()
        {
            ContactUs = new HashSet<ContactUs>();
            NotifyClient = new HashSet<NotifyClient>();
            NotifyDelegt = new HashSet<NotifyDelegt>();
            DeviceId = new HashSet<DeviceId>();
            Sender = new HashSet<Messages>();
            Receiver = new HashSet<Messages>();
            ConnectUser = new HashSet<ConnectUser>();
            HistoryNotify = new HashSet<HistoryNotify>();
            Orders = new HashSet<Orders>();
            OrdersP = new HashSet<Orders>();
            UserInvitations = new HashSet<UserInvitation>();

        }
        public bool ActiveCode { get; set; } = false;
        public bool IsActive { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
        public int Code { get; set; } = 1234;
        public string ShowPassword { get; set; }
        public string Lang { get; set; } = "ar";  //اللغه هتكون عند اليوزر وتكون عربى فى الاول - وتتغير بسيرفس
        public DateTime PublishDate { get; set; } = DateTime.Now;
        //تم اضافته لتعامل مع السيرفس اما 
        //UuserName  ده هنساويه بال email
        public string user_Name { get; set; } //= first_name + " " + last_name;
        public int TypeUser { get; set; } //Client = 1  //deleget = 2 //org_delget = 3//Admin = 4

        public bool CloseNotify { get; set; } = false; //تفعيل الاشعار
        public string ImgProfile { get; set; } = "";
        public string InvitationCode { get; set; } = "";
        public double Wallet { get; set; }

        public int? OilStationId { get; set; }



        // for billing
        //[Required(ErrorMessage = "من فضلك ادخل اسم الشارع")]
        public string Street { get; set; }
        //[Required(ErrorMessage = "من فضلك ادخل اسم المدينة")]
        public string City { get; set; }
        //[Required(ErrorMessage = "من فضلك ادخل اسم المنطقة")]
        public string State { get; set; }
        //[RegularExpression("[A-Z]{2}", ErrorMessage = "ادخل كود الدولة بشكل صحيح مثال : SA")]
        public string Country { get; set; }
        //[Required(ErrorMessage = "من فضلك ادخل الرمز البريدي")]
        public string PostCode { get; set; }
         

        //Relation
        [ForeignKey(nameof(OilStationId))]
        public virtual OilStation OilStation { get; set; }

        //ContactUs >> user  m>> o
        public virtual ICollection<ContactUs> ContactUs { get; set; }

        //DevieId >> user  m>> o
        [InverseProperty(nameof(Data.TableDb.DeviceId.user))]
        public virtual ICollection<DeviceId> DeviceId { get; set; }
        //notifyclient >> user  m>> o
        public virtual ICollection<NotifyClient> NotifyClient { get; set; }
        //notifyDelegt >> user m>> o
        public virtual ICollection<NotifyDelegt> NotifyDelegt { get; set; }

        [InverseProperty(nameof(Data.TableDb.RateDelget.Deleget))]
        public virtual ICollection<RateDelget> Delget { get; set; }

        [InverseProperty(nameof(Data.TableDb.RateDelget.ApplicationDbUser))]
        public virtual ICollection<RateDelget> Client { get; set; }

        public virtual ICollection<Messages> Sender { get; set; }
        public virtual ICollection<Messages> Receiver { get; set; }

        [InverseProperty(nameof(TableDb.Orders.User))]
        public virtual ICollection<Orders> Orders { get; set; }
        [InverseProperty(nameof(TableDb.Orders.Provider))]
        public virtual ICollection<Orders> OrdersP { get; set; }
        public virtual ICollection<ConnectUser> ConnectUser { get; set; }

        public virtual ICollection<HistoryNotify> HistoryNotify { get; set; }

        [InverseProperty(nameof(TableDb.UserInvitation.User))]
        public virtual ICollection<UserInvitation> UserInvitations { get; set; } 
        
       

    }
}
