
using App.Common.Models.Responses;
using App.Payments.Models.Requests;
using App.Payments.Models.Responses;

namespace App.Payments.Contracts;
public interface IPayment
{
    public Task<bool> UpdatePayment(PaymentFullRequest request);
    public Task<ResultResponse<PaymentResponse>> GetPayment(string billNo);
    public Task<ResultResponse<IEnumerable<PaymentResponse>>> GetPayments(int page, int pageSize);
}