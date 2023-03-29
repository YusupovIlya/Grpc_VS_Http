using Grpc.Net.Client;
using Server;
using Google.Protobuf.WellKnownTypes;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

//BenchmarkRunner.Run<TestsGRPC>();
//BenchmarkRunner.Run<TestsREST>();
const string host = "http://192.168.162.191:3000";
Greeter.GreeterClient client = new Greeter.GreeterClient(GrpcChannel.ForAddress(host));
var response = await client.GetUserByIdAsync(new GetUserRequest { Id = 1 });
Console.WriteLine($"User from gRPC server = {response.Id} {response.FirstName} {response.LastName}");

[MemoryDiagnoser]
public class TestsGRPC
{
    const string host = "http://192.168.162.191:3000";
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
    const string host = "http://192.168.162.191:3000";
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
