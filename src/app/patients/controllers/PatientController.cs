
using App.Common.Utils;
using App.Patients.Contracts;
using App.Surgeries.Contracts;
using App.Patients.Models.Requests;
using App.Patients.Models.Responses;
using App.Common.Models.Requests;

namespace App.Patients.Controllers;

public static class PatientController 
{
    public static async Task<IResult> CreatePatient(PatientRequest request, IPatient repo, TimeProvider timeProvider, 
                                                    HttpContext context, ILogger<PatientRequest> logger)
    {      
        try
        {      

            string createdBy = context.Request.Headers[Constants.XAgentId].ToString() ?? Constants.ClinicMaster;

            var creatorRequest = CreatorRequest.Create(agentId: createdBy, agentName: createdBy, 
                                                        syncCount: 1, syncStatus: true, 
                                                        syncDateTime: timeProvider.GetUtcNow(), 
                                                        errorMessage: string.Empty);

            string creator = Utils.SerializeContent(content: creatorRequest);        

            var fullRequest = PatientFullRequest.Create(request: request, creator: creator, 
                                                        createdAt: timeProvider.GetUtcNow());

            var patient = await repo.GetPatient(patientNo: fullRequest.PatientNo);
            if (!patient.Data.Equals(PatientResponse.Empty) && patient.Success) 
            {
                logger.LogError(message: "Patient with Patient No: {PatientNo} already exists", args: [fullRequest.PatientNo]);

                return Results.Conflict(new { 
                    Success = false,
                    Message = $"Patient with Patient No: {fullRequest.PatientNo} already exists"
                    });
            }
            
            await repo.CreatePatient(request: fullRequest);

            return Results.Created(uri: $"/patients/{fullRequest.PatientNo}/", value: new 
                    { 
                        Success = true,
                        Message = $"Patient with Patient No: {fullRequest.PatientNo} created successfully"
                    });            
        }
        catch (Exception ex) 
        {             
            logger.LogError(ex, message: "An error occurred while creating patient with Patient No: {PatientNo}", 
                            args: [request.PatientNo]);        
                                                                                    
            return Results.Problem(ex.Message); 
        }  
    }

    public static async Task<IResult> GetPatient(string patientNo, IPatient repo, ISurgery surgeryRepo, 
                                                HttpContext context, TimeProvider timeProvider,  
                                                ILogger<PatientResponse> logger)
    {      
        try
        {
            string createdBy = context.Request.Headers[Constants.XAgentId].ToString() ?? Constants.ClinicMaster;       

            var result = await repo.GetPatient(patientNo);
            if (result.Data.Equals(PatientResponse.Empty)) return Results.NotFound(value: result);

            var surgeries = await surgeryRepo.GetSurgeries(patientNo);
            var finalResult = result with {Data = result.Data with {Surgeries = surgeries.Data.ToList()}};

            await Helpers.UpdatePatientConsumers(patientNo: patientNo, patient: repo, createdBy: createdBy, 
                                                createdAt: timeProvider.GetUtcNow(), logger: logger);

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