using API.Data.SqlServer.Interfaces;
using API.Data.SqlServer.Entities;

namespace API.Domain.Infrastructure.Data.Interfaces
{
    public interface ITesteUnitOfWork : IUnitOfWork
    {
        IRepository<ArquiteturaExemplo> ArquiteturaExemploRepository { get; }
    }
}
