
using App.Common.Utils;
using App.Surgeries.Contracts;

namespace App.Surgeries.Models.Responses;
public sealed record SurgeryRowData : SurgeryBase<string> {
    public static SurgeryRowData Empty => new() 
    {
        TreatmentNo = string.Empty,
        PatientNo = string.Empty,
        VisitDate = DateTimeOffset.Parse(CommonConstants.NullDateTimeString),
        Content = string.Empty,
    };

}

