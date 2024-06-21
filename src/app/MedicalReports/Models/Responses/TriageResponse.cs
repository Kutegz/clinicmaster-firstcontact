
namespace ClinicMasterFirstContact.src.App.MedicalReports.Models.Responses;
public sealed record TriageResponse 
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
    public static TriageResponse Empty => new() 
    {
        Weight = 0,
        Height = 0,
        Temperature = 0,
        Pulse = 0,
        Blood_pressure = string.Empty,
        Muac = 0,
        Bmi = 0,
        Bmi_status = string.Empty,
        Head_circum = 0,
        Body_surface_area = 0,
        Respiration_rate = 0,
        Oxygen_saturation = 0,
        Heart_rate = 0,
        Notes = string.Empty
    };

}