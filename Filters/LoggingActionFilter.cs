using Microsoft.AspNetCore.Mvc.Filters;

namespace EfCorePracticeApiNet10.Filters
{
    public class LoggingActionFilter : IActionFilter
    {
        private readonly ILogger<LoggingActionFilter> _logger;

        public LoggingActionFilter(ILogger<LoggingActionFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var method = context.HttpContext.Request.Method;
            var path = context.HttpContext.Request.Path;
            var time = DateTime.Now.ToString("HH:mm:ss");
            _logger.LogInformation($"[{time}] Request started: {method} {path}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var statusCode = context.HttpContext.Response.StatusCode;
            _logger.LogInformation($"Request finished with status code: {statusCode}");
        }
    }
}
