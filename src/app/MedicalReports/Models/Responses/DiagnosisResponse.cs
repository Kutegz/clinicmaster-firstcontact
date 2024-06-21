
namespace ClinicMasterFirstContact.src.App.MedicalReports.Models.Responses;
public sealed record DiagnosisResponse 
{
    public required DiagnosisDiagnosedByResponse Diagnosed_by {get; init;}  
    public required string Category {get; init;}
    public required string Diagnosis {get; init;}
    public required string Notes {get; init;}
    public static DiagnosisResponse Empty => new() 
    {
        Diagnosed_by = DiagnosisDiagnosedByResponse.Empty,
        Category = string.Empty,
        Diagnosis = string.Empty,
        Notes = string.Empty
    };
}