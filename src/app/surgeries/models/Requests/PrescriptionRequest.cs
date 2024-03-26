
namespace App.Surgeries.Models.Requests;
public sealed record PrescriptionRequest 
{
    public required string DrugNo {get; init;}
    public required string DrugName {get; init;}
    public required string Dosage {get; init;}    
}
