
namespace App.MedicalReports.Models.Requests;
public sealed record DiagnosisDiagnosedByRequest 
{
    public required string Identifier {get; init;}
    public required string Name {get; init;}
    public required string Specialty {get; init;}
    public static DiagnosisDiagnosedByRequest Empty => new() 
    {
        Identifier = string.Empty,
        Name = string.Empty,
        Specialty = string.Empty,
    };

}
