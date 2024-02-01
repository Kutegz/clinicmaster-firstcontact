
using App.Patients.Models;
using App.Patients.Contracts;
using App.Surgeries.Contracts;

namespace App.Patients.Controllers;

public static class PatientController 
{
    public static async Task<IResult> GetPatient(string patientNo, IPatient repo, ISurgery surgeryRepo)
    {      
        try
        {
            var result = await repo.GetPatient(patientNo);
            if (result.Data.Equals(PatientResponse.Empty)) return Results.NotFound(value: result);

            var surgeries = await surgeryRepo.GetSurgeries(patientNo);
            var finalResult = result with {Data = result.Data with {Surgeries = surgeries.Data.ToList()}};

            return Results.Ok(value: finalResult);            
        }
        catch (Exception ex) { return Results.Problem(ex.Message); }  
    }

    public static async Task<IResult> GetPatients(IPatient repo, ISurgery surgeryRepo, HttpContext context)
    {
        try
        {
            var pageValue = context.Request.Query["page"].FirstOrDefault();
            var pageSizeValue = context.Request.Query["pageSize"].FirstOrDefault();

            if (!int.TryParse(pageValue, out int page) || page <= 0) page = 1;
            if (!int.TryParse(pageSizeValue, out int pageSize) || pageSize <= 0) pageSize = 10;
        
            var results = await repo.GetPatients(page: page, pageSize: pageSize);
            var finalResults = results with { Data = results.Data.Select(async patient => 
                {
                    var surgeries = await surgeryRepo.GetSurgeries(patient.PatientNo);
                    return patient with { Surgeries = surgeries.Data.ToList()};
                }).Select(pr => pr.Result).ToList()            
            };

            return Results.Ok(value: finalResults);   
            
        }
        catch (Exception ex) { return Results.Problem(ex.Message); }
    }

}