
namespace ClinicMasterFirstContact.src.App.MedicalReports.Models.Requests;
public sealed record MedicalReportRequest 
{
    public required string FacilityCode {get; init;}
    public required string VisitNo {get; init;}
    public required DateTime VisitDate {get; init;}
    public required MedicalReportContentRequest Content {get; init;}   
}

