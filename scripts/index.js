const axios = require("axios");
const {uuid} = require("uuidv4");
const CryptoJS = require("crypto-js");
const csv = require("csv-parser");
const fs = require("fs");

const nhsNos = [];
const fakeNhsNo = [
    "patient1", "patient2",
    "patient3", "patient4", "patient5",
    "patient6", "patient7", "patient8", "patient9", "patient10",
    "patient11", "patient12", "patient13", "patient14", "patient15",
];

const demoServerBaseUrl = "https://orange.testlab.nhs.uk/gpconnect-demonstrator/v1/fhir";

const generateJwtToken = (baseUrl) => {
    var requesting_organization_ODS_Code = "GPC001";

// Construct the JWT token for the request
    var currentTime = new Date();
    var expiryTime = new Date(currentTime.getTime() + 300000); // 5 mins after current time
    var jwtCreationTime = Math.round(currentTime.getTime() / 1000);
    var jwtExpiryTime = Math.round(expiryTime.getTime() / 1000);

    var header = {
        "alg": "none",
        "typ": "JWT"
    };

    var payload = {
        "iss": "http://gpconnect-postman-url",
        "sub": "1",
        "aud": baseUrl,
        "exp": jwtExpiryTime,
        "iat": jwtCreationTime,
        "reason_for_request": "directcare",
        "requested_scope": "patient/*.read",
        "requesting_device": {
            "resourceType": "Device",
            "id": "1",
            "identifier": [
                {
                    "system": "Web Interface",
                    "value": "Postman example consumer"
                }
            ],
            "model": "Postman",
            "version": "1.0"
        },
        "requesting_organization": {
            "resourceType": "Organization",
            "identifier": [
                {
                    "system": "https://fhir.nhs.uk/Id/ods-organization-code",
                    "value": requesting_organization_ODS_Code
                }
            ],
            "name": "Postman Organization"
        },
        "requesting_practitioner": {
            "resourceType": "Practitioner",
            "id": "1",
            "identifier": [
                {
                    "system": "https://fhir.nhs.uk/Id/sds-user-id",
                    "value": "G13579135"
                },
                {
                    "system": "https://fhir.nhs.uk/Id/sds-role-profile-id",
                    "value": "111111111"
                },
            ],
            "name": [{
                "family": "Demonstrator",
                "given": [
                    "GPConnect"
                ],
                "prefix": [
                    "Mr"
                ]
            }]
        }
    };

    const base64url = (source) => {
        // Encode in classical base64
        let encodedSource = CryptoJS.enc.Base64.stringify(source);
        // Remove padding equal characters
        encodedSource = encodedSource.replace(/=+$/, '');
        // Replace characters according to base64url specifications
        encodedSource = encodedSource.replace(/\+/g, '-');
        encodedSource = encodedSource.replace(/\//g, '_');
        return encodedSource;
    };

// Encode the JWT data into the base64url encoded string
    var stringifiedHeader = CryptoJS.enc.Utf8.parse(JSON.stringify(header));
    var encodedHeader = base64url(stringifiedHeader);
    var stringifiedPayload = CryptoJS.enc.Utf8.parse(JSON.stringify(payload));
    var encodedPayload = base64url(stringifiedPayload);
    return encodedHeader + "." + encodedPayload + ".";
};

const retrievePatient = (demoServerBaseUrl, nhsNo) => {
    const jwtString = generateJwtToken(demoServerBaseUrl);

    const config = {
        params: {
            identifier: `https://fhir.nhs.uk/Id/nhs-number|${nhsNo}`
        },
        headers: {
            Authorization: `Bearer ${jwtString}`,
            Accept: "application/fhir+json",
            "Ssp-From": "200000000359",
            "Ssp-To": "918999198993",
            "Ssp-TraceID": uuid(),
            "Ssp-InteractionID": "urn:nhs:names:services:gpconnect:fhir:rest:search:patient-1",
        }
    };


    return axios
        .get(`${demoServerBaseUrl}/Patient`, config)
        .then(result => {
            return result.data.entry[0].resource;
        })
        .catch(err => {
            console.log("error retrieving for:", nhsNo);
        });
};

const hackPatientForOpenGP = patient => {
    patient["deceasedBoolean"] = false;
    patient.identifier[0]["use"] = "usual";
    delete patient.name[0].prefix;
    return patient;
};

const testBaseUrl = process.env.TEST_BASE_URL || "http://localhost:8080/openmrs/ws/fhir";
const user = process.env.TEST_USERNAME;
const pass = process.env.PASS;


const storePatient = patient => {
    axios
        .post(`${testBaseUrl}/Patient`, patient,{auth: {username: user, password: pass}})
        .then(result => {
            console.log("Success", patient.id, result.response.status)
        })
        .catch(err => {
            // console.log(patient);
            console.log(err.response.data.issue)
        });
};

fs.createReadStream("../Data/NHSNoMap.csv")
    .pipe(csv())
    .on('data', (row) => {
        if (fakeNhsNo.includes(row["NATIVE_NHS_NUMBER"])) {
            nhsNos.push(row["PROVIDER_NHS_NUMBER"]);
        }
    })
    .on('end', () => {
        console.log('CSV file successfully processed');
        nhsNos.forEach(nhsNo => retrievePatient(demoServerBaseUrl, nhsNo)
            .then(hackPatientForOpenGP)
            .then(storePatient)
            .catch(error => console.log(error))
        );
    });