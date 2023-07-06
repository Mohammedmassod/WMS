using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WMS.Data;
using WMS.Models;
using WMS.Repositories;
using WMS.Repository;

namespace WMS.Controllers
{
    public class ItemGroupMainController : Controller
    {

        //...مستودع البيانات الخاص بعمليات مجموعة الاصناف الرئيسية
        private readonly IInvSysRepository<ItemGroup> itemGrouprepository;
        private readonly AppDbContext _context;
        private readonly MainRepository<ItemGroup> repo;
        private readonly MainRepository<Sector> sectorRepo;

        public ItemGroupMainController(IInvSysRepository<ItemGroup> itemGrouprepository,AppDbContext context,MainRepository<BaseModel> repo,MainRepository<BaseModel> sectorRepo)
        {
            this.itemGrouprepository = itemGrouprepository;
            this._context = context;
            this.repo = repo;
            this.sectorRepo = sectorRepo;
        }


        // GET: ItemGroupMain
        public IActionResult Index()
        {
            ViewData["navbarText"] = "مجموعة الاصناف الرئيسية";

            // var itemGroupM = itemGrouprepository.List().Where(r => r.Ranking == 1 && r.Id == null);
            //var itemGroupM = repo.GetAll().Where(r => r.Ranking == 1 && r.Id == null).ToList();
            var itemGroupM = repo.Find(r => r.Ranking == 1 );
            

            return View(itemGroupM);
        }



        //... انشاء او تعديل مجموعة الاصناف الرئيسية 
        // GET: RuleController/AddOrEdit
        public IActionResult AddOrEdit(int id = 0)
        {
            var itemGroupM = repo.GetById(id);
            if (itemGroupM == null)
            {

                 itemGroupM = new ItemGroup();
                return View(itemGroupM);
            }

            else
            {
               
                
                return View(itemGroupM);
            }
        }

        // POST: RuleController/AddOrEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit( ItemGroup obj)
        {
           // var itemGroup= repo.GetById(obj.Id);

            if (obj.Id==0)
            {
                var sectors = sectorRepo.GetAll().FirstOrDefault();
                obj.SectorId = sectors.SectorId;
                var itemGroupAdd = repo.Add(obj);
                


                //_context.ItemGroups.Add(itemGroupM);
                //_context.SaveChanges();
                //itemGrouprepository.Add(itemGroupM);
                return RedirectToAction(nameof(Index));
            }
            else
            {
               var itemGroupEdit= repo.Update( obj);
                return RedirectToAction(nameof(Index));
            }
        }


    }
}

