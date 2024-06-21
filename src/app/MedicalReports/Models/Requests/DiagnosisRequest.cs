
namespace ClinicMasterFirstContact.src.App.MedicalReports.Models.Requests;
public sealed record DiagnosisRequest 
{
    public required DiagnosisDiagnosedByRequest Diagnosed_by {get; init;}  
    public required string Category {get; init;}
    public required string Diagnosis {get; init;}
    public required string Notes {get; init;}

}