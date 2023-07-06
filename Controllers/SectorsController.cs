using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WMS.Data;
using WMS.Models;
using WMS.Repositories;

namespace WMS.Controllers
{
    public class SectorsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly MainRepository<Sector> sectorRepo;

        public SectorsController(AppDbContext context,MainRepository<BaseModel> sectorRepo)
        {
            _context = context;
            this.sectorRepo = sectorRepo;
        }
        [HttpGet]   
        public IActionResult Index()
        {
            List<Sector> sectors = sectorRepo.GetAll();

            return View(sectors);
        }

        [HttpGet]
        public IActionResult Create222()
        {
            Sector newSector = new Sector();
            return PartialView("_AddSectorPartialView", newSector);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create222(Sector newSector)
        {


            var Res = sectorRepo.Add(newSector);
            if(Res==null)
            {
                return PartialView("_AddSectorPartialView", newSector);
            }
            return RedirectToAction("Index");

            /*  if (newSector!=null)
              {
                  _context.Sectors.Add(newSector);
                  _context.SaveChanges();

                  TempData["positionTopEnd"] = "تم الحفظ بنجاح";
                  return RedirectToAction("Index");
              }
              else
              {
                  return PartialView("_AddSectorPartialView", newSector);
              }*/
        }
        [HttpGet]
        public IActionResult Edit222(int Id)
        {

            Sector sectorup = sectorRepo.GetById(Id);

            return PartialView("_EditSectorPartialView", sectorup);

                
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit222(Sector sectorup)
        {
            var sector = _context.Sectors.Find(sectorup.SectorId);
            sector.SectorName = sectorup.SectorName;
            sector.Discription = sectorup.Discription;

            var Res= sectorRepo.Update(sector);
            return RedirectToAction("Index");
        }
            //public IActionResult Edit222(Sector sectorup)
            //{
            //    if (ModelState.IsValid)
            //    {
            //        _context.Sectors.Update(sectorup);
            //        _context.SaveChanges();
            //        return RedirectToAction("Index");

            //    }
            //    else
            //    {   

            //        return View("_EditSectorPartialView");
            //    }

            //}


            [HttpGet]
        public IActionResult Delete(int Id)
        {

            Sector sectordel = sectorRepo.GetById(Id);

            return PartialView("_EditSectorPartialView", sectordel);


        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Sector sectordel)
        {
            var sect = sectorRepo.GetById(sectordel.SectorId);
            if (sect != null)
            {
                sectorRepo.Delete(sect);
                return RedirectToAction("Index");

            }
            else
            {

                ModelState.AddModelError("", "لا يمكن حذف هذا العنصر لأنه غير موجود في قاعدة البيانات.");
                return View("_DeleteSectorPartialView");
            }

        }


        public IActionResult OfficeIndex()
        {
            return View();
        } 
        public IActionResult OfficeAddOrEdit()
        {
            return View();
        }
    }
}
