
namespace ClinicMasterFirstContact.src.App.Common.Models.Responses;
public sealed record ConsumerResponse
{
    public required string AgentId { get; init; }
    public required string AgentName { get; init; }
    public required int SyncCount { get; init; }
    public required bool SyncStatus { get; init; }
    public required DateTime SyncDateTime { get; init; }
    public required DateTime LastUpdateDateTime { get; init; }
    public required string SyncMessage { get; init; }

}