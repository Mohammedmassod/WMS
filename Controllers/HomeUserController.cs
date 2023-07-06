using Microsoft.AspNetCore.Mvc;

namespace WMS.Controllers
{
    public class HomeUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
