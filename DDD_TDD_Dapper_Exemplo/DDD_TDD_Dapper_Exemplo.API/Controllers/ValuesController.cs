using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DDD_TDD_Dapper_Exemplo.Infra.Dados.Repositorios;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using DDD_TDD_Dapper_Exemplo.API.Models;
using DDD_TDD_Dapper_Exemplo.Dominio.Entidades;

namespace DDD_TDD_Dapper_Exemplo.API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private static IConfiguration _config;

        private readonly ClienteRepositorio _clienteRepositorio = new ClienteRepositorio(_config);

        public ValuesController(IConfiguration config)
        {
            _config = config;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<ClienteModel> Get()
        {
            var clienteview = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteModel>>(_clienteRepositorio.ObterTodos());
            
            return clienteview;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
