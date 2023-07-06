using Microsoft.AspNetCore.Mvc;

namespace WMS.Controllers
{
    public class ProductPricing : Controller
    {
        public IActionResult Index()
        {
            return View();
        }    
        public IActionResult AddPricing()
        {
            return View();
        }
    }
}
