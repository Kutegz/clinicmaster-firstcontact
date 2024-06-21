
using ClinicMasterFirstContact.src.App.Common.Utils;

namespace ClinicMasterFirstContact.src.App.MedicalReports.Models.Requests;
public sealed record TheaterOperationRequest
{
    public required string Anaesthesia_type {get; init;}
    public required string Operation_class {get; init;}
    public required string Preoperative_diagnosis {get; init;}
    public required string Planned_procedures {get; init;}
    public required string Report {get; init;}
    public required string Postoperative_instructions {get; init;}
    public required DateTime Operation_datetime {get; init;}
}
