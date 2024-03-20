
using System.Diagnostics.Metrics;

namespace Api.MedicalReports.Services;
public class MedicalReportMetrics 
{
    public Counter<int> MedicalReportCounter { get; private set;  }
    public MedicalReportMetrics(IMeterFactory meterFactory) {
        var meter = meterFactory.Create("ReadMedicalReport");
        MedicalReportCounter = meter.CreateCounter<int>("readmedicalReport.medicalReport.count");
    }

}