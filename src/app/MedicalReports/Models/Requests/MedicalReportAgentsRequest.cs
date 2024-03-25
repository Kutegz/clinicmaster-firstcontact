
namespace App.MedicalReports.Models.Requests;
public sealed record MedicalReportAgentsRequest 
{    
    public required AgentsSubmitterRequest Submitter {get; init;} 

}