using Microsoft.AspNetCore.Mvc;

namespace WMS.Controllers
{
    public class RestrictedStoreController : Controller
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
        public IActionResult AddStore()
        {
            return View();
        }
        public IActionResult AddStoreRepacking()
        {
            return View();
        } 
        public IActionResult AddRepacking()
        {
            return View();
        } 
        public IActionResult RepackingIndex()
        {
            return View();
        } 
        public IActionResult StoreAthorizationCertificate()
        {
            return View();
        } 
        public IActionResult PrintStoreAthorizationCertificate()
        {
            return View();
        }
    }
}
