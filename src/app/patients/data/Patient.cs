
using Dapper;
using System.Data;
using ClinicMasterFirstContact.src.App.Common.Utils;
using ClinicMasterFirstContact.src.App.Common.Context;
using ClinicMasterFirstContact.src.App.Patients.Contracts;
using ClinicMasterFirstContact.src.App.Common.Models.Responses;
using ClinicMasterFirstContact.src.App.Patients.Models.Requests;
using ClinicMasterFirstContact.src.App.Patients.Models.Responses;

namespace ClinicMasterFirstContact.src.App.Patients.Data;

public sealed class Patient(ClinicMasterContext context) : IPatient 
{
    public async Task<bool> CreatePatient(PatientFullRequest request)    
    {        
        var query = """
                        INSERT INTO Patients (PatientNo, FullName, Gender, Age, Creator, CreatedAt, Consumers)
                        VALUES (@PatientNo, @FullName, @Gender, @Age, @Creator, @CreatedAt, @Consumers);
                    """;

        var parameters = new DynamicParameters ();

        parameters.Add(name: nameof(request.PatientNo), value: request.PatientNo, dbType: DbType.String);
        parameters.Add(name: nameof(request.FullName), value: request.FullName, dbType: DbType.String);
        parameters.Add(name: nameof(request.Gender), value: request.Gender, dbType: DbType.String);
        parameters.Add(name: nameof(request.Age), value: request.Age, dbType: DbType.Int32);
        parameters.Add(name: nameof(request.Creator), value: request.Creator, dbType: DbType.String);
        parameters.Add(name: nameof(request.CreatedAt), value: request.CreatedAt, dbType: DbType.DateTime2);
        parameters.Add(name: nameof(request.Consumers), value: request.Consumers, dbType: DbType.String);

        using var connection = context.CreateConnection();
        var result = await connection.ExecuteAsync(sql: query, param: parameters);

        return result > 0;
    }

    public async Task<ResultResponse<PatientResponse>> GetPatient(string patientNo)
    {

        var query = """
                        SELECT PatientNo, FullName, Gender, Age FROM Patients WHERE PatientNo = @PatientNo
                    """;

        using var connection = context.CreateConnection();
        var patient = await connection.QuerySingleOrDefaultAsync<PatientResponse> (sql: query, param: new { patientNo });
        
        if (patient is null) return new () 
            {
                Success = false,
                Count = 0,
                Message = "Patient Not Found",
                Data = PatientResponse.Empty,            
            };

        return new () 
            {
                Success = true,
                Count = 1,
                Message = string.Empty,
                Data = patient,            
            };

    }
    public async Task<IEnumerable<ConsumerResponse>> GetPatientConsumers(string patientNo)
    { 
        var query = """
                        SELECT Consumers FROM dbo.Patients WHERE PatientNo = @PatientNo
                    """;

        using var connection = context.CreateConnection();
        var data = await connection.QuerySingleOrDefaultAsync<ConsumerAgents> (sql: query, param: new { patientNo });

        if (data is null || data.Consumers is null || data.Consumers.Equals(string.Empty)) return [];

        var consumers = CommonUtils.DeserializeContent<IEnumerable<ConsumerResponse>>(content: data.Consumers);

        return consumers ?? [];

    }

    public async Task<bool> UpdatePatientConsumers(string patientNo, string consumers)
    {
       var query = """
                        UPDATE dbo.Patients SET Consumers = @Consumers WHERE PatientNo = @PatientNo;
                    """;
                    
        var parameters = new DynamicParameters ();

        parameters.Add(name: "PatientNo", value: patientNo, dbType: DbType.String);
        parameters.Add(name: "Consumers", value: consumers, dbType: DbType.String);

        using var connection = context.CreateConnection();
        var result = await connection.ExecuteAsync(sql: query, param: parameters);
        return result > 0;
    }
    public async Task<ResultResponse<IEnumerable<PatientResponse>>> GetPatients(int page , int pageSize)
    {       
        if (page <= 0) page = 1;
        if (pageSize <= 0) pageSize = 10;
        if (pageSize > 100) pageSize = 100;

        var query = $"""
                        SELECT PatientNo AS {nameof(PatientResponse.PatientNo)}, FullName, Gender, Age FROM Patients
                    """;

        using var connection = context.CreateConnection();
        var patients = await connection.QueryAsync<PatientResponse>(sql: query);
        
        var pagedPatients = patients.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        return new () 
                {
                    Success = true,
                    Count = pagedPatients.Count,
                    Message = string.Empty,
                    Data = pagedPatients,            
                };           

    }
  
}