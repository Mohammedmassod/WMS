using WMS.Data;
using WMS.Models;
using WMS.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WMS.Repository
{
    public class ItemUoMRepository : IInvSysRepository<Unit>
    {
        private readonly AppDbContext _db;

        public ItemUoMRepository(AppDbContext db)
        {
            _db = db;
        }

        public void Add(Unit entity)
        {
            _db.Units.Add(entity);
            _db.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var itemUoM = Find(id);
            _db.Remove(itemUoM);
            _db.SaveChangesAsync();
        }

        public void Edit(int id, Unit newEntity)
        {
            var itemUoM = Find(id);
            itemUoM.Name = newEntity.Name; // تغيير الخصائص المطلوبة للكيان الحالي
            itemUoM.Abbreviation = newEntity.Abbreviation;
            itemUoM.Packagings = newEntity.Packagings;
            // قم بتحديث الخصائص الأخرى حسب الحاجة

            _db.SaveChanges();
        }

        public Unit Find(int id)
        {
            var itemUoM = _db.Units.SingleOrDefault(u => u.Id == id);
            return itemUoM;
        }

        public IList<Unit> List()
        {
            return _db.Units.Include(a => a.ItemUnits).Include(a => a.Abbreviation).ToList();
    
        }

        public List<ItemGroup> ListByFilter(Func<ItemGroup, bool> filter)
        {
            throw new NotImplementedException();
        }
    }
}
