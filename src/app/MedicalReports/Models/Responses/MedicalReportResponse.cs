
using App.Common.Utils;
using App.MedicalReports.Contracts;

namespace App.MedicalReports.Models.Responses;
public sealed record MedicalReportResponse : MedicalReportBase<MedicalReportContentResponse> 
{
    public static MedicalReportResponse Empty => new() 
    {
        FacilityCode = string.Empty,
        VisitNo = string.Empty,
        VisitDate = DateTime.Parse(Constants.NullDateTimeString),
        Content = MedicalReportContentResponse.Empty,
        CreatedAt = DateTime.Parse(Constants.NullDateTimeString),
    };

}

