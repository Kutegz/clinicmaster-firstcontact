
using App.Surgeries.Models;

namespace App.Patients.Models;
public sealed record PatientResponse {
    public required string PatientNo {get; init;}
    public required string FullName {get; init;}
    public required string Gender {get; init;}
    public required int Age {get; init;}
    public required List<SurgeryResponse> Surgeries {get; init;}   
    public static PatientResponse Empty => new() 
    {
        PatientNo = string.Empty,
        FullName = string.Empty,
        Gender = string.Empty,
        Age = 0,
        Surgeries= [],
    };

}