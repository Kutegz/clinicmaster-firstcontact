
using Dapper;
using System.Data;
using ClinicMasterFirstContact.src.App.Common.Utils;
using ClinicMasterFirstContact.src.App.Common.Context;
using ClinicMasterFirstContact.src.App.Common.Models.Responses;
using ClinicMasterFirstContact.src.App.MedicalReports.Contracts;
using ClinicMasterFirstContact.src.App.MedicalReports.Models.Requests;
using ClinicMasterFirstContact.src.App.MedicalReports.Models.Responses;

namespace ClinicMasterFirstContact.src.App.MedicalReports.Data;
public sealed class MedicalReport(ClinicMasterContext context) : IMedicalReport 
{
    public async Task<bool> CreateMedicalReport(MedicalReportFullRequest request)    
    {        
        var query = """
                        INSERT INTO MedicalReports (FacilityCode, VisitNo, VisitDate, Content, Creator, CreatedAt, Consumers)
                        VALUES (@FacilityCode, @VisitNo, @VisitDate, @Content, @Creator, @CreatedAt, @Consumers);
                    """;
                    
        var parameters = new DynamicParameters ();

        parameters.Add(name: nameof(request.FacilityCode), value: request.FacilityCode, dbType: DbType.String);
        parameters.Add(name: nameof(request.VisitNo), value: request.VisitNo, dbType: DbType.String);
        parameters.Add(name: nameof(request.VisitDate), value: request.VisitDate, dbType: DbType.Date);
        parameters.Add(name: nameof(request.Content), value: request.Content, dbType: DbType.String);
        parameters.Add(name: nameof(request.Creator), value: request.Creator, dbType: DbType.String);
        parameters.Add(name: nameof(request.CreatedAt), value: request.CreatedAt, dbType: DbType.DateTime2);
        parameters.Add(name: nameof(request.Consumers), value: request.Consumers, dbType: DbType.String);

        using var connection = context.CreateConnection();
        var result = await connection.ExecuteAsync(sql: query, param: parameters);

        return result > 0;
    }
    public async Task<bool> UpdateMedicalReport(MedicalReportFullRequest request)
    {        
        var query = """
                        UPDATE dbo.MedicalReports SET VisitDate = @VisitDate, Content = @Content, 
                            Creator = @Creator, CreatedAt = @CreatedAt, Consumers = @Consumers
                            WHERE FacilityCode = @FacilityCode AND VisitNo = @VisitNo;
                    """;
                    
        var parameters = new DynamicParameters ();

        parameters.Add(name: nameof(request.FacilityCode), value: request.FacilityCode, dbType: DbType.String);
        parameters.Add(name: nameof(request.VisitNo), value: request.VisitNo, dbType: DbType.String);
        parameters.Add(name: nameof(request.VisitDate), value: request.VisitDate, dbType: DbType.Date);
        parameters.Add(name: nameof(request.Content), value: request.Content, dbType: DbType.String);
        parameters.Add(name: nameof(request.Creator), value: request.Creator, dbType: DbType.String);
        parameters.Add(name: nameof(request.CreatedAt), value: request.CreatedAt, dbType: DbType.DateTime2);
        parameters.Add(name: nameof(request.Consumers), value: request.Consumers, dbType: DbType.String);

        using var connection = context.CreateConnection();
        var result = await connection.ExecuteAsync(sql: query, param: parameters);

        return result > 0;
    }

    public async Task<ResultResponse<MedicalReportResponse>> GetMedicalReport(string facilityCode, string visitNo)
    {
        var query = """
                        SELECT FacilityCode, VisitNo, VisitDate, Content, CreatedAt FROM MedicalReports 
                        WHERE FacilityCode = @FacilityCode AND VisitNo = @VisitNo
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
                Content = CommonUtils.DeserializeContent<MedicalReportContentResponse>
                (content: data.Content) ?? MedicalReportContentResponse.Empty,
                CreatedAt = data.CreatedAt                        
            };

        return new () 
            {
                Success = true,
                Message = string.Empty,
                Data = patient,            
            };

    }

        public async Task<string> GetMedicalReportBuddle(string facilityCode, string visitNo)
    {
        var query = """
                        SELECT Content FROM MedicalReports 
                        WHERE FacilityCode = @FacilityCode AND VisitNo = @VisitNo
                    """;

        using var connection = context.CreateConnection();
        var parameters = new { facilityCode, visitNo };
        var data = await connection.QuerySingleOrDefaultAsync<string> (sql: query, param: parameters);
                  
        return data ?? string.Empty;


    }

    public async Task<IEnumerable<ConsumerResponse>> GetMedicalReportConsumers(string facilityCode, string visitNo)
    { 
        var query = """
                        SELECT Consumers FROM dbo.MedicalReports WHERE FacilityCode = @FacilityCode AND VisitNo = @VisitNo
                    """;

        using var connection = context.CreateConnection();
        var data = await connection.QuerySingleOrDefaultAsync<ConsumerAgents> (sql: query, param: new { facilityCode, visitNo });

        if (data is null || data.Consumers is null || data.Consumers.Equals(string.Empty)) return [];

        var consumers = CommonUtils.DeserializeContent<IEnumerable<ConsumerResponse>>(content: data.Consumers);

        return consumers ?? [];

    }

    public async Task<bool> UpdateMedicalReportConsumers(string facilityCode, string visitNo, string consumers)
    {
       var query = """
                        UPDATE dbo.MedicalReports SET Consumers = @Consumers WHERE FacilityCode = @FacilityCode AND VisitNo = @VisitNo;
                    """;
                    
        var parameters = new DynamicParameters ();

        parameters.Add(name: "FacilityCode", value: facilityCode, dbType: DbType.String);
        parameters.Add(name: "VisitNo", value: visitNo, dbType: DbType.String);
        parameters.Add(name: "Consumers", value: consumers, dbType: DbType.String);

        using var connection = context.CreateConnection();
        var result = await connection.ExecuteAsync(sql: query, param: parameters);
        return result > 0;
    }
   
    public async Task<ResultResponse<IEnumerable<MedicalReportResponse>>> GetMedicalReports(string facilityCode, int page, int pageSize)
    {        
        if (page <= 0) page = 1;
        if (pageSize <= 0) pageSize = 10;
        if (pageSize > 100) pageSize = 100;

        var query = """
                        SELECT FacilityCode, VisitNo, VisitDate, Content, CreatedAt
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
                Content = CommonUtils.DeserializeContent<MedicalReportContentResponse>
                (content: data.Content) ?? MedicalReportContentResponse.Empty,
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