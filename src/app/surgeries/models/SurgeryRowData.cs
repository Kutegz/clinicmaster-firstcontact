
using App.Common.Utils;
using App.Surgeries.Contracts;

namespace App.Surgeries.Models;
public sealed record SurgeryRowData : SurgeryBase<string> {
    public static SurgeryRowData Empty => new() 
    {
        TreatmentNo = string.Empty,
        PatientNo = string.Empty,
        VisitDate = DateTime.Parse(Constants.NullDateTimeString),
        Content = string.Empty,
    };

}

