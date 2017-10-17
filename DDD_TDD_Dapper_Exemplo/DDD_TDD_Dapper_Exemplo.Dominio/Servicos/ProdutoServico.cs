using DDD_TDD_Dapper_Exemplo.Dominio.Entidades;
using DDD_TDD_Dapper_Exemplo.Dominio.Interfaces.Repositorios;
using DDD_TDD_Dapper_Exemplo.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD_TDD_Dapper_Exemplo.Dominio.Servicos
{
    public class ProdutoServico : ServicoBase<Produto>, IProdutoServico
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoServico(IProdutoRepositorio produtoRepositorio) 
            : base(produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public IEnumerable<Produto> BuscaPorNome(string nome)
        {
            return _produtoRepositorio.BuscaPorNome(nome);
        }
    }
}
