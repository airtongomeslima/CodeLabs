using DDD_TDD_Dapper_Exemplo.Dominio.Entidades;
using System.Collections.Generic;

namespace DDD_TDD_Dapper_Exemplo.Dominio.Interfaces.Servicos
{
    public interface IProdutoServico : IServicoBase<Produto>
    {
        IEnumerable<Produto> BuscaPorNome(string nome);
    }
}
