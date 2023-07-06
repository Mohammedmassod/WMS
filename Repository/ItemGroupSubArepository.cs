using WMS.Models;
using WMS.Data;
using Microsoft.EntityFrameworkCore;

namespace WMS.Repository
{
    public class ItemGroupSubArepository : IInvSysRepository<ItemGroup>
    {
        private readonly AppDbContext db;

        public ItemGroupSubArepository(AppDbContext db)
        {
            this.db = db;
        }

        public void Add(ItemGroup entity)
        {
            db.ItemGroups.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var ItemGroupSubA = Find(id);
            db.ItemGroups.Remove(ItemGroupSubA);
            db.SaveChanges();
        }

        public void Edit(int id, ItemGroup newentity)
        {
            db.ItemGroups.Update(newentity);
            db.SaveChanges();
        }

        public ItemGroup Find(int id)
        {
            var ItemGroupSubA = db.ItemGroups.Include(a => a.ParentGroup)
                .SingleOrDefault(u => u.Id == id);
            return ItemGroupSubA;
        }

        public IList<ItemGroup> List()
        {
            return db.ItemGroups.Include(a => a.ParentGroup).ToList();
        }

        public List<ItemGroup> ListByFilter(Func<ItemGroup, bool> filter)
        {
            return db.ItemGroups.Include(a => a.ParentGroup).Where(filter).ToList();
        }
    }
}
