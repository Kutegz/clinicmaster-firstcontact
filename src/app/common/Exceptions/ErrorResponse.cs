
namespace App.Common.Exceptions;

public sealed record ErrorResponse
{
    public required int StatusCode { get; set; }
    public required string Title { get; set; }
    public required string ErrorMessage { get; set; }
}
