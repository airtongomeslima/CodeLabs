using System;
using System.Collections.Generic;
using System.Text;

namespace DDD_TDD_Dapper_Exemplo.Aplicacao.Interfaces
{
    public interface IAppServicoBase<TEntity> where TEntity : class
    {
        void Adicionar(TEntity obj);
        IEnumerable<TEntity> GetAll();
        TEntity GetbyId(int id);
        void Atualizar(TEntity obj);
        void Remover(int id);
        void Dispose();
    }
}
