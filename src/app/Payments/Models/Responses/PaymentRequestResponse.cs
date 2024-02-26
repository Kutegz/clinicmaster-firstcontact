
namespace App.Payments.Models.Responses;
public sealed record PaymentRequestResponse 
{
    public required string Ref {get; init;}
    public required int Msisdn {get; init;}
    public required PaymentTransactionResponse Transaction {get; init;}
    public static PaymentRequestResponse Empty => new() 
    {
        Ref = string.Empty,
        Msisdn = 0,
        Transaction = PaymentTransactionResponse.Empty,
    };
}

  