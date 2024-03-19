
namespace App.MedicalReports.Models.Requests;
public sealed record MedicalReportContentRequest 
{
    public required string SupplierNo {get; init;}
    public required string SupplierName {get; init;}
    public required decimal TotalAmount {get; init;}
    public required decimal TotalDiscount {get; init;}
    public required List<MedicalReportDetailsRequest> Details {get; init;}   
}
