using API.Integration.Wcf.Interfaces;
using API.Services.Facades.Interfaces;
using Teste.Services.Entity.Client;

namespace API.Services.Facades
{
    public class ArquiteturaExemploIntegracaoLegadoFacade : IArquiteturaExemploIntegracaoLegadoFacade
    {
        readonly IClienteIntegration _clienteIntegration;

        public ArquiteturaExemploIntegracaoLegadoFacade(IClienteIntegration clienteIntegration)
        {
            _clienteIntegration = clienteIntegration;
        }

        public ClientInfo BuscarClientePorId(int id) => _clienteIntegration.BuscarClientePorId(id);
    }
}
