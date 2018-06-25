using System;
using System.Linq;

namespace API.Data.SqlServer.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IQueryable<T> Queryable { get; }
        void Delete(T model);
        void Add(T model);
        void Update(T modelNew);
    }
}
