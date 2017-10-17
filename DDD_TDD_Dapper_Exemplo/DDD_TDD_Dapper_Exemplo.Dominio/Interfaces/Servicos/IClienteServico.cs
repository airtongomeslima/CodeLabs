using DDD_TDD_Dapper_Exemplo.Dominio.Entidades;
using System.Collections.Generic;

namespace DDD_TDD_Dapper_Exemplo.Dominio.Interfaces.Servicos
{
    public interface IClienteServico : IServicoBase<Cliente>
    {
        IEnumerable<Cliente> ObterClientesEspeciais(IEnumerable<Cliente> clientes);
    }
}
