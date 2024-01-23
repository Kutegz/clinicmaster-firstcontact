namespace App.Patients.Models;
public sealed record PatientResult<TResponse> {
    public required bool Success {get; init;}
    public required string Message {get; init;}
    public required TResponse Data {get; init;}

}
