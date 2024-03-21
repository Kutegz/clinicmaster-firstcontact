
using App.Common.Utils;

namespace App.MedicalReports.Models.Requests;
public sealed record PathologyRequest 
{
    public required string Test { get; init; }
    public required DateTime Examination_date { get; init; }
    public required string Indication { get; init; }
    public required string Diagnosis { get; init; }
    public static PathologyRequest Empty => new() 
    {
        Test = string.Empty,
        Examination_date = DateTime.Parse(Constants.NullDateTimeString),
        Indication = string.Empty,
        Diagnosis = string.Empty
    };
}
