using Microsoft.AspNetCore.Mvc;
using API.Application;
using API.WebApi.Filters;
using Teste.Services.Entity.Client;

namespace API.WebApi.Controllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ArquiteturaExemploIntegracaoController : Controller
    {
        readonly ArquiteturaExemploApplication _arquiteturaExemploApplication;

        public ArquiteturaExemploIntegracaoController(ArquiteturaExemploApplication arquiteturaExemploApplication)
        {
            _arquiteturaExemploApplication = arquiteturaExemploApplication;
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(InterceptCallActionFilter))]
        public ClientInfo Get(int id)
        {
            return _arquiteturaExemploApplication.BuscarClientePorId(id);
        }
    }
}