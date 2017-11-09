using ModeloDDD.Aplicacao.Interfaces;
using ModeloDDD.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;

namespace ModeloDDD.Aplicacao
{
    public class AppServicoBase<TEntity> : IDisposable, IAppServicoBase<TEntity> where TEntity : class
    {
        private readonly IServicoBase<TEntity> _servicoBase;

        public AppServicoBase(IServicoBase<TEntity> servicoBase)
        {
            _servicoBase = servicoBase;
        }

        public void Adicionar(TEntity obj)
        {
            _servicoBase.Adicionar(obj);
        }

        public void Atualizar(TEntity obj)
        {
            _servicoBase.Atualizar(obj);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return _servicoBase.ObterTodos();
        }

        public TEntity ObterPorId(int id)
        {
            return _servicoBase.ObterPorId(id);
        }

        public void Remover(TEntity obj)
        {
            _servicoBase.Remover(obj);
        }

        public void Dispose()
        {
            _servicoBase.Dispose();
        }
    }
}
