using Service;
using Serilog;
using Server.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGrpc(options =>
{
    options.Interceptors.Add<LoggerInterceptor>();
});

var logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .Enrich.FromLogContext()
        .CreateLogger();

builder.Logging.AddSerilog(logger);


var app = builder.Build();
app.MapGrpcService<GreeterService>();

app.Run();

