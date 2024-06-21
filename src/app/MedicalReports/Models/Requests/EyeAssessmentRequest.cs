
namespace ClinicMasterFirstContact.src.App.MedicalReports.Models.Requests;
public sealed record EyeAssessmentRequest 
{
    public required string Left_pupil { get; init; }
    public required string Right_pupil { get; init; }
    public required string Left_lid_margin { get; init; }
    public required string Right_lid_margin { get; init; }
    public required string Left_conjunctiva { get; init; }
    public required string Right_conjunctiva { get; init; }
    public required string Left_bulbar_conjunctiva { get; init; }
    public required string Right_bulbar_conjunctiva { get; init; }
    public required string Left_central_cornea { get; init; }
    public required string Right_central_cornea { get; init; }
    public required string Left_vertical_cornea { get; init; }
    public required string Right_vertical_cornea { get; init; }
    public required string Left_anterior_chamber { get; init; }
    public required string Right_anterior_chamber { get; init; }
    public required string Left_iris { get; init; }
    public required string Right_iris { get; init; }
    public required string Left_anterior_chamber_angle { get; init; }
    public required string Right_anterior_chamber_angle { get; init; }
    public required string Left_retina { get; init; }
    public required string Right_retina { get; init; }
    public required string Left_macula { get; init; }
    public required string Right_macula { get; init; }
    public required string Left_optic_disc { get; init; }
    public required string Right_optic_disc { get; init; }
    public required string Left_iop { get; init; }
    public required string Right_iop { get; init; }
    public required string Left_vitreous { get; init; }
    public required string Right_vitreous { get; init; }
    public required string Left_lens { get; init; }
    public required string Right_lens { get; init; }
    public required string Eye_notes { get; init; }
    public required string Left_eye_ball { get; init; }
    public required string Right_eye_ball { get; init; }
    public required string Left_orbit { get; init; }
    public required string Right_orbit { get; init; }

}
