using DDD_TDD_Dapper_Exemplo.Dominio.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace DDD_TDD_Dapper_Exemplo.Infra.Dados.Repositorios
{
    public class RepositorioBase<TEntity> : IDisposable, IRepositorioBase<TEntity> where TEntity : class
    {
        protected Contexto.Contexto contexto;

        public RepositorioBase(IConfiguration config)
        {
            contexto = new Contexto.Contexto(config);
        }

        public void Adiciona(TEntity obj)
        {
            contexto.Insert<TEntity>(obj);
        }

        public void Atualizar(TEntity obj)
        {
            contexto.Update<TEntity>(obj);
        }

        public TEntity GetPorId(int id)
        {
            return contexto.Find<TEntity>(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return contexto.ReadAll<TEntity>();
        }

        public void Remover(int id)
        {
            contexto.Delete<TEntity>(id);
        }

        public void Dispose()
        {
            contexto.Dispose();
        }
    }
}
