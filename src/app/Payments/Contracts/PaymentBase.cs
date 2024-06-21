
namespace ClinicMasterFirstContact.src.App.Payments.Contracts;
public abstract record PaymentBase<TContentSent> 
{
    public required string BillNo {get; init;}
    public required string PayNo {get; init;}
    public required string PayType {get; init;}
    public required TContentSent ContentSent {get; init;}  
    public required string CreatedBy {get; init;}
    public required DateTime CreatedAt {get; init;}   
    public required bool Completed {get; init;}  
}
