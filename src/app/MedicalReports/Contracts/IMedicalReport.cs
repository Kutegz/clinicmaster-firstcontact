
using ClinicMasterFirstContact.src.App.Common.Models.Responses;
using ClinicMasterFirstContact.src.App.MedicalReports.Models.Requests;
using ClinicMasterFirstContact.src.App.MedicalReports.Models.Responses;

namespace ClinicMasterFirstContact.src.App.MedicalReports.Contracts;
public interface IMedicalReport
{
    public Task<int> CreateMedicalReport(MedicalReportFullRequest request);
    public Task<int> UpdateMedicalReport(MedicalReportFullRequest request);
    public Task<ResultResponse<MedicalReportResponse>> GetMedicalReport(string facilityCode, string visitNo);
    public Task<IEnumerable<ConsumerResponse>> GetMedicalReportConsumers(string facilityCode, string visitNo);
    public Task<string> GetMedicalReportBuddle(string facilityCode, string visitNo);
    public Task<int> UpdateMedicalReportConsumers(string facilityCode, string visitNo, string consumers);
    public Task<ResultResponse<IEnumerable<MedicalReportResponse>>> GetMedicalReports(string facilityCode, int page, int pageSize);
}
