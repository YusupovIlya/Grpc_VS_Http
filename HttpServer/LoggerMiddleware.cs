namespace HttpServer;

public class LoggerMiddleware
{
    private readonly RequestDelegate _next;
    ILogger<LoggerMiddleware> _logger;
    public LoggerMiddleware(RequestDelegate next, 
        ILogger<LoggerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        _logger.LogInformation($"Request from host {context.Request.Host} on endpoint {context.Request.Path}");
        await _next(context);
    }
}
