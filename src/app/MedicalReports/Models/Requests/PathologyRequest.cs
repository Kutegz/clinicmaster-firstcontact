
using ClinicMasterFirstContact.src.App.Common.Utils;

namespace ClinicMasterFirstContact.src.App.MedicalReports.Models.Requests;
public sealed record PathologyRequest 
{
    public required string Test { get; init; }
    public required DateTime Examination_date { get; init; }
    public required string Indication { get; init; }
    public required string Diagnosis { get; init; }

}
