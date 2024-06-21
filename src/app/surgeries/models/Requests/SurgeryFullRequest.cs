
using ClinicMasterFirstContact.src.App.Common.Utils;
using ClinicMasterFirstContact.src.App.Common.Models.Requests;

namespace ClinicMasterFirstContact.src.App.Surgeries.Models.Requests;
public sealed record SurgeryFullRequest 
{    
    public required string TreatmentNo {get; init;}
    public required string PatientNo {get; init;}
    public required DateTime VisitDate {get; init;}
    public required string Content {get; init;}   
    public required string Creator {get; init;}   
    public required DateTime CreatedAt {get; init;}  
    public required List<ConsumerRequest> Consumers {get; init;}  
    public static SurgeryFullRequest Create (SurgeryRequest request, string creator, DateTime createdAt) 
        => new()
            {
                TreatmentNo = request.TreatmentNo,
                PatientNo = request.PatientNo,
                VisitDate = request.VisitDate,
                Content = CommonUtils.SerializeContent(content: request.Content),
                Creator = creator,
                CreatedAt = createdAt,
                Consumers = []
            };
    
}