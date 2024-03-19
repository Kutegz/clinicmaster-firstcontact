
namespace App.Surgeries.Models.Responses;
public sealed record PrecriptionResponse {
    public required string DrugNo {get; init;}
    public required string DrugName {get; init;}
    public required string Dosage {get; init;}   
    public static PrecriptionResponse Empty => new() 
    {
        DrugNo = string.Empty,
        DrugName = string.Empty,
        Dosage = string.Empty,
    };

}