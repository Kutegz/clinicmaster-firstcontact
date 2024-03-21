
namespace App.MedicalReports.Models.Requests;
public sealed record DentalRequest 
{
    public required string Dental_service { get; init; }
    public required string Notes { get; init; }
    public required string Status { get; init; }
    public static DentalRequest Empty => new() 
    {
        Dental_service = string.Empty,
        Notes = string.Empty,
        Status = string.Empty
    };
}
 