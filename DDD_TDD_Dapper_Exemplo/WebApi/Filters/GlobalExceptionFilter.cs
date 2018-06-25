using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using API.CrossCutting.Api;

namespace API.WebApi.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        readonly ILoggerFactory _loggerfactory;
        readonly ILogger _logger;

        public GlobalExceptionFilter(ILoggerFactory loggerFactory)
        {
            _loggerfactory = loggerFactory;
            _logger = _loggerfactory.CreateLogger("API.WebApi.Filters.GlobalExceptionFilter");
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError($"{context.Exception}\n{context.Exception.StackTrace}");

            var response = HttpResult<object>.Error(-1, context.Exception.Message);

            context.Result = response;
        }
    }
}
