using FluentValidation;
using ClinicMasterFirstContact.src.App.Patients.Models.Requests;

namespace ClinicMasterFirstContact.src.App.Patients.Validators;
public sealed class PatientRequestValidator : AbstractValidator<PatientRequest> 
{
    public PatientRequestValidator() 
    {

        RuleFor(expression: request => request.PatientNo).Length(min: 1, max: 20).NotEmpty()
                                            .WithMessage(errorMessage: "Please include Patient No");
        RuleFor(expression: request => request.FullName).Length(min: 1, max: 41).NotEmpty()
                                            .WithMessage(errorMessage: "Please include Full Name");
        RuleFor(expression: request => request.Gender)
                                .NotEmpty().WithMessage(errorMessage: "Patient gender cannot be empty")
                                .Must(predicate: gender => gender.ToLower().Equals("male") || gender.ToLower().Equals("female"))
                                .WithMessage(errorMessage: "Patient gender must be either 'Male' or 'Female'");
        RuleFor(expression: request => request.Age)
                                .NotEmpty().WithMessage(errorMessage: "Patient age cannot be empty")
                                .InclusiveBetween(from: 0, to: 104)
                                .WithMessage(errorMessage: "Patient age must be between 0 and 104 years");
    }
}
