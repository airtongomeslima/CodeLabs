using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DDD_TDD_Dapper_Exemplo.Aplicacao.Interfaces;
using DDD_TDD_Dapper_Exemplo.Dominio.Entidades;
using AutoMapper;
using DDD_TDD_Dapper_Exemplo.API.Models;

namespace DDD_TDD_Dapper_Exemplo.API.Controllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Authorize]
    public class ProdutosController : Controller
    {
        protected IProdutoAppServico _servico;

        public ProdutosController(IProdutoAppServico produtoServico)
        {
            _servico = produtoServico;
        }

        [HttpGet]
        public IEnumerable<ProdutoModel> Get()
        {
            var produtos = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoModel>>(_servico.GetAll());
            return produtos;
        }

        [HttpGet("Get/{id}")]
        public ProdutoModel Get(int id)
        {
            var produto = Mapper.Map<Produto, ProdutoModel>(_servico.GetbyId(id));
            return produto;
        }
        
        [HttpPost]
        public void Post([FromBody]ProdutoModel produto)
        {
            var _produto = Mapper.Map<ProdutoModel, Produto>(produto);
            _servico.Adicionar(_produto);
        }
        
        [HttpPut("{id}")]
        public void Put([FromBody]ProdutoModel produto)
        {
            var _produto = Mapper.Map<ProdutoModel, Produto>(produto);
            _servico.Atualizar(_produto);
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _servico.Remover(id);
        }
    }
}
