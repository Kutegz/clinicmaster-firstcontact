
namespace App.MedicalReports.Models;
public sealed record DiagnosisDiagnosedByResponse 
{
    public required string Identifier {get; init;}
    public required string Name {get; init;}
    public required string Specialty {get; init;}
    public static DiagnosisDiagnosedByResponse Empty => new() 
    {
        Identifier = string.Empty,
        Name = string.Empty,
        Specialty = string.Empty,
    };

}
