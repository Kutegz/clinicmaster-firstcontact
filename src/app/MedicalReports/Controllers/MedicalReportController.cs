
using App.Common.Utils;
using Api.MedicalReports.Services;
using App.MedicalReports.Contracts;
using App.MedicalReports.Models.Requests;
using App.MedicalReports.Models.Responses;

namespace App.MedicalReports.Controllers;
public static class MedicalReportController 
{
    public static async Task<IResult> CreateMedicalReport(string facilityCode, MedicalReportRequest request, 
                                                        IMedicalReport repo, HttpContext context,
                                                        ILogger<MedicalReportRequest> logger, MedicalReportMetrics metrics)
    {      
        try
        {     
            
            string? createdBy = context.Request.Headers[Constants.XAgentId];           
            var fullRequest = MedicalReportFullRequest.Create(request: request, createdBy: createdBy ?? Constants.ClinicMaster);

            if (!facilityCode.ToLower().Equals(fullRequest.FacilityCode.ToLower()))
            {
                logger.LogError(message: "Route Facility Code: {facilityCode} does not match the request Facility Code: {fullRequest.FacilityCode}", 
                                                                    args: [facilityCode, fullRequest.FacilityCode]); 

                return Results.BadRequest(new { 
                    Success = false,
                    Message = $"Route Facility Code: {facilityCode} does not match the request Facility Code: {fullRequest.FacilityCode}"
                    });
            }

            var medicalReport = await repo.GetMedicalReport(facilityCode: fullRequest.FacilityCode, visitNo: fullRequest.VisitNo);
            if (!medicalReport.Data.Equals(MedicalReportResponse.Empty) && medicalReport.Success) 
            {
                logger.LogError(message: "Medical Report with Facility Code: {FacilityCode}, and Visit No: {VisitNo} already exists", 
                                                                    args: [fullRequest.FacilityCode, fullRequest.VisitNo]); 

                return Results.Conflict(new { 
                    Success = false,
                    Message = $"Medical Report with Facility Code: {fullRequest.FacilityCode}, and Visit No: {fullRequest.VisitNo} already exists"
                    });
            }
            
            await repo.CreateMedicalReport(request: fullRequest);

            metrics.MedicalReportCounter.Add(delta: 1, 
                                        tag1: new KeyValuePair<string, dynamic?>("FacilityCode", fullRequest.FacilityCode),
                                        tag2: new KeyValuePair<string, dynamic?>("VisitNo", fullRequest.VisitNo),
                                        tag3: new KeyValuePair<string, dynamic?>("CreatedAt", fullRequest.CreatedAt)
                                    );

            return Results.Created(uri: $"/{fullRequest.FacilityCode}/visits/medicalreports/{fullRequest.VisitNo}/", 
                                    value: new 
                                            { 
                                                Success = true,
                                                Message = "Medical Report Created Successfully"
                                            });            
        }
        catch (Exception ex) 
        { 
            logger.LogError("Failed to create Medical Report with Facility Code: {FacilityCode}, and Visit No: {VisitNo}", 
                                                                                    request.FacilityCode, request.VisitNo); 
            return Results.Problem(ex.Message); 
        }  
    }
    public static async Task<IResult> GetMedicalReport(string facilityCode, string visitNo, IMedicalReport repo)
    {      
        try
        {
            var result = await repo.GetMedicalReport(facilityCode, visitNo);
            if (result.Data.Equals(MedicalReportResponse.Empty)) return Results.NotFound(value: result);

            return Results.Ok(value: result);            
        }
        catch (Exception ex) { return Results.Problem(ex.Message); }  
    }
   
    public static async Task<IResult> GetMedicalReports(string facilityCode, IMedicalReport repo, HttpContext context)
    {
        try
        {
            var pageValue = context.Request.Query["page"].FirstOrDefault();
            var pageSizeValue = context.Request.Query["pageSize"].FirstOrDefault();

            if (!int.TryParse(pageValue, out int page) || page <= 0) page = 1;
            if (!int.TryParse(pageSizeValue, out int pageSize) || pageSize <= 0) pageSize = 10;

            var results = await repo.GetMedicalReports(facilityCode: facilityCode, page: page, pageSize: pageSize);            
            return Results.Ok(value: results);   
            
        }
        catch (Exception ex) { return Results.Problem(ex.Message); }
    }

}