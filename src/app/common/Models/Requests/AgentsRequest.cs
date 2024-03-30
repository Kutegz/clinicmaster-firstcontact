
namespace App.Common.Models.Requests;
public sealed record AgentsRequest
{        
    public required AgentsSubmitterRequest Submitter {get; init;} 
}