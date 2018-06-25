using Microsoft.Extensions.Configuration;
using API.Integration.Wcf.Interfaces;
using API.Integration.Wcf.Interfaces.Operations;
using Teste.Services.Entity.Client;

namespace API.Integration.Wcf
{
    public class ClienteIntegration : IClienteIntegration
    {
        IConfiguration _config;

        public ClienteIntegration(IConfiguration config)
        {
            _config = config;
        }

        IClientOperation _wcfCliente;
        private IClientOperation WcfCliente
        {
            get
            {
                return _wcfCliente ?? 
                    (_wcfCliente = WcfChannel.CreateChannel<IClientOperation>
                    (_config.GetSection("WcfCliente").Value, WcfChannel.WcfBinding.NetTcpBinding));
            }
        }

        public ClientInfo BuscarClientePorId(int id)
        {
            var clientInfoDto = WcfCliente.SyncClientInformation(new ClientInfo { ClientId = id });

            _wcfCliente.CloseChannel();

            return clientInfoDto;
        }
    }
}
