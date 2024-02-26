
using App.Common.Utils;
using App.Payments.Contracts;

namespace App.Payments.Models.Responses;
public sealed record PaymentResponse : PaymentBase<PaymentContentSentResponse> {
    public static PaymentResponse Empty => new() 
    {
        BillNo = string.Empty,
        PayNo = string.Empty,
        PayType = string.Empty,
        ContentSent =  PaymentContentSentResponse.Empty,
        CreatedBy = string.Empty,
        CreatedAt = DateTime.Parse(Constants.NullDateTimeString),
        Completed = false,
    };

}

