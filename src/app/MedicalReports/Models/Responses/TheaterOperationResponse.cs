
using App.Common.Utils;

namespace App.MedicalReports.Models.Responses;
public sealed record TheaterOperationResponse 
{
    public required string Anaesthesia_type {get; init;}
    public required string Operation_class {get; init;}
    public required string Preoperative_diagnosis {get; init;}
    public required string Planned_procedures {get; init;}
    public required string Report {get; init;}
    public required string Postoperative_instructions {get; init;}
    public required DateTime Operation_datetime {get; init;}
    public static TheaterOperationResponse Empty => new() 
    {
        Anaesthesia_type = string.Empty,
        Operation_class = string.Empty,
        Preoperative_diagnosis = string.Empty,
        Planned_procedures = string.Empty,
        Report = string.Empty,
        Postoperative_instructions = string.Empty,
        Operation_datetime = DateTime.Parse(Constants.NullDateTimeString),
    };
}
