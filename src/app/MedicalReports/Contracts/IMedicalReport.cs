
using App.MedicalReports.Models;

namespace App.MedicalReports.Contracts;
public interface IMedicalReport
{
    public Task<MedicalReportResult<MedicalReportResponse>> GetMedicalReport(string facilityCode, string visitNo);
    public Task<MedicalReportResult<IEnumerable<MedicalReportResponse>>> GetMedicalReports(string facilityCode, int page, int pageSize);
}
