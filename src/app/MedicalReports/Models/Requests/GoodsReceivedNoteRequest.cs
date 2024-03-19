
namespace App.GoodsReceivedNote.Models.Requests;
public sealed record GoodsReceivedNoteRequest 
{
    public required string GRNNo {get; init;}
    public required DateTime ReceivedDate {get; init;}
    public required GoodsReceivedNoteContentRequest Content {get; init;}   
}

