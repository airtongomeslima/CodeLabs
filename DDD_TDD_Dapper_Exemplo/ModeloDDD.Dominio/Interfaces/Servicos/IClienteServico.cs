using ModeloDDD.Dominio.Entitades;
using System;
using System.Collections.Generic;

namespace ModeloDDD.Dominio.Interfaces.Servicos
{
    public interface IClienteServico : IServicoBase<Cliente>
    {
        IEnumerable<Cliente> FiltrarCliente(string filtro);
    }
}
