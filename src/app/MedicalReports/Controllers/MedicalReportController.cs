
using App.MedicalReports.Contracts;
using App.MedicalReports.Models.Requests;
using App.MedicalReports.Models.Responses;

namespace App.MedicalReports.Controllers;
public static class MedicalReportController 
{
    public static async Task<IResult> CreateMedicalReport(MedicalReportRequest request, 
                                        IMedicalReport repo, ILogger<MedicalReportRequest> logger)
    {      
        try
        {    
            var fullRequest = MedicalReportFullRequest.Create(request);
            await repo.CreateMedicalReport(fullRequest);

            logger.LogInformation("Goods Received Note request received {@fullRequest}", fullRequest); 

            return Results.Created(uri: $"/medicalReport/{request.GRNNo}/", 
                                    value: new { Message = "Goods Received Note Created Successfully"});            
        }
        catch (Exception ex) 
        { 
            logger.LogError("Failed to create Gooods Received Note with GRN No: {@GRNNo}", request.GRNNo); 
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