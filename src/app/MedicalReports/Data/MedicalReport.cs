
using Dapper;
using App.Common.Utils;
using App.Common.Context;
using App.MedicalReports.Contracts;
using App.MedicalReports.Models.Responses;

namespace App.MedicalReports.Data;
public sealed class MedicalReport(ClinicMasterContext context) : IMedicalReport 
{
     public async Task<MedicalReportResult<MedicalReportResponse>> GetMedicalReport(string facilityCode, string visitNo)
    {
        var query = """
                        SELECT FacilityCode, VisitNo, VisitDate, Content, CreatedBy, CreatedAt
                        FROM MedicalReports WHERE FacilityCode = @FacilityCode AND VisitNo = @VisitNo
                    """;

        using var connection = context.CreateConnection();
        var parameters = new { facilityCode, visitNo };
        var data = await connection.QuerySingleOrDefaultAsync<MedicalReportRowData> (sql: query, param: parameters);
                  
        if (data is null) return new () 
            {
                Success = false,
                Message = "Medical Report Not Found",
                Data = MedicalReportResponse.Empty,            
            };

        var patient = new MedicalReportResponse 
            {
                VisitNo = data.VisitNo,
                FacilityCode = data.FacilityCode,
                VisitDate = data.VisitDate,
                Content = Helpers.DeserializeContent<MedicalReportContentResponse>
                (content: data.Content) ?? MedicalReportContentResponse.Empty,
                CreatedBy = data.CreatedBy,
                CreatedAt = data.CreatedAt                        
            };

        return new () 
            {
                Success = true,
                Message = string.Empty,
                Data = patient,            
            };

    }
   
    public async Task<MedicalReportResult<IEnumerable<MedicalReportResponse>>> GetMedicalReports(string facilityCode, int page, int pageSize)
    {        
        if (page <= 0) page = 1;
        if (pageSize <= 0) pageSize = 10;
        if (pageSize > 100) pageSize = 100;

        var query = """
                        SELECT FacilityCode, VisitNo, VisitDate, Content, CreatedBy, CreatedAt
                        FROM MedicalReports WHERE FacilityCode = @FacilityCode
                    """;
                    
        using var connection = context.CreateConnection();
        var incomingData = await connection.QueryAsync<MedicalReportRowData>(sql: query, param: new { facilityCode });

        if (incomingData is null) return new () 
            {
                Success = false,
                Message = "Medical Reports Not Found",
                Data = [],            
            };
            
        var medicalReports = incomingData.Select(data => new MedicalReportResponse 
            {
                VisitNo = data.VisitNo,
                FacilityCode = data.FacilityCode,
                VisitDate = data.VisitDate,
                Content = Helpers.DeserializeContent<MedicalReportContentResponse>
                (content: data.Content) ?? MedicalReportContentResponse.Empty,
                CreatedBy = data.CreatedBy,
                CreatedAt = data.CreatedAt
                                            
            });
        
        var pagedMedicalReports = medicalReports.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        return new () 
            {
                Success = true,
                Message = string.Empty,
                Data = pagedMedicalReports,            
            };         

    }
  
}