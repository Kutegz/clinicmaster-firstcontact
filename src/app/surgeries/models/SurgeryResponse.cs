
using App.Common.Helpers;
using App.Surgeries.Contracts;

namespace App.Surgeries.Models;
public sealed record SurgeryResponse : SurgeryBase<SurgeryContentResponse> {
    public static SurgeryResponse Empty => new() 
    {
        TreatmentNo = string.Empty,
        PatientNo = string.Empty,
        VisitDate = DateTime.Parse(Properties.NullDateTimeString),
        Content = SurgeryContentResponse.Empty,
    };

}

