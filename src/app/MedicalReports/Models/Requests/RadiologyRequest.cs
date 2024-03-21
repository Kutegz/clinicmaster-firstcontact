
using App.Common.Utils;

namespace App.MedicalReports.Models.Requests;
public sealed record RadiologyRequest 
{
    public required string Examination { get; init; } 
    public required DateTime Examination_date { get; init; }
    public required string Indication { get; init; }
    public required string Report { get; init; }
    public required string Conclusion { get; init; }
    public static RadiologyRequest Empty => new() 
    {
        Examination = string.Empty,
        Examination_date = DateTime.Parse(Constants.NullDateTimeString),
        Indication = string.Empty,
        Report = string.Empty,
        Conclusion = string.Empty
    };

}