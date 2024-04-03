
namespace App.MedicalReports.Contracts;
public abstract record MedicalReportBase<TContent> {
    public required string FacilityCode {get; init;}
    public required string VisitNo {get; init;}
    public required DateTimeOffset VisitDate {get; init;}   
    public required TContent Content {get; init;}  
    public required DateTimeOffset CreatedAt {get; init;}   
}
