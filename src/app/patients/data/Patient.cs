
using Dapper;
using App.Common.Context;
using App.Patients.Models;
using App.Patients.Contracts;

namespace App.Patients.Data;

public sealed class Patient(ClinicMasterContext context) : IPatient 
{
    public async Task<PatientResult<PatientResponse>> GetPatient(string patientNo)
    {

        var query = """
                        SELECT PatientNo, FullName, Gender, Age 
                        FROM Patients WHERE PatientNo = @PatientNo
                    """;
        using var connection = context.CreateConnection();
        var patient = await connection.QuerySingleOrDefaultAsync<PatientResponse> (sql: query, param: new { patientNo });
        
        if (patient is null) return new () 
            {
                Success = false,
                Message = "Patient Not Found",
                Data = PatientResponse.Empty,            
            };

        return new () 
            {
                Success = true,
                Message = string.Empty,
                Data = patient,            
            };

    }
    public async Task<PatientResult<IEnumerable<PatientResponse>>> GetPatients(int page , int pageSize)
    {       
        if (page <= 0) page = 1;
        if (pageSize <= 0) pageSize = 10;
        if (pageSize > 100) pageSize = 100;

        var query = """
                        SELECT PatientNo, FullName, Gender, Age FROM Patients
                    """;
        using var connection = context.CreateConnection();
        var patients = await connection.QueryAsync<PatientResponse>(sql: query);
        
        var pagedPatients = patients.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        return new () 
                {
                    Success = true,
                    Message = string.Empty,
                    Data = pagedPatients,            
                };           

    }
  
}