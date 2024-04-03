using FluentValidation;
using App.Common.Utils;
using App.MedicalReports.Models.Requests;

namespace App.MedicalReports.Validators;
public sealed class MedicalReportRequestValidator : AbstractValidator<MedicalReportRequest> 
{
    public MedicalReportRequestValidator() 
    {

        RuleFor(expression: request => request.FacilityCode).Length(min: 1, max: 20).NotEmpty()
                                            .WithMessage(errorMessage: "Please include Facility Code");
        RuleFor(expression: request => request.VisitNo).Length(min: 1, max: 20).NotEmpty()
                                            .WithMessage(errorMessage: "Please include Visit No");
        RuleFor(expression: request => request.VisitDate).NotEmpty()
                                            .WithMessage(errorMessage: "Please include Visit Date")
                                            .GreaterThan(DateTimeOffset.Parse(Constants.NullDateTimeString))
                                            .WithMessage(errorMessage: "Visit Date cannot be in the past")
                                            .LessThan(DateTimeOffset.UtcNow)
                                            .WithMessage(errorMessage: "Visit Date cannot be ahead of today" );
                                            
        RuleFor(expression: request => request.Content.Encounter_type).NotEmpty();
        RuleFor(expression: request => request.Content.Identifier).NotEmpty();
        RuleFor(expression: request => request.Content.Encounter_status).NotEmpty();
        RuleFor(expression: request => request.Content.System).NotEmpty();

        RuleFor(expression: request => request.Content.Organization.Code).NotEmpty();
        RuleFor(expression: request => request.Content.Organization.Name).NotEmpty();
        RuleFor(expression: request => request.Content.Organization.Address).NotEmpty();
        RuleFor(expression: request => request.Content.Organization.Contact).NotEmpty();

        RuleFor(expression: request => request.Content.Patient.Identifier).NotEmpty();
        RuleFor(expression: request => request.Content.Patient.Age)
                                .NotEmpty().WithMessage(errorMessage: "Patient age cannot be empty")
                                .InclusiveBetween(from: 0, to: 104)
                                .WithMessage(errorMessage: "Patient age must be between 0 and 104 years");
        RuleFor(expression: request => request.Content.Patient.Gender)
                                .NotEmpty().WithMessage(errorMessage: "Patient gender cannot be empty")
                                .Must(predicate: gender => gender == "Male" || gender == "Female")
                                .WithMessage(errorMessage: "Patient gender must be either 'Male' or 'Female'");
        RuleFor(expression: request => request.Content.Patient.Join_date).NotEmpty();
        RuleFor(expression: request => request.Content.Patient.Status).NotEmpty();

        RuleFor(expression: request => request.Content.Patient.Chronic_diseases).Must(predicate: chronicDiseases => chronicDiseases != null)
                                                    .WithMessage(errorMessage: "Chronic diseases cannot be empty");

        RuleFor(expression: request => request.Content.Patient.Allergies).Must(predicate: allergies => allergies != null)
                                                    .WithMessage(errorMessage: "Allergies cannot be empty");

        When(predicate: request => request.Content.Patient.Allergies != null && request.Content.Patient.Allergies.Count > 0, action: () =>
            {
                RuleForEach(expression: request => request.Content.Patient.Allergies).ChildRules(action: allergies =>
                    {
                        allergies.RuleFor(expression: allergy => allergy.Allergy).NotEmpty();
                        allergies.RuleFor(expression: allergy => allergy.Category).NotEmpty();
                        allergies.RuleFor(expression: allergy => allergy.Reaction).NotEmpty();
                    });
            });

        RuleFor(expression: request => request.Content.Triage.Weight).NotEmpty();
        RuleFor(expression: request => request.Content.Triage.Height).NotEmpty();
        RuleFor(expression: request => request.Content.Triage.Temperature).NotEmpty();
        RuleFor(expression: request => request.Content.Triage.Pulse).NotEmpty();
        RuleFor(expression: request => request.Content.Triage.Blood_pressure).NotEmpty();
        RuleFor(expression: request => request.Content.Triage.Muac).NotEmpty();
        RuleFor(expression: request => request.Content.Triage.Bmi).NotEmpty();
        RuleFor(expression: request => request.Content.Triage.Bmi_status).NotEmpty();
        RuleFor(expression: request => request.Content.Triage.Head_circum).NotEmpty();
        RuleFor(expression: request => request.Content.Triage.Body_surface_area).NotEmpty();
        RuleFor(expression: request => request.Content.Triage.Respiration_rate).NotEmpty();
        RuleFor(expression: request => request.Content.Triage.Oxygen_saturation).NotEmpty();
        RuleFor(expression: request => request.Content.Triage.Heart_rate).NotEmpty();
        RuleFor(expression: request => request.Content.Triage.Notes).NotEmpty();

        RuleFor(expression: request => request.Content.Prescriptions).Must(predicate: prescriptions => prescriptions != null)
                                                    .WithMessage(errorMessage: "Prescriptions cannot be empty");

        When(request => request.Content.Prescriptions != null && request.Content.Prescriptions.Count > 0, () =>
            {
                RuleForEach(expression: request => request.Content.Prescriptions).ChildRules(action: prescriptions =>
                    {
                        prescriptions.RuleFor(expression: prescription => prescription.Drug_code).NotEmpty();
                        prescriptions.RuleFor(expression: prescription => prescription.Drug_name).NotEmpty();
                        prescriptions.RuleFor(expression: prescription => prescription.Dosage).NotEmpty();
                        prescriptions.RuleFor(expression: prescription => prescription.Duration).NotEmpty();
                        prescriptions.RuleFor(expression: prescription => prescription.Quantity).NotEmpty();
                        prescriptions.RuleFor(expression: prescription => prescription.Notes).NotEmpty();
                    });
            });

        RuleFor(expression: request => request.Content.Clinical_findings.Presenting_complaint).NotEmpty();
        RuleFor(expression: request => request.Content.Clinical_findings.Ros).NotEmpty();
        RuleFor(expression: request => request.Content.Clinical_findings.Pmh).NotEmpty();
        RuleFor(expression: request => request.Content.Clinical_findings.Poh).NotEmpty();
        RuleFor(expression: request => request.Content.Clinical_findings.Pgh).NotEmpty();
        RuleFor(expression: request => request.Content.Clinical_findings.Fsh).NotEmpty();
        RuleFor(expression: request => request.Content.Clinical_findings.Ent).NotEmpty();
        RuleFor(expression: request => request.Content.Clinical_findings.Eye).NotEmpty();
        RuleFor(expression: request => request.Content.Clinical_findings.Skin).NotEmpty();
        RuleFor(expression: request => request.Content.Clinical_findings.Provisional_diagnosis).NotEmpty();
        RuleFor(expression: request => request.Content.Clinical_findings.Treatment_plan).NotEmpty();
        RuleFor(expression: request => request.Content.Clinical_findings.Clinical_notes).NotEmpty();
        RuleFor(expression: request => request.Content.Clinical_findings.Respiratory).NotEmpty();
        RuleFor(expression: request => request.Content.Clinical_findings.General_appearance).NotEmpty();
        RuleFor(expression: request => request.Content.Clinical_findings.Cvs).NotEmpty();
        RuleFor(expression: request => request.Content.Clinical_findings.Muscular_skeletal).NotEmpty();
        RuleFor(expression: request => request.Content.Clinical_findings.Psychological_status).NotEmpty();
        RuleFor(expression: request => request.Content.Clinical_findings.Clinical_diagnosis).NotEmpty();
        RuleFor(expression: request => request.Content.Clinical_findings.Clinical_image).NotEmpty();
        RuleFor(expression: request => request.Content.Clinical_findings.Pv).NotEmpty();

        RuleFor(expression: request => request.Content.Diagnosis).Must(predicate: diagnosis => diagnosis != null)
                                                    .WithMessage(errorMessage: "Diagnosis cannot be empty");

        When(request => request.Content.Diagnosis != null && request.Content.Diagnosis.Count > 0, () =>
            {
                RuleForEach(expression: request => request.Content.Diagnosis).ChildRules(action: diagnosis =>
                    {
                        diagnosis.RuleFor(expression: diag => diag.Diagnosed_by).NotNull()
                                                                    .WithMessage(errorMessage: "Diagnosed by must not be null");
                        diagnosis.When(predicate: diag => diag.Diagnosed_by != null, action: () =>
                            {
                                diagnosis.RuleFor(expression: diag => diag.Diagnosed_by.Identifier).NotEmpty();
                                diagnosis.RuleFor(expression: diag => diag.Diagnosed_by.Name).NotEmpty();
                                diagnosis.RuleFor(expression: diag => diag.Diagnosed_by.Specialty).NotEmpty();
                            });

                        diagnosis.RuleFor(expression: diag => diag.Category).NotEmpty();
                        diagnosis.RuleFor(expression: diag => diag.Diagnosis).NotEmpty();
                        diagnosis.RuleFor(expression: diag => diag.Notes).NotEmpty();
                    });
            });

        RuleFor(expression: request => request.Content.Cancer_diagnosis)
                                                    .Must(predicate: cancerDiagnosis => cancerDiagnosis != null)
                                                    .WithMessage(errorMessage: "Cancer diagnosis cannot be empty");

        When(predicate: request => request.Content.Cancer_diagnosis != null && request.Content.Cancer_diagnosis.Count > 0, action: () =>
            {
                RuleForEach(expression: request => request.Content.Cancer_diagnosis).ChildRules(action: cancerDiagnosis =>
                    {
                        cancerDiagnosis.RuleFor(expression: cancerDiag => cancerDiag.Disease_code).NotEmpty();
                        cancerDiagnosis.RuleFor(expression: cancerDiag => cancerDiag.Site).NotEmpty();
                        cancerDiagnosis.RuleFor(expression: cancerDiag => cancerDiag.Basis_of_diagnosis).NotEmpty();
                        cancerDiagnosis.RuleFor(expression: cancerDiag => cancerDiag.Cancer_stage).NotEmpty();
                        cancerDiagnosis.RuleFor(expression: cancerDiag => cancerDiag.Notes).NotEmpty();
                    });
            });

        RuleFor(expression: request => request.Content.Theater_operation)
                                    .Must(predicate: theaterOperation => theaterOperation != null)
                                    .WithMessage(errorMessage: "Theater operation cannot be empty");

        When(predicate: request => request.Content.Theater_operation != null && request.Content.Theater_operation.Count > 0, action: () =>
            {
                RuleForEach(expression: request => request.Content.Theater_operation).ChildRules(action: theaterOperation =>
                    {
                        theaterOperation.RuleFor(expression: theaterOp => theaterOp.Anaesthesia_type).NotEmpty();
                        theaterOperation.RuleFor(expression: theaterOp => theaterOp.Operation_class).NotEmpty();
                        theaterOperation.RuleFor(expression: theaterOp => theaterOp.Preoperative_diagnosis).NotEmpty();
                        theaterOperation.RuleFor(expression: theaterOp => theaterOp.Planned_procedures).NotEmpty();
                        theaterOperation.RuleFor(expression: theaterOp => theaterOp.Report).NotEmpty();
                        theaterOperation.RuleFor(expression: theaterOp => theaterOp.Postoperative_instructions).NotEmpty();
                        theaterOperation.RuleFor(expression: theaterOp => theaterOp.Operation_datetime).NotEmpty()
                                                                        .GreaterThan(DateTime.Parse(Constants.NullDateTimeString))
                                                                        .WithMessage(errorMessage: "Operation Date cannot be in the past")
                                                                        .LessThan(DateTime.Now)
                                                                        .WithMessage(errorMessage: "Operation Date cannot be ahead of today" );

                    });
            });
            
        RuleFor(expression: request => request.Content.Radiology)
                                                    .Must(predicate: radiology => radiology != null)
                                                    .WithMessage(errorMessage: "Radiology cannot be empty");

        When(predicate: request => request.Content.Radiology != null && request.Content.Radiology.Count > 0, action: () =>
            {
                RuleForEach(expression: request => request.Content.Radiology).ChildRules(action: radiology =>
                    {
                        radiology.RuleFor(expression: rad => rad.Examination).NotEmpty();
                        radiology.RuleFor(expression: rad => rad.Examination_date).NotEmpty()
                                                                        .GreaterThan(DateTime.Parse(Constants.NullDateTimeString))
                                                                        .WithMessage(errorMessage: "Examination Date cannot be in the past")
                                                                        .LessThan(DateTime.Now)
                                                                        .WithMessage(errorMessage: "Examination Date cannot be ahead of today" );
                        radiology.RuleFor(expression: rad => rad.Indication).NotEmpty();
                        radiology.RuleFor(expression: rad => rad.Report).NotEmpty();
                        radiology.RuleFor(expression: rad => rad.Conclusion).NotEmpty();
                    });
            });

        RuleFor(expression: request => request.Content.Pathology)
                                    .Must(predicate: pathology => pathology != null)
                                    .WithMessage(errorMessage: "Pathology cannot be empty");

        When(predicate: request => request.Content.Pathology != null && request.Content.Pathology.Count > 0, action: () =>
            {
                RuleForEach(expression: request => request.Content.Pathology).ChildRules(action: pathology =>
                    {
                        pathology.RuleFor(expression: path => path.Test).NotEmpty();
                        pathology.RuleFor(expression: path => path.Examination_date).NotEmpty()
                                                            .GreaterThan(DateTime.Parse(Constants.NullDateTimeString))
                                                            .WithMessage(errorMessage: "Examination Date cannot be in the past")
                                                            .LessThan(DateTime.Now)
                                                            .WithMessage(errorMessage: "Examination Date cannot be ahead of today" );
                        pathology.RuleFor(expression: path => path.Indication).NotEmpty();
                        pathology.RuleFor(expression: path => path.Diagnosis).NotEmpty();

                    });
            });

        RuleFor(expression: request => request.Content.Vision_assessment.Entry_order).NotEmpty();
        RuleFor(expression: request => request.Content.Vision_assessment.Eye_test).NotEmpty();
        RuleFor(expression: request => request.Content.Vision_assessment.Visual_acuity_right).NotEmpty();
        RuleFor(expression: request => request.Content.Vision_assessment.Visual_acuity_right_ext).NotEmpty();
        RuleFor(expression: request => request.Content.Vision_assessment.Visual_acuity_left).NotEmpty();
        RuleFor(expression: request => request.Content.Vision_assessment.Visual_acuity_left_ext).NotEmpty();
        RuleFor(expression: request => request.Content.Vision_assessment.Preferential_looking_right).NotEmpty();
        RuleFor(expression: request => request.Content.Vision_assessment.Preferential_looking_left).NotEmpty();
        RuleFor(expression: request => request.Content.Vision_assessment.Notes).NotEmpty();

        RuleFor(expression: request => request.Content.Dental)
                                    .Must(predicate: dental => dental != null)
                                    .WithMessage(errorMessage: "Dental cannot be empty");

        When(predicate: request => request.Content.Dental != null && request.Content.Dental.Count > 0, action: () =>
            {
                RuleForEach(expression: request => request.Content.Dental).ChildRules(action: dental =>
                    {
                        dental.RuleFor(expression: den => den.Dental_service).NotEmpty();
                        dental.RuleFor(expression: den => den.Notes).NotEmpty();
                        dental.RuleFor(expression: den => den.Status).NotEmpty();
                    });
            });

        RuleFor(expression: request => request.Content.Eye_assessment.Left_pupil).NotEmpty();
        RuleFor(expression: request => request.Content.Eye_assessment.Right_pupil).NotEmpty();
        RuleFor(expression: request => request.Content.Eye_assessment.Left_lid_margin).NotEmpty();
        RuleFor(expression: request => request.Content.Eye_assessment.Right_lid_margin).NotEmpty();
        RuleFor(expression: request => request.Content.Eye_assessment.Left_conjunctiva).NotEmpty();
        RuleFor(expression: request => request.Content.Eye_assessment.Right_conjunctiva).NotEmpty();
        RuleFor(expression: request => request.Content.Eye_assessment.Left_bulbar_conjunctiva).NotEmpty();
        RuleFor(expression: request => request.Content.Eye_assessment.Right_bulbar_conjunctiva).NotEmpty();
        RuleFor(expression: request => request.Content.Eye_assessment.Left_central_cornea).NotEmpty();
        RuleFor(expression: request => request.Content.Eye_assessment.Right_central_cornea).NotEmpty();
        RuleFor(expression: request => request.Content.Eye_assessment.Left_vertical_cornea).NotEmpty();
        RuleFor(expression: request => request.Content.Eye_assessment.Right_vertical_cornea).NotEmpty();
        RuleFor(expression: request => request.Content.Eye_assessment.Left_anterior_chamber).NotEmpty();
        RuleFor(expression: request => request.Content.Eye_assessment.Right_anterior_chamber).NotEmpty();
        RuleFor(expression: request => request.Content.Eye_assessment.Left_iris).NotEmpty();
        RuleFor(expression: request => request.Content.Eye_assessment.Right_iris).NotEmpty();
        RuleFor(expression: request => request.Content.Eye_assessment.Left_anterior_chamber_angle).NotEmpty();
        RuleFor(expression: request => request.Content.Eye_assessment.Right_anterior_chamber_angle).NotEmpty();
        RuleFor(expression: request => request.Content.Eye_assessment.Left_retina).NotEmpty();
        RuleFor(expression: request => request.Content.Eye_assessment.Right_retina).NotEmpty();
        RuleFor(expression: request => request.Content.Eye_assessment.Left_macula).NotEmpty();
        RuleFor(expression: request => request.Content.Eye_assessment.Right_macula).NotEmpty();
        RuleFor(expression: request => request.Content.Eye_assessment.Left_optic_disc).NotEmpty();
        RuleFor(expression: request => request.Content.Eye_assessment.Right_optic_disc).NotEmpty();
        RuleFor(expression: request => request.Content.Eye_assessment.Left_iop).NotEmpty();
        RuleFor(expression: request => request.Content.Eye_assessment.Right_iop).NotEmpty();
        RuleFor(expression: request => request.Content.Eye_assessment.Left_vitreous).NotEmpty();
        RuleFor(expression: request => request.Content.Eye_assessment.Right_vitreous).NotEmpty();
        RuleFor(expression: request => request.Content.Eye_assessment.Left_lens).NotEmpty();
        RuleFor(expression: request => request.Content.Eye_assessment.Right_lens).NotEmpty();
        RuleFor(expression: request => request.Content.Eye_assessment.Eye_notes).NotEmpty();
        RuleFor(expression: request => request.Content.Eye_assessment.Left_eye_ball).NotEmpty();
        RuleFor(expression: request => request.Content.Eye_assessment.Right_eye_ball).NotEmpty();
        RuleFor(expression: request => request.Content.Eye_assessment.Left_orbit).NotEmpty();
        RuleFor(expression: request => request.Content.Eye_assessment.Right_orbit).NotEmpty();

        RuleFor(expression: request => request.Content.Labtests).Must(predicate: labtests => labtests != null)
                                                    .WithMessage(errorMessage: "Lab tests cannot be empty");
        
        When(request => request.Content.Labtests != null && request.Content.Labtests.Count > 0, () =>
            {
                RuleForEach(expression: request => request.Content.Labtests).ChildRules(labtest =>
                    {
                        labtest.RuleFor(expression: text => text.Test_code).NotEmpty()
                                .WithMessage(errorMessage: "Test code cannot be empty");
                        labtest.RuleFor(expression: text => text.Test_name).NotEmpty()
                                .WithMessage(errorMessage: "Test name cannot be empty");
                        labtest.RuleFor(expression: text => text.Status).NotEmpty()
                                .WithMessage(errorMessage: "Test status cannot be empty");
                        labtest.RuleFor(expression: text => text.Notes).NotEmpty()
                                .WithMessage(errorMessage: "Test notes cannot be empty");

                        labtest.RuleFor(expression: text => text.Requested_by).NotNull()
                                .WithMessage(errorMessage: "Requested by must not be null");
                        labtest.When(predicate: text => text.Requested_by != null, action: () =>
                            {
                                labtest.RuleFor(expression: text => text.Requested_by.Identifier).NotEmpty()
                                        .WithMessage(errorMessage: "Requester identifier cannot be empty");
                                labtest.RuleFor(expression: text => text.Requested_by.Name).NotEmpty()
                                        .WithMessage(errorMessage: "Requester name cannot be empty");
                                labtest.RuleFor(expression: text => text.Requested_by.Specialty).NotEmpty()
                                        .WithMessage(errorMessage: "Requester specialty cannot be empty");
                            });
                    });
            });

    }
}
