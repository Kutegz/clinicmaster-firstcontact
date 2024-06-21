
using ClinicMasterFirstContact.src.App.Auth.Filters;
using ClinicMasterFirstContact.src.App.Common.Filters;
using ClinicMasterFirstContact.src.App.MedicalReports.Controllers;
using ClinicMasterFirstContact.src.App.MedicalReports.Models.Requests;

namespace ClinicMasterFirstContact.src.App.MedicalReports.Apis;
public static class MedicalReportEndpoints
{
    public static void ConfigureMedicalReportApis(this WebApplication app)
    {
        // Includes all Patient MedicalReports API endpoint mappings
        var group = app.MapGroup(prefix: "/{facilityCode}/visits/medicalreports");
                        //.RequireAuthorization().AddEndpointFilter<ApiAccessAuthEndpointFilter>();
                        
        group.MapPost(pattern: "", handler: MedicalReportController.CreateMedicalReport).AllowAnonymous()
                                    .WithName(nameof(MedicalReportController.CreateMedicalReport))
                                    .AddEndpointFilter<RequestEndPontFilter<MedicalReportRequest>>();   

        group.MapGet(pattern: "", handler: MedicalReportController.GetMedicalReports).AllowAnonymous(); 

        group.MapGet(pattern: "/{visitNo}", handler: MedicalReportController.GetMedicalReport).AllowAnonymous(); 
        group.MapGet(pattern: "/{visitNo}/buddle", handler: MedicalReportController.GetMedicalReportBuddle).AllowAnonymous(); 
    }

}
