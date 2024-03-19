
namespace App.MedicalReports.Models.Responses;
public sealed record PrescriptionResponse 
{
    public required string Drug_code {get; init;}
    public required string Drug_name {get; init;}
    public required string Dosage {get; init;}   
    public required int Duration {get; init;}   
    public required int Quantity {get; init;}   
    public required string Notes {get; init;}   
    public static PrescriptionResponse Empty => new() 
    {
        Drug_code = string.Empty,
        Drug_name = string.Empty,
        Dosage = string.Empty,
        Duration = 0,
        Quantity = 0,
        Notes = string.Empty
    };

}
