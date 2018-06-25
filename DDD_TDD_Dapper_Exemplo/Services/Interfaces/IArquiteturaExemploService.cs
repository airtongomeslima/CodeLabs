using API.Data.SqlServer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services.Interfaces
{
    public interface IArquiteturaExemploService
    {
        ArquiteturaExemplo BuscarExemploPorId(int id);
        IList<ArquiteturaExemplo> BuscarTodosExemplos();
        Task AdicionarExemplo(string nome, string descricao);
        Task AtualizarExemplo(int id, string nome, string descricao);
        Task ExcluirExemploPorId(int id);
    }
}
