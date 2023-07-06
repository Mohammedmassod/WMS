using System.Linq.Expressions;

namespace WMS.Repository
{
    public interface IRepository<T>
    {
        public T Add(T obj);
        public T GetById(int id);
        public List<T> GetAll();
        public List<T> Find(Expression<Func<T, bool>> exp);
        public T Update(T obj);
        public T Delete(T obj);
    }
}
