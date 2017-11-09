using Microsoft.Extensions.Configuration;
using ModeloDDD.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModeloDDD.Infra.Dados.Respositorio
{
    public class RepositorioBase<TEntity> : IDisposable, IRepositorioBase<TEntity> where TEntity : class
    {
        protected Contexto.ContextoEF contexto;

        public RepositorioBase(IConfiguration config)
        {
            contexto = new Contexto.ContextoEF(config);
        }

        public void Adicionar(TEntity obj)
        {
            contexto.Add<TEntity>(obj);
        }

        public void Atualizar(TEntity obj)
        {
            contexto.Update<TEntity>(obj);
        }

        public TEntity ObterPorId(int id)
        {
            return contexto.Find<TEntity>(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return contexto.Set<TEntity>();
        }

        public void Remover(TEntity obj)
        {
            contexto.Remove<TEntity>(obj);
        }

        public void Dispose()
        {
            contexto.Dispose();
        }
    }
}
