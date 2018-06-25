using Teste.Services.Entity.Client;
using System.ServiceModel;

namespace API.Integration.Wcf.Interfaces.Operations
{
    [ServiceContract]
    public interface IClientOperation
    {
        [OperationContract]
        ClientInfo SyncClientInformation(ClientInfo clientInfo, decimal debit = 0, bool useCache = false);
    }
}
