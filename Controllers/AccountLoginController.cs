using Microsoft.AspNetCore.Mvc;
using WMS.Models;
using WMS.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;

namespace WMS.Controllers
{
    public class AccountLoginController : Controller
    {
        private readonly SignInManager<Users> signInManager;
        private readonly UserManager<Users> userManager;
        private readonly IDataProtectionProvider _dataProtectionProvider;


        public AccountLoginController(SignInManager<Users> signInManager, UserManager<Users> userManager, IDataProtectionProvider dataProtectionProvider)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            _dataProtectionProvider = dataProtectionProvider;

        }
        //دالة التي :، يمكن استخدام عنوان IP العام للجهاز كمعرف، وذلك باستخدام الكود التالي:
        private string GetDeviceId()
        {
            var ipAddress = HttpContext.Connection.RemoteIpAddress;
            return ipAddress.ToString();
            // استخدام معرف ملف تعريف المستخدم (User Agent) الخاص بالمتصفح كمعرف للجهاز
            /* var userAgent = HttpContext.Request.Headers["User-Agent"].ToString();
                return userAgent;*/
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if (ModelState.IsValid)
            {
                /*var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: true);*/
                var result = await signInManager.PasswordSignInAsync(login.UserName, login.Password, login.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    // store the user name in session
                    var user = await userManager.FindByNameAsync(login.UserName);
                    if (user != null && await userManager.CheckPasswordAsync(user, login.Password))
                    {
                        // Check if user is already logged in from another browser
                        var existingDeviceId = HttpContext.Session.GetString("DeviceId");
                        if (!string.IsNullOrEmpty(existingDeviceId) && existingDeviceId != GetDeviceId())
                        {
                            ModelState.AddModelError(string.Empty, "تم تسجيل الدخول من جهاز آخر، يرجى تسجيل الدخول مرة أخرى.");
                            return View(login);
                        }
                        HttpContext.Session.SetString("deviceId", GetDeviceId());

                        string Name = (user.Name);
                        string PhoneNumber = (user.PhoneNumber);
                        int OfficeId = (user.OfficeId);
                        // Store the protected values in the session
                        HttpContext.Session.SetString("Name", Name);
                        HttpContext.Session.SetString("PhoneNumber", PhoneNumber);
                        HttpContext.Session.SetInt32("OfficeId", OfficeId);
                    }


                    return RedirectToAction("Index", "Home");
                }
                //اذا تقفل الحساب ماذا يفعل النظام
                if (result.IsLockedOut)
                {
                    /*var forgotPassLink = Url.Action(nameof(ForgotPassword), "Account", new { }, Request.Scheme);
                    var content = string.Format("Your account is locked out, to reset your password, please click this link: {0}", forgotPassLink);
                    var message = new Message(new string[] { userModel.Email }, "Locked out account information", content, null);
                    await _emailSender.SendEmailAsync(message);*/
                    ModelState.AddModelError("", "تم قفل الحساب");
                    return View();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "اسم المستخدم او كلمة السر خطاء ");
                    return View(login);
                }

            }
            else
            {
                Console.WriteLine("in else in login user");
                return View(login);
            }
            //return View();
        }

        public async Task<ActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("id");
            HttpContext.Session.Remove("Name");
            HttpContext.Session.Remove("PhoneNumber");

            ViewBag.Message = "لقد تم تسجيل الخروج";
            return RedirectToAction("Login", "AccountLogin");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
