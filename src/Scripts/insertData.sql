USE ClinicMasterFirstContact
GO

-- DELETE FROM dbo.Surgeries;
-- DELETE FROM dbo.Patients;

---------------------------------------------------------------
------- Patients ----------------------------------------------
---------------------------------------------------------------

INSERT INTO dbo.Patients (PatientNo, FullName, Gender, Age, Creator, CreatedAt, Consumers) 
VALUES ('240001', 'Kintu Moses', 'Male', 45, '{
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

INSERT INTO dbo.Patients (PatientNo, FullName, Gender, Age, Creator, CreatedAt, Consumers) 
VALUES ('240002', 'Mary Okello', 'Female', 18, '{
        "agentId": "ClinicMaster",
        "agentName": "ClinicMaster",
        "syncCount": 1,
        "syncStatus": true,
        "syncDateTime": "2024-03-25T00:00:00.000Z",
        "syncMessage": ""
    }', SYSDATETIMEOFFSET(), 
    '[]');

INSERT INTO dbo.Patients (PatientNo, FullName, Gender, Age, Creator, CreatedAt, Consumers) 
VALUES ('240003', 'Adam Gonza', 'Male', 34, '{
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
        },
        {
            "agentId": "FirstContact",
            "agentName": "FirstContact",
            "syncCount": 1,
            "syncStatus": false,
            "syncDateTime": "2024-03-25T00:00:00.000Z",
            "lastUpdateDateTime": "2024-03-25T00:00:00.000Z",
            "syncMessage": ""
        }
    ]'
    );

INSERT INTO dbo.Patients (PatientNo, FullName, Gender, Age, Creator, CreatedAt, Consumers) 
VALUES ('240004', 'James Mainuka', 'Male', 31, '{
        "agentId": "ClinicMaster",
        "agentName": "ClinicMaster",
        "syncCount": 1,
        "syncStatus": true,
        "syncDateTime": "2024-03-25T00:00:00.000Z",
        "syncMessage": ""
    }', SYSDATETIMEOFFSET(), '[]'
);
GO

---------------------------------------------------------------
------- Surgeries ---------------------------------------------
---------------------------------------------------------------

INSERT INTO dbo.Surgeries (TreatmentNo, PatientNo, VisitDate, Content, Creator, CreatedAt, Consumers) 
VALUES ('240001001', '240001', '2023-12-07T00:00:00.000Z',     
    N'{
      "procedureCode": "SURG185",
      "procedureName": "Diagnostic Laparascopy",
      "details": "Requires Enough Bed Rest",
      "medicalHistory": "Lots of body pain",
      "attachmentUrls": [
          "https://images.unsplash.com/photo-1558642452-9d2a7deb7f62",
          "https://images.unsplash.com/photo-1597645587822-e99fa5d45d25"
      ],
      "precriptions": [
          {
              "drugNo": "D001",
              "drugName": "Paracetamol",
              "dosage": "2X3 for 5 days"
          },
          {
              "drugNo": "D002",
              "drugName": "Cloxacillin 250mg",
              "dosage": "1X4 for 8 days"
          }
      ]
  }', '{
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

INSERT INTO dbo.Surgeries (TreatmentNo, PatientNo, VisitDate, Content, Creator, CreatedAt, Consumers) 
VALUES ('240001002', '240001', '2023-12-12T00:00:00.000Z',     
    N'{
      "procedureCode": "SURG223",
      "procedureName": "Debresment of a wound large",
      "details": "Drink a lot",
      "medicalHistory": "Lots of body pain",
      "attachmentUrls": [
          "https://images.unsplash.com/photo-1567306301408-9b74779a11af"
      ],
      "precriptions": []
  }', '{
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

INSERT INTO dbo.Surgeries (TreatmentNo, PatientNo, VisitDate, Content, Creator, CreatedAt, Consumers) 
VALUES ('240001003', '240001', '2023-10-21T00:00:00.000Z', 
    N'{
      "procedureCode": "SURG128",
      "procedureName": "Bonemarrow Puncture",
      "details": "Constant Fever",
      "medicalHistory": "",
      "attachmentUrls": [
          "https://images.unsplash.com/photo-1567306301408-9b74779a11af",
          "https://images.unsplash.com/photo-1558642452-9d2a7deb7f62"
      ],
      "precriptions": [
          {
            "drugNo": "D001",
            "drugName": "Paracetamol",
            "dosage": "2X3 for 5 days"
          },
          {
            "drugNo": "D002",
            "drugName": "Cloxacillin 250mg",
            "dosage": "1X4 for 8 days"
          }
      ]
  }', '{
        "agentId": "ClinicMaster",
        "agentName": "ClinicMaster",
        "syncCount": 1,
        "syncStatus": true,
        "syncDateTime": "2024-03-25T00:00:00.000Z",
        "syncMessage": ""
    }', SYSDATETIMEOFFSET(),
    '[]'
    );

INSERT INTO dbo.Surgeries (TreatmentNo, PatientNo, VisitDate, Content, Creator, CreatedAt, Consumers) 
VALUES ('240001004', '240001', '2023-09-18T00:00:00.000Z',
    N'{
      "procedureCode": "SURG124",
      "procedureName": "Catheterisation retention",
      "details": "Vomiting",
      "medicalHistory": "Loss of weight",
      "attachmentUrls": [
          "https://images.unsplash.com/photo-1567306301408-9b74779a11af",
          "https://images.unsplash.com/photo-1558642452-9d2a7deb7f62"
      ],
      "precriptions": [
          {
            "drugNo": "D001",
            "drugName": "Paracetamol",
            "dosage": "2X3 for 5 days"
          },
          {
            "drugNo": "D002",
            "drugName": "Cloxacillin 250mg",
            "dosage": "1X4 for 8 days"
          }
      ]
  }', '{
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

INSERT INTO dbo.Surgeries (TreatmentNo, PatientNo, VisitDate, Content, Creator, CreatedAt, Consumers) 
VALUES ('240002001', '240002', '2023-10-25T00:00:00.000Z', 
    N'{
      "procedureCode": "SURG124",
      "procedureName": "Catheterisation retention",
      "details": "Vomiting",
      "medicalHistory": "Loss of weight",
      "attachmentUrls": [
          "https://images.unsplash.com/photo-1558642452-9d2a7deb7f62",
          "https://images.unsplash.com/photo-1597645587822-e99fa5d45d25"
        ],
      "precriptions": [
          {
            "drugNo": "D001",
            "drugName": "Paracetamol",
            "dosage": "2X3 for 5 days"
          },
          {
            "drugNo": "D002",
            "drugName": "Cloxacillin 250mg",
            "dosage": "1X4 for 8 days"
          }
      ]
  }', '{
        "agentId": "ClinicMaster",
        "agentName": "ClinicMaster",
        "syncCount": 1,
        "syncStatus": true,
        "syncDateTime": "2024-03-25T00:00:00.000Z",
        "syncMessage": ""
    }', SYSDATETIMEOFFSET(), 
  '[]'
  );
  