using Teste.Services.Entity.Client;

namespace API.Integration.Wcf.Interfaces
{
    public interface IClienteIntegration
    {
        ClientInfo BuscarClientePorId(int id);
    }
}
