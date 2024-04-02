
using App.Common.Utils;
using App.Common.Models.Requests;

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
    public static MedicalReportFullRequest Create (MedicalReportRequest request, string createdBy) 
        => new()
            {
                FacilityCode = request.FacilityCode,
                VisitNo = request.VisitNo,
                VisitDate = request.VisitDate,
                Content = Utils.SerializeContent(content: request.Content),
                CreatedBy = createdBy,
                CreatedAt = DateTime.Now,
                Agents = Utils.SerializeContent(content: new AgentsRequest
                    {
                        Submitter = new SubmitterRequest
                            {
                                AgentId = createdBy,
                                AgentName = createdBy,
                                SyncCount = 1,
                                SyncStatus = true,
                                SyncDateTime = DateTime.Now,
                                ErrorMessage = string.Empty
                            }
                    }),
            };
    
}