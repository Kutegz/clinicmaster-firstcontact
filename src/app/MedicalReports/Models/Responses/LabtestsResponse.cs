

namespace ClinicMasterFirstContact.src.App.MedicalReports.Models.Responses;
public sealed record LabtestsResponse 
{
    public required string Test_code { get; init; }
    public required string Test_name { get; init; }
    public required string Status { get; init; }
    public required string Notes { get; init; }
    public required LabtestsRequestedByResponse Requested_by {get; init;}  
    public static LabtestsResponse Empty => new() 
    {
        Test_code = string.Empty,
        Test_name = string.Empty,
        Status = string.Empty,
        Notes = string.Empty,
        Requested_by = LabtestsRequestedByResponse.Empty,
    };
}