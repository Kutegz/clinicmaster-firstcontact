
namespace ClinicMasterFirstContact.src.App.MedicalReports.Models.Requests;
public sealed record CancerDiagnosisRequest 
{
    public required string Disease_code {get; init;}
    public required string Site {get; init;}
    public required string Basis_of_diagnosis {get; init;}
    public required string Cancer_stage {get; init;}
    public required string Notes {get; init;}
}
