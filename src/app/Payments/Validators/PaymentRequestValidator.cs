using FluentValidation;
using App.Common.Utils;
using App.Payments.Models.Requests;

namespace App.Payments.Validators;
public sealed class PaymentRequestValidator : AbstractValidator<PaymentRequest> 
{
    public PaymentRequestValidator() 
    {
        RuleFor(request => request.GRNNo).Length(1, 20).NotEmpty()
                                            .WithMessage(errorMessage: "Please include GRNNo");
        RuleFor(request => request.ReceivedDate).NotEmpty()
                                            .WithMessage(errorMessage: "Please include Received Date")
                                            .GreaterThan(DateTime.Parse(Constants.NullDateTimeString))
                                            .WithMessage(errorMessage: "Received Date cannot be in the past")
                                            .LessThan(DateTime.Now)
                                            .WithMessage(errorMessage: "Received Date cannot be ahead of today" );
                                            
        RuleFor(request => request.ContentReceived.SupplierNo).NotEmpty();
        RuleFor(request => request.ContentReceived.SupplierName).NotEmpty();
    }
}

