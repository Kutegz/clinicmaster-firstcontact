using ClinicMasterFirstContact.src.App.Surgeries.Contracts;

namespace ClinicMasterFirstContact.src.App.Surgeries.Models.Responses;
public sealed record SurgeryRowData : SurgeryBase<string> {
    public static SurgeryRowData Empty => new() 
    {
        TreatmentNo = string.Empty,
        PatientNo = string.Empty,
        VisitDate = DateTime.MinValue,
        Content = string.Empty,
    };

}

