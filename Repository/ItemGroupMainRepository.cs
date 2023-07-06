using WMS.Data;
using WMS.Models;

namespace WMS.Repository
{
    public class ItemGroupMainRepository : IInvSysRepository<ItemGroup>
    {
        private readonly AppDbContext db;

        public ItemGroupMainRepository(AppDbContext _db)
        {
            db = _db;
        }

        public void Add(ItemGroup entity)
        {
            db.ItemGroups.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var itemGroup = Find(id);
            db.ItemGroups.Remove(itemGroup);
            db.SaveChanges();
        }

        public void Edit(int id, ItemGroup newEntity)
        {
            var itemGroup = Find(id);
            itemGroup.GroupName = newEntity.GroupName;
            itemGroup.Description = newEntity.Description;
            // قم بتحديث أي خصائص أخرى تحتاج إلى تحديثها
            db.SaveChanges();
        }

        public ItemGroup Find(int id)
        {
            return db.ItemGroups.SingleOrDefault(u => u.Id == id);
        }

        public IList<ItemGroup> List()
        {
            return db.ItemGroups.ToList();
        }

        public List<ItemGroup> ListByFilter(Func<ItemGroup, bool> filter)
        {
            return db.ItemGroups.Where(filter).ToList();
        }
    }
}
