
using App.Common.Utils;
using App.MedicalReports.Contracts;

namespace App.MedicalReports.Models.Responses;
public sealed record MedicalReportRowData : MedicalReportBase<string> 
{
    public static MedicalReportRowData Empty => new() 
    {
        FacilityCode = string.Empty,
        VisitNo = string.Empty,
        VisitDate = DateTime.Parse(CommonConstants.NullDateTimeString),
        Content = string.Empty,
        CreatedAt = DateTime.Parse(CommonConstants.NullDateTimeString),
    };

}
