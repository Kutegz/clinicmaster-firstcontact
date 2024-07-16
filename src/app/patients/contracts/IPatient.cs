
using ClinicMasterFirstContact.src.App.Common.Models.Responses;
using ClinicMasterFirstContact.src.App.Patients.Models.Requests;
using ClinicMasterFirstContact.src.App.Patients.Models.Responses;

namespace ClinicMasterFirstContact.src.App.Patients.Contracts;
public interface IPatient
{
    public Task<int> CreatePatient(PatientFullRequest request);
    public Task<ResultResponse<PatientResponse>> GetPatient(string patientNo);
    public Task<IEnumerable<ConsumerResponse>> GetPatientConsumers(string patientNo);
    public Task<int> UpdatePatientConsumers(string patientNo, string consumers);
    public Task<ResultResponse<IEnumerable<PatientResponse>>> GetPatients(int page, int pageSize);
}

