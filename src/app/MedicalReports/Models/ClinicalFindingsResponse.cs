
namespace App.MedicalReports.Models;

public sealed record ClinicalFindingsResponse 
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
    public static ClinicalFindingsResponse Empty => new() 
    {
        Presenting_complaint = string.Empty,
        Ros = string.Empty,
        Pmh = string.Empty,
        Poh = string.Empty,
        Pgh = string.Empty,
        Fsh = string.Empty,
        Ent = string.Empty,
        Eye = string.Empty,
        Skin = string.Empty,
        Provisional_diagnosis = string.Empty,
        Treatment_plan = string.Empty,
        Clinical_notes = string.Empty,
        Respiratory = string.Empty,
        General_appearance = string.Empty,
        Cvs = string.Empty,
        Muscular_skeletal = string.Empty,
        Psychological_status = string.Empty,
        Clinical_diagnosis = string.Empty,
        Clinical_image = string.Empty,
        Pv = string.Empty
    };

}
