
namespace App.GoodsReceivedNote.Models.Requests;
public sealed record GoodsReceivedNoteDetailsRequest 
{
    public required string ItemCode {get; init;}   
    public required string ItemName {get; init;}
    public required string ItemCategory {get; init;}
    public required string UnitMeasure {get; init;}
    public required int Quantity {get; init;}
    public required int BonusQuantity {get; init;}
    public required decimal UnitPrice {get; init;}
    public required decimal Discount {get; init;}
    public required decimal VATValue {get; init;}
    public required decimal Amount {get; init;}    
}
