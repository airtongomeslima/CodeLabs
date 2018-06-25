using Microsoft.AspNetCore.Mvc;
using API.Application;
using API.DTO;
using API.WebApi.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.WebApi.Controllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ArquiteturaExemploController : Controller
    {
        readonly ArquiteturaExemploApplication _arquiteturaExemploApplication;

        public ArquiteturaExemploController(ArquiteturaExemploApplication arquiteturaExemploApplication)
        {
            _arquiteturaExemploApplication = arquiteturaExemploApplication;
        }

        // GET api/values
        [HttpGet]
        [ServiceFilter(typeof(InterceptCallActionFilter))]
        public IList<ArquiteturaExemploDto> Get()
        {
            return _arquiteturaExemploApplication.BuscarTodosExemplos();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ServiceFilter(typeof(InterceptCallActionFilter))]
        public ArquiteturaExemploDto Get(int id)
        {
            return _arquiteturaExemploApplication.BuscarExemploPorId(id);
        }

        // POST api/values
        [HttpPost]
        [ServiceFilter(typeof(InterceptCallActionFilter))]
        public async Task Post([FromBody]ArquiteturaExemploDto value)
        {
            await _arquiteturaExemploApplication.AdicionarExemplo(value);
        }

        // PUT api/values/5
        [HttpPut()]
        [ServiceFilter(typeof(InterceptCallActionFilter))]
        public async Task Put([FromBody]ArquiteturaExemploDto value)
        {
            await _arquiteturaExemploApplication.AtualizarExemplo(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [ServiceFilter(typeof(InterceptCallActionFilter))]
        public async Task Delete(int id)
        {
            await _arquiteturaExemploApplication.ExcluirExemploPorId(id);
        }
    }
}
