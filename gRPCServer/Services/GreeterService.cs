using Grpc.Core;
using Google.Protobuf.WellKnownTypes;

namespace Server.Services;

public class GreeterService : Greeter.GreeterBase
{
    public GreeterService(){}

    public override Task<User> GetUserById(GetUserRequest request, ServerCallContext context)
    {
        return Task.FromResult(new User
        {
            Id = 1,
            FirstName = "Name",
            LastName = "LastName"
        });
    }

    public override Task<BigArray> GetArray(Empty request, ServerCallContext context)
    {
        var response = new BigArray();
        for (int i = 0; i < 1000; i++) response.Array.Add(1);
        return Task.FromResult(response);
    }
    public override Task<BigObject> GetBigObj(Empty request, ServerCallContext context)
    {
        var response = new BigObject();
        for (int i = 0; i < 1000; i++)
        {
            response.Array.Add(i);
            response.BigStr.Add("abcdf");
        }
        return Task.FromResult(response);
    }
}
