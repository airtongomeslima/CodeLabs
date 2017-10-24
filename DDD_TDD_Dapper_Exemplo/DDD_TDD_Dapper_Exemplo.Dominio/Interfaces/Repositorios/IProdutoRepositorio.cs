using DDD_TDD_Dapper_Exemplo.Dominio.Entidades;
using System.Collections.Generic;

namespace DDD_TDD_Dapper_Exemplo.Dominio.Interfaces.Repositorios
{
    public interface IProdutoRepositorio : IRepositorioBase<Produto>
    {
        IEnumerable<Produto> BuscaPorNome(string nome);
    }
}
