using System.Collections.Generic;

namespace ModeloDDD.Dominio.Interfaces.Servicos
{
    public interface IServicoBase<TEntity> where TEntity : class
    {
        void Adicionar(TEntity obj);
        IEnumerable<TEntity> ObterTodos();
        TEntity ObterPorId(int id);
        void Atualizar(TEntity obj);
        void Remover(TEntity obj);
        void Dispose();
    }
}
