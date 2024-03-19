
namespace App.MedicalReports.Models.Responses;
public sealed record MedicalReportContentResponse 
{
    public required string Encounter_type {get; init;}
    public required string Identifier {get; init;}
    public required string Encounter_status {get; init;}    
    public required string System {get; init;}   
    public required OrganizationResponse Organization {get; init;}  
    public required PatientResponse Patient {get; init;}
    public required TriageResponse Triage {get; init;}
    public required List<PrescriptionResponse> Prescriptions {get; init;}  
    public required ClinicalFindingsResponse Clinical_findings {get; init;}  
    public required List<DiagnosisResponse> Diagnosis {get; init;}  
    public required List<CancerDiagnosisResponse> Cancer_diagnosis {get; init;}  
    public required List<TheaterOperationResponse> Theater_operation {get; init;}  
    public required List<RadiologyResponse> Radiology {get; init;}  
    public required List<PathologyResponse> Pathology {get; init;}  
    public required VisionAssessmentResponse Vision_assessment {get; init;}  
    public required List<DentalResponse> Dental {get; init;}  
    public required EyeAssessmentResponse Eye_assessment {get; init;}  
    public required List<LabtestsResponse> Labtests {get; init;}  
    public static MedicalReportContentResponse Empty => new() 
    {
        Encounter_type = string.Empty,
        Identifier = string.Empty,
        Encounter_status = string.Empty,
        System = string.Empty,
        Organization = OrganizationResponse.Empty,
        Patient = PatientResponse.Empty,
        Triage = TriageResponse.Empty,
        Prescriptions = [],
        Clinical_findings = ClinicalFindingsResponse.Empty,
        Diagnosis = [],
        Cancer_diagnosis = [],
        Theater_operation = [],
        Radiology = [],
        Pathology = [],
        Vision_assessment = VisionAssessmentResponse.Empty,
        Dental = [],
        Eye_assessment = EyeAssessmentResponse.Empty,
        Labtests = [],
    };

}