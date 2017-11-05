using System.Collections.Generic;

namespace ModeloDDD.Aplicacao.Interfaces
{
    public interface IAppServicoBase<TEntity> where TEntity : class
    {
        void Adicionar(TEntity obj);
        IEnumerable<TEntity> ObterTodos();
        TEntity ObterPorId(int id);
        IEnumerable<TEntity> Where(string param);
        void Atualizar(TEntity obj);
        void Remover(int id);
        void Dispose();
    }
}
