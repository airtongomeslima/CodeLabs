using System.Collections.Generic;

namespace DDD_TDD_Dapper_Exemplo.Dominio.Interfaces.Servicos
{
    public interface IServicoBase<TEntity> where TEntity : class
    {
        void Adicionar(TEntity obj);
        IEnumerable<TEntity> GetAll();
        void Atualizar(TEntity obj);
        void Remover(int id);
        void Dispose();
    }
}
