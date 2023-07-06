using WMS.Data;
using WMS.Models;
using Microsoft.EntityFrameworkCore;


namespace WMS.Repository
{
    public class ItemGroupSubBrepository : IInvSysRepository<ItemGroup>
    {
        private readonly AppDbContext db;

        public ItemGroupSubBrepository(AppDbContext db)
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
            var ItemGroupSubB = Find(id);
            db.ItemGroups.Remove(ItemGroupSubB);
            db.SaveChanges();
        }

 public void Edit(int id, ItemGroup newentity)
        {
            db.ItemGroups.Update(newentity);
            db.SaveChanges();
        }
        public ItemGroup Find(int id)
        {
            var ItemGroupSubB = db.ItemGroups.Include(a => a.ParentGroup)
                .ThenInclude(a => a.ParentGroup)
                .SingleOrDefault(u => u.Id == id);
            return ItemGroupSubB;
        }

        public IList<ItemGroup> List()
        {
            return db.ItemGroups.Include(a => a.ParentGroup)
                .ThenInclude(a => a.ParentGroup)
                .ToList();
        }

        public List<ItemGroup> ListByFilter(Func<ItemGroup, bool> filter)
        {
            return db.ItemGroups.Include(a => a.ParentGroup)
                .ThenInclude(a => a.ParentGroup)
                .Where(filter)
                .ToList();
        }
    }
}
