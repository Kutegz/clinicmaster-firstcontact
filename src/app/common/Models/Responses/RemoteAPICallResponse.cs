
namespace ClinicMasterFirstContact.src.App.Common.Models.Responses;
public sealed record RemoteAPICallResponse<TResponse>
{
    public required bool Success {get; init;}
    public required int StatusCode { get; init; }
    public required string Message {get; init;}
    public required TResponse Data {get; init;}
}
