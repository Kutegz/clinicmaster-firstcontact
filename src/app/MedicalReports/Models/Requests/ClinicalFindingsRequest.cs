
namespace ClinicMasterFirstContact.src.App.MedicalReports.Models.Requests;
public sealed record ClinicalFindingsRequest 
{
    public required string Presenting_complaint {get; init;}
    public required string Ros {get; init;}
    public required string Pmh {get; init;}
    public required string Poh {get; init;}
    public required string Pgh {get; init;}
    public required string Fsh {get; init;}
    public required string Ent {get; init;}
    public required string Eye {get; init;}
    public required string Skin {get; init;}
    public required string Provisional_diagnosis {get; init;}
    public required string Treatment_plan {get; init;}
    public required string Clinical_notes {get; init;}
    public required string Respiratory {get; init;}
    public required string General_appearance {get; init;}
    public required string Cvs {get; init;}
    public required string Muscular_skeletal {get; init;}
    public required string Psychological_status {get; init;}
    public required string Clinical_diagnosis {get; init;}
    public required string Clinical_image {get; init;}
    public required string Pv {get; init;}

}
