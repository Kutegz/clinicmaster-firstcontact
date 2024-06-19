
-- DELETE FROM MedicalReports;

INSERT INTO MedicalReports (FacilityCode, VisitNo, VisitDate, Content, Creator, CreatedAt, Consumers) 
VALUES (
    'FAC001', 
    '240001001', 
    '2024-01-11', 
    '{
    "encounter_type": "OPD",
    "identifier": "240001001",
    "encounter_status": "Closed",
    "system": "ClinicMaster",
    "organization": {
        "code": "FAC001",
        "name": "Sample Hospital",
        "address": "123 Main Street, City, Country",
        "contact": "+256750000000"
    },
    "patient": {
        "identifier": "PAT001",
        "age": 34,
        "gender": "Male",
        "join_date": "2023-02-28T00:00:00",
        "status": "Active",
        "chronic_diseases": [
            "Hypertension",
            "Diabetes"
        ],
        "allergies": [
            {
                "allergy": "Peanuts",
                "category": "Food",
                "reaction": "Hives"
            },
            {
                "allergy": "Penicillin",
                "category": "Medication",
                "reaction": "Anaphylaxis"
            },
            {
                "allergy": "Bee venom",
                "category": "Insect sting",
                "reaction": "Swelling"
            }
        ]
    },
    "triage": {
        "weight": 56.9,
        "height": 165,
        "temperature": 98.6,
        "pulse": 80,
        "blood_pressure": "120/80 mmHg",
        "muac": 25.5,
        "bmi": "20.9",
        "bmi_status": "Normal",
        "head_circum": 55,
        "body_surface_area": 1.7,
        "respiration_rate": 16,
        "oxygen_saturation": 98,
        "heart_rate": 72,
        "notes": "Patient presents with fever and cough. No other significant findings observed."
    },
    "prescriptions": [
        {
            "drug_code": "ABC123",
            "drug_name": "Ibuprofen",
            "dosage": "1x3",
            "duration": 5,
            "quantity": 15,
            "notes": "Take with food to reduce stomach upset."
        },
        {
            "drug_code": "XYZ456",
            "drug_name": "Acetaminophen",
            "dosage": "2x2",
            "duration": 7,
            "quantity": 20,
            "notes": "Avoid alcohol consumption while taking this medication."
        }
    ],
    "clinical_findings": {
        "presenting_complaint": "Chest pain and shortness of breath",
        "ros": "Denies any fevers, chills, or weight loss.",
        "pmh": "Hypertension, Type 2 Diabetes",
        "poh": "Appendectomy 10 years ago",
        "pgh": "None",
        "fsh": "Non-smoker, occasional alcohol use",
        "ent": "No history of ear, nose, or throat issues",
        "eye": "Wears corrective lenses for myopia",
        "skin": "No history of significant skin conditions",
        "provisional_diagnosis": "Pneumonia",
        "treatment_plan": "Prescribe antibiotics and advise rest",
        "clinical_notes": "Patient appears fatigued and has a productive cough.",
        "respiratory": "Decreased breath sounds in right lower lung field.",
        "general_appearance": "Patient is alert and oriented.",
        "cvs": "Regular rate and rhythm, no murmurs.",
        "muscular_skeletal": "No tenderness or swelling noted in joints.",
        "psychological_status": "Patient is anxious about symptoms.",
        "clinical_diagnosis": "Community-acquired pneumonia",
        "clinical_image": "base64_encoded_image_bytes_here",
        "pv": "Normal pulse volume"
    },
    "diagnosis": [
        {
            "diagnosed_by": {
                "identifier": "DOC123",
                "name": "Dr. Smith",
                "specialty": "Internal Medicine"
            },
            "category": "Cardiology",
            "diagnosis": "Hypertension",
            "notes": "Patient''s blood pressure consistently elevated during check-ups."
        },
        {
            "diagnosed_by": {
                "identifier": "DOC456",
                "name": "Dr. Johnson",
                "specialty": "Cardiology"
            },
            "category": "Cardiology",
            "diagnosis": "Arrhythmia",
            "notes": "Patient experiences irregular heartbeats."
        }
    ],
    "cancer_diagnosis": [
        {
            "disease_code": "C123",
            "site": "Lung",
            "basis_of_diagnosis": "Biopsy",
            "cancer_stage": "Stage II",
            "notes": "Patient is a non-smoker."
        },
        {
            "disease_code": "C456",
            "site": "Colon",
            "basis_of_diagnosis": "Colonoscopy",
            "cancer_stage": "Stage I",
            "notes": "Patient has a family history of colorectal cancer."
        },
        {
            "disease_code": "C789",
            "site": "Breast",
            "basis_of_diagnosis": "Mammogram",
            "cancer_stage": "Stage III",
            "notes": "Patient underwent mastectomy in the past."
        }
    ],
    "theater_operation": [
        {
            "anaesthesia_type": "General",
            "operation_class": "Major",
            "preoperative_diagnosis": "Appendicitis",
            "planned_procedures": "Appendectomy",
            "report": "Procedure performed without complications.",
            "postoperative_instructions": "Complete the prescribed course of antibiotics.",
            "operation_datetime": "2023-02-28T00:00:00"
        },
        {
            "anaesthesia_type": "Local",
            "operation_class": "Minor",
            "preoperative_diagnosis": "Carpal tunnel syndrome",
            "planned_procedures": "Carpal tunnel release",
            "report": "Procedure completed successfully.",
            "postoperative_instructions": "Rest the hand and elevate it for 24 hours.",
            "operation_datetime": "2023-02-28T00:00:00"
        }
    ],
    "radiology": [
        {
            "examination": "MRI Brain Scan",
            "examination_date": "2023-02-28T00:00:00",
            "indication": "Headache and dizziness",
            "report": "No abnormal findings observed.",
            "conclusion": "Normal MRI scan results. Further evaluation may be required if symptoms persist."
        },
        {
            "examination": "X-ray Chest",
            "examination_date": "2023-02-28T00:00:00",
            "indication": "Cough and shortness of breath",
            "report": "Opacity in right lower lobe, suggestive of pneumonia.",
            "conclusion": "Pneumonia confirmed. Prescribe antibiotics and follow-up in 1 week."
        }
    ],
    "pathology": [
        {
            "test": "Histopathological Examination of Biopsy Specimen",
            "examination_date": "2023-02-28T00:00:00",
            "indication": "Skin lesion biopsy",
            "diagnosis": "Melanoma"
        },
        {
            "test": "Blood Chemistry Panel",
            "examination_date": "2023-02-28T00:00:00",
            "indication": "General health check-up",
            "diagnosis": "Normal"
        }
    ],
    "vision_assessment": {
        "entry_order": "Initial assessment",
        "eye_test": "Visual acuity test",
        "visual_acuity_right": "20/20",
        "visual_acuity_right_ext": "With correction",
        "visual_acuity_left": "20/25",
        "visual_acuity_left_ext": "Without correction",
        "preferential_looking_right": "Normal",
        "preferential_looking_left": "Normal",
        "notes": "Patient reports no difficulty in reading or seeing objects."
    },
    "dental": [
        {
            "dental_service": "Teeth cleaning",
            "notes": "Patient has a history of sensitive gums.",
            "status": "Completed"
        },
        {
            "dental_service": "Cavity filling",
            "notes": "Patient reported pain while chewing.",
            "status": "Scheduled"
        }
    ],
    "eye_assessment": {
        "left_pupil": "Normal",
        "right_pupil": "Dilated",
        "left_lid_margin": "Clear",
        "right_lid_margin": "Swollen",
        "left_conjunctiva": "Pink",
        "right_conjunctiva": "Pale",
        "left_bulbar_conjunctiva": "Clear",
        "right_bulbar_conjunctiva": "Red",
        "left_central_cornea": "Clear",
        "right_central_cornea": "Cloudy",
        "left_vertical_cornea": "Normal",
        "right_vertical_cornea": "Abnormal",
        "left_anterior_chamber": "Normal depth",
        "right_anterior_chamber": "Shallow",
        "left_iris": "Normal",
        "right_iris": "Dilated",
        "left_anterior_chamber_angle": "Open",
        "right_anterior_chamber_angle": "Narrow",
        "left_retina": "Healthy",
        "right_retina": "Detached",
        "left_macula": "Intact",
        "right_macula": "Damaged",
        "left_optic_disc": "Normal",
        "right_optic_disc": "Abnormal",
        "left_iop": "12 mmHg",
        "right_iop": "20 mmHg",
        "left_vitreous": "Clear",
        "right_vitreous": "Hazy",
        "left_lens": "Clear",
        "right_lens": "Cloudy",
        "eye_notes": "Patient complains of blurred vision in the right eye.",
        "left_eye_ball": "Normal movement",
        "right_eye_ball": "Restricted movement",
        "left_orbit": "No tenderness",
        "right_orbit": "Tender on palpation"
    },
    "labtests": [
        {
            "test_code": "TC123",
            "test_name": "Blood Glucose Test",
            "status": "Pending",
            "notes": "Fasting required for accurate results.",
            "requested_by": {
                "identifier": "DOC789",
                "name": "Dr. Smith",
                "specialty": "Endocrinology"
            }
        },
        {
            "test_code": "TC456",
            "test_name": "Lipid Profile",
            "status": "Completed",
            "notes": "Patient has a family history of cardiovascular diseases.",
            "requested_by": {
                "identifier": "DOC123",
                "name": "Dr. Johnson",
                "specialty": "Cardiology"
            }
        }
    ]
}',
    '{
        "agentId": "ClinicMaster",
        "agentName": "ClinicMaster",
        "syncCount": 1,
        "syncStatus": true,
        "syncDateTime": "2024-03-25T00:00:00.000Z",
        "syncMessage": ""
    }', SYSDATETIMEOFFSET(),   
    '[
        {
            "agentId": "ClinicMaster",
            "agentName": "ClinicMaster",
            "syncCount": 1,
            "syncStatus": false,
            "syncDateTime": "2024-03-25T00:00:00.000Z",
            "lastUpdateDateTime": "2024-03-25T00:00:00.000Z",
            "syncMessage": ""
        }
    ]'
);


