using DDD_TDD_Dapper_Exemplo.Dominio.Entidades;
using System.Collections.Generic;

namespace DDD_TDD_Dapper_Exemplo.Aplicacao.Interfaces
{
    public interface IClienteAppServico : IAppServicoBase<Cliente>
    {
        IEnumerable<Cliente> ObterClientesEspeciais();
    }
}
