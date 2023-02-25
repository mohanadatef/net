
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Models.AuthModel
{
    public class RegisterDto
    {

        [Required(ErrorMessage = "من فضلك ادخل الاسم")]
        [Display(Name = "User Name")]
        public string userName { get; set; }


        //[Required(ErrorMessage = "من فضلك ادخل البريد الالكترونى")]
        //[EmailAddress(ErrorMessage = " من فضلك ادخل البريد الالكترونى بشكل صحيح")]
        //[Display(Name = "Email Address")]
        //[RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "من فضلك ادخل البريد الالكترونى بشكل صحيح")]
        //public string email { get; set; }


        [Required(ErrorMessage = "من فضلك ادخل رقم الجوال")]
        [Display(Name = "Phone Number")]
        //[RegularExpression(@"^(009665|9665|\+9665|05|5)(5|0|3|6|4|9|1|8|7)([0-9]{7})$", ErrorMessage = "من فضل ادخل رقم الجوال بشكل صحيح")]
        public string phone { get; set; }

        public string InvitationCode { get; set; }

        [Required(ErrorMessage = "من فضلك ادخل كلمة المرور")]
        [StringLength(100, ErrorMessage = "يجب ان تزيد كلمة المرور عن 6 ارقام", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }


        //[DataType(DataType.Password)]
        //[Display(Name = "Confirm password")]
        //[Compare("password", ErrorMessage = "يرجى التأكد من تطابق كلمتا المرور")]
        //public string confirmPassword { get; set; }



        [Required]
        public string deviceId { get; set; } = "";
        public string deviceType { get; set; }
        public string projectName { get; set; }



        //[Required(ErrorMessage = "من فضلك ادخل الدولة")]
        //[Display(Name = "Country")]
        //public int fk_country { get; set; }


        //[Required(ErrorMessage = "من فضلك ادخل المدينه")]
        //[Display(Name = "City")]
        //public int fk_city { get; set; }


        //[Required(ErrorMessage = "من فضلك ادخل المنطقه")]
        //[Display(Name = "Region")]
        //public int fk_regoin { get; set; }


        //[Required(ErrorMessage = "من فضلك ادخل الموقع")]
        //public string location { get; set; }

        //public string lat { get; set; }

        //public string lng { get; set; }



        /// <summary>
        ///ar or en
        /// </summary>

        public string lang { get; set; } = "ar";



        //[Required(ErrorMessage = "من فضلك ادخل الصورة الشخصية")]
        //public FormFile img { get; set; }



    }

    public class RegisterDelegetViewModel
    {
        [Required(ErrorMessage = "من فضلك ادخل الاسم")]
        [Display(Name = "User Name")]
        public string userName { get; set; }


        //[Required(ErrorMessage = "من فضلك ادخل البريد الالكترونى")]
        //[EmailAddress(ErrorMessage = " من فضلك ادخل البريد الالكترونى بشكل صحيح")]
        //[Display(Name = "Email Address")]
        //[RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "من فضلك ادخل البريد الالكترونى بشكل صحيح")]
        //public string email { get; set; }


        [Required(ErrorMessage = "من فضلك ادخل رقم الجوال")]
        [Display(Name = "Phone Number")]
        //[RegularExpression(@"^(009665|9665|\+9665|05|5)(5|0|3|6|4|9|1|8|7)([0-9]{7})$", ErrorMessage = "من فضل ادخل رقم الجوال بشكل صحيح")]
        public string phone { get; set; }



        [Required(ErrorMessage = "من فضلك ادخل كلمة المرور")]
        [StringLength(100, ErrorMessage = "يجب ان تزيد كلمة المرور عن 6 ارقام", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }

        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "يرجى التأكد من تطابق كلمتا المرور")]
        public string confirmPassword { get; set; }

        [Required(ErrorMessage = "من فضلك ادخل صورة المستخدم")]
        public IFormFile Img { get; set; }

        [Required(ErrorMessage = "من فضلك اختر المحطة")]

        public int oilStationId { get; set; } 

        //[Required]
        //public string deviceId { get; set; } = "";
        //public string deviceType { get; set; }
        //public string projectName { get; set; }

        /// <summary>
        ///ar or en
        /// </summary>

        public string lang { get; set; } = "ar";

    }

    public class EditDelegetViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = " من فضلك ادخل الاسم ")]
        public string userName { get; set; }

        [Required(ErrorMessage = "من فضلك ادخل رقم الجوال")]
        //[RegularExpression(@"^(009665|9665|\+9665|05|5)(5|0|3|6|4|9|1|8|7)([0-9]{7})$", ErrorMessage = "من فضل ادخل رقم الجوال بشكل صحيح")]
        public string phone { get; set; }
        public int? oilStationId { get; set; }

        public IFormFile ImgFormFile { get; set; }
        public string Img { get; set; }

       }
}
