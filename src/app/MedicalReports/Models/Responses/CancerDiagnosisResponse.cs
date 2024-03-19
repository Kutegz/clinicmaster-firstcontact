
namespace App.MedicalReports.Models.Responses;
public sealed record CancerDiagnosisResponse 
{
    public required string Disease_code {get; init;}
    public required string Site {get; init;}
    public required string Basis_of_diagnosis {get; init;}
    public required string Cancer_stage {get; init;}
    public required string Notes {get; init;}
    public static CancerDiagnosisResponse Empty => new() 
    {
        Disease_code = string.Empty,
        Site = string.Empty,
        Basis_of_diagnosis = string.Empty,
        Cancer_stage = string.Empty,
        Notes = string.Empty
    };
}
