using System;
using System.Runtime.Serialization;

namespace Teste.Services.Entity.Client
{
    [DataContract]
    [Serializable()]
    public class ClientInfo
    {
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public string CPF { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}
