
using ClinicMasterFirstContact.src.App.Common.Models.Responses;
using ClinicMasterFirstContact.src.App.Payments.Models.Requests;
using ClinicMasterFirstContact.src.App.Payments.Models.Responses;

namespace ClinicMasterFirstContact.src.App.Payments.Contracts;
public interface IPayment
{
    public Task<bool> UpdatePayment(PaymentFullRequest request);
    public Task<ResultResponse<PaymentResponse>> GetPayment(string billNo);
    public Task<ResultResponse<IEnumerable<PaymentResponse>>> GetPayments(int page, int pageSize);
}