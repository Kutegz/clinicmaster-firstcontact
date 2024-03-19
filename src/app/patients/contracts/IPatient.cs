
using App.Patients.Models.Responses;

namespace App.Patients.Contracts;
public interface IPatient{
    public Task<PatientResult<PatientResponse>> GetPatient(string patientNo);
    public Task<PatientResult<IEnumerable<PatientResponse>>> GetPatients(int page, int pageSize);

}

