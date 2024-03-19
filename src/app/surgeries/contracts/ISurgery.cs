
using App.Surgeries.Models.Responses;

namespace App.Surgeries.Contracts;
public interface ISurgery{

    public Task<SurgeryResult<SurgeryResponse>> GetSurgery(string patientNo, string treatmentNo);
    public Task<SurgeryResult<IEnumerable<SurgeryResponse>>> GetSurgeries(string patientNo);
}
