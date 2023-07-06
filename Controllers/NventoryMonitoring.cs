using Microsoft.AspNetCore.Mvc;

namespace WMS.Controllers
{
    public class NventoryMonitoring : Controller
    {
        public IActionResult Index()
        {
            return View();
        } 
        public IActionResult Add()
        {
            return View();
        }    
        public IActionResult Details()
        {
            return View();
        } 
        public IActionResult SelectionItem()
        {
            return View();
        }   
        public IActionResult AddOrEditItem()
        {
            return View();
        }  
        public IActionResult PrintDetails()
        {
            return View();
        }
    }
}
