
namespace App.MedicalReports.Models.Requests;
public sealed record OrganizationRequest 
{
    public required string Code {get; init;}
    public required string Name {get; init;}
    public required string Address {get; init;}   
    public required string Contact {get; init;}   
    public static OrganizationRequest Empty => new() 
    {
        Code = string.Empty,
        Name = string.Empty,
        Address = string.Empty,
        Contact = string.Empty
    };

}