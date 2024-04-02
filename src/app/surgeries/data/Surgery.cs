
using Dapper;
using App.Common.Utils;
using App.Common.Context;
using App.Surgeries.Contracts;
using App.Surgeries.Models.Responses;

namespace App.Surgeries.Data;
public sealed class Surgery(ClinicMasterContext context) : ISurgery 
{
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
                Content = Utils.DeserializeContent<SurgeryContentResponse>
                (content: data.Content) ?? SurgeryContentResponse.Empty                                
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
                Content = Utils.DeserializeContent<SurgeryContentResponse>
                (content: data.Content) ?? SurgeryContentResponse.Empty                             
            });

        return new () 
            {
                Success = true,
                Message = string.Empty,
                Data = surgeries.ToList(),            
            };           

    }
  
}