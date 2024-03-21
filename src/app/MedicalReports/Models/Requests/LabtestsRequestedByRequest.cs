
namespace App.MedicalReports.Models.Requests;
public sealed record LabtestsRequestedByRequest 
{
    public required string Identifier { get; init; }
    public required string Name { get; init; }
    public required string Specialty { get; init; }
    public static LabtestsRequestedByRequest Empty => new() 
    {
        Identifier = string.Empty,
        Name = string.Empty,
        Specialty = string.Empty
    };

}
