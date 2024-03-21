
namespace App.MedicalReports.Models.Requests;
public sealed record PatientAllergiesRequest 
{
    public required string Allergy {get; init;}
    public required string Category {get; init;}
    public required string Reaction {get; init;}   
    public static PatientAllergiesRequest Empty => new() 
    {
        Allergy = string.Empty,
        Category = string.Empty,
        Reaction = string.Empty
    };

}
