

using App.Common.Utils;
using App.Surgeries.Contracts;

namespace App.Surgeries.Models;
public sealed record SurgeryResponse : SurgeryBase<SurgeryContentResponse> {
    public static SurgeryResponse Empty => new() 
    {
        TreatmentNo = string.Empty,
        PatientNo = string.Empty,
        VisitDate = DateTime.Parse(Constants.NullDateTimeString),
        Content = SurgeryContentResponse.Empty,
    };

}

