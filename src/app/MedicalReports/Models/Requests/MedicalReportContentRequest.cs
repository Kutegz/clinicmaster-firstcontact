
namespace App.MedicalReports.Models.Requests;
public sealed record MedicalReportContentRequest 
{
    public required string Encounter_type {get; init;}
    public required string Identifier {get; init;}
    public required string Encounter_status {get; init;}    
    public required string System {get; init;}   
    public required OrganizationRequest Organization {get; init;}  
    public required PatientRequest Patient {get; init;}
    public required TriageRequest Triage {get; init;}
    public required List<PrescriptionRequest> Prescriptions {get; init;}  
    public required ClinicalFindingsRequest Clinical_findings {get; init;}  
    public required List<DiagnosisRequest> Diagnosis {get; init;}  
    public required List<CancerDiagnosisRequest> Cancer_diagnosis {get; init;}  
    public required List<TheaterOperationRequest> Theater_operation {get; init;}  
    public required List<RadiologyRequest> Radiology {get; init;}  
    public required List<PathologyRequest> Pathology {get; init;}  
    public required VisionAssessmentRequest Vision_assessment {get; init;}  
    public required List<DentalRequest> Dental {get; init;}  
    public required EyeAssessmentRequest Eye_assessment {get; init;}  
    public required List<LabtestsRequest> Labtests {get; init;}  
    public static MedicalReportContentRequest Empty => new() 
    {
        Encounter_type = string.Empty,
        Identifier = string.Empty,
        Encounter_status = string.Empty,
        System = string.Empty,
        Organization = OrganizationRequest.Empty,
        Patient = PatientRequest.Empty,
        Triage = TriageRequest.Empty,
        Prescriptions = [],
        Clinical_findings = ClinicalFindingsRequest.Empty,
        Diagnosis = [],
        Cancer_diagnosis = [],
        Theater_operation = [],
        Radiology = [],
        Pathology = [],
        Vision_assessment = VisionAssessmentRequest.Empty,
        Dental = [],
        Eye_assessment = EyeAssessmentRequest.Empty,
        Labtests = [],
    };

}