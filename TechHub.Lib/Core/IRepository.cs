using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects;

namespace TechHub.Lib.Core
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IQueryable<T> GetQuery();
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Func<T, bool> predicate);
        T Single(Func<T, bool> predicate);
        T First(Func<T, bool> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Attach(T entity);
        void SaveChanges();
        void SaveChanges(SaveOptions options);
        void Update(T entity);
    }
}
