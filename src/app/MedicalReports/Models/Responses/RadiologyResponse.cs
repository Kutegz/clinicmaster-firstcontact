
namespace ClinicMasterFirstContact.src.App.MedicalReports.Models.Responses;
public sealed record RadiologyResponse 
{
    public required string Examination { get; init; } 
    public required DateTime Examination_date { get; init; }
    public required string Indication { get; init; }
    public required string Report { get; init; }
    public required string Conclusion { get; init; }
    public static RadiologyResponse Empty => new() 
    {
        Examination = string.Empty,
        Examination_date = DateTime.MinValue,
        Indication = string.Empty,
        Report = string.Empty,
        Conclusion = string.Empty
    };

}