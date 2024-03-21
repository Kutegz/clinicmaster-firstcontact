
namespace App.MedicalReports.Models.Requests;
public sealed record DiagnosisRequest 
{
    public required DiagnosisDiagnosedByRequest Diagnosed_by {get; init;}  
    public required string Category {get; init;}
    public required string Diagnosis {get; init;}
    public required string Notes {get; init;}
    public static DiagnosisRequest Empty => new() 
    {
        Diagnosed_by = DiagnosisDiagnosedByRequest.Empty,
        Category = string.Empty,
        Diagnosis = string.Empty,
        Notes = string.Empty
    };
}