using ClinicMasterFirstContact.src.App.MedicalReports.Contracts;

namespace ClinicMasterFirstContact.src.App.MedicalReports.Models.Responses;
public sealed record MedicalReportRowData : MedicalReportBase<string> 
{
    public static MedicalReportRowData Empty => new() 
    {
        FacilityCode = string.Empty,
        VisitNo = string.Empty,
        VisitDate = DateTime.MinValue,
        Content = string.Empty,
        CreatedAt = DateTime.MinValue,
    };

}
