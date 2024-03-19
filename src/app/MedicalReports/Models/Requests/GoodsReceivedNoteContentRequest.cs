
namespace App.GoodsReceivedNote.Models.Requests;
public sealed record GoodsReceivedNoteContentRequest 
{
    public required string SupplierNo {get; init;}
    public required string SupplierName {get; init;}
    public required decimal TotalAmount {get; init;}
    public required decimal TotalDiscount {get; init;}
    public required List<GoodsReceivedNoteDetailsRequest> Details {get; init;}   
}
