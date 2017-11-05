using ModeloDDD.Dominio.Entitades;
using System;
using System.Collections.Generic;

namespace ModeloDDD.Aplicacao.Interfaces
{
    public interface IClienteAppServico : IAppServicoBase<Cliente>
    {
        IEnumerable<Cliente> FiltrarCliente(string filtro);
    }
}
