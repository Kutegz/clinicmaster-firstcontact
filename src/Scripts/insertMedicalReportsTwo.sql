
-- DELETE FROM MedicalReports;

INSERT INTO MedicalReports (FacilityCode, VisitNo, VisitDate, Content, Creator, CreatedAt, Consumers) 
VALUES (
    'FAC001', 
    '240001001', 
    '2024-01-11', 
    '{
  "resourceType": "Bundle",
  "type": "transaction",
  "entry": [
    {
      "resource": {
        "resourceType": "ServiceRequest",
        "id": "22 121271001-27171005",
        "identifier": [
          {
            "type": {
              "text": "EMR-System"
            },
            "value": "ClinicMaster (MOH)"
          }
        ],
        "status": "active",
        "intent": "order",
        "category": [
          {
            "coding": [
              {
                "system": "http://snomed.info/sct",
                "code": "108252007",
                "display": "Laboratory procedure"
              }
            ],
            "text": "Laboratory procedure"
          }
        ],
        "priority": "routine",
        "code": {
          "coding": [
            {
              "system": "http://snomed.info/sct",
              "code": "27171005",
              "display": ""
            }
          ],
          "text": ""
        },
        "subject": {
          "reference": "urn:uuid:c197b218-7edb-4122-bdde-0e5377f01a75"
        },
        "authoredOn": "2023-09-22",
        "requester": {
          "reference": "urn:uuid:64bcd753-ed46-4235-8291-7df596a39d62",
          "type": "Practitioner"
        },
        "supportingInfo": [
          {
            "reference": "urn:uuid:b5c37d30-9a6a-47c3-8405-32c96d144cdf",
            "type": "MedicationStatement",
            "display": "previous therapy"
          },
          {
            "reference": "urn:uuid:6df794e4-8c6e-4189-bc8a-40e86e9d07f7",
            "type": "MedicationStatement",
            "display": "current therapy"
          },
          {
            "reference": "urn:uuid:e6e827a5-2b38-429e-ae36-171fb745bddc",
            "type": "Observation",
            "display": "antibiotics and hospitalisation info"
          }
        ],
        "specimen": [
          {
            "reference": "urn:uuid:fe877754-322e-404d-9b06-a9d71c0b5e7a",
            "type": "Specimen"
          }
        ],
        "note": [
          {
            "text": "--"
          }
        ]
      }
    },
    {
      "resource": {
        "resourceType": "Specimen",
        "id": "fe877754-322e-404d-9b06-a9d71c0b5e7a",
        "meta": {
          "profile": ["http://hl7.org/fhir/StructureDefinition/Specimen"]
        },
        "type": {
          "coding": [
            {
              "system": "http://snomed.info/sct",
              "code": "122575003"
            }
          ],
          "text": "Urine"
        },
        "collection": {
          "collector": {
            "reference": "urn:uuid:64bcd753-ed46-4235-8291-7df596a39d62",
            "type": "Practitioner"
          },
          "collectedDateTime": "2023-09-22T20:47:06.1519017+03:00"
        }
      }
    },
    {
      "resource": {
        "resourceType": "Patient",
        "id": "c197b218-7edb-4122-bdde-0e5377f01a75",
        "extension": [
          {
            "extension": [
              {
                "url": "nationality",
                "valueString": "National (N)"
              },
              {
                "url": "age",
                "valueAge": {
                  "value": 48,
                  "system": "http://unitsofmeasure.org",
                  "code": "a"
                }
              },
              {
                "url": "occupation",
                "valueString": "SELF EMPLOYMENT"
              }
            ],
            "url": "http://labhie.cphluganda.org/fhir/patient-extension"
          }
        ],
        "identifier": [
          {
            "use": "official",
            "type": {
              "coding": [
                {
                  "system": "http://snomed.info/sct",
                  "code": "184107009",
                  "display": "Patient hospital number"
                }
              ],
              "text": "Patient No"
            },
            "value": "22 121271"
          },
          {
            "use": "official",
            "type": {
              "coding": [
                {
                  "system": "http://snomed.info/sct",
                  "code": "722248002",
                  "display": "Patient hospital visit number"
                }
              ],
              "text": "OPD/IPD No"
            },
            "value": "22 121271002"
          },
          {
            "use": "official",
            "type": {
              "coding": [
                {
                  "system": "http://terminology.hl7.org/CodeSystem/v2-0203",
                  "code": "NI",
                  "display": "National unique individual identifier"
                }
              ],
              "text": "NIN/ Passport No"
            },
            "value": "CF750471024NPC"
          }
        ],
        "name": [
          {
            "family": "ESERY",
            "given": ["NABUYOBO"]
          }
        ],
        "telecom": [
          {
            "system": "phone",
            "value": "0789986294"
          },
          {
            "system": "email",
            "value": ""
          }
        ],
        "gender": "female",
        "birthDate": "1975-09-12",
        "address": [
          {
            "use": "work",
            "city": "SEETA"
          },
          {
            "use": "home",
            "city": "SEETA"
          }
        ]
      }
    },
    {
      "resource": {
        "resourceType": "Practitioner",
        "id": "64bcd753-ed46-4235-8291-7df596a39d62",
        "meta": {
          "profile": ["http://hl7.org/fhir/StructureDefinition/Practitioner"]
        },
        "identifier": [
          {
            "use": "official",
            "type": {
              "text": "Cadre"
            },
            "value": "Doctor"
          },
          {
            "use": "official",
            "type": {
              "text": "EMR-ID"
            },
            "value": "S050"
          }
        ],
        "name": [
          {
            "family": "Johnwycliff",
            "given": ["Barinda"]
          }
        ],
        "telecom": [
          {
            "system": "phone",
            "value": "0780000000"
          },
          {
            "system": "email",
            "value": "default@email.com"
          }
        ]
      }
    },
    {
      "resource": {
        "resourceType": "MedicationStatement",
        "id": "current-therapy",
        "status": "active",
        "medicationCodeableConcept": {
          "coding": [
            {
              "system": "http://snomed.info/sct",
              "code": "513881000000106",
              "display": "Current medication as reported by patient (observable entity)"
            }
          ],
          "text": ""
        },
        "subject": {
          "reference": "urn:uuid:c197b218-7edb-4122-bdde-0e5377f01a75"
        },
        "note": [
          {
            "text": ""
          }
        ]
      }
    },
    {
      "resource": {
        "resourceType": "MedicationStatement",
        "id": "previous-therapy",
        "status": "completed",
        "medicationCodeableConcept": {
          "coding": [
            {
              "system": "http://snomed.info/sct",
              "code": "394829006",
              "display": "Past medication (situation)"
            }
          ],
          "text": ""
        },
        "subject": {
          "reference": "urn:uuid:c197b218-7edb-4122-bdde-0e5377f01a75"
        },
        "note": [
          {
            "text": ""
          }
        ]
      }
    },
    {
      "resource": {
        "resourceType": "Observation",
        "id": "observation-1",
        "status": "final",
        "code": {
          "coding": [
            {
              "system": "http://snomed.info/sct",
              "code": "129268004",
              "display": "Observation - action (qualifier value)"
            }
          ]
        },
        "component": [
          {
            "code": {
              "coding": [
                {
                  "system": "http://snomed.info/sct",
                  "code": "32485007",
                  "display": "Hospital admission (procedure)"
                }
              ],
              "text": "None"
            },
            "valueBoolean": true
          },
          {
            "code": {
              "coding": [
                {
                  "system": "http://snomed.info/sct",
                  "code": "129019007",
                  "display": "Taking medication (observable entity)"
                }
              ],
              "text": "None"
            },
            "valueBoolean": false
          },
          {
            "code": {
              "text": "Interim Diagnosis"
            },
            "valueString": ""
          }
        ]
      }
    },
    {
      "resource": {
        "resourceType": "Encounter",
        "status": "in-progress",
        "class": {
          "system": "http://terminology.hl7.org/CodeSystem/v3-ActCode",
          "code": "AMB",
          "display": "ambulatory"
        },
        "serviceType": {
          "coding": [
            {
              "system": "http://terminology.hl7.org/CodeSystem/service-type",
              "code": "397",
              "display": "Out-Patient"
            }
          ],
          "text": "Out-Patient"
        },
        "subject": {
          "reference": "urn:uuid:c197b218-7edb-4122-bdde-0e5377f01a75"
        },
        "location": [
          {
            "location": {
              "reference": "urn:uuid:441617f0-1199-4a0a-bfe4-1109a1c07bff"
            },
            "physicalType": {
              "coding": [
                {
                  "system": "http://terminology.hl7.org/CodeSystem/location-physical-type",
                  "code": "507BUS",
                  "display": "GENERAL OPD"
                }
              ]
            }
          },
          {
            "location": {
              "reference": "urn:uuid:78a91359-3d0b-48bf-acea-6ed125439f25"
            },
            "physicalType": {
              "coding": [
                {
                  "system": "http://terminology.hl7.org/CodeSystem/location-physical-type",
                  "code": "bd",
                  "display": "Bed"
                }
              ]
            }
          }
        ]
      }
    },
    {
      "resource": {
        "resourceType": "Location",
        "status": "active",
        "name": "GENERAL OPD",
        "physicalType": {
          "coding": [
            {
              "system": "http://terminology.hl7.org/CodeSystem/location-physical-type",
              "code": "wa",
              "display": "Ward"
            }
          ]
        }
      }
    },
    {
      "resource": {
        "resourceType": "Location",
        "status": "active",
        "name": "",
        "physicalType": {
          "coding": [
            {
              "system": "http://terminology.hl7.org/CodeSystem/location-physical-type",
              "code": "Bd",
              "display": "Bed"
            }
          ]
        },
        "partOf": {
          "reference": "urn:uuid:441617f0-1199-4a0a-bfe4-1109a1c07bff"
        }
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

