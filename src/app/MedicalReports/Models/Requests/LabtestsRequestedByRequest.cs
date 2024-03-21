
namespace App.MedicalReports.Models.Requests;
public sealed record LabtestsRequestedByRequest 
{
    public required string Identifier { get; init; }
    public required string Name { get; init; }
    public required string Specialty { get; init; }
}
