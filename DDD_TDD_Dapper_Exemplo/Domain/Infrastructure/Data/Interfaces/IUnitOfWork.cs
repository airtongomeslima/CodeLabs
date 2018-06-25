using System.Threading.Tasks;

namespace API.Domain.Infrastructure.Data.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
