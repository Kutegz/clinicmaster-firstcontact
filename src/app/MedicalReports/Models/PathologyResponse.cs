
using App.Common.Utils;

namespace App.MedicalReports.Models;
public sealed record PathologyResponse 
{
    public required string Test { get; init; }
    public required DateTime Examination_date { get; init; }
    public required string Indication { get; init; }
    public required string Diagnosis { get; init; }
    public static PathologyResponse Empty => new() 
    {
        Test = string.Empty,
        Examination_date = DateTime.Parse(Constants.NullDateTimeString),
        Indication = string.Empty,
        Diagnosis = string.Empty
    };
}
