
namespace App.Surgeries.Models;
public sealed record SurgeryContentResponse {

    public required string ProcedureCode {get; init;}
    public required string ProcedureName {get; init;}
    public required string Details {get; init;}    
    public required string MedicalHistory {get; init;}   
    public required List<string> AttachmentUrls {get; init;}   
    public required List<PrecriptionResponse> Precriptions {get; init;}  
    public static SurgeryContentResponse Empty => new() 
    {
        ProcedureCode = string.Empty,
        ProcedureName = string.Empty,
        Details = string.Empty,
        MedicalHistory = string.Empty,
        AttachmentUrls = [],
        Precriptions = [],
    };

}

