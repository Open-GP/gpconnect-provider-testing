import {getHeaders} from "./demoServerSetup.js";

import csv from "csv-parser";
import fs from "fs";
import axios from "axios";

const retrievePractitioner = (demoServerBaseUrl, practitionerCode) => {

    const config = {
        params: {
            identifier: `https://fhir.nhs.uk/Id/sds-user-id|${practitionerCode}`
        },
        headers: getHeaders(demoServerBaseUrl, "urn:nhs:names:services:gpconnect:fhir:rest:search:practitioner-1")
    };

    return axios
        .get(`${demoServerBaseUrl}/Practitioner`, config)
        .then(result => {
            return result.data.entry[0].resource;
        })
        .catch(err => {
            console.log("error retrieving for:", practitionerCode, err);
        });
};

const storePractitioner = (practitioner, testBaseUrl, user, pass) => {

    const body = {
        resourceType: "Parameters",
        parameter: [
            {
                name: "practitioner",
                resource: practitioner
            }
        ]
    };

    axios
        .post(`${testBaseUrl}/Practitioner/$setup`, body,
            {auth: {username: user, password: pass},
                headers: {"Content-Type": "application/fhir+json"}})
        .then(result => {
            console.log("Practitioner Success", practitioner.identifier);
        })
        .catch(err => {
            console.log("Practitioner Error", practitioner.identifier);
        });
};


export const setupPractitioners = (demoServerBaseUrl, testBaseUrl, user, pass) => {
    const practitionerCodes = [];
    fs.createReadStream("../Data/PractitionerCodeMap.csv")
        .pipe(csv())
        .on('data', (row) => {
            practitionerCodes.push(row["PROVIDER_PRACTITIONER_CODE"]);
        })
        .on('end', () => {
            console.log('Practitioner CSV file successfully processed');

            practitionerCodes.forEach(practitionerCode =>
                retrievePractitioner(demoServerBaseUrl, practitionerCode)
                    .then(practitioner => storePractitioner(practitioner, testBaseUrl, user, pass))
                    .catch(console.log)
            )
        });
};
