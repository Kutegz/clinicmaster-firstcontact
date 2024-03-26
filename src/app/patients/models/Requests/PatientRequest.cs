
namespace App.Patients.Models.Requests;
public sealed record PatientRequest 
{
    public required string PatientNo {get; init;}
    public required string FullName {get; init;}
    public required string Gender {get; init;}
    public required int Age {get; init;}
}
