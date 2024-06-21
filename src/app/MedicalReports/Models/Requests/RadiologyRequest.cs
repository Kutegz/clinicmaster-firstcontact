
using ClinicMasterFirstContact.src.App.Common.Utils;

namespace ClinicMasterFirstContact.src.App.MedicalReports.Models.Requests;
public sealed record RadiologyRequest 
{
    public required string Examination { get; init; } 
    public required DateTime Examination_date { get; init; }
    public required string Indication { get; init; }
    public required string Report { get; init; }
    public required string Conclusion { get; init; }
}