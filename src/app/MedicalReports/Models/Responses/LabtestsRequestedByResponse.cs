
namespace ClinicMasterFirstContact.src.App.MedicalReports.Models.Responses;
public sealed record LabtestsRequestedByResponse 
{
    public required string Identifier { get; init; }
    public required string Name { get; init; }
    public required string Specialty { get; init; }
    public static LabtestsRequestedByResponse Empty => new() 
    {
        Identifier = string.Empty,
        Name = string.Empty,
        Specialty = string.Empty
    };

}
