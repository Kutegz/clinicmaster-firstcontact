
using App.Common.Utils;
using App.Payments.Contracts;

namespace App.Payments.Models.Responses;
public sealed record PaymentRowData : PaymentBase<string> 
{
    public static PaymentRowData Empty => new() 
    {
        BillNo = string.Empty,
        PayNo = string.Empty,
        PayType = string.Empty,
        ContentSent =  string.Empty,
        CreatedBy = string.Empty,
        CreatedAt = DateTime.Parse(CommonConstants.NullDateTimeString),
        Completed = false,
    };
}
