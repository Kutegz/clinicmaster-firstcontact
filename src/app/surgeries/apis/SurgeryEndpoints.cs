
using ClinicMasterFirstContact.src.App.Auth.Filters;
using ClinicMasterFirstContact.src.App.Surgeries.Controllers;

namespace ClinicMasterFirstContact.src.App.Surgeries.Apis;
public static class SurgeryEndpoints
{
    public static void ConfigureSurgeryApis(this WebApplication app)
    {
        // Includes all Patient Surgeries API endpoint mappings 
        var group = app.MapGroup(prefix: "/patients").RequireAuthorization()
                        .AddEndpointFilter<ApiAccessAuthEndpointFilter>();

        group.MapGet(pattern: "/{patientNo}/surgeries/{treatmentNo}", 
                    handler: SurgeryController.GetSurgery).AllowAnonymous(); 
                    
        group.MapGet(pattern: "/{patientNo}/surgeries", 
                    handler: SurgeryController.GetSurgeries).AllowAnonymous(); 

    }

}
