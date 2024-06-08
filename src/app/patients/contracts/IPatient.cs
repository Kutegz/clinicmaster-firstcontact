
using App.Common.Models.Responses;
using App.Patients.Models.Requests;
using App.Patients.Models.Responses;

namespace App.Patients.Contracts;
public interface IPatient
{
    public Task<bool> CreatePatient(PatientFullRequest request);
    public Task<ResultResponse<PatientResponse>> GetPatient(string patientNo);
    public Task<IEnumerable<ConsumerResponse>> GetPatientConsumers(string patientNo);
    public Task<bool> UpdatePatientConsumers(string patientNo, string consumers);
    public Task<ResultResponse<IEnumerable<PatientResponse>>> GetPatients(int page, int pageSize);
}

