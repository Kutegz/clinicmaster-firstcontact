
namespace App.Common.Models.Responses;
public sealed record ConsumerAgentsResponse
{
    public required string Consumers {get; init;}   
    public static ConsumerAgentsResponse Empty => new()
    {
        Consumers = string.Empty
    };

}