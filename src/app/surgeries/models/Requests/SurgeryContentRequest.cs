
namespace App.Surgeries.Models.Requests;
public sealed record SurgeryContentRequest 
{
    public required string ProcedureCode {get; init;}
    public required string ProcedureName {get; init;}
    public required string Details {get; init;}    
    public required string MedicalHistory {get; init;}   
    public required List<string> AttachmentUrls {get; init;}
    public required List<PrescriptionRequest> Prescriptions {get; init;}   

}
