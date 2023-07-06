using Microsoft.AspNetCore.Mvc;

namespace WMS.Controllers
{
    public class ItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        } 
        
        public IActionResult AddOrEdit()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult ItemDetails()
        {
            return View();
        }
    }
}
