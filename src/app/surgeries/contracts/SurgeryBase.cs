
namespace App.Surgeries.Contracts;
public abstract record SurgeryBase<TContent> {
    public required string TreatmentNo {get; init;}
    public required string PatientNo {get; init;}
    public required DateTime VisitDate {get; init;}   
    public required TContent Content {get; init;}  
}

