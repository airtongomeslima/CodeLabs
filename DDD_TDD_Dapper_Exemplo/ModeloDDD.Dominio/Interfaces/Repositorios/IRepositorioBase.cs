using System.Collections.Generic;

namespace ModeloDDD.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioBase<TEntity> where TEntity : class
    {
        void Adicionar(TEntity obj);
        TEntity ObterPorId(int id);
        IEnumerable<TEntity> ObterTodos();
        IEnumerable<TEntity> Where(string param);
        void Atualizar(TEntity obj);
        void Remover(int id);
        void Dispose();
    }
}
