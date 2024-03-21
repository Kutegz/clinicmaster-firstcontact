
namespace App.MedicalReports.Models.Requests;
public sealed record TriageRequest 
{
    public required float Weight {get; init;}
    public required int Height {get; init;}
    public required float Temperature {get; init;}   
    public required int Pulse {get; init;}   
    public required string Blood_pressure {get; init;}   
    public required float Muac {get; init;}
    public required float Bmi {get; init;}
    public required string Bmi_status {get; init;}
    public required int Head_circum {get; init;}
    public required float Body_surface_area {get; init;}
    public required int Respiration_rate {get; init;}
    public required int Oxygen_saturation {get; init;}
    public required int Heart_rate {get; init;} 
    public required string Notes {get; init;}  
}