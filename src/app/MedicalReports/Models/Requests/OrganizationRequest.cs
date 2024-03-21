
namespace App.MedicalReports.Models.Requests;
public sealed record OrganizationRequest 
{
    public required string Code {get; init;}
    public required string Name {get; init;}
    public required string Address {get; init;}   
    public required string Contact {get; init;}   

}