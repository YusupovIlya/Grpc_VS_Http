using Grpc.Core;
using Grpc.Core.Interceptors;

namespace Service;

public class LoggerInterceptor : Interceptor
{
    private readonly ILogger _logger;

    public LoggerInterceptor(ILogger<LoggerInterceptor> logger)
    {
        _logger = logger;
    }

    public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
        TRequest request,
        ServerCallContext context,
        UnaryServerMethod<TRequest, TResponse> continuation)
    {
        _logger.LogInformation($"Request from host {context.Peer} on method: {context.Method}");
        return await continuation(request, context);
    }
}
