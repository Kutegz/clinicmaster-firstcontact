
using ClinicMasterFirstContact.src.App.Surgeries.Contracts;

namespace ClinicMasterFirstContact.src.App.Surgeries.Models.Responses;
public sealed record SurgeryResponse : SurgeryBase<SurgeryContentResponse> {
    public static SurgeryResponse Empty => new() 
    {
        TreatmentNo = string.Empty,
        PatientNo = string.Empty,
        VisitDate = DateTime.MinValue,
        Content = SurgeryContentResponse.Empty,
    };

}

