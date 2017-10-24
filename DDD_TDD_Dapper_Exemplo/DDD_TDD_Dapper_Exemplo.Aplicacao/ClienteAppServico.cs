using DDD_TDD_Dapper_Exemplo.Aplicacao.Interfaces;
using DDD_TDD_Dapper_Exemplo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using DDD_TDD_Dapper_Exemplo.Dominio.Interfaces.Servicos;

namespace DDD_TDD_Dapper_Exemplo.Aplicacao
{
    public class ClienteAppServico : AppServicoBase<Cliente>, IClienteAppServico
    {
        private readonly IClienteServico _clienteServico;

        public ClienteAppServico(IClienteServico clienteServico) : base(clienteServico)
        {
            _clienteServico = clienteServico;
        }

        public IEnumerable<Cliente> ObterClientesEspeciais()
        {
            return _clienteServico.ObterClientesEspeciais(_clienteServico.GetAll());
        }
    }
}
