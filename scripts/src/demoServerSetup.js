import Uuidv4 from "uuidv4";
import CryptoJS from "crypto-js";

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

export const getHeaders = (demoServerBaseUrl, interaction) => {
    return {
        Authorization: `Bearer ${generateJwtToken(demoServerBaseUrl)}`,
        Accept: "application/fhir+json",
        "Ssp-From": "200000000359",
        "Ssp-To": "918999198993",
        "Ssp-TraceID": Uuidv4.uuid(),
        "Ssp-InteractionID": interaction,
    };
};