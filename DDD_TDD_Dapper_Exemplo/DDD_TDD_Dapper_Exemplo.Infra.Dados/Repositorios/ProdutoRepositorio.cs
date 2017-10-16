using System.Collections.Generic;
using DDD_TDD_Dapper_Exemplo.Dominio.Entidades;
using DDD_TDD_Dapper_Exemplo.Dominio.Interfaces;
using Microsoft.Extensions.Configuration;

namespace DDD_TDD_Dapper_Exemplo.Infra.Dados.Repositorios
{
    public class ProdutoRepositorio : RepositorioBase<Produto>, IProdutoRepositorio
    {
        public ProdutoRepositorio(IConfiguration config) : base(config)
        {
        }

        public IEnumerable<Produto> BuscaPorNome(string nome)
        {
            return contexto.Where<Produto>($"Nome = {nome}");
        }
    }
}
