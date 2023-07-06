using System.ComponentModel.DataAnnotations;

namespace WMS.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage ="يرجى ادخال اسم المستخدم")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "يرجى ادخال كلمة السر")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; } = false;
    }
}
