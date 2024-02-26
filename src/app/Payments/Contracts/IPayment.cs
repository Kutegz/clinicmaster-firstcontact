
using App.Payments.Models.Requests;
using App.Payments.Models.Responses;

namespace App.Payments.Contracts;
public interface IPayment
{
    public Task<bool> UpdatePayment(PaymentFullRequest request);
    public Task<PaymentResult<PaymentResponse>> GetPayment(string billNo);
    public Task<PaymentResult<IEnumerable<PaymentResponse>>> GetPayments(int page, int pageSize);
}