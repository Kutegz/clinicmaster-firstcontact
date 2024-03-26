
using App.Patients.Models.Requests;
using App.Patients.Models.Responses;

namespace App.Patients.Contracts;
public interface IPatient
{
    public Task<bool> CreatePatient(PatientFullRequest request);
    public Task<PatientResult<PatientResponse>> GetPatient(string patientNo);
    public Task<PatientResult<IEnumerable<PatientResponse>>> GetPatients(int page, int pageSize);
}

