using WMS.Data;
using WMS.Models;
using WMS;
using Microsoft.EntityFrameworkCore;


namespace WMS.Repository
{
    public class ItemTypeRepository : IInvSysRepository<ItemType>
    {
        private readonly AppDbContext db;

        public ItemTypeRepository(AppDbContext db)
        {
            this.db = db;
        }

        public void Add(ItemType entity)
        {
            db.ItemTypes.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var itemType = Find(id);
            db.ItemTypes.Remove(itemType);
            db.SaveChanges();
        }

        public void Edit(int id, ItemType newEntity)
        {
            var existingEntity = Find(id);
            if (existingEntity != null)
            {
              //  existingEntity.Property1 = newEntity.Property1; // استبدال Property1 بالخاصيات الفعلية لكائن ItemType
              //  existingEntity.Property2 = newEntity.Property2; // استبدال Property2 بالخاصيات الفعلية لكائن ItemType
                // تحديث المزيد من الخصائص حسب الحاجة
                db.SaveChanges();
            }
        }

        public ItemType Find(int id)
        {
            var itemType = db.ItemTypes.SingleOrDefault(u => u.TypeId == id);
            return itemType;
        }

        public IList<ItemType> List()
        {
            return db.ItemTypes.ToList();
        }

        public List<ItemGroup> ListByFilter(Func<ItemGroup, bool> filter)
        {
            throw new NotImplementedException();
        }
    }
}
