
using Dapper;
using System.Text.Json;
using App.Common.Context;
using App.Surgeries.Models;
using App.Surgeries.Contracts;

namespace App.Surgeries.Data;
public sealed class Surgery(ClinicMasterContext context) : ISurgery 
{
    private readonly ClinicMasterContext context = context;
    private readonly JsonSerializerOptions serializerOptions = new ()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,            
        };
     public async Task<SurgeryResult<SurgeryResponse>> GetSurgery(string patientNo, string treatmentNo)
    {
        var query = """
                        SELECT TreatmentNo, PatientNo, VisitDate, Content 
                        FROM Surgeries WHERE PatientNo = @PatientNo AND TreatmentNo = @TreatmentNo
                    """;

        using var connection = context.CreateConnection();
        var parameters = new { patientNo, treatmentNo };
        var data = await connection.QuerySingleOrDefaultAsync<SurgeryRowData> (sql: query, param: parameters);
                  
        if (data is null) return new () 
            {
                Success = false,
                Message = "Surgery Not Found",
                Data = SurgeryResponse.Empty,            
            };

        var patient = new SurgeryResponse 
            {
                TreatmentNo = data.TreatmentNo,
                PatientNo = data.PatientNo,
                VisitDate = data.VisitDate,
                Content = JsonSerializer.Deserialize<SurgeryContentResponse>
                (json: data.Content, options: serializerOptions) ?? SurgeryContentResponse.Empty                                
            };

        return new () 
            {
                Success = true,
                Message = string.Empty,
                Data = patient,            
            };

    }
   
    public async Task<SurgeryResult<IEnumerable<SurgeryResponse>>> GetSurgeries(string patientNo)
    { 
        var query = """
                        SELECT TreatmentNo, PatientNo, VisitDate, Content 
                        FROM Surgeries WHERE PatientNo = @PatientNo
                    """;
                    
        using var connection = context.CreateConnection();
        var incomingData = await connection.QueryAsync<SurgeryRowData>(sql: query, param: new { patientNo });

        if (incomingData is null) return new () 
            {
                Success = false,
                Message = "Surgeries Not Found",
                Data = [],            
            };
            
        var surgeries = incomingData.Select(data => new SurgeryResponse 
            {
                TreatmentNo = data.TreatmentNo,
                PatientNo = data.PatientNo,
                VisitDate = data.VisitDate,
                Content = JsonSerializer.Deserialize<SurgeryContentResponse>
                (json: data.Content, options: serializerOptions) ?? SurgeryContentResponse.Empty                                
            });

        return new () 
            {
                Success = true,
                Message = string.Empty,
                Data = surgeries.ToList(),            
            };           

    }
  
}