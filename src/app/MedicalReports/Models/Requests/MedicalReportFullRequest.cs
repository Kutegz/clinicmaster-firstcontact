
using ClinicMasterFirstContact.src.App.Common.Utils;

namespace ClinicMasterFirstContact.src.App.MedicalReports.Models.Requests;
public sealed record MedicalReportFullRequest 
{
    public required string FacilityCode {get; init;}
    public required string VisitNo {get; init;}
    public required DateTime VisitDate {get; init;}
    public required string Content {get; init;}   
    public required string Creator {get; init;}   
    public required DateTime CreatedAt {get; init;}  
    public required string Consumers {get; init;}  
    public static MedicalReportFullRequest Create (MedicalReportRequest request, string creator, DateTime createdAt) 
        => new()
            {
                FacilityCode = request.FacilityCode,
                VisitNo = request.VisitNo,
                VisitDate = request.VisitDate,
                Content = CommonUtils.SerializeContent(content: request.Content),
                Creator = creator,
                CreatedAt = createdAt,
                Consumers = "[]"
            };
    
}