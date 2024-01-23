namespace App.Surgeries.Models;
public sealed record SurgeryResult<TResponse> {
    public required bool Success {get; init;}
    public required string Message {get; init;}
    public required TResponse Data {get; init;}

}
