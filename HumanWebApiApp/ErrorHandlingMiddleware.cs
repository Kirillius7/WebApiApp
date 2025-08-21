namespace HumanWebApiApp
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorEventHandler> logger;

        public ErrorHandlingMiddleware(RequestDelegate _requestDelegate, 
            ILogger<ErrorEventHandler> _logger)
        {
            _next = _requestDelegate;
            logger = _logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                logger.LogInformation("Request: {method}, {url}",
                    context.Request.Method, context.Request.Path);

                await _next(context);
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Unhandled exception");

                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync($"{{\"error\": \"{ex.Message}\"}}");
            }
        }
    }
}
