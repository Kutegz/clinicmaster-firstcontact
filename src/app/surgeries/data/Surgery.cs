
using Dapper;
using ClinicMasterFirstContact.src.App.Common.Utils;
using ClinicMasterFirstContact.src.App.Common.Context;
using ClinicMasterFirstContact.src.App.Surgeries.Contracts;
using ClinicMasterFirstContact.src.App.Common.Models.Responses;
using ClinicMasterFirstContact.src.App.Surgeries.Models.Responses;

namespace ClinicMasterFirstContact.src.App.Surgeries.Data;
public sealed class Surgery(ClinicMasterContext context) : ISurgery 
{
     public async Task<ResultResponse<SurgeryResponse>> GetSurgery(string patientNo, string treatmentNo)
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
                Count = 0,
                Message = "Surgery Not Found",
                Data = SurgeryResponse.Empty,            
            };

        var patient = new SurgeryResponse 
            {
                TreatmentNo = data.TreatmentNo,
                PatientNo = data.PatientNo,
                VisitDate = data.VisitDate,
                Content = CommonUtils.DeserializeContent<SurgeryContentResponse>
                (content: data.Content) ?? SurgeryContentResponse.Empty                                
            };

        return new () 
            {
                Success = true,
                Count = 1,
                Message = string.Empty,
                Data = patient,            
            };
    }
   
    public async Task<ResultResponse<IEnumerable<SurgeryResponse>>> GetSurgeries(string patientNo)
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
                Count = 0,
                Message = "Surgeries Not Found",
                Data = [],            
            };
            
        var surgeries = incomingData.Select(data => new SurgeryResponse 
            {
                TreatmentNo = data.TreatmentNo,
                PatientNo = data.PatientNo,
                VisitDate = data.VisitDate,
                Content = CommonUtils.DeserializeContent<SurgeryContentResponse>
                (content: data.Content) ?? SurgeryContentResponse.Empty                             
            });

        return new () 
            {
                Success = true,
                Count = surgeries.Count(),
                Message = string.Empty,
                Data = surgeries.ToList(),            
            };
    }
}