
using App.Common.Models.Responses;
using App.MedicalReports.Models.Requests;
using App.MedicalReports.Models.Responses;

namespace App.MedicalReports.Contracts;
public interface IMedicalReport
{
    public Task<bool> CreateMedicalReport(MedicalReportFullRequest request);
    public Task<bool> UpdateMedicalReport(MedicalReportFullRequest request);
    public Task<ResultResponse<MedicalReportResponse>> GetMedicalReport(string facilityCode, string visitNo);
    public Task<IEnumerable<ConsumerResponse>> GetMedicalReportConsumers(string facilityCode, string visitNo);
    public Task<string> GetMedicalReportBuddle(string facilityCode, string visitNo);
    public Task<bool> UpdateMedicalReportConsumers(string facilityCode, string visitNo, string consumers);
    public Task<ResultResponse<IEnumerable<MedicalReportResponse>>> GetMedicalReports(string facilityCode, int page, int pageSize);
}
