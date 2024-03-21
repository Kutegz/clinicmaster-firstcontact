
namespace App.MedicalReports.Models.Requests;
public sealed record CancerDiagnosisRequest 
{
    public required string Disease_code {get; init;}
    public required string Site {get; init;}
    public required string Basis_of_diagnosis {get; init;}
    public required string Cancer_stage {get; init;}
    public required string Notes {get; init;}
    public static CancerDiagnosisRequest Empty => new() 
    {
        Disease_code = string.Empty,
        Site = string.Empty,
        Basis_of_diagnosis = string.Empty,
        Cancer_stage = string.Empty,
        Notes = string.Empty
    };
}
