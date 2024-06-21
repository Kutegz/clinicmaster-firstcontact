
namespace ClinicMasterFirstContact.src.App.MedicalReports.Models.Responses;
public sealed record OrganizationResponse 
{
    public required string Code {get; init;}
    public required string Name {get; init;}
    public required string Address {get; init;}   
    public required string Contact {get; init;}   
    public static OrganizationResponse Empty => new() 
    {
        Code = string.Empty,
        Name = string.Empty,
        Address = string.Empty,
        Contact = string.Empty
    };

}