
using App.Surgeries.Contracts;
using App.Surgeries.Models.Responses;

namespace App.Surgeries.Controllers;
public static class SurgeryController 
{
    public static async Task<IResult> GetSurgery(string patientNo, string treatmentNo, ISurgery repo)
    {      
        try
        {
            var result = await repo.GetSurgery(patientNo, treatmentNo);
            if (result.Data.Equals(SurgeryResponse.Empty)) return Results.NotFound(value: result);

            return Results.Ok(value: result);            
        }
        catch (Exception ex) { return Results.Problem(ex.Message); }  
    }
   
    public static async Task<IResult> GetSurgeries(string patientNo, ISurgery repo)
    {
        try
        {
            var results = await repo.GetSurgeries(patientNo);            
            return Results.Ok(value: results);   
            
        }
        catch (Exception ex) { return Results.Problem(ex.Message); }
    }

}