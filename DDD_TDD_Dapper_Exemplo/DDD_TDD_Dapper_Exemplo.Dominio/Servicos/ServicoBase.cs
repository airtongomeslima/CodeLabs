﻿using DDD_TDD_Dapper_Exemplo.Dominio.Interfaces.Repositorios;
using DDD_TDD_Dapper_Exemplo.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;

namespace DDD_TDD_Dapper_Exemplo.Dominio.Servicos
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
            _repositorio.Adiciona(obj);
        }
        
        public TEntity GetById(int id)
        {
            return _repositorio.GetPorId(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repositorio.ObterTodos();
        }

        public void Remover(int id)
        {
            _repositorio.Remover(id);
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
