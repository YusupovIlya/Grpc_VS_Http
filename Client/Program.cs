using Grpc.Net.Client;
using Server;
using Google.Protobuf.WellKnownTypes;
using BenchmarkDotNet.Attributes;

//const string host = "https://localhost:7139";
//HttpClient httpClient = new HttpClient();
//httpClient.GetAsync($"{host}/users/1");

//BenchmarkRunner.Run<TestsGRPC>();
//BenchmarkRunner.Run<TestsREST>();
const string host = "https://localhost:7200";
Greeter.GreeterClient client = new Greeter.GreeterClient(GrpcChannel.ForAddress(host));
var r = await client.GetArrayAsync(new Empty());
Console.WriteLine(r.Array[0]);

[MemoryDiagnoser]
public class TestsGRPC
{
    const string host = "https://localhost:7200";
    Greeter.GreeterClient client = new Greeter.GreeterClient(GrpcChannel.ForAddress(host));

    [Benchmark]
    public async Task GetUserByGrpc()
    {
        await client.GetUserByIdAsync(new GetUserRequest { Id = 1 });
    }

    [Benchmark]
    public async Task GetArrayByGrpc()
    {
        await client.GetArrayAsync(new Empty());
    }

    [Benchmark]
    public async Task GetBigObjByGrpc()
    {
        await client.GetBigObjAsync(new Empty());
    }
}

[MemoryDiagnoser]
public class TestsREST
{
    const string host = "https://localhost:7187";
    private HttpClient httpClient = new HttpClient();

    [Benchmark]
    public async Task GetUserByRest()
    {
        await httpClient.GetAsync($"{host}/users/1");
    }
    [Benchmark]
    public async Task GetArrayByRest()
    {
        await httpClient.GetAsync($"{host}/array");
    }
    [Benchmark]
    public async Task GetBigObjByRest()
    {
        await httpClient.GetAsync($"{host}/bigobject");
    }
}
