using System.Collections.Generic;
using ModeloDDD.Aplicacao.Interfaces;
using ModeloDDD.Dominio.Entitades;
using ModeloDDD.Dominio.Interfaces.Servicos;

namespace ModeloDDD.Aplicacao
{
    public class ClienteAppServico : AppServicoBase<Cliente>, IClienteAppServico
    {
        private readonly IClienteServico _servico;

        public ClienteAppServico(IClienteServico servico) : base(servico)
        {
            _servico = servico;
        }

        public IEnumerable<Cliente> FiltrarCliente(string filtro)
        {
            return _servico.FiltrarCliente(filtro);
        }
    }
}
