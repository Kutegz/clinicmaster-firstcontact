
namespace App.MedicalReports.Models.Requests;
public sealed record MedicalReportRequest 
{
    public required string GRNNo {get; init;}
    public required DateTime ReceivedDate {get; init;}
    public required MedicalReportContentRequest Content {get; init;}   
}

