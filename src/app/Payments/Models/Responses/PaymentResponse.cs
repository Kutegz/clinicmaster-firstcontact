
using ClinicMasterFirstContact.src.App.Common.Utils;
using ClinicMasterFirstContact.src.App.Payments.Contracts;

namespace ClinicMasterFirstContact.src.App.Payments.Models.Responses;
public sealed record PaymentResponse : PaymentBase<PaymentContentSentResponse> {
    public static PaymentResponse Empty => new() 
    {
        BillNo = string.Empty,
        PayNo = string.Empty,
        PayType = string.Empty,
        ContentSent =  PaymentContentSentResponse.Empty,
        CreatedBy = string.Empty,
        CreatedAt = DateTime.Parse(CommonConstants.NullDateTimeString),
        Completed = false,
    };

}

