
namespace App.MedicalReports.Models.Responses;
public sealed record EyeAssessmentResponse 
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
    public static EyeAssessmentResponse Empty => new() 
    {
        Left_pupil = string.Empty,
        Right_pupil = string.Empty,
        Left_lid_margin = string.Empty,
        Right_lid_margin = string.Empty,
        Left_conjunctiva = string.Empty,
        Right_conjunctiva = string.Empty,
        Left_bulbar_conjunctiva = string.Empty,
        Right_bulbar_conjunctiva = string.Empty,
        Left_central_cornea = string.Empty,
        Right_central_cornea = string.Empty,
        Left_vertical_cornea = string.Empty,
        Right_vertical_cornea = string.Empty,
        Left_anterior_chamber = string.Empty,
        Right_anterior_chamber = string.Empty,
        Left_iris = string.Empty,
        Right_iris = string.Empty,
        Left_anterior_chamber_angle = string.Empty,
        Right_anterior_chamber_angle = string.Empty,
        Left_retina = string.Empty,
        Right_retina = string.Empty,
        Left_macula = string.Empty,
        Right_macula = string.Empty,
        Left_optic_disc = string.Empty,
        Right_optic_disc = string.Empty,
        Left_iop = string.Empty,
        Right_iop = string.Empty,
        Left_vitreous = string.Empty,
        Right_vitreous = string.Empty,
        Left_lens = string.Empty,
        Right_lens = string.Empty,
        Eye_notes = string.Empty,
        Left_eye_ball = string.Empty,
        Right_eye_ball = string.Empty,
        Left_orbit = string.Empty,
        Right_orbit = string.Empty
    };
}
