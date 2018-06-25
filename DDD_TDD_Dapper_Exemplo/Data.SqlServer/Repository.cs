using Microsoft.EntityFrameworkCore;
using API.Data.SqlServer.Interfaces;
using System;
using System.Linq;

namespace API.Data.SqlServer
{
    public class Repository<T> : IDisposable, IRepository<T> where T : class
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Queryable => _context.Set<T>();

        public void Delete(T model)
        {
            _context.Set<T>().Remove(model);
        }

        public void Add(T model)
        {
            _context.Set<T>().Add(model);
        }

        public void Update(T modelNew)
        {
            _context.Entry(modelNew).State = EntityState.Modified;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

