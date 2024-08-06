
namespace ClinicMasterFirstContact.src.App.MedicalReports.Models.Responses;
public sealed record PatientResponse 
{
    public required string Identifier {get; init;}
    public required int Age {get; init;}
    public required string Gender {get; init;}
    public required DateTime Join_date {get; init;}
    public required string Status {get; init;}
    public required List<string> Chronic_diseases {get; init;}   
    public required List<PatientAllergiesResponse> Allergies {get; init;}  
    public static PatientResponse Empty => new() 
    {
        Identifier = string.Empty,
        Age = 0,
        Gender = string.Empty,
        Join_date = DateTime.MinValue,
        Status = string.Empty,
        Chronic_diseases = [],
        Allergies = [],
    };

}