
namespace ClinicMasterFirstContact.src.App.Payments.Models.Responses;
public sealed record PaymentContentSentResponse 
{
    public required string Service {get; init;} 
    public required PaymentRequestResponse Request {get; init;}
    public static PaymentContentSentResponse Empty => new() 
    {
        Service = string.Empty,
        Request = PaymentRequestResponse.Empty,
    };
}
