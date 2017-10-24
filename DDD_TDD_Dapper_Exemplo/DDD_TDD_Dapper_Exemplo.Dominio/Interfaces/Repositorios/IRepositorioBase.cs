using System.Collections.Generic;

namespace DDD_TDD_Dapper_Exemplo.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioBase<TEntity> where TEntity : class
    {
        void Adiciona(TEntity obj);
        TEntity GetPorId(int id);
        IEnumerable<TEntity> ObterTodos();
        void Atualizar(TEntity obj);
        void Remover(int id);
        void Dispose();
    }
}
