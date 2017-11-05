using Microsoft.Extensions.Configuration;
using ModeloDDD.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;

namespace ModeloDDD.Infra.Dados.Respositorio
{
    public class RepositorioBase<TEntity> : IDisposable, IRepositorioBase<TEntity> where TEntity : class
    {
        protected Contexto.Contexto contexto;

        public RepositorioBase(IConfiguration config)
        {
            contexto = new Contexto.Contexto(config);
        }

        public void Adicionar(TEntity obj)
        {
            contexto.Inserir<TEntity>(obj);
        }

        public void Atualizar(TEntity obj)
        {
            contexto.Atualizar<TEntity>(obj);
        }

        public TEntity ObterPorId(int id)
        {
            return contexto.ObterPorId<TEntity>(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return contexto.LerTudo<TEntity>();
        }

        public IEnumerable<TEntity> Where(string param)
        {
            return contexto.Where<TEntity>(param);
        }

        public void Remover(int id)
        {
            contexto.Deletar<TEntity>(id);
        }

        public void Dispose()
        {
            contexto.Dispose();
        }
    }
}
