
using App.Common.Utils;
using App.Common.Models.Requests;

namespace App.MedicalReports.Models.Requests;
public sealed record MedicalReportFullRequest 
{
    public required string FacilityCode {get; init;}
    public required string VisitNo {get; init;}
    public required DateTimeOffset VisitDate {get; init;}
    public required string Content {get; init;}   
    public required string Creator {get; init;}   
    public required DateTimeOffset CreatedAt {get; init;}  
    public required string Consumers {get; init;}  
    public static MedicalReportFullRequest Create (MedicalReportRequest request, string creator, DateTimeOffset createdAt) 
        => new()
            {
                FacilityCode = request.FacilityCode,
                VisitNo = request.VisitNo,
                VisitDate = request.VisitDate,
                Content = Utils.SerializeContent(content: request.Content),
                Creator = creator,
                CreatedAt = createdAt,
                Consumers = "[]"
            };
    
}