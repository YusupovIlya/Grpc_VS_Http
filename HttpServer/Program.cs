using HttpServer;
using Serilog;
using Server;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .Enrich.FromLogContext()
        .CreateLogger();

builder.Logging.AddSerilog(logger);

var app = builder.Build();


app.MapGet("/user/{id:int}", async (context) =>
{
    var user = new User { Id = 1, FirstName = "Name", LastName = "LastName" };
    await context.Response.WriteAsJsonAsync(user);
});

app.MapGet("/array", async (context) =>
{
    int[] mas = new int[1000];
    for (int i = 0; i < mas.Length; i++) mas[i] = 1;
    await context.Response.WriteAsJsonAsync(mas);
});

app.MapGet("/bigobject", async (context) =>
{
    BigObject obj = new BigObject();
    for (int i = 0; i < 1000; i++)
    {
        obj.Array.Add(i);
        obj.BigStr.Add("abcdf");
    }
    await context.Response.WriteAsJsonAsync(obj);
});

app.UseMiddleware<LoggerMiddleware>();

app.Run();
