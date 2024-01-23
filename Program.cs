using App.Home.Apis;
using App.Patients.Apis;
using App.Patients.Data;
using App.Common.Context;
using App.Surgeries.Apis;
using App.Surgeries.Data;
using OpenTelemetry.Metrics;
using App.Patients.Contracts;
using App.Surgeries.Contracts;

var builder = WebApplication.CreateBuilder(args);
{    
    builder.Services.AddAuthentication();
    builder.Services.AddAuthorization();
    
    builder.Services.AddSingleton<ClinicMasterContext>();
    builder.Services.AddScoped<IPatient, Patient>();
    builder.Services.AddScoped<ISurgery, Surgery>();

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

}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.

    app.MapPrometheusScrapingEndpoint();

    app.UseExceptionHandler(errorHandlingPath: "/error");
    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

    app.ConfigureHomeApis();
    app.ConfigurePatientApis();
    app.ConfigureSurgeryApis();

    app.Run();

}

