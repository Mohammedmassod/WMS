using Microsoft.EntityFrameworkCore;
using WMS.Data;
using WMS.Models;

namespace WMS.Repository
{
    public class ItemRepository : IInvSysRepository<Item>
    {
        private readonly AppDbContext db;

        public ItemRepository(AppDbContext db)
        {
            this.db = db;
        }

        public void Add(Item entity)
        {
            db.Items.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = Find(id);
            db.Items.Remove(item);
            db.SaveChanges();
        }

        public void Edit(int id, Item newEntity)
        {
            throw new NotImplementedException();
        }

        //public void Edit(int id, Item newEntity)
        //{
        //    var existingEntity = Find(id);
        //    if (existingEntity != null)
        //    {
        //        existingEntity.Property1 = newEntity.Property1; // استبدال Property1 بالخاصيات الفعلية لكائن Item
        //        existingEntity.Property2 = newEntity.Property2; // استبدال Property2 بالخاصيات الفعلية لكائن Item
        //        // تحديث المزيد من الخصائص حسب الحاجة
        //        db.SaveChanges();
        //    }
        //}

        public Item Find(int id)
        {
            var item = db.Items.Include(a => a.OriginCountry)
                .Include(a => a.ItemUnits)
                .Include(a => a.ItemGroup)
                .SingleOrDefault(u => u.ItemId == id);
            return item;
        }

        public IList<Item> List()
        {
            return db.Items.Include(a => a.OriginCountry)
                .Include(a => a.ItemUnits)
                .Include(a => a.ItemGroup)
                .ToList();
        }

        public List<Item> ListByFilter(Func<Item, bool> filter)
        {
            return db.Items.Include(a => a.OriginCountry)
                .Include(a => a.ItemUnits)
                .Include(a => a.ItemGroup)
                .Where(filter)
                .ToList();
        }

        public List<ItemGroup> ListByFilter(Func<ItemGroup, bool> filter)
        {
            throw new NotImplementedException();
        }
    }
}
