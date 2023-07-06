using Microsoft.AspNetCore.Mvc;

namespace WMS.Controllers
{
    public class ExaminationController : Controller
    {
        public IActionResult Index()
        {
            //IEnumerable<Examination> Examinations = new List<Examination>();
            ////shops = context.Shops.ToList();
            return View();
        }
        [HttpGet]
        public IActionResult AddExamination()
        {
            return View();
        } 
        public IActionResult EditExamination()
        {
            return View();
        }
        [HttpGet]
        // [ValidateAntiForgeryToken]
       
        public IActionResult Refrigerators()
        {
            return View();
        }
        public IActionResult DetailsExamination()
        {
            return View();
        }

        public IActionResult ViolationsIndex()
        {

            //IEnumerable<Examination> Examinations = new List<Examination>();

            return View();


        }
        [HttpGet]
        public IActionResult AddOrEditViolations()
        {
            return View();
        }
        
        public IActionResult WetPlaces()
        {
            return View();
        }  
        public IActionResult Delete()
        {
            return View();
        }
      //  [HttpPost]
        //[ValidateAntiForgeryToken]
     
    }
}
