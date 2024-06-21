
namespace ClinicMasterFirstContact.src.App.Payments.Models.Requests;
public sealed record PaymentRequest 
{
    public required string GRNNo {get; init;}
    public required DateTime ReceivedDate {get; init;}
    public required PaymentContentReceivedRequest ContentReceived {get; init;}   
}

