using ModeloDDD.Dominio.Entitades;
using ModeloDDD.Dominio.Interfaces.Servicos;
using ModeloDDD.Dominio.Interfaces.Repositorios;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ModeloDDD.Dominio.Servicos
{
    public class ClienteServico : ServicoBase<Cliente>, IClienteServico
    {
        private IClienteRepositorio _repositorio;

        public ClienteServico(IClienteRepositorio repositorio) : base(repositorio)
        {
            _repositorio = repositorio;
        }
        
        public IEnumerable<Cliente> FiltrarCliente(string filtro)
        {
            var pagamentos = _repositorio.Where($"");
            if (!string.IsNullOrEmpty(filtro))
            {
                var tsult = pagamentos.SelectMany(t => t.GetType().ToString());

                var result =
                        pagamentos.Where(t => t.GetType().GetProperties()
                        .Any(a => a.GetValue(t) != null && a.GetValue(t, null).ToString().ToUpper().Contains(filtro.ToUpper()))
                        )
                        .ToList();
                return result;
            }

            return pagamentos;
        }
    }
}
