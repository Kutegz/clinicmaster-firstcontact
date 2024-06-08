
using App.Common.Models.Responses;
using App.Surgeries.Models.Responses;

namespace App.Surgeries.Contracts;
public interface ISurgery{

    public Task<ResultResponse<SurgeryResponse>> GetSurgery(string patientNo, string treatmentNo);
    public Task<ResultResponse<IEnumerable<SurgeryResponse>>> GetSurgeries(string patientNo);
}
