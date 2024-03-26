
using App.Common.Utils;
using App.Common.Models.Requests;

namespace App.Patients.Models.Requests;
public sealed record PatientFullRequest 
{
    public required string PatientNo {get; init;}
    public required string FullName {get; init;}
    public required string Gender {get; init;}
    public required int Age {get; init;}
    public required string CreatedBy {get; init;}   
    public required DateTime CreatedAt {get; init;}   
    public required string Agents {get; init;}   
    public static PatientFullRequest Create (PatientRequest request, string createdBy) 
        => new()
            {
                PatientNo = request.PatientNo,
                FullName = request.FullName,
                Gender = request.Gender,
                Age = request.Age,
                CreatedBy = createdBy,
                CreatedAt = DateTime.Now,
                Agents = Helpers.SerializeContent(content: new AgentsRequest
                    {
                        Submitter = new AgentsSubmitterRequest
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