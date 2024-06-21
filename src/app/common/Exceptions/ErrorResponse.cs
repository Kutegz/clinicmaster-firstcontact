
namespace ClinicMasterFirstContact.src.App.Common.Exceptions;

public sealed record ErrorResponse
{
    public required int StatusCode { get; init; }
    public required string Title { get; init; }
    public required string ErrorMessage { get; init; }
    public required string TraceId { get; init; }
}
