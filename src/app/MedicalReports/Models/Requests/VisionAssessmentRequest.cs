
namespace App.MedicalReports.Models.Requests;
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
    public static VisionAssessmentRequest Empty => new() 
    {
        Entry_order = string.Empty,
        Eye_test = string.Empty,
        Visual_acuity_right = string.Empty,
        Visual_acuity_right_ext = string.Empty,
        Visual_acuity_left = string.Empty,
        Visual_acuity_left_ext = string.Empty,
        Preferential_looking_right = string.Empty,
        Preferential_looking_left = string.Empty,
        Notes = string.Empty
    };

}
