
namespace App.Common.Models.Requests;
public sealed record AgentsRequest
{        
    public required SubmitterRequest Submitter {get; init;} 
}