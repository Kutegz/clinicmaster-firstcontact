
namespace ClinicMasterFirstContact.src.App.MedicalReports.Models.Responses;
public sealed record PatientAllergiesResponse 
{
    public required string Allergy {get; init;}
    public required string Category {get; init;}
    public required string Reaction {get; init;}   
    public static PatientAllergiesResponse Empty => new() 
    {
        Allergy = string.Empty,
        Category = string.Empty,
        Reaction = string.Empty
    };

}
