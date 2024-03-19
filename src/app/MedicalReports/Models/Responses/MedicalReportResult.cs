namespace App.MedicalReports.Models.Responses;
public sealed record MedicalReportResult<TResponse> 
{
    public required bool Success {get; init;}
    public required string Message {get; init;}
    public required TResponse Data {get; init;}

}
