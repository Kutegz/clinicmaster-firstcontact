
using App.Common.Utils;

namespace App.MedicalReports.Models.Requests;
public sealed record MedicalReportFullRequest 
{
    public required string GRNNo {get; init;}
    public required DateTime ReceivedDate {get; init;}
    public required string Content {get; init;}   
    public required string CreatedBy {get; init;}   
    public required DateTime CreatedAt {get; init;}   
    public required bool SyncStatus {get; init;}   
    public static MedicalReportFullRequest Create (MedicalReportRequest request) => new()
    {
        GRNNo = request.GRNNo,
        ReceivedDate = request.ReceivedDate,
        Content = Helpers.SerializeContent(content: request.Content),
        CreatedBy = "System User",
        CreatedAt = DateTime.Now,
        SyncStatus = false
    };
    
}