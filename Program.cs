using App.Home.Apis;
using FluentValidation;
using App.Patients.Apis;
using App.Patients.Data;
// using App.Payments.Apis;
using App.Payments.Data;
using OpenTelemetry.Logs;
using App.Common.Context;
using App.Surgeries.Apis;
using App.Surgeries.Data;
using App.Common.Exceptions;
using OpenTelemetry.Metrics;
using App.Patients.Contracts;
using App.Payments.Contracts;
using App.MedicalReports.Apis;
using App.Surgeries.Contracts;
using App.Payments.Validators;
using App.Patients.Validators;
using App.MedicalReports.Data;
using Api.MedicalReports.Services;
using App.MedicalReports.Contracts;
using App.MedicalReports.Validators;

var builder = WebApplication.CreateBuilder(args);
{       
    builder.Services.AddOpenTelemetry().WithMetrics(configure: metrics => 
    {
        metrics.AddMeter(names: ["Microsoft.AspNetCore.Hosting", "System.Net.Http",
                                "Microsoft.AspNetCore.Server.Kestrel", "ReadMedicalReport"]);
        metrics.AddPrometheusExporter();

        // OTLP destination can configure using an environment variable
        // OTEL_EXPORTER_OTLP_ENDPOINT

        metrics.AddOtlpExporter();
    });

    builder.Logging.AddOpenTelemetry(configure: options => 
    {
        options.AddOtlpExporter();
    });

    builder.Services.AddSingleton<MedicalReportMetrics>();

    builder.Services.AddAuthentication();
    builder.Services.AddAuthorization();
    
    builder.Services.AddSingleton<ClinicMasterContext>();
    builder.Services.AddScoped<IPatient, Patient>();
    builder.Services.AddScoped<ISurgery, Surgery>();
    builder.Services.AddScoped<IPayment, Payment>();
    builder.Services.AddScoped<IMedicalReport, MedicalReport>();

    builder.Services.AddValidatorsFromAssemblyContaining(type: typeof(PatientRequestValidator));
    builder.Services.AddValidatorsFromAssemblyContaining(type: typeof(PaymentRequestValidator));
    builder.Services.AddValidatorsFromAssemblyContaining(type: typeof(MedicalReportRequestValidator));

    builder.Services.AddExceptionHandler<AppExceptionHandler>();

}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.

    app.UseExceptionHandler(_ => {});
    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

    app.ConfigureHomeApis();
    app.ConfigurePatientApis();
    app.ConfigureSurgeryApis();
    // app.ConfigurePaymentApis();
    app.ConfigureMedicalReportApis();

    app.MapPrometheusScrapingEndpoint();

    app.Run();

}

