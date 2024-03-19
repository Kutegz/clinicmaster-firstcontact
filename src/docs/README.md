# ClinicMaster FirstContact API

- [ClinicMaster FirstContact API](#clinicmaster-firstcontact-api)
  - [Get All Patients](#get-all-patients)
    - [All Patients Request](#all-patients-request)
    - [All Patients Response](#all-patients-response)
  - [Get Single Patient](#get-single-patient)
    - [Single Patient Request](#single-patient-request)
    - [Single Patient Response](#single-patient-response)
  - [Get Patient Surgeries](#get-patient-surgeries)
    - [Patient Surgeries Request](#patient-surgeries-request)
    - [Patient Surgeries Response](#patient-surgeries-response)
  - [Get Patient Single Surgery](#get-patient-single-surgery)
    - [Patient Single Surgery Request](#patient-single-surgery-request)
    - [Patient Single Surgery Response](#patient-single-surgery-response)

## Get All Patients

### All Patients Request

```js
GET http://ksc-cm.kyabirwasc.org:9090/patients/
```

```js
GET http://ksc-cm.kyabirwasc.org:9090/patients?page=1$pageSize=10/
```

### All Patients Response

```js
200 Ok
```

```json
{
  "success": true,
  "message": "",
  "data": [
    {
      "patientNo": "240001",
      "fullName": "Kintu Moses",
      "gender": "Male",
      "age": 45,
      "surgeries": [
        {
          "treatmentNo": "240001001",
          "patientNo": "240001",
          "visitDate": "2023-12-07T00:00:00",
          "content": {
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
          }
        },
        {
          "treatmentNo": "240001004",
          "patientNo": "240001",
          "visitDate": "2023-09-18T00:00:00",
          "content": {
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
          }
        }
      ]
    },
    {
      "patientNo": "240003",
      "fullName": "Adam Gonza",
      "gender": "Male",
      "age": 34,
      "surgeries": []
    }
  ]
}
```

## Get Single Patient

### Single Patient Request

```js
GET http://ksc-cm.kyabirwasc.org:9090/patients/{{patientNo}}
```

### Single Patient Response

```js
200 Ok
```

```json
{
  "success": true,
  "message": "",
  "data": {
    "patientNo": "240001",
    "fullName": "Kintu Moses",
    "gender": "Male",
    "age": 45,
    "surgeries": [
      {
        "treatmentNo": "240001001",
        "patientNo": "240001",
        "visitDate": "2023-12-07T00:00:00",
        "content": {
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
        }
      },
      {
        "treatmentNo": "240001002",
        "patientNo": "240001",
        "visitDate": "2023-12-12T00:00:00",
        "content": {
          "procedureCode": "SURG223",
          "procedureName": "Debresment of a wound large",
          "details": "Drink a lot",
          "medicalHistory": "Lots of body pain",
          "attachmentUrls": [
            "https://images.unsplash.com/photo-1567306301408-9b74779a11af"
          ],
          "precriptions": []
        }
      }
    ]
  }
}
```

## Get Patient Surgeries

### Patient Surgeries Request

```js
GET http://ksc-cm.kyabirwasc.org:9090/patients/{{patientNo}}/surgeries/
```

### Patient Surgeries Response

```js
200 Ok
```

```json
{
  "success": true,
  "message": "",
  "data": [
    {
      "treatmentNo": "240001001",
      "patientNo": "240001",
      "visitDate": "2023-12-07T00:00:00",
      "content": {
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
      }
    },
    {
      "treatmentNo": "240001002",
      "patientNo": "240001",
      "visitDate": "2023-12-12T00:00:00",
      "content": {
        "procedureCode": "SURG223",
        "procedureName": "Debresment of a wound large",
        "details": "Drink a lot",
        "medicalHistory": "Lots of body pain",
        "attachmentUrls": [
          "https://images.unsplash.com/photo-1567306301408-9b74779a11af"
        ],
        "precriptions": []
      }
    }
  ]
}
```

## Get Patient Single Surgery

### Patient Single Surgery Request

```js
GET http://ksc-cm.kyabirwasc.org:9090/patients/{{patientNo}}/surgeries/{{treatmentNo}}
```

### Patient Single Surgery Response

```js
200 Ok
```

```json
{
  "success": true,
  "message": "",
  "data": {
    "treatmentNo": "240001001",
    "patientNo": "240001",
    "visitDate": "2023-12-07T00:00:00",
    "content": {
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
    }
  }
}
```
