

namespace App.MedicalReports.Models.Requests;
public sealed record LabtestsRequest 
{
    public required string Test_code { get; init; }
    public required string Test_name { get; init; }
    public required string Status { get; init; }
    public required string Notes { get; init; }
    public required LabtestsRequestedByRequest Requested_by {get; init;}  
}