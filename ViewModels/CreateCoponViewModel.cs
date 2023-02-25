using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.ViewModels
{
    public class CreateCoponViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "من فضلك هذا الحقل مطلوب")]
        [RegularExpression("([0-9]+)", ErrorMessage = "برجاء ادخال ارقام موجبة فقط")]
        public int Count { get; set; }// عدد المستفيدين 
        [Required(ErrorMessage = "من فضلك هذا الحقل مطلوب")]
        [RegularExpression("([0-9]+)", ErrorMessage = "برجاء ادخال ارقام موجبة فقط")]
        public int CountUsed { get; set; }// عدد استخدام الكوبون 
        [Required(ErrorMessage = "من فضلك هذا الحقل مطلوب")]
        public DateTime expirdate { get; set; }// تاريخ انتهاء الخصم
        [Required(ErrorMessage = "من فضلك هذا الحقل مطلوب")]
        public string CoponCode { get; set; } // 
        [Required(ErrorMessage = "من فضلك هذا الحقل مطلوب")]
        //[RegularExpression("([0-9]+)", ErrorMessage = "برجاء ادخال ارقام موجبة فقط")]
        public double Discount { get; set; }// نسبه ياعنى 20% 
        [Required(ErrorMessage = "من فضلك هذا الحقل مطلوب")]
        //[RegularExpression("([0-9]+)", ErrorMessage = "برجاء ادخال ارقام موجبة فقط")]
        public double limt_discount { get; set; } //حد اقصى للخصم مثلا 50 ريال
        public bool IsActive { get; set; }// يعامل معامله الحذف 
    }
}
