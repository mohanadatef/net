using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.ViewModels
{
    public class CoponViewModel
    {
        public int ID { get; set; }

        public int Count { get; set; }// عدد المستفيدين 

        public int CountUsed { get; set; }// عدد استخدام الكوبون 
        public string expirdate { get; set; }// تاريخ انتهاء الخصم
        public string CoponCode { get; set; } // 

        public double Discount { get; set; }// نسبه ياعنى 20% 

        public double limt_discount { get; set; } //حد اقصى للخصم مثلا 50 ريال
        public bool IsActive { get; set; }// يعامل معامله الحذف 
    }
}
