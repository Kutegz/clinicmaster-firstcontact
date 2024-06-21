
namespace ClinicMasterFirstContact.src.App.MedicalReports.Models.Requests;
public sealed record VisionAssessmentRequest 
{
    public required string Entry_order { get; init; }
    public required string Eye_test { get; init; }
    public required string Visual_acuity_right { get; init; }
    public required string Visual_acuity_right_ext { get; init; }
    public required string Visual_acuity_left { get; init; }
    public required string Visual_acuity_left_ext { get; init; }
    public required string Preferential_looking_right { get; init; }
    public required string Preferential_looking_left { get; init; }
    public required string Notes { get; init; }
}
