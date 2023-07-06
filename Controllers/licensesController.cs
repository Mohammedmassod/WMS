using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WMS.Controllers
{
    public class licensesController : Controller
    {
        // GET: licensesController
        public IActionResult Index()
        {
            return View();
        } 
        public IActionResult StoreDetails()
        {
            return View();
        } 
        public IActionResult PrintStoreDetails()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Addlicenses()
        {
            return View();
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Addlicenses(licenses model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        licenses newlicenses = new licenses();
        //        newlicenses = model;

        //        context.Shops.Add(newshop);
        //        context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}
        public IActionResult RepackingLicenseIndex()
        {
            //IEnumerable<licenses> licensess = new List<licenses>();
            ////shops = context.Shops.ToList();
            return View();
        }
        public IActionResult DetailsRepackingLicenses()
        {
            //IEnumerable<licenses> licensess = new List<licenses>();
            ////shops = context.Shops.ToList();
            return View();
        }
        public IActionResult PrintDetailsRepacking()
        {
            //IEnumerable<licenses> licensess = new List<licenses>();
            ////shops = context.Shops.ToList();
            return View();
        }
        [HttpGet]
        public IActionResult AddOrEditRepacking()
        {
            return View();
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        ////public IActionResult AddOrEditRepacking(licenses model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        licenses newlicenses = new licenses();
        //        newlicenses = model;

        //        // context.Shops.Add(newshop);
        //        context.SaveChanges();
        //        return RedirectToAction("RepackingLicenseIndex");
        //    }
        //    return View();
        //}

        public IActionResult SelectionItem()
        {
            //IEnumerable<licenses> licensess = new List<licenses>();
            ////shops = context.Shops.ToList();
            return View();
        }
        [HttpGet]
        public IActionResult AddOrEditItem()
        {
            return View();
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        ////public IActionResult AddOrEditItem(licenses model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        licenses newlicenses = new licenses();
        //        newlicenses = model;

        //        // context.Shops.Add(newshop);
        //        context.SaveChanges();
        //        return RedirectToAction("SelectionItem");
        //    }
        //    return View();
        //}

       
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        ////public IActionResult AddOrEditViolations(licenses model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        licenses newlicenses = new licenses();
        //        newlicenses = model;

        //        // context.Shops.Add(newshop);
        //        context.SaveChanges();
        //        return RedirectToAction("ViolationsIndex");
        //    }
        //    return View();
        //}
    }
}
