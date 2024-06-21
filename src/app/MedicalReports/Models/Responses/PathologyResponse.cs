
using ClinicMasterFirstContact.src.App.Common.Utils;

namespace ClinicMasterFirstContact.src.App.MedicalReports.Models.Responses;
public sealed record PathologyResponse 
{
    public required string Test { get; init; }
    public required DateTime Examination_date { get; init; }
    public required string Indication { get; init; }
    public required string Diagnosis { get; init; }
    public static PathologyResponse Empty => new() 
    {
        Test = string.Empty,
        Examination_date = DateTime.Parse(CommonConstants.NullDateTimeString),
        Indication = string.Empty,
        Diagnosis = string.Empty
    };
}
