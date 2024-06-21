
using ClinicMasterFirstContact.src.App.Auth.Filters;
using ClinicMasterFirstContact.src.App.Common.Filters;
using ClinicMasterFirstContact.src.App.Patients.Controllers;
using ClinicMasterFirstContact.src.App.Patients.Models.Requests;

namespace ClinicMasterFirstContact.src.App.Patients.Apis;
public static class PatientEndpoints
{
    public static void ConfigurePatientApis(this WebApplication app)
    {
        // Includes all Patients API endpoint mappings
        var group = app.MapGroup(prefix: "/patients").RequireAuthorization()
                        .AddEndpointFilter<ApiAccessAuthEndpointFilter>();
                        
        group.MapPost(pattern: "", handler: PatientController.CreatePatient).AllowAnonymous()
                                    .WithName(nameof(PatientController.CreatePatient))
                                    .AddEndpointFilter<RequestEndPontFilter<PatientRequest>>();   
                        
        group.MapGet(pattern: "/{patientNo}", handler: PatientController.GetPatient).AllowAnonymous(); 
        group.MapGet(pattern: "", handler: PatientController.GetPatients).AllowAnonymous();
    }

}