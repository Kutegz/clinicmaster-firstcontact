
namespace App.Common.Models.Responses;
public sealed record AgentsResponse
{
    public required string Consumers {get; init;}   
    public static AgentsResponse Empty => new() 
    {
        Consumers = string.Empty
    };

}