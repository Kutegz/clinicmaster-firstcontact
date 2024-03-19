namespace App.Surgeries.Models.Responses;
public sealed record SurgeryResult<TResponse> {
    public required bool Success {get; init;}
    public required string Message {get; init;}
    public required TResponse Data {get; init;}

}
