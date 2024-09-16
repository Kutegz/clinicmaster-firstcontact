
namespace ClinicMasterFirstContact.src.App.Common.Models.Responses;

public sealed record CreatedResponse
{
    public required bool Success {get; init;}
    public required int StatusCode { get; init; }
    public required int Count {get; init;}
    public required string Message {get; init;}
    public required string Location {get; init;}
}
