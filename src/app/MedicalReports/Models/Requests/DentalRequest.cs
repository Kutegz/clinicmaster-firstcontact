
namespace ClinicMasterFirstContact.src.App.MedicalReports.Models.Requests;
public sealed record DentalRequest 
{
    public required string Dental_service { get; init; }
    public required string Notes { get; init; }
    public required string Status { get; init; }
}
 