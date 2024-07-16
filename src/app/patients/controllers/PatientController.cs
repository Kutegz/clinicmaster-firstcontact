
using ClinicMasterFirstContact.src.App.Common.Utils;
using ClinicMasterFirstContact.src.App.Patients.Contracts;
using ClinicMasterFirstContact.src.App.Surgeries.Contracts;
using ClinicMasterFirstContact.src.App.Common.Models.Requests;
using ClinicMasterFirstContact.src.App.Common.Models.Responses;
using ClinicMasterFirstContact.src.App.Patients.Models.Requests;
using ClinicMasterFirstContact.src.App.Patients.Models.Responses;

namespace ClinicMasterFirstContact.src.App.Patients.Controllers;

public static class PatientController 
{
    public static async Task<IResult> CreatePatient(PatientRequest request, IPatient repo, TimeProvider timeProvider, 
                                                    HttpContext context, ILogger<PatientRequest> logger)
    {      
        try
        {      

            string createdBy = context.Request.Headers[CommonConstants.XAgentId].ToString() ?? CommonConstants.ClinicMaster;

            var creatorRequest = CreatorRequest.Create(agentId: createdBy, agentName: createdBy, 
                                                        syncCount: 1, syncStatus: true, 
                                                        syncDateTime: CommonUtils.GetCurrentDateTime(timeProvider), 
                                                        syncMessage: string.Empty);

            string creator = CommonUtils.SerializeContent(content: creatorRequest);        

            var fullRequest = PatientFullRequest.Create(request: request, creator: creator, 
                                                        createdAt: CommonUtils.GetCurrentDateTime(timeProvider));

            var patient = await repo.GetPatient(patientNo: fullRequest.PatientNo);
            if (!patient.Data.Equals(PatientResponse.Empty) && patient.Success) 
            {
                logger.LogError(message: "Patient with Patient No: {PatientNo} already exists", args: [fullRequest.PatientNo]);

                return Results.Conflict(new { 
                    Success = false,
                    Message = $"Patient with Patient No: {fullRequest.PatientNo} already exists"
                    });
            }
            
            var result = await repo.CreatePatient(request: fullRequest);

            return Results.Created(uri: $"/patients/{fullRequest.PatientNo}/", value: new CreatedResponse
                    {
                        Success = result > 0,
                        Status = StatusCodes.Status201Created,
                        Count = result,
                        Message = $"Patient with Patient No: {fullRequest.PatientNo} created successfully",
                        Location = $"/patients/{fullRequest.PatientNo}/"
                    });            
        }
        catch (Exception ex) 
        {             
            logger.LogError(ex, message: "An error occurred while creating patient with Patient No: {PatientNo}", 
                            args: [request.PatientNo]);        
                                                                                    
            return Results.Problem(detail: ex.Message); 
        }  
    }

    public static async Task<IResult> GetPatient(string patientNo, IPatient repo, ISurgery surgeryRepo, 
                                                HttpContext context, TimeProvider timeProvider,  
                                                ILogger<PatientResponse> logger)
    {      
        try
        {
            string createdBy = context.Request.Headers[CommonConstants.XAgentId].ToString() ?? CommonConstants.ClinicMaster;       

            var result = await repo.GetPatient(patientNo);
            if (result.Data.Equals(PatientResponse.Empty)) return Results.NotFound(value: result);

            var surgeries = await surgeryRepo.GetSurgeries(patientNo);
            var finalResult = result with {Data = result.Data with {Surgeries = surgeries.Data.ToList()}};

            await Helpers.UpdatePatientConsumers(patientNo: patientNo, patient: repo, createdBy: createdBy, 
                                                createdAt: CommonUtils.GetCurrentDateTime(timeProvider), logger: logger);

            return Results.Ok(value: finalResult);         
        }
        catch (Exception ex) { return Results.Problem(detail: ex.Message); }  
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
        catch (Exception ex) { return Results.Problem(detail: ex.Message); }
    }

}