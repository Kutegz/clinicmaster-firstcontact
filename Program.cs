using FluentValidation;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using HealthChecks.UI.Client;
using ClinicMasterFirstContact.src.App.Home.Apis;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using ClinicMasterFirstContact.src.App.Common.Utils;
using ClinicMasterFirstContact.src.App.Patients.Apis;
using ClinicMasterFirstContact.src.App.Patients.Data;
using ClinicMasterFirstContact.src.App.Payments.Data;
using ClinicMasterFirstContact.src.App.Common.Context;
using ClinicMasterFirstContact.src.App.Surgeries.Apis;
using ClinicMasterFirstContact.src.App.Surgeries.Data;
using ClinicMasterFirstContact.src.App.Common.Exceptions;
using ClinicMasterFirstContact.src.App.Patients.Contracts;
using ClinicMasterFirstContact.src.App.Payments.Contracts;
using ClinicMasterFirstContact.src.App.MedicalReports.Apis;
using ClinicMasterFirstContact.src.App.Surgeries.Contracts;
using ClinicMasterFirstContact.src.App.Payments.Validators;
using ClinicMasterFirstContact.src.App.Patients.Validators;
using ClinicMasterFirstContact.src.App.MedicalReports.Data;
using ClinicMasterFirstContact.src.App.MedicalReports.Services;
using ClinicMasterFirstContact.src.App.MedicalReports.Contracts;
using ClinicMasterFirstContact.src.App.MedicalReports.Validators;

var builder = WebApplication.CreateBuilder(args: args);
{
    string connectionString = builder.Configuration.GetConnectionString(name: "ClinicMasterConnection")!;
    builder.Services.AddHealthChecks()
    .AddSqlServer(connectionString: connectionString, name: "Database", tags: ["db", "sql", "sqlserver"]);

    builder.Services.AddOpenTelemetry().WithMetrics(configure: metrics => 
    {
        metrics.AddMeter(names: [..CommonConstants.OpenTelemetryMeterNames]);

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

    builder.Services.AddCors(setupAction: options 
        => options.AddPolicy(name: CommonConstants.CorsPolicyName, configurePolicy: builder 
            => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .WithOrigins(origins: "*")));

}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.

    app.UseExceptionHandler(configure: _ => {});
    app.UseHttpsRedirection();
    app.UseCors(policyName: CommonConstants.CorsPolicyName);

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

