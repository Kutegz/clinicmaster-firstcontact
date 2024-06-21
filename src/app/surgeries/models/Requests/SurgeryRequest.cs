
namespace ClinicMasterFirstContact.src.App.Surgeries.Models.Requests;
public sealed record SurgeryRequest 
{
    public required string TreatmentNo {get; init;}
    public required string PatientNo {get; init;}
    public required DateTime VisitDate {get; init;}
    public required SurgeryContentRequest Content {get; init;}   
}

