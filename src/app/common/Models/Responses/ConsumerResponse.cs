
namespace App.Common.Models.Responses;
public sealed record ConsumerResponse
{
    public required string AgentId { get; init; }
    public required string AgentName { get; init; }
    public required int SyncCount { get; init; }
    public required bool SyncStatus { get; init; }
    public required DateTimeOffset SyncDateTime { get; init; }
    public required DateTimeOffset LastUpdateDateTime { get; init; }
    public required string ErrorMessage { get; init; }

}