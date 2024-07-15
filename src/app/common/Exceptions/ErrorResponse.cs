
namespace ClinicMasterFirstContact.src.App.Common.Exceptions;
public sealed record ErrorResponse
{
    public required string Title { get; init; }
    public required int Status { get; init; }
    public required string Message { get; init; }
    public required string TraceId { get; init; }
    public static ErrorResponse Empty => new() 
    {
        Title = string.Empty,
        Status = 0,
        Message = string.Empty,
        TraceId = string.Empty
    };
}
