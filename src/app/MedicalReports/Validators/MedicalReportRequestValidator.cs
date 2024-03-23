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
                                            
        RuleFor(request => request.Content.Encounter_type).NotEmpty();
        RuleFor(request => request.Content.Identifier).NotEmpty();
        RuleFor(request => request.Content.Encounter_status).NotEmpty();
        RuleFor(request => request.Content.System).NotEmpty();

        RuleFor(request => request.Content.Organization.Code).NotEmpty();
        RuleFor(request => request.Content.Organization.Name).NotEmpty();
        RuleFor(request => request.Content.Organization.Address).NotEmpty();
        RuleFor(request => request.Content.Organization.Contact).NotEmpty();

        RuleFor(request => request.Content.Patient.Identifier).NotEmpty();
        RuleFor(request => request.Content.Patient.Age)
                                .NotEmpty().WithMessage("Patient age cannot be empty")
                                .InclusiveBetween(0, 104).WithMessage("Patient age must be between 0 and 104 years");
        RuleFor(request => request.Content.Patient.Gender)
                                .NotEmpty().WithMessage("Patient gender cannot be empty")
                                .Must(gender => gender == "Male" || gender == "Female")
                                .WithMessage("Patient gender must be either 'Male' or 'Female'");
        RuleFor(request => request.Content.Patient.Join_date).NotEmpty();
        RuleFor(request => request.Content.Patient.Status).NotEmpty();
        RuleFor(request => request.Content.Patient.Chronic_diseases).NotEmpty();
        RuleFor(request => request.Content.Patient.Allergies).NotEmpty();

        RuleFor(request => request.Content.Triage.Weight).NotEmpty();
        RuleFor(request => request.Content.Triage.Height).NotEmpty();
        RuleFor(request => request.Content.Triage.Temperature).NotEmpty();
        RuleFor(request => request.Content.Triage.Pulse).NotEmpty();
        RuleFor(request => request.Content.Triage.Blood_pressure).NotEmpty();
        RuleFor(request => request.Content.Triage.Muac).NotEmpty();
        RuleFor(request => request.Content.Triage.Bmi).NotEmpty();
        RuleFor(request => request.Content.Triage.Bmi_status).NotEmpty();
        RuleFor(request => request.Content.Triage.Head_circum).NotEmpty();
        RuleFor(request => request.Content.Triage.Body_surface_area).NotEmpty();
        RuleFor(request => request.Content.Triage.Respiration_rate).NotEmpty();
        RuleFor(request => request.Content.Triage.Oxygen_saturation).NotEmpty();
        RuleFor(request => request.Content.Triage.Heart_rate).NotEmpty();
        RuleFor(request => request.Content.Triage.Notes).NotEmpty();

        RuleFor(request => request.Content.Prescriptions).NotEmpty();

        RuleFor(request => request.Content.Clinical_findings.Presenting_complaint).NotEmpty();
        RuleFor(request => request.Content.Clinical_findings.Ros).NotEmpty();
        RuleFor(request => request.Content.Clinical_findings.Pmh).NotEmpty();
        RuleFor(request => request.Content.Clinical_findings.Poh).NotEmpty();
        RuleFor(request => request.Content.Clinical_findings.Pgh).NotEmpty();
        RuleFor(request => request.Content.Clinical_findings.Fsh).NotEmpty();
        RuleFor(request => request.Content.Clinical_findings.Ent).NotEmpty();
        RuleFor(request => request.Content.Clinical_findings.Eye).NotEmpty();
        RuleFor(request => request.Content.Clinical_findings.Skin).NotEmpty();
        RuleFor(request => request.Content.Clinical_findings.Provisional_diagnosis).NotEmpty();
        RuleFor(request => request.Content.Clinical_findings.Treatment_plan).NotEmpty();
        RuleFor(request => request.Content.Clinical_findings.Clinical_notes).NotEmpty();
        RuleFor(request => request.Content.Clinical_findings.Respiratory).NotEmpty();
        RuleFor(request => request.Content.Clinical_findings.General_appearance).NotEmpty();
        RuleFor(request => request.Content.Clinical_findings.Cvs).NotEmpty();
        RuleFor(request => request.Content.Clinical_findings.Muscular_skeletal).NotEmpty();
        RuleFor(request => request.Content.Clinical_findings.Psychological_status).NotEmpty();
        RuleFor(request => request.Content.Clinical_findings.Clinical_diagnosis).NotEmpty();
        RuleFor(request => request.Content.Clinical_findings.Clinical_image).NotEmpty();
        RuleFor(request => request.Content.Clinical_findings.Pv).NotEmpty();

        RuleFor(request => request.Content.Diagnosis).NotEmpty();
        RuleFor(request => request.Content.Cancer_diagnosis).NotEmpty();
        RuleFor(request => request.Content.Theater_operation).NotEmpty();
        RuleFor(request => request.Content.Radiology).NotEmpty();
        RuleFor(request => request.Content.Pathology).NotEmpty();

        RuleFor(request => request.Content.Vision_assessment.Entry_order).NotEmpty();
        RuleFor(request => request.Content.Vision_assessment.Eye_test).NotEmpty();
        RuleFor(request => request.Content.Vision_assessment.Visual_acuity_right).NotEmpty();
        RuleFor(request => request.Content.Vision_assessment.Visual_acuity_right_ext).NotEmpty();
        RuleFor(request => request.Content.Vision_assessment.Visual_acuity_left).NotEmpty();
        RuleFor(request => request.Content.Vision_assessment.Visual_acuity_left_ext).NotEmpty();
        RuleFor(request => request.Content.Vision_assessment.Preferential_looking_right).NotEmpty();
        RuleFor(request => request.Content.Vision_assessment.Preferential_looking_left).NotEmpty();
        RuleFor(request => request.Content.Vision_assessment.Notes).NotEmpty();

        RuleFor(request => request.Content.Dental).NotEmpty();

        RuleFor(request => request.Content.Eye_assessment.Left_pupil).NotEmpty();
        RuleFor(request => request.Content.Eye_assessment.Right_pupil).NotEmpty();
        RuleFor(request => request.Content.Eye_assessment.Left_lid_margin).NotEmpty();
        RuleFor(request => request.Content.Eye_assessment.Right_lid_margin).NotEmpty();
        RuleFor(request => request.Content.Eye_assessment.Left_conjunctiva).NotEmpty();
        RuleFor(request => request.Content.Eye_assessment.Right_conjunctiva).NotEmpty();
        RuleFor(request => request.Content.Eye_assessment.Left_bulbar_conjunctiva).NotEmpty();
        RuleFor(request => request.Content.Eye_assessment.Right_bulbar_conjunctiva).NotEmpty();
        RuleFor(request => request.Content.Eye_assessment.Left_central_cornea).NotEmpty();
        RuleFor(request => request.Content.Eye_assessment.Right_central_cornea).NotEmpty();
        RuleFor(request => request.Content.Eye_assessment.Left_vertical_cornea).NotEmpty();
        RuleFor(request => request.Content.Eye_assessment.Right_vertical_cornea).NotEmpty();
        RuleFor(request => request.Content.Eye_assessment.Left_anterior_chamber).NotEmpty();
        RuleFor(request => request.Content.Eye_assessment.Right_anterior_chamber).NotEmpty();
        RuleFor(request => request.Content.Eye_assessment.Left_iris).NotEmpty();
        RuleFor(request => request.Content.Eye_assessment.Right_iris).NotEmpty();
        RuleFor(request => request.Content.Eye_assessment.Left_anterior_chamber_angle).NotEmpty();
        RuleFor(request => request.Content.Eye_assessment.Right_anterior_chamber_angle).NotEmpty();
        RuleFor(request => request.Content.Eye_assessment.Left_retina).NotEmpty();
        RuleFor(request => request.Content.Eye_assessment.Right_retina).NotEmpty();
        RuleFor(request => request.Content.Eye_assessment.Left_macula).NotEmpty();
        RuleFor(request => request.Content.Eye_assessment.Right_macula).NotEmpty();
        RuleFor(request => request.Content.Eye_assessment.Left_optic_disc).NotEmpty();
        RuleFor(request => request.Content.Eye_assessment.Right_optic_disc).NotEmpty();
        RuleFor(request => request.Content.Eye_assessment.Left_iop).NotEmpty();
        RuleFor(request => request.Content.Eye_assessment.Right_iop).NotEmpty();
        RuleFor(request => request.Content.Eye_assessment.Left_vitreous).NotEmpty();
        RuleFor(request => request.Content.Eye_assessment.Right_vitreous).NotEmpty();
        RuleFor(request => request.Content.Eye_assessment.Left_lens).NotEmpty();
        RuleFor(request => request.Content.Eye_assessment.Right_lens).NotEmpty();
        RuleFor(request => request.Content.Eye_assessment.Eye_notes).NotEmpty();
        RuleFor(request => request.Content.Eye_assessment.Left_eye_ball).NotEmpty();
        RuleFor(request => request.Content.Eye_assessment.Right_eye_ball).NotEmpty();
        RuleFor(request => request.Content.Eye_assessment.Left_orbit).NotEmpty();
        RuleFor(request => request.Content.Eye_assessment.Right_orbit).NotEmpty();
        
        RuleFor(request => request.Content.Labtests).Must(labtests => labtests != null)
                                                    .WithMessage("Lab tests cannot be empty");

        When(request => request.Content.Labtests != null && request.Content.Labtests.Count > 0, () =>
            {
                RuleForEach(request => request.Content.Labtests).ChildRules(labtest =>
                    {
                        labtest.RuleFor(lt => lt.Test_code).NotEmpty().WithMessage("Test code cannot be empty");
                        labtest.RuleFor(lt => lt.Test_name).NotEmpty().WithMessage("Test name cannot be empty");
                        labtest.RuleFor(lt => lt.Status).NotEmpty().WithMessage("Test status cannot be empty");
                        labtest.RuleFor(lt => lt.Notes).NotEmpty().WithMessage("Test notes cannot be empty");
                        labtest.RuleFor(lt => lt.Requested_by).NotEmpty().WithMessage("Requested by cannot be empty");
                        labtest.RuleFor(lt => lt.Requested_by.Identifier).NotEmpty().WithMessage("Requester identifier cannot be empty");
                        labtest.RuleFor(lt => lt.Requested_by.Name).NotEmpty().WithMessage("Requester name cannot be empty");
                        labtest.RuleFor(lt => lt.Requested_by.Specialty).NotEmpty().WithMessage("Requester specialty cannot be empty");
                    });
            });

    }
}
