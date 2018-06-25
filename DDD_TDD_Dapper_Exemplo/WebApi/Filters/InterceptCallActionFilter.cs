using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using API.CrossCutting.Api;
using System.Linq;
using System.Threading.Tasks;

namespace API.WebApi.Filters
{
    public class InterceptCallActionFilter : ActionFilterAttribute
    {
        const string KEY_ACTION_ARGUMENTS = "value";
        readonly ILoggerFactory _loggerFactory;
        readonly ILogger _logger;

        public InterceptCallActionFilter(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger("API.WebApi.Filters.InterceptCallActionFilter");
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string parametros = string.Empty;

            if (context.ActionArguments.Any())
                parametros = JsonConvert.SerializeObject(context.ActionArguments.FirstOrDefault().Value);

            var controller = context.Controller.ToString();
            var verbo = context.ActionDescriptor.DisplayName;

            _logger.LogInformation($"Controller -> {controller} : Action -> {verbo} : \nPayload -> {parametros}");

            await base.OnActionExecutionAsync(context, next);
        }

        public async override Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (context.Result.GetType() != typeof(Microsoft.AspNetCore.Mvc.EmptyResult))
            {
                var contextResult = (Microsoft.AspNetCore.Mvc.ObjectResult)context.Result;

                var resultado = JsonConvert.SerializeObject(contextResult.Value);

                _logger.LogInformation($"Output -> {resultado}");

                var response = HttpResult<object>.Success(contextResult.Value);

                context.Result = response;
            }

            await base.OnResultExecutionAsync(context, next);
        }
    }
}

