using Microsoft.AspNetCore.Mvc;
using WMS.Data;
using WMS.Models;
using WMS.Repositories;
using WMS.Repository;

namespace WMS.Controllers
{
    public class CountryOriginController : Controller
    {
        private readonly AppDbContext _context;
        private readonly MainRepository<OriginCountry> repo;

        public CountryOriginController(AppDbContext context,MainRepository<BaseModel> repo)
        {
            _context = context;
            this.repo = repo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var countryList= repo.GetAll();
            //List<OriginCountry> countries = _context.OriginCountries.ToList();

          //  return View(countries);
          return View(countryList);
        }

        [HttpGet]
        public IActionResult AddOrEdit()
        {
            OriginCountry newCountry = new OriginCountry();
            
            return PartialView("_AddCountryPartialView", newCountry);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(OriginCountry newCountry)
        {
            if(ModelState.IsValid)
            {
                var Country = new OriginCountry();
                Country.CountryName = newCountry.CountryName;
                Country.Description = newCountry.Description;
                var sectors = _context.Sectors.FirstOrDefault();
                Country.SectorId = sectors.SectorId;
               var repoAdd= repo.Add(Country);
                //_context.OriginCountries.Add(Country);
                //_context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return PartialView("_AddCountryPartialView", newCountry);
            }

        }
    }
}
