using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WMS.Data;
using WMS.Models;
using WMS.Repository;

namespace WMS.Repositories
{
    public class MainRepository<T>:IRepository<T> where T : class
    {
        private readonly AppDbContext db;

        public MainRepository(AppDbContext db)
        {
            this.db = db;
        }

        public T Add(T obj)
        {
            var res = db.Add(obj);
            db.SaveChanges();
            return (T)res.Entity;           
        }

        public T Delete(T obj)
        {
           var res= db.Set<T>().Remove(obj);
           
            db.SaveChanges();
            return (T)res.Entity;
            
        }

        public List<T> GetAll()
        {
           return db.Set<T>().ToList();
        }
        public List<T> Find(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().Where(exp).ToList();
        }
        public T GetById(int id)
        {
            return db.Find<T>(id);
        }

        public T Update(T obj)
        {
            var res = db.Set<T>().Update(obj);
            db.SaveChanges();
            return (T)res.Entity;
        }
        
        public static implicit operator MainRepository<T>(MainRepository<BaseModel> v)
        {
            return new MainRepository<T>(v.db);
        }

       
    }
}
