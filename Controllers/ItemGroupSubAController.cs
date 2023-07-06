using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WMS.Models;
using WMS.Repository;
using WMS.ViewModels;

namespace WMS.Controllers
{
    public class ItemGroupSubAController : Controller
    {
        //...مستودع البيانات الخاص بعمليات مجموعة الاصناف الفرعية أ
        private readonly IInvSysRepository<ItemGroup> itemGroupSubArepository;



        public ItemGroupSubAController(IInvSysRepository<ItemGroup> itemGroupSubArepository)
        {
            this.itemGroupSubArepository = itemGroupSubArepository;
        }


        public ActionResult ItemGroupList(int id, ItemGroup itemGroup)
        {
            itemGroup = itemGroupSubArepository.Find(id);

            var itemGroupSubAList = itemGroupSubArepository.List().Where(r => r.Ranking == 2 && r.ParentGroupId == itemGroup.Id);

            ViewData["navbarText"] = "مجموعة الاصناف الفرعية أ";
            return View("Index", itemGroupSubAList);
        }


        public ActionResult Index()
        {
            var itemGroupSubA = itemGroupSubArepository.List().Where(r => r.Ranking == 2);
            ViewData["navbarText"] = "مجموعة الاصناف الفرعية أ";

            return View(itemGroupSubA);
        }



        //... انشاء او تعديل مجموعة الاصناف الفرعية أ 
        // GET: ItemGroupSubAController/AddOrEdit
        public ActionResult AddOrEdit(int id = 0)
        {
            var itemGroupList = itemGroupSubArepository.List();
            List<ItemGroup> itemGroupM;
            itemGroupM = itemGroupList.Where(p => p.Ranking == 1 && p.Status == true).ToList();
            itemGroupM.Insert(0, new ItemGroup { Id = -1, GroupName = "" });

            ViewData["ItemGroupId1"] = new SelectList(itemGroupM, "Id", "GroupName");

            if (id == 0)
            {
                var model = new ItemGroupViewModels
                {
                    ParentGroup = itemGroupSubArepository.List().ToList()
                };
                return View(model);
            }

            else
            {
                var itemGroupSubA = itemGroupSubArepository.Find(id);
                var Viewmodel = new ItemGroupViewModels
                {
                    GroupId = itemGroupSubA.Id,
                    GroupName = itemGroupSubA.GroupName,
                    Description = itemGroupSubA.Description,
                 //   Code = itemGroupSubA.Code,
                    Ranking = itemGroupSubA.Ranking,
                    Status = itemGroupSubA.Status,
                   ParentGroupId = itemGroupSubA.ParentGroupId,
                    ParentGroup = itemGroupSubArepository.List().ToList()
                };
                return View(Viewmodel);
            }
        }


        // POST: ItemGroupSubAController/AddOrEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrEdit(int id, ItemGroup itemGroupSubA)
        {
            try
            {
                if (id != itemGroupSubA.Id)
                {
                    itemGroupSubArepository.Add(itemGroupSubA);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    itemGroupSubArepository.Edit(id, itemGroupSubA);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
            }
        }

    }
}
