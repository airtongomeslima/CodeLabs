using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ModeloDDD.Aplicacao.Interfaces;
using AutoMapper;
using ModeloDDD.DTO;
using ModeloDDD.Dominio.Entitades;

namespace ModeloDDD.Servicos.API.Controllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ClienteController : Controller
    {
        protected IClienteAppServico _servico;

        public ClienteController(IClienteAppServico servico)
        {
            _servico = servico;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<ClienteDTO> Get()
        {
            var pagamentos = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteDTO>>(_servico.ObterTodos());

            return pagamentos;
        }

        // GET api/values/5
        [HttpGet("Filtro")]
        public IEnumerable<ClienteDTO> Get(string filtro)
        {
            var pagamentos = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteDTO>>(
                _servico.FiltrarCliente(filtro)
                );

            return pagamentos;
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
