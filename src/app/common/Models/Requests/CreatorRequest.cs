
namespace App.Common.Models.Requests;
public sealed record CreatorRequest 
{
    public required string AgentId { get; init; }
    public required string AgentName { get; init; }
    public required int SyncCount { get; init; }
    public required bool SyncStatus { get; init; }
    public required DateTime SyncDateTime { get; init; }
    public required string ErrorMessage { get; init; }
    public static CreatorRequest Create (string agentId, string agentName, int syncCount, 
                                        bool syncStatus, DateTime syncDateTime, string errorMessage) 
    {
        return new()
            {
                AgentId = agentId,
                AgentName = agentName,
                SyncCount = syncCount,
                SyncStatus = syncStatus,
                SyncDateTime = syncDateTime,
                ErrorMessage = errorMessage
            };
    }

}
