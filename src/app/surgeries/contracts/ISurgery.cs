
using ClinicMasterFirstContact.src.App.Common.Models.Responses;
using ClinicMasterFirstContact.src.App.Surgeries.Models.Responses;

namespace ClinicMasterFirstContact.src.App.Surgeries.Contracts;
public interface ISurgery{

    public Task<ResultResponse<SurgeryResponse>> GetSurgery(string patientNo, string treatmentNo);
    public Task<ResultResponse<IEnumerable<SurgeryResponse>>> GetSurgeries(string patientNo);
}
