using Teste.Services.Entity.Client;

namespace API.Services.Facades.Interfaces
{
    public interface IArquiteturaExemploIntegracaoLegadoFacade
    {
        ClientInfo BuscarClientePorId(int id);
    }
}