INSERT INTO MedicalReports (FacilityCode, VisitNo, VisitDate, Content, Creator, CreatedAt, Consumers) 
VALUES (
    'FAC001', 
    '240001002', 
    '2024-01-11', 
    '{
    "encounter_type": "OPD",
    "identifier": "240001002",
    "encounter_status": "Closed",
    "system": "ClinicMaster",
    "organization": {
        "code": "FAC001",
        "name": "Sample Hospital",
        "address": "123 Main Street, City, Country",
        "contact": "+256750000000"
    },
    "patient": {
        "identifier": "PAT001",
        "age": 34,
        "gender": "Male",
        "join_date": "2023-02-28T00:00:00",
        "status": "Active",
        "chronic_diseases": [
            "Hypertension",
            "Diabetes"
        ],
        "allergies": [
            {
                "allergy": "Peanuts",
                "category": "Food",
                "reaction": "Hives"
            },
            {
                "allergy": "Penicillin",
                "category": "Medication",
                "reaction": "Anaphylaxis"
            },
            {
                "allergy": "Bee venom",
                "category": "Insect sting",
                "reaction": "Swelling"
            }
        ]
    },
    "triage": {
        "weight": 56.9,
        "height": 165,
        "temperature": 98.6,
        "pulse": 80,
        "blood_pressure": "120/80 mmHg",
        "muac": 25.5,
        "bmi": "20.9",
        "bmi_status": "Normal",
        "head_circum": 55,
        "body_surface_area": 1.7,
        "respiration_rate": 16,
        "oxygen_saturation": 98,
        "heart_rate": 72,
        "notes": "Patient presents with fever and cough. No other significant findings observed."
    },
    "prescriptions": [
        {
            "drug_code": "ABC123",
            "drug_name": "Ibuprofen",
            "dosage": "1x3",
            "duration": 5,
            "quantity": 15,
            "notes": "Take with food to reduce stomach upset."
        },
        {
            "drug_code": "XYZ456",
            "drug_name": "Acetaminophen",
            "dosage": "2x2",
            "duration": 7,
            "quantity": 20,
            "notes": "Avoid alcohol consumption while taking this medication."
        }
    ],
    "clinical_findings": {
        "presenting_complaint": "Chest pain and shortness of breath",
        "ros": "Denies any fevers, chills, or weight loss.",
        "pmh": "Hypertension, Type 2 Diabetes",
        "poh": "Appendectomy 10 years ago",
        "pgh": "None",
        "fsh": "Non-smoker, occasional alcohol use",
        "ent": "No history of ear, nose, or throat issues",
        "eye": "Wears corrective lenses for myopia",
        "skin": "No history of significant skin conditions",
        "provisional_diagnosis": "Pneumonia",
        "treatment_plan": "Prescribe antibiotics and advise rest",
        "clinical_notes": "Patient appears fatigued and has a productive cough.",
        "respiratory": "Decreased breath sounds in right lower lung field.",
        "general_appearance": "Patient is alert and oriented.",
        "cvs": "Regular rate and rhythm, no murmurs.",
        "muscular_skeletal": "No tenderness or swelling noted in joints.",
        "psychological_status": "Patient is anxious about symptoms.",
        "clinical_diagnosis": "Community-acquired pneumonia",
        "clinical_image": "base64_encoded_image_bytes_here",
        "pv": "Normal pulse volume"
    },
    "diagnosis": [
        {
            "diagnosed_by": {
                "identifier": "DOC123",
                "name": "Dr. Smith",
                "specialty": "Internal Medicine"
            },
            "category": "Cardiology",
            "diagnosis": "Hypertension",
            "notes": "Patient''s blood pressure consistently elevated during check-ups."
        },
        {
            "diagnosed_by": {
                "identifier": "DOC456",
                "name": "Dr. Johnson",
                "specialty": "Cardiology"
            },
            "category": "Cardiology",
            "diagnosis": "Arrhythmia",
            "notes": "Patient experiences irregular heartbeats."
        }
    ],
    "cancer_diagnosis": [
        {
            "disease_code": "C123",
            "site": "Lung",
            "basis_of_diagnosis": "Biopsy",
            "cancer_stage": "Stage II",
            "notes": "Patient is a non-smoker."
        },
        {
            "disease_code": "C456",
            "site": "Colon",
            "basis_of_diagnosis": "Colonoscopy",
            "cancer_stage": "Stage I",
            "notes": "Patient has a family history of colorectal cancer."
        },
        {
            "disease_code": "C789",
            "site": "Breast",
            "basis_of_diagnosis": "Mammogram",
            "cancer_stage": "Stage III",
            "notes": "Patient underwent mastectomy in the past."
        }
    ],
    "theater_operation": [
        {
            "anaesthesia_type": "General",
            "operation_class": "Major",
            "preoperative_diagnosis": "Appendicitis",
            "planned_procedures": "Appendectomy",
            "report": "Procedure performed without complications.",
            "postoperative_instructions": "Complete the prescribed course of antibiotics.",
            "operation_datetime": "2023-02-28T00:00:00"
        },
        {
            "anaesthesia_type": "Local",
            "operation_class": "Minor",
            "preoperative_diagnosis": "Carpal tunnel syndrome",
            "planned_procedures": "Carpal tunnel release",
            "report": "Procedure completed successfully.",
            "postoperative_instructions": "Rest the hand and elevate it for 24 hours.",
            "operation_datetime": "2023-02-28T00:00:00"
        }
    ],
    "radiology": [
        {
            "examination": "MRI Brain Scan",
            "examination_date": "2023-02-28T00:00:00",
            "indication": "Headache and dizziness",
            "report": "No abnormal findings observed.",
            "conclusion": "Normal MRI scan results. Further evaluation may be required if symptoms persist."
        },
        {
            "examination": "X-ray Chest",
            "examination_date": "2023-02-28T00:00:00",
            "indication": "Cough and shortness of breath",
            "report": "Opacity in right lower lobe, suggestive of pneumonia.",
            "conclusion": "Pneumonia confirmed. Prescribe antibiotics and follow-up in 1 week."
        }
    ],
    "pathology": [
        {
            "test": "Histopathological Examination of Biopsy Specimen",
            "examination_date": "2023-02-28T00:00:00",
            "indication": "Skin lesion biopsy",
            "diagnosis": "Melanoma"
        },
        {
            "test": "Blood Chemistry Panel",
            "examination_date": "2023-02-28T00:00:00",
            "indication": "General health check-up",
            "diagnosis": "Normal"
        }
    ],
    "vision_assessment": {
        "entry_order": "Initial assessment",
        "eye_test": "Visual acuity test",
        "visual_acuity_right": "20/20",
        "visual_acuity_right_ext": "With correction",
        "visual_acuity_left": "20/25",
        "visual_acuity_left_ext": "Without correction",
        "preferential_looking_right": "Normal",
        "preferential_looking_left": "Normal",
        "notes": "Patient reports no difficulty in reading or seeing objects."
    },
    "dental": [
        {
            "dental_service": "Teeth cleaning",
            "notes": "Patient has a history of sensitive gums.",
            "status": "Completed"
        },
        {
            "dental_service": "Cavity filling",
            "notes": "Patient reported pain while chewing.",
            "status": "Scheduled"
        }
    ],
    "eye_assessment": {
        "left_pupil": "Normal",
        "right_pupil": "Dilated",
        "left_lid_margin": "Clear",
        "right_lid_margin": "Swollen",
        "left_conjunctiva": "Pink",
        "right_conjunctiva": "Pale",
        "left_bulbar_conjunctiva": "Clear",
        "right_bulbar_conjunctiva": "Red",
        "left_central_cornea": "Clear",
        "right_central_cornea": "Cloudy",
        "left_vertical_cornea": "Normal",
        "right_vertical_cornea": "Abnormal",
        "left_anterior_chamber": "Normal depth",
        "right_anterior_chamber": "Shallow",
        "left_iris": "Normal",
        "right_iris": "Dilated",
        "left_anterior_chamber_angle": "Open",
        "right_anterior_chamber_angle": "Narrow",
        "left_retina": "Healthy",
        "right_retina": "Detached",
        "left_macula": "Intact",
        "right_macula": "Damaged",
        "left_optic_disc": "Normal",
        "right_optic_disc": "Abnormal",
        "left_iop": "12 mmHg",
        "right_iop": "20 mmHg",
        "left_vitreous": "Clear",
        "right_vitreous": "Hazy",
        "left_lens": "Clear",
        "right_lens": "Cloudy",
        "eye_notes": "Patient complains of blurred vision in the right eye.",
        "left_eye_ball": "Normal movement",
        "right_eye_ball": "Restricted movement",
        "left_orbit": "No tenderness",
        "right_orbit": "Tender on palpation"
    },
    "labtests": [
        {
            "test_code": "TC123",
            "test_name": "Blood Glucose Test",
            "status": "Pending",
            "notes": "Fasting required for accurate results.",
            "requested_by": {
                "identifier": "DOC789",
                "name": "Dr. Smith",
                "specialty": "Endocrinology"
            }
        },
        {
            "test_code": "TC456",
            "test_name": "Lipid Profile",
            "status": "Completed",
            "notes": "Patient has a family history of cardiovascular diseases.",
            "requested_by": {
                "identifier": "DOC123",
                "name": "Dr. Johnson",
                "specialty": "Cardiology"
            }
        }
    ]
}',
    '{
        "agentId": "ClinicMaster",
        "agentName": "ClinicMaster",
        "syncCount": 1,
        "syncStatus": true,
        "syncDateTime": "2024-03-25T00:00:00.000Z",
        "syncMessage": ""
    }', SYSDATETIMEOFFSET(),   
    '[]'
);

