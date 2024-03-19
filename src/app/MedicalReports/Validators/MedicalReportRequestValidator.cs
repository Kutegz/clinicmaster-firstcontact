using FluentValidation;
using App.Common.Utils;
using App.MedicalReports.Models.Requests;

namespace App.MedicalReports.Validators;
public sealed class MedicalReportRequestValidator : AbstractValidator<MedicalReportRequest> 
{
    public MedicalReportRequestValidator() 
    {
        RuleFor(request => request.GRNNo).Length(1, 20).NotEmpty()
                                            .WithMessage(errorMessage: "Please include GRNNo");
        RuleFor(request => request.ReceivedDate).NotEmpty()
                                            .WithMessage(errorMessage: "Please include Received Date")
                                            .GreaterThan(DateTime.Parse(Constants.NullDateTimeString))
                                            .WithMessage(errorMessage: "Received Date cannot be in the past")
                                            .LessThan(DateTime.Now)
                                            .WithMessage(errorMessage: "Received Date cannot be ahead of today" );
                                            
        RuleFor(request => request.Content.SupplierNo).NotEmpty();
        RuleFor(request => request.Content.SupplierName).NotEmpty();
    }
}
