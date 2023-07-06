using Microsoft.AspNetCore.Mvc;

namespace WMS.Controllers
{
    public class RuleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddOrEdit()
        {
            return View();
        } 
        public IActionResult Delete()
        {
            return View();
        }
    }
}
