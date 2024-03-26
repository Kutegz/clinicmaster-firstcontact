
namespace App.Common.Models.Requests;
public sealed record AgentsSubmitterRequest 
{
    public required string AgentId { get; init; }
    public required string AgentName { get; init; }
    public required int SyncCount { get; init; }
    public required bool SyncStatus { get; init; }
    public required DateTime SyncDateTime { get; init; }
    public required string ErrorMessage { get; init; }

}