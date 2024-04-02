
using App.Common.Utils;
using App.Common.Models.Requests;

namespace App.Surgeries.Models.Requests;
public sealed record SurgeryFullRequest 
{    
    public required string TreatmentNo {get; init;}
    public required string PatientNo {get; init;}
    public required DateTime VisitDate {get; init;}
    public required string Content {get; init;}   
    public required string CreatedBy {get; init;}   
    public required DateTime CreatedAt {get; init;}   
    public required string Agents {get; init;}   
    public static SurgeryFullRequest Create (SurgeryRequest request, string createdBy) 
        => new()
            {
                TreatmentNo = request.TreatmentNo,
                PatientNo = request.PatientNo,
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