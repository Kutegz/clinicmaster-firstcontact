
namespace ClinicMasterFirstContact.src.App.MedicalReports.Models.Requests;
public sealed record PrescriptionRequest 
{
    public required string Drug_code {get; init;}
    public required string Drug_name {get; init;}
    public required string Dosage {get; init;}   
    public required int Duration {get; init;}   
    public required int Quantity {get; init;}   
    public required string Notes {get; init;}   
}
