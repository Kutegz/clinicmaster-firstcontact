using App.Home.Apis;
using FluentValidation;
using App.Patients.Apis;
using App.Patients.Data;
// using App.Payments.Apis;
using App.Payments.Data;
using App.Common.Context;
using App.Surgeries.Apis;
using App.Surgeries.Data;
using App.Common.Exceptions;
using OpenTelemetry.Metrics;
using App.Patients.Contracts;
using App.Payments.Contracts;
using App.Surgeries.Contracts;
using App.Payments.Validators;
using App.MedicalReports.Data;
using App.MedicalReports.Apis;
using App.MedicalReports.Contracts;

var builder = WebApplication.CreateBuilder(args);
{    
    builder.Services.AddAuthentication();
    builder.Services.AddAuthorization();
    
    builder.Services.AddSingleton<ClinicMasterContext>();
    builder.Services.AddScoped<IPatient, Patient>();
    builder.Services.AddScoped<ISurgery, Surgery>();
    builder.Services.AddScoped<IPayment, Payment>();
    builder.Services.AddScoped<IMedicalReport, MedicalReport>();

    builder.Services.AddOpenTelemetry()
                    .WithMetrics(configure: option => 
                    {
                        option.AddPrometheusExporter();
                        option.AddMeter(names: ["Microsoft.AspNetCore.Hosting",
                                                "Microsoft.AspNetCore.Server.Kestrel"]);
                        option.AddView(instrumentName: "request-processing", 
                        metricStreamConfiguration: new ExplicitBucketHistogramConfiguration()
                        {
                            Boundaries = [10, 20]
                        });
                    });
    
    builder.Services.AddValidatorsFromAssemblyContaining(type: typeof(PaymentRequestValidator));
    builder.Services.AddGlobalExceptionHandler();

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

