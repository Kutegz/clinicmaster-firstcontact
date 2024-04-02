
using App.Common.Utils;
using App.Common.Models.Requests;

namespace App.Patients.Models.Requests;
public sealed record PatientFullRequest 
{
    public required string PatientNo {get; init;}
    public required string FullName {get; init;}
    public required string Gender {get; init;}
    public required int Age {get; init;}
    public required string Creator {get; init;}   
    public required DateTime CreatedAt {get; init;}  
    public required string Consumers {get; init;}  
    public static PatientFullRequest Create (PatientRequest request, string creator, DateTime createdAt) 
    {
        return new()
            {
                PatientNo = request.PatientNo,
                FullName = request.FullName,
                Gender = request.Gender,
                Age = request.Age,
                Creator = creator,
                CreatedAt = createdAt,
                Consumers = "[]"
            };
    }
    
}