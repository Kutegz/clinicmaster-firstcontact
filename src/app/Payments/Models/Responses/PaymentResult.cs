namespace App.Payments.Models.Responses;
public sealed record PaymentResult<TResponse> {
    public required bool Success {get; init;}
    public required string Message {get; init;}
    public required TResponse Data {get; init;}

}
