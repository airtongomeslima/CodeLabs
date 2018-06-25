using API.Data.SqlServer.Interfaces;
using API.Data.SqlServer;
using API.Data.SqlServer.Entities;
using API.Domain.Infrastructure.Data.Interfaces;
using System.Threading.Tasks;

namespace API.Domain.Infrastructure.Data
{
    public class TesteUnitOfWork : ITesteUnitOfWork
    {
        readonly TesteDbContext _TesteDbContext;

        public TesteUnitOfWork(TesteDbContext TesteDbContext)
        {
            _TesteDbContext = TesteDbContext;
        }

        IRepository<ArquiteturaExemplo> _arquiteturaExemploRepository;
        public IRepository<ArquiteturaExemplo> ArquiteturaExemploRepository
        {
            get
            {
                if (_arquiteturaExemploRepository == null)
                    _arquiteturaExemploRepository = new Repository<ArquiteturaExemplo>(_TesteDbContext);

                return _arquiteturaExemploRepository;
            }
        }

        public async Task CommitAsync()
        {
            await _TesteDbContext.SaveChangesAsync();
        }
    }
}
