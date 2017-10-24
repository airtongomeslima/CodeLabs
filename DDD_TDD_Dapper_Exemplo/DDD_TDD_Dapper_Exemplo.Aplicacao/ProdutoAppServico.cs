using DDD_TDD_Dapper_Exemplo.Aplicacao.Interfaces;
using DDD_TDD_Dapper_Exemplo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using DDD_TDD_Dapper_Exemplo.Dominio.Interfaces.Servicos;

namespace DDD_TDD_Dapper_Exemplo.Aplicacao
{
    public class ProdutoAppServico : AppServicoBase<Produto>, IProdutoAppServico
    {
        protected IProdutoServico _produtoAppServico;

        public ProdutoAppServico(IProdutoServico produtoAppServico) : base(produtoAppServico)
        {
            _produtoAppServico = produtoAppServico;
        }

        public IEnumerable<Produto> BuscaPorNome(string nome)
        {
            return _produtoAppServico.BuscaPorNome(nome);
        }
    }
}
