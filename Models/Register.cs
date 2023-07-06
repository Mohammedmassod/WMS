using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WMS.Models
{
    public class Register
    {
        [Required(ErrorMessage = "يرجى إدخال الايميل ")]
        [EmailAddress]
        [Display(Name = "  ادخل الإيميل")]
        public string Email { get; set; }


        [Required(ErrorMessage ="يرجى إدخال كلمة المرور")]
        [DataType(DataType.Password)]
        [Display(Name = "ادخل كلمة المرور")]
        public string Password { get; set; }


        [Required(ErrorMessage = "يرجى تأكيد كلمة المرور")]
        [DataType(DataType.Password)]
        [Display(Name = "تأكيد كلمة المرور")]
        [Compare("Password",ErrorMessage ="كلمة المرور غير متطابقة")]
        public string ConfirmPassword { get; set; }

       [Required(ErrorMessage = "يرجى إدخال المحافظة ")]
        [Display(Name = "  ادخل المحافظة")]
        public int OfficeID { get; set; }



    }
}
