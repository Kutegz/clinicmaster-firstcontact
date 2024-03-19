
using App.Auth;
using App.MedicalReports.Controllers;

namespace App.MedicalReports.Apis;
public static class MedicalReportEndpoints
{
    public static void ConfigureMedicalReportApis(this WebApplication app)
    {
        // Includes all Patient MedicalReports API endpoint mappings
        var group = app.MapGroup(prefix: "/{facilityCode}/visits/medicalreports")
                        .RequireAuthorization().AddEndpointFilter<ApiAccessAuthEndpointFilter>();

        group.MapGet(pattern: "/{visitNo}", handler: MedicalReportController.GetMedicalReport).AllowAnonymous(); 
                    
        group.MapGet(pattern: "", handler: MedicalReportController.GetMedicalReports).AllowAnonymous(); 

    }

}
