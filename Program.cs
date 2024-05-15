using App.Home.Apis;
using App.Common.Utils;
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
using HealthChecks.UI.Client;
using App.MedicalReports.Apis;
using App.Surgeries.Contracts;
using App.Payments.Validators;
using App.Patients.Validators;
using App.MedicalReports.Data;
using Api.MedicalReports.Services;
using App.MedicalReports.Contracts;
using App.MedicalReports.Validators;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);
{
    string connectionString = builder.Configuration.GetConnectionString(name: "ClinicMasterConnection")!;
    builder.Services.AddHealthChecks()
    .AddSqlServer(connectionString: connectionString, name: "Database", tags: ["db", "sql", "sqlserver"]);

    builder.Services.AddOpenTelemetry().WithMetrics(configure: metrics => 
    {
        metrics.AddMeter(names: [..Constants.OpenTelemetryMeterNames]);

        metrics.AddView(instrumentName: "http.server.request.duration", 
            metricStreamConfiguration: new ExplicitBucketHistogramConfiguration
                {
                    Boundaries = [ 0, 0.005, 0.01, 0.025, 0.05, 0.075, 0.1, 
                                    0.25, 0.5, 0.75, 1, 2.5, 5, 7.5, 10 ]
                });
    
        metrics.AddPrometheusExporter();

        // OTLP destination can configure using an environment variable
        // OTEL_EXPORTER_OTLP_ENDPOINT

        metrics.AddOtlpExporter();
    });

    builder.Logging.AddOpenTelemetry(configure: options => 
    {
        options.AddOtlpExporter();
    });

    builder.Services.AddSingleton(implementationInstance: TimeProvider.System);
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

    app.UseHealthChecks(path: "/health", options: new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });

    app.ConfigureHomeApis();
    app.ConfigurePatientApis();
    app.ConfigureSurgeryApis();
    // app.ConfigurePaymentApis();
    app.ConfigureMedicalReportApis();

    app.MapPrometheusScrapingEndpoint();

    app.Run();

}

