
namespace App.Common.Models.Requests;
public sealed record ConsumerRequest
{    
    public required string AgentId { get; init; }
    public required string AgentName { get; init; }
    public required int SyncCount { get; init; }
    public required bool SyncStatus { get; init; }
    public required DateTime SyncDateTime { get; init; }
    public required DateTime LastUpdateDateTime { get; init; }
    public required string ErrorMessage { get; init; }  
    public static ConsumerRequest Create (string agentId, string agentName, int syncCount, bool syncStatus, 
                                            DateTime syncDateTime, DateTime lastUpdateDateTime, string errorMessage) 
    {
        return new()
            {
                AgentId = agentId,
                AgentName = agentName,
                SyncCount = syncCount,
                SyncStatus = syncStatus,
                SyncDateTime = syncDateTime,
                LastUpdateDateTime = lastUpdateDateTime,
                ErrorMessage = errorMessage
            };
    }

}
