
namespace ClinicMasterFirstContact.src.App.Common.Models.Requests;
public sealed record ConsumerUpdateRequest
{    
    public required string UserName {get; init;}
    public required string FullName {get; init;}
    public required bool SyncStatus { get; init; }
    public required DateTime LastUpdateDateTime { get; init; }
    public required string SyncMessage { get; init; }  
    public static ConsumerUpdateRequest Create (string userName, string fullName, bool syncStatus, 
                                                DateTime lastUpdateDateTime, string syncMessage) 
    {
        return new()
            {
                UserName = userName,
                FullName = fullName,
                SyncStatus = syncStatus,
                LastUpdateDateTime = lastUpdateDateTime,
                SyncMessage = syncMessage
            };
    }

}