INSERT INTO MedicalReports (FacilityCode, VisitNo, VisitDate, Content, Creator, CreatedAt, Consumers) 
VALUES (
    'FAC001', 
    '240002001', 
    '2024-01-11', 
    '{
    "encounter_type": "OPD",
    "identifier": "240002001",
    "encounter_status": "Closed",
    "system": "ClinicMaster",
    "organization": {
        "code": "FAC001",
        "name": "Sample Hospital",
        "address": "123 Main Street, City, Country",
        "contact": "+256750000000"
    },
    "patient": {
        "identifier": "PAT001",
        "age": 34,
        "gender": "Male",
        "join_date": "2023-02-28T00:00:00",
        "status": "Active",
        "chronic_diseases": [
            "Hypertension",
            "Diabetes"
        ],
        "allergies": [
            {
                "allergy": "Peanuts",
                "category": "Food",
                "reaction": "Hives"
            },
            {
                "allergy": "Penicillin",
                "category": "Medication",
                "reaction": "Anaphylaxis"
            },
            {
                "allergy": "Bee venom",
                "category": "Insect sting",
                "reaction": "Swelling"
            }
        ]
    },
    "triage": {
        "weight": 56.9,
        "height": 165,
        "temperature": 98.6,
        "pulse": 80,
        "blood_pressure": "120/80 mmHg",
        "muac": 25.5,
        "bmi": "20.9",
        "bmi_status": "Normal",
        "head_circum": 55,
        "body_surface_area": 1.7,
        "respiration_rate": 16,
        "oxygen_saturation": 98,
        "heart_rate": 72,
        "notes": "Patient presents with fever and cough. No other significant findings observed."
    },
    "prescriptions": [
        {
            "drug_code": "ABC123",
            "drug_name": "Ibuprofen",
            "dosage": "1x3",
            "duration": 5,
            "quantity": 15,
            "notes": "Take with food to reduce stomach upset."
        },
        {
            "drug_code": "XYZ456",
            "drug_name": "Acetaminophen",
            "dosage": "2x2",
            "duration": 7,
            "quantity": 20,
            "notes": "Avoid alcohol consumption while taking this medication."
        }
    ],
    "clinical_findings": {
        "presenting_complaint": "Chest pain and shortness of breath",
        "ros": "Denies any fevers, chills, or weight loss.",
        "pmh": "Hypertension, Type 2 Diabetes",
        "poh": "Appendectomy 10 years ago",
        "pgh": "None",
        "fsh": "Non-smoker, occasional alcohol use",
        "ent": "No history of ear, nose, or throat issues",
        "eye": "Wears corrective lenses for myopia",
        "skin": "No history of significant skin conditions",
        "provisional_diagnosis": "Pneumonia",
        "treatment_plan": "Prescribe antibiotics and advise rest",
        "clinical_notes": "Patient appears fatigued and has a productive cough.",
        "respiratory": "Decreased breath sounds in right lower lung field.",
        "general_appearance": "Patient is alert and oriented.",
        "cvs": "Regular rate and rhythm, no murmurs.",
        "muscular_skeletal": "No tenderness or swelling noted in joints.",
        "psychological_status": "Patient is anxious about symptoms.",
        "clinical_diagnosis": "Community-acquired pneumonia",
        "clinical_image": "base64_encoded_image_bytes_here",
        "pv": "Normal pulse volume"
    },
    "diagnosis": [
        {
            "diagnosed_by": {
                "identifier": "DOC123",
                "name": "Dr. Smith",
                "specialty": "Internal Medicine"
            },
            "category": "Cardiology",
            "diagnosis": "Hypertension",
            "notes": "Patient''s blood pressure consistently elevated during check-ups."
        },
        {
            "diagnosed_by": {
                "identifier": "DOC456",
                "name": "Dr. Johnson",
                "specialty": "Cardiology"
            },
            "category": "Cardiology",
            "diagnosis": "Arrhythmia",
            "notes": "Patient experiences irregular heartbeats."
        }
    ],
    "cancer_diagnosis": [
        {
            "disease_code": "C123",
            "site": "Lung",
            "basis_of_diagnosis": "Biopsy",
            "cancer_stage": "Stage II",
            "notes": "Patient is a non-smoker."
        },
        {
            "disease_code": "C456",
            "site": "Colon",
            "basis_of_diagnosis": "Colonoscopy",
            "cancer_stage": "Stage I",
            "notes": "Patient has a family history of colorectal cancer."
        },
        {
            "disease_code": "C789",
            "site": "Breast",
            "basis_of_diagnosis": "Mammogram",
            "cancer_stage": "Stage III",
            "notes": "Patient underwent mastectomy in the past."
        }
    ],
    "theater_operation": [
        {
            "anaesthesia_type": "General",
            "operation_class": "Major",
            "preoperative_diagnosis": "Appendicitis",
            "planned_procedures": "Appendectomy",
            "report": "Procedure performed without complications.",
            "postoperative_instructions": "Complete the prescribed course of antibiotics.",
            "operation_datetime": "2023-02-28T00:00:00"
        },
        {
            "anaesthesia_type": "Local",
            "operation_class": "Minor",
            "preoperative_diagnosis": "Carpal tunnel syndrome",
            "planned_procedures": "Carpal tunnel release",
            "report": "Procedure completed successfully.",
            "postoperative_instructions": "Rest the hand and elevate it for 24 hours.",
            "operation_datetime": "2023-02-28T00:00:00"
        }
    ],
    "radiology": [
        {
            "examination": "MRI Brain Scan",
            "examination_date": "2023-02-28T00:00:00",
            "indication": "Headache and dizziness",
            "report": "No abnormal findings observed.",
            "conclusion": "Normal MRI scan results. Further evaluation may be required if symptoms persist."
        },
        {
            "examination": "X-ray Chest",
            "examination_date": "2023-02-28T00:00:00",
            "indication": "Cough and shortness of breath",
            "report": "Opacity in right lower lobe, suggestive of pneumonia.",
            "conclusion": "Pneumonia confirmed. Prescribe antibiotics and follow-up in 1 week."
        }
    ],
    "pathology": [
        {
            "test": "Histopathological Examination of Biopsy Specimen",
            "examination_date": "2023-02-28T00:00:00",
            "indication": "Skin lesion biopsy",
            "diagnosis": "Melanoma"
        },
        {
            "test": "Blood Chemistry Panel",
            "examination_date": "2023-02-28T00:00:00",
            "indication": "General health check-up",
            "diagnosis": "Normal"
        }
    ],
    "vision_assessment": {
        "entry_order": "Initial assessment",
        "eye_test": "Visual acuity test",
        "visual_acuity_right": "20/20",
        "visual_acuity_right_ext": "With correction",
        "visual_acuity_left": "20/25",
        "visual_acuity_left_ext": "Without correction",
        "preferential_looking_right": "Normal",
        "preferential_looking_left": "Normal",
        "notes": "Patient reports no difficulty in reading or seeing objects."
    },
    "dental": [
        {
            "dental_service": "Teeth cleaning",
            "notes": "Patient has a history of sensitive gums.",
            "status": "Completed"
        },
        {
            "dental_service": "Cavity filling",
            "notes": "Patient reported pain while chewing.",
            "status": "Scheduled"
        }
    ],
    "eye_assessment": {
        "left_pupil": "Normal",
        "right_pupil": "Dilated",
        "left_lid_margin": "Clear",
        "right_lid_margin": "Swollen",
        "left_conjunctiva": "Pink",
        "right_conjunctiva": "Pale",
        "left_bulbar_conjunctiva": "Clear",
        "right_bulbar_conjunctiva": "Red",
        "left_central_cornea": "Clear",
        "right_central_cornea": "Cloudy",
        "left_vertical_cornea": "Normal",
        "right_vertical_cornea": "Abnormal",
        "left_anterior_chamber": "Normal depth",
        "right_anterior_chamber": "Shallow",
        "left_iris": "Normal",
        "right_iris": "Dilated",
        "left_anterior_chamber_angle": "Open",
        "right_anterior_chamber_angle": "Narrow",
        "left_retina": "Healthy",
        "right_retina": "Detached",
        "left_macula": "Intact",
        "right_macula": "Damaged",
        "left_optic_disc": "Normal",
        "right_optic_disc": "Abnormal",
        "left_iop": "12 mmHg",
        "right_iop": "20 mmHg",
        "left_vitreous": "Clear",
        "right_vitreous": "Hazy",
        "left_lens": "Clear",
        "right_lens": "Cloudy",
        "eye_notes": "Patient complains of blurred vision in the right eye.",
        "left_eye_ball": "Normal movement",
        "right_eye_ball": "Restricted movement",
        "left_orbit": "No tenderness",
        "right_orbit": "Tender on palpation"
    },
    "labtests": [
        {
            "test_code": "TC123",
            "test_name": "Blood Glucose Test",
            "status": "Pending",
            "notes": "Fasting required for accurate results.",
            "requested_by": {
                "identifier": "DOC789",
                "name": "Dr. Smith",
                "specialty": "Endocrinology"
            }
        },
        {
            "test_code": "TC456",
            "test_name": "Lipid Profile",
            "status": "Completed",
            "notes": "Patient has a family history of cardiovascular diseases.",
            "requested_by": {
                "identifier": "DOC123",
                "name": "Dr. Johnson",
                "specialty": "Cardiology"
            }
        }
    ]
}',
    '{
        "agentId": "ClinicMaster",
        "agentName": "ClinicMaster",
        "syncCount": 1,
        "syncStatus": true,
        "syncDateTime": "2024-03-25T00:00:00.000Z",
        "syncMessage": ""
    }', SYSDATETIMEOFFSET(),   
    '[
        {
            "agentId": "ClinicMaster",
            "agentName": "ClinicMaster",
            "syncCount": 1,
            "syncStatus": false,
            "syncDateTime": "2024-03-25T00:00:00.000Z",
            "lastUpdateDateTime": "2024-03-25T00:00:00.000Z",
            "syncMessage": ""
        }
    ]'
);


INSERT INTO MedicalReports (FacilityCode, VisitNo, VisitDate, Content, Creator, CreatedAt, Consumers) 
VALUES (
    'FAC002', 
    '230781001', 
    '2024-01-11', 
    '{
    "encounter_type": "OPD",
    "identifier": "230781001",
    "encounter_status": "Closed",
    "system": "ClinicMaster",
    "organization": {
        "code": "FAC002",
        "name": "Sample Hospital",
        "address": "123 Main Street, City, Country",
        "contact": "+256750000000"
    },
    "patient": {
        "identifier": "PAT001",
        "age": 34,
        "gender": "Male",
        "join_date": "2023-02-28T00:00:00",
        "status": "Active",
        "chronic_diseases": [
            "Hypertension",
            "Diabetes"
        ],
        "allergies": [
            {
                "allergy": "Peanuts",
                "category": "Food",
                "reaction": "Hives"
            },
            {
                "allergy": "Penicillin",
                "category": "Medication",
                "reaction": "Anaphylaxis"
            },
            {
                "allergy": "Bee venom",
                "category": "Insect sting",
                "reaction": "Swelling"
            }
        ]
    },
    "triage": {
        "weight": 56.9,
        "height": 165,
        "temperature": 98.6,
        "pulse": 80,
        "blood_pressure": "120/80 mmHg",
        "muac": 25.5,
        "bmi": "20.9",
        "bmi_status": "Normal",
        "head_circum": 55,
        "body_surface_area": 1.7,
        "respiration_rate": 16,
        "oxygen_saturation": 98,
        "heart_rate": 72,
        "notes": "Patient presents with fever and cough. No other significant findings observed."
    },
    "prescriptions": [
        {
            "drug_code": "ABC123",
            "drug_name": "Ibuprofen",
            "dosage": "1x3",
            "duration": 5,
            "quantity": 15,
            "notes": "Take with food to reduce stomach upset."
        },
        {
            "drug_code": "XYZ456",
            "drug_name": "Acetaminophen",
            "dosage": "2x2",
            "duration": 7,
            "quantity": 20,
            "notes": "Avoid alcohol consumption while taking this medication."
        }
    ],
    "clinical_findings": {
        "presenting_complaint": "Chest pain and shortness of breath",
        "ros": "Denies any fevers, chills, or weight loss.",
        "pmh": "Hypertension, Type 2 Diabetes",
        "poh": "Appendectomy 10 years ago",
        "pgh": "None",
        "fsh": "Non-smoker, occasional alcohol use",
        "ent": "No history of ear, nose, or throat issues",
        "eye": "Wears corrective lenses for myopia",
        "skin": "No history of significant skin conditions",
        "provisional_diagnosis": "Pneumonia",
        "treatment_plan": "Prescribe antibiotics and advise rest",
        "clinical_notes": "Patient appears fatigued and has a productive cough.",
        "respiratory": "Decreased breath sounds in right lower lung field.",
        "general_appearance": "Patient is alert and oriented.",
        "cvs": "Regular rate and rhythm, no murmurs.",
        "muscular_skeletal": "No tenderness or swelling noted in joints.",
        "psychological_status": "Patient is anxious about symptoms.",
        "clinical_diagnosis": "Community-acquired pneumonia",
        "clinical_image": "base64_encoded_image_bytes_here",
        "pv": "Normal pulse volume"
    },
    "diagnosis": [
        {
            "diagnosed_by": {
                "identifier": "DOC123",
                "name": "Dr. Smith",
                "specialty": "Internal Medicine"
            },
            "category": "Cardiology",
            "diagnosis": "Hypertension",
            "notes": "Patient''s blood pressure consistently elevated during check-ups."
        },
        {
            "diagnosed_by": {
                "identifier": "DOC456",
                "name": "Dr. Johnson",
                "specialty": "Cardiology"
            },
            "category": "Cardiology",
            "diagnosis": "Arrhythmia",
            "notes": "Patient experiences irregular heartbeats."
        }
    ],
    "cancer_diagnosis": [
        {
            "disease_code": "C123",
            "site": "Lung",
            "basis_of_diagnosis": "Biopsy",
            "cancer_stage": "Stage II",
            "notes": "Patient is a non-smoker."
        },
        {
            "disease_code": "C456",
            "site": "Colon",
            "basis_of_diagnosis": "Colonoscopy",
            "cancer_stage": "Stage I",
            "notes": "Patient has a family history of colorectal cancer."
        },
        {
            "disease_code": "C789",
            "site": "Breast",
            "basis_of_diagnosis": "Mammogram",
            "cancer_stage": "Stage III",
            "notes": "Patient underwent mastectomy in the past."
        }
    ],
    "theater_operation": [
        {
            "anaesthesia_type": "General",
            "operation_class": "Major",
            "preoperative_diagnosis": "Appendicitis",
            "planned_procedures": "Appendectomy",
            "report": "Procedure performed without complications.",
            "postoperative_instructions": "Complete the prescribed course of antibiotics.",
            "operation_datetime": "2023-02-28T00:00:00"
        },
        {
            "anaesthesia_type": "Local",
            "operation_class": "Minor",
            "preoperative_diagnosis": "Carpal tunnel syndrome",
            "planned_procedures": "Carpal tunnel release",
            "report": "Procedure completed successfully.",
            "postoperative_instructions": "Rest the hand and elevate it for 24 hours.",
            "operation_datetime": "2023-02-28T00:00:00"
        }
    ],
    "radiology": [
        {
            "examination": "MRI Brain Scan",
            "examination_date": "2023-02-28T00:00:00",
            "indication": "Headache and dizziness",
            "report": "No abnormal findings observed.",
            "conclusion": "Normal MRI scan results. Further evaluation may be required if symptoms persist."
        },
        {
            "examination": "X-ray Chest",
            "examination_date": "2023-02-28T00:00:00",
            "indication": "Cough and shortness of breath",
            "report": "Opacity in right lower lobe, suggestive of pneumonia.",
            "conclusion": "Pneumonia confirmed. Prescribe antibiotics and follow-up in 1 week."
        }
    ],
    "pathology": [
        {
            "test": "Histopathological Examination of Biopsy Specimen",
            "examination_date": "2023-02-28T00:00:00",
            "indication": "Skin lesion biopsy",
            "diagnosis": "Melanoma"
        },
        {
            "test": "Blood Chemistry Panel",
            "examination_date": "2023-02-28T00:00:00",
            "indication": "General health check-up",
            "diagnosis": "Normal"
        }
    ],
    "vision_assessment": {
        "entry_order": "Initial assessment",
        "eye_test": "Visual acuity test",
        "visual_acuity_right": "20/20",
        "visual_acuity_right_ext": "With correction",
        "visual_acuity_left": "20/25",
        "visual_acuity_left_ext": "Without correction",
        "preferential_looking_right": "Normal",
        "preferential_looking_left": "Normal",
        "notes": "Patient reports no difficulty in reading or seeing objects."
    },
    "dental": [
        {
            "dental_service": "Teeth cleaning",
            "notes": "Patient has a history of sensitive gums.",
            "status": "Completed"
        },
        {
            "dental_service": "Cavity filling",
            "notes": "Patient reported pain while chewing.",
            "status": "Scheduled"
        }
    ],
    "eye_assessment": {
        "left_pupil": "Normal",
        "right_pupil": "Dilated",
        "left_lid_margin": "Clear",
        "right_lid_margin": "Swollen",
        "left_conjunctiva": "Pink",
        "right_conjunctiva": "Pale",
        "left_bulbar_conjunctiva": "Clear",
        "right_bulbar_conjunctiva": "Red",
        "left_central_cornea": "Clear",
        "right_central_cornea": "Cloudy",
        "left_vertical_cornea": "Normal",
        "right_vertical_cornea": "Abnormal",
        "left_anterior_chamber": "Normal depth",
        "right_anterior_chamber": "Shallow",
        "left_iris": "Normal",
        "right_iris": "Dilated",
        "left_anterior_chamber_angle": "Open",
        "right_anterior_chamber_angle": "Narrow",
        "left_retina": "Healthy",
        "right_retina": "Detached",
        "left_macula": "Intact",
        "right_macula": "Damaged",
        "left_optic_disc": "Normal",
        "right_optic_disc": "Abnormal",
        "left_iop": "12 mmHg",
        "right_iop": "20 mmHg",
        "left_vitreous": "Clear",
        "right_vitreous": "Hazy",
        "left_lens": "Clear",
        "right_lens": "Cloudy",
        "eye_notes": "Patient complains of blurred vision in the right eye.",
        "left_eye_ball": "Normal movement",
        "right_eye_ball": "Restricted movement",
        "left_orbit": "No tenderness",
        "right_orbit": "Tender on palpation"
    },
    "labtests": [
        {
            "test_code": "TC123",
            "test_name": "Blood Glucose Test",
            "status": "Pending",
            "notes": "Fasting required for accurate results.",
            "requested_by": {
                "identifier": "DOC789",
                "name": "Dr. Smith",
                "specialty": "Endocrinology"
            }
        },
        {
            "test_code": "TC456",
            "test_name": "Lipid Profile",
            "status": "Completed",
            "notes": "Patient has a family history of cardiovascular diseases.",
            "requested_by": {
                "identifier": "DOC123",
                "name": "Dr. Johnson",
                "specialty": "Cardiology"
            }
        }
    ]
}',
    '{
        "agentId": "ClinicMaster",
        "agentName": "ClinicMaster",
        "syncCount": 1,
        "syncStatus": true,
        "syncDateTime": "2024-03-25T00:00:00.000Z",
        "syncMessage": ""
    }', SYSDATETIMEOFFSET(),   
    '[
        {
            "agentId": "ClinicMaster",
            "agentName": "ClinicMaster",
            "syncCount": 1,
            "syncStatus": false,
            "syncDateTime": "2024-03-25T00:00:00.000Z",
            "lastUpdateDateTime": "2024-03-25T00:00:00.000Z",
            "syncMessage": ""
        }
    ]'
);
