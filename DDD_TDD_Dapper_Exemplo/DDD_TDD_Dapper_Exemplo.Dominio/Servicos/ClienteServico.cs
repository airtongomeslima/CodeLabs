using DDD_TDD_Dapper_Exemplo.Dominio.Entidades;
using DDD_TDD_Dapper_Exemplo.Dominio.Interfaces.Servicos;
using DDD_TDD_Dapper_Exemplo.Dominio.Interfaces.Repositorios;
using System.Collections.Generic;
using System.Linq;

namespace DDD_TDD_Dapper_Exemplo.Dominio.Servicos
{
    public class ClienteServico : ServicoBase<Cliente>, IClienteServico
    {
        private IClienteRepositorio _clienteRepositorio;

        public ClienteServico(IClienteRepositorio clienteRepositorio) 
            : base(clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public IEnumerable<Cliente> ObterClientesEspeciais(IEnumerable<Cliente> clientes)
        {
            return clientes.Where(c => c.ClienteEspecial(c));
        }
    }
}
