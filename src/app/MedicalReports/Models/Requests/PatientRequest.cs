
using ClinicMasterFirstContact.src.App.Common.Utils;

namespace ClinicMasterFirstContact.src.App.MedicalReports.Models.Requests;
public sealed record PatientRequest 
{
    public required string Identifier {get; init;}
    public required int Age {get; init;}
    public required string Gender {get; init;}
    public required DateTime Join_date {get; init;}
    public required string Status {get; init;}
    public required List<string> Chronic_diseases {get; init;}   
    public required List<PatientAllergiesRequest> Allergies {get; init;}  
}