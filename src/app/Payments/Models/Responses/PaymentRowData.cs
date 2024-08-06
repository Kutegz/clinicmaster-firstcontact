using ClinicMasterFirstContact.src.App.Payments.Contracts;

namespace ClinicMasterFirstContact.src.App.Payments.Models.Responses;
public sealed record PaymentRowData : PaymentBase<string> 
{
    public static PaymentRowData Empty => new() 
    {
        BillNo = string.Empty,
        PayNo = string.Empty,
        PayType = string.Empty,
        ContentSent =  string.Empty,
        CreatedBy = string.Empty,
        CreatedAt = DateTime.MinValue,
        Completed = false,
    };
}
