
using ClinicMasterFirstContact.src.App.Common.Utils;

namespace ClinicMasterFirstContact.src.App.Payments.Models.Requests;
public sealed record PaymentFullRequest 
{
    public required string GRNNo {get; init;}
    public required DateTime ReceivedDate {get; init;}
    public required string Content {get; init;}   
    public required string CreatedBy {get; init;}   
    public required DateTime CreatedAt {get; init;}   
    public required bool SyncStatus {get; init;}   
    public static PaymentFullRequest Create (PaymentRequest request) => new()
    {
        GRNNo = request.GRNNo,
        ReceivedDate = request.ReceivedDate,
        Content = CommonUtils.SerializeContent(content: request.ContentReceived),
        CreatedBy = "Admin",
        CreatedAt = DateTime.Now,
        SyncStatus = false
    };
    
}