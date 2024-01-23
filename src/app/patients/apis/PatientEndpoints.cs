
using App.Auth;
using App.Patients.Controllers;

namespace App.Patients.Apis;
public static class PatientEndpoints
{
    public static void ConfigurePatientApis(this WebApplication app)
    {
        // Includes all Patients API endpoint mappings
        var group = app.MapGroup(prefix: "/patients")
                        .RequireAuthorization()
                        .AddEndpointFilter<ApiKeyAuthEndpointFilter>();
                        
        group.MapGet(pattern: "/{patientNo}", handler: PatientController.GetPatient).AllowAnonymous(); 
        group.MapGet(pattern: "", handler: PatientController.GetPatients).AllowAnonymous();
    }

}