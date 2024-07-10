
namespace ClinicMasterFirstContact.src.App.Common.Models.Responses;
public sealed record ResultResponse<TResponse>
{
    public required bool Success {get; init;}
    public required int Count {get; init;}
    public required string Message {get; init;}
    public required TResponse Data {get; init;}
}
