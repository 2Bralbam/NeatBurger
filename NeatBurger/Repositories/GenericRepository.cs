using NeatBurger.Models.Entities;

namespace NeatBurger.Repositories
{
    public class GenericRepository <T> where T : class
    {
        private readonly NeatContext _context;
        public GenericRepository(NeatContext context)
        {
            _context = context;
        }
        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }
        public virtual T? GetId(object Id)
        {
            return _context.Find<T>(Id);
        }
        public virtual void Update(T obj)
        {
            _context.Set<T>().Update(obj);
            _context.SaveChanges();
        }
        public virtual void Insert(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
        }
        public virtual void Delete(T obj)
        {
            _context.Set<T>().Remove(obj);
            _context.SaveChanges();
        }
        public virtual void Delete(object Id)
        {
            var entity = GetId(Id);
            if (entity != null)
            {
                Delete(entity);
            }
            _context.SaveChanges();
        }
    }
}
