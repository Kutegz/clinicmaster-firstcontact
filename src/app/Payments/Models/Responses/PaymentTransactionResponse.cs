
namespace ClinicMasterFirstContact.src.App.Payments.Models.Responses;
public sealed record PaymentTransactionResponse 
{
    public required string Id {get; init;}
    public required decimal Amount {get; init;}
    public required string Country {get; init;}
    public required string Currency {get; init;}
    public static PaymentTransactionResponse Empty => new() 
    {
        Id = string.Empty,
        Amount = 0,
        Country = string.Empty,
        Currency = string.Empty,
    };

}

  