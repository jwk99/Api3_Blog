namespace Api3_Blog.Middleware
{
    public class RequestLoggingMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleWare> _logger;
        public RequestLoggingMiddleWare(RequestDelegate next, ILogger<RequestLoggingMiddleWare> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext ctx)
        {
            _logger.LogInformation("{m} {p}", ctx.Request.Method, ctx.Request.Path);
            await _next(ctx);
        }
    }
}
