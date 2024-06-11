
using App.Common.Utils;
using App.Patients.Contracts;
using App.Common.Models.Responses;

namespace App.Patients.Controllers;
public static class Helpers 
{
    public static async Task UpdatePatientConsumers(string patientNo, IPatient patient, string createdBy, DateTime createdAt, ILogger logger)
    {      
        try
        {
            
            var consumers = await patient.GetPatientConsumers(patientNo);

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

            var result = await patient.UpdatePatientConsumers(patientNo: patientNo, consumers: CommonUtils.SerializeContent(content: updatedConsumers));

            logger.LogInformation("Patient Consummers successfully updated for Patient No: {PatientNo} by {CreatedBy}", patientNo, createdBy);

        }

        catch  
        {
            logger.LogError("An error occurred while updating patient consumers for Patient No: {PatientNo} by {CreatedBy}", patientNo, createdBy);
        }
    }

}