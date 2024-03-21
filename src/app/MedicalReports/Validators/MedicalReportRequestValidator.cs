using FluentValidation;
using App.Common.Utils;
using App.MedicalReports.Models.Requests;

namespace App.MedicalReports.Validators;
public sealed class MedicalReportRequestValidator : AbstractValidator<MedicalReportRequest> 
{

    public MedicalReportRequestValidator() 
    {
        // context.Request.RouteValues.TryGetValue("facilityCode", out var facilityCode);
        // Console.WriteLine($"facilityCode: {facilityCode}");

        RuleFor(request => request.FacilityCode).Length(1, 20).NotEmpty()
                                            .WithMessage(errorMessage: "Please include Facility Code");
        RuleFor(request => request.VisitNo).Length(1, 20).NotEmpty()
                                            .WithMessage(errorMessage: "Please include Visit No");
        RuleFor(request => request.VisitDate).NotEmpty()
                                            .WithMessage(errorMessage: "Please include Visit Date")
                                            .GreaterThan(DateTime.Parse(Constants.NullDateTimeString))
                                            .WithMessage(errorMessage: "Visit Date cannot be in the past")
                                            .LessThan(DateTime.Now)
                                            .WithMessage(errorMessage: "Visit Date cannot be ahead of today" );
                                            
        // RuleFor(request => request.Content.Organization).NotEmpty();//.NotEqual("");
        // RuleFor(request => request.Content.Patient).NotEmpty();
    }
}
