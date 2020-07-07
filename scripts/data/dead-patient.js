export const deadPatient = {
  "resourceType": "Patient",
  "meta": {
    "profile": [
      "https://fhir.nhs.uk/STU3/StructureDefinition/CareConnect-GPC-Patient-1"
    ]
  },
  "identifier": [
    {
      "extension": [
        {
          "url": "https://fhir.nhs.uk/STU3/StructureDefinition/Extension-CareConnect-GPC-NHSNumberVerificationStatus-1",
          "valueCodeableConcept": {
            "coding": [
              {
                "system": "https://fhir.nhs.uk/STU3/CodeSystem/CareConnect-NHSNumberVerificationStatus-1",
                "code": "01",
                "display": "Number present and verified"
              }
            ]
          }
        }
      ],
      "system": "https://fhir.nhs.uk/Id/nhs-number",
      "value": "9658220290"
    }
  ],
  "name": [
    {
      "use": "official",
      "text": "Test Testerson",
      "family": "Testerson",
      "given": [
        "Test"
      ],
      "prefix": [
        "MR"
      ]
    }
  ],
  "telecom": [
    {
      "system": "phone",
      "value": "01454587554",
      "use": "home"
    }
  ],
  "gender": "male",
  "deceasedDeathTime": "2020-09-12",
  "birthDate": "1967-09-12",
  "address": [
    {
      "use": "home",
      "type": "physical",
      "line": [
        "17 NEW STREET",
        "ELSHAM"
      ],
      "city": "BRIGG",
      "postalCode": "DN20 0RW"
    }
  ],
  "generalPractitioner": [
    {
      "reference": "Practitioner/1"
    }
  ],
  "managingOrganization": {
    "reference": "Organization/7"
  }
};