using API.Data.SqlServer.Entities;
using API.Domain.Infrastructure.Data.Interfaces;
using System.Collections.Generic;

namespace API.Domain.Repositories.Interfaces
{
    public interface IArquiteturaExemploRepository : IBaseRepository
    {
        ArquiteturaExemplo BuscarExemploPorId(int id);
        IList<ArquiteturaExemplo> BuscarTodosExemplos();
        void AdicionarExemplo(ArquiteturaExemplo arquiteturaExemplo);
        void AtualizarExemplo(ArquiteturaExemplo arquiteturaExemplo);
        void ExcluirExemploPorId(int id);
    }
}
