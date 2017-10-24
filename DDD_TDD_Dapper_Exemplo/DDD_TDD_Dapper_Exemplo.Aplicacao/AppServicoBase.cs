using DDD_TDD_Dapper_Exemplo.Aplicacao.Interfaces;
using DDD_TDD_Dapper_Exemplo.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;

namespace DDD_TDD_Dapper_Exemplo.Aplicacao
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

        public IEnumerable<TEntity> GetAll()
        {
            return _servicoBase.GetAll();
        }
        
        public TEntity GetbyId(int id)
        {
            return _servicoBase.GetById(id);
        }

        public void Remover(int id)
        {
            _servicoBase.Remover(id);
        }

        public void Dispose()
        {
            _servicoBase.Dispose();
        }
    }
}
