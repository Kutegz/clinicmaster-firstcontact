
using App.MedicalReports.Models.Requests;
using App.MedicalReports.Models.Responses;

namespace App.MedicalReports.Contracts;
public interface IMedicalReport
{
    public Task<bool> CreateMedicalReport(MedicalReportFullRequest request);
    public Task<MedicalReportResult<MedicalReportResponse>> GetMedicalReport(string facilityCode, string visitNo);
    public Task<MedicalReportResult<IEnumerable<MedicalReportResponse>>> GetMedicalReports(string facilityCode, int page, int pageSize);
}
