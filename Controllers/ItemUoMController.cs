using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WMS.Models;
using WMS.Repository;

namespace WMS.Controllers
{
    public class ItemUoMController : Controller
    {
        private readonly IInvSysRepository<ItemUnit> itemUoMrepository;
        private readonly IInvSysRepository<Item> itemrepository;


        public ItemUoMController(IInvSysRepository<ItemUnit> itemUoMrepository, IInvSysRepository<Item> itemrepository)
        {
            this.itemUoMrepository = itemUoMrepository;
            this.itemrepository = itemrepository;
        }


        //... عرض بيانات حسابات المستخدمين
        //[Route("وحدات القياس")]
        public ActionResult Index(int pg = 1, string SearchText = "", int RowCounter = 0)
        {
            //ViewData["navbarText"] = "وحدات القياس";

            //var itemUoM = itemUoMrepository.List();

            //var MainUoM = itemUoM.Max(a => a.Quaintity);

            //ViewBag.MainUoM = MainUoM;

            //var rowCounter = RowCounter;

            //const int pageSize = 5;

            //if (pg < 1)
            //    pg = 1;

            //int recsCount = itemUoM.Count();

            //var pager = new Pager(recsCount, pg, pageSize);

            //int recSkip = (pg - 1) * pageSize;

            //var data = itemUoM.Skip(recSkip).Take(pager.PageSize).ToList();

            //this.ViewBag.Pager = pager;

            ////return View(users);
            return View();
        }
    }
}

