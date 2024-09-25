
namespace ClinicMasterFirstContact.src.App.Common.Models.Responses;
public sealed record ConsumerAgents
{
    public required string Consumers {get; init;}   
    public static ConsumerAgents Empty => new()
    {
        Consumers = string.Empty
    };
}