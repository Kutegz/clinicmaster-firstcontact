
namespace App.Payments.Models.Requests;
public sealed record PaymentContentReceivedRequest 
{
    public required string SupplierNo {get; init;}
    public required string SupplierName {get; init;}
    public required decimal TotalAmount {get; init;}
    public required decimal TotalDiscount {get; init;}
    public required List<PaymentDetailsRequest> Details {get; init;}   
}
