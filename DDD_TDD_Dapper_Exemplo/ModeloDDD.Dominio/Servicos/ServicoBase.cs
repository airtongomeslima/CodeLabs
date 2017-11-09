using ModeloDDD.Dominio.Interfaces.Repositorios;
using ModeloDDD.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;

namespace ModeloDDD.Dominio.Servicos
{
    public class ServicoBase<TEntity> : IDisposable, IServicoBase<TEntity> where TEntity : class
    {
        private readonly IRepositorioBase<TEntity> _repositorio;

        public ServicoBase(IRepositorioBase<TEntity> repositorio)
        {
            _repositorio = repositorio;
        }

        public void Adicionar(TEntity obj)
        {
            _repositorio.Adicionar(obj);
        }

        public TEntity ObterPorId(int id)
        {
            return _repositorio.ObterPorId(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return _repositorio.ObterTodos();
        }

        public void Remover(TEntity obj)
        {
            _repositorio.Remover(obj);
        }

        public void Atualizar(TEntity obj)
        {
            _repositorio.Atualizar(obj);
        }

        public void Dispose()
        {
            _repositorio.Dispose();
        }
    }
}
