
using App.Auth;
using App.Surgeries.Controllers;

namespace App.Surgeries.Apis;
public static class SurgeryEndpoints
{
    public static void ConfigureSurgeryApis(this WebApplication app)
    {
        // Includes all Patient Surgeries API endpoint mappings 
        var group = app.MapGroup(prefix: "/patients")
                        .RequireAuthorization()
                        .AddEndpointFilter<ApiKeyAuthEndpointFilter>();

        group.MapGet(pattern: "/{patientNo}/surgeries/{treatmentNo}", 
                    handler: SurgeryController.GetSurgery).AllowAnonymous(); 
                    
        group.MapGet(pattern: "/{patientNo}/surgeries", 
                    handler: SurgeryController.GetSurgeries).AllowAnonymous(); 

    }

}
