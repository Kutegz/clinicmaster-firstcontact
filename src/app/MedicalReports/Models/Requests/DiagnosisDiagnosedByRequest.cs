
namespace ClinicMasterFirstContact.src.App.MedicalReports.Models.Requests;
public sealed record DiagnosisDiagnosedByRequest 
{
    public required string Identifier {get; init;}
    public required string Name {get; init;}
    public required string Specialty {get; init;}

}
