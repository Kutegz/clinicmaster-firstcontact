
using App.Common.Utils;

namespace App.MedicalReports.Models.Requests;
public sealed record MedicalReportFullRequest 
{
    public required string FacilityCode {get; init;}
    public required string VisitNo {get; init;}
    public required DateTime VisitDate {get; init;}
    public required string Content {get; init;}   
    public required string CreatedBy {get; init;}   
    public required DateTime CreatedAt {get; init;}   
    public required string Agents {get; init;}   
    public static MedicalReportFullRequest Create (MedicalReportRequest request) => new()
    {
        FacilityCode = request.FacilityCode,
        VisitNo = request.VisitNo,
        VisitDate = request.VisitDate,
        Content = Helpers.SerializeContent(content: request.Content),
        CreatedBy = "System User",
        CreatedAt = DateTime.Now,
        Agents = "[]"
    };
    
}