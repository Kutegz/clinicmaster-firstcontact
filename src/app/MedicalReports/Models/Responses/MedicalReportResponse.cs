
using ClinicMasterFirstContact.src.App.Common.Utils;
using ClinicMasterFirstContact.src.App.MedicalReports.Contracts;

namespace ClinicMasterFirstContact.src.App.MedicalReports.Models.Responses;
public sealed record MedicalReportResponse : MedicalReportBase<MedicalReportContentResponse> 
{
    public static MedicalReportResponse Empty => new() 
    {
        FacilityCode = string.Empty,
        VisitNo = string.Empty,
        VisitDate = DateTime.Parse(CommonConstants.NullDateTimeString),
        Content = MedicalReportContentResponse.Empty,
        CreatedAt = DateTime.Parse(CommonConstants.NullDateTimeString),
    };

}

