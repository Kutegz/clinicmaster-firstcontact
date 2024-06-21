
namespace ClinicMasterFirstContact.src.App.MedicalReports.Models.Responses;
public sealed record DentalResponse 
{
    public required string Dental_service { get; init; }
    public required string Notes { get; init; }
    public required string Status { get; init; }
    public static DentalResponse Empty => new() 
    {
        Dental_service = string.Empty,
        Notes = string.Empty,
        Status = string.Empty
    };
}
 