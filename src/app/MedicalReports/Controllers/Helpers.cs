
using ClinicMasterFirstContact.src.App.Common.Utils;
using ClinicMasterFirstContact.src.App.MedicalReports.Contracts;
using ClinicMasterFirstContact.src.App.Common.Models.Responses;

namespace ClinicMasterFirstContact.src.App.MedicalReports.Controllers;
public static class Helpers 
{
    public static async Task UpdateMedicalReportConsumers(string facilityCode, string visitNo, 
                                                        IMedicalReport medicalReport, string createdBy, 
                                                        DateTime createdAt, ILogger logger)
    {      
        try
        {
            
            var consumers = await medicalReport.GetMedicalReportConsumers(facilityCode: facilityCode, visitNo: visitNo);

            bool consumerExists = consumers.Any(c => string.Equals(c.AgentId, createdBy, StringComparison.OrdinalIgnoreCase));
            
            var updatedConsumers = consumers.Select(c =>
            {
                if (string.Equals(c.AgentId, createdBy, StringComparison.OrdinalIgnoreCase))
                {
                    return c with
                    {
                        SyncCount = c.SyncCount + 1,
                        SyncStatus = true,
                        LastUpdateDateTime = createdAt
                    };
                }

                return c;

            }).ToList();

            if (!consumerExists)
            {
                updatedConsumers.Add(new ConsumerResponse
                {
                    AgentId = createdBy,
                    AgentName = createdBy,
                    SyncCount = 1,
                    SyncStatus = true,
                    SyncDateTime = createdAt,
                    LastUpdateDateTime = createdAt,
                    SyncMessage = string.Empty
                });
            }

            var result = await medicalReport.UpdateMedicalReportConsumers(facilityCode: facilityCode, visitNo: visitNo, 
                                                                        consumers: CommonUtils.SerializeContent(content: updatedConsumers));

            logger.LogInformation("MedicalReport Consummers successfully updated for Facility Code No: {FacilityCode} and Visit No: {VisitNo} by {CreatedBy}", 
                                facilityCode, visitNo, createdBy);

        }

        catch  
        {
            logger.LogError("An error occurred while updating medicalReport consumers for Facility Code No: {FacilityCode} and Visit No: {VisitNo} by {CreatedBy}", 
                            facilityCode, visitNo, createdBy);
        }
    }

}