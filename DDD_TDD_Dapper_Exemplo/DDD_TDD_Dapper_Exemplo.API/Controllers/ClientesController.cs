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
    public class ClientesController : Controller
    {
        protected IClienteAppServico _servico;

        public ClientesController(IClienteAppServico clienteServico)
        {
            _servico = clienteServico;
        }

        [HttpGet]
        public IEnumerable<ClienteModel> Get()
        {
            var clientes = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteModel>>(_servico.GetAll());
            return clientes;
        }

        [HttpGet("Get/{id}")]
        public ClienteModel Get(int id)
        {
            var cliente = Mapper.Map<Cliente, ClienteModel>(_servico.GetbyId(id));
            return cliente;
        }
        
        [HttpPost]
        public void Post([FromBody]ClienteModel cliente)
        {
            var _cliente = Mapper.Map<ClienteModel, Cliente>(cliente);
            _servico.Adicionar(_cliente);
        }
        
        [HttpPut("{id}")]
        public void Put([FromBody]ClienteModel cliente)
        {
            var _cliente = Mapper.Map<ClienteModel, Cliente>(cliente);
            _servico.Atualizar(_cliente);
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _servico.Remover(id);
        }
    }
}
