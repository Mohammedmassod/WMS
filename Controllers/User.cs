using Microsoft.AspNetCore.Mvc;

namespace WMS.Controllers
{
    public class User : Controller
    {
        public IActionResult Index()
        {
            return View();
        } 
        
        public IActionResult AddOrEdit()
        {
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }
    }
}
