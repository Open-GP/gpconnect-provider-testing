import {getHeaders} from "./demoServerSetup.js";
import {deadPatient} from "../data/dead-patient.js";

import csv from "csv-parser";
import fs from "fs";
import axios from "axios";

const nhsNos = [];
//missing patient9 and patient10 as they have the sensitive flag and cant be retrieved from the system
const fakeNhsNo = [
    "patient1", "patient2",
    "patient3", "patient4", "patient5",
    "patient6", "patient7", "patient8",
    "patient11", "patient12", "patient13", "patient14", "patient15"
];

const retrievePatient = (demoServerBaseUrl, nhsNo) => {
    const config = {
        params: {
            identifier: `https://fhir.nhs.uk/Id/nhs-number|${nhsNo}`
        },
        headers: getHeaders(demoServerBaseUrl, "urn:nhs:names:services:gpconnect:fhir:rest:search:patient-1")
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

const storePatient = (patient, testBaseUrl, user, pass) => {
    const body = {
        resourceType: "Parameters",
        parameter: [
            {
                name: "registerPatient",
                resource: patient
            }
        ]
    };
    axios
        .post(`${testBaseUrl}/Patient/$gpc.registerpatient`, body,{auth: {username: user, password: pass}})
        .then(result => {
            console.log("Patient Success", patient.identifier)
        })
        .catch(err => {
            if (err.response){
                console.log("Patient Error", err.response.status, patient.identifier)
            } else {
                console.log("Patient Error", patient.identifier);
            }
        });
};

export const setupPatients = (demoServerBaseUrl, testBaseUrl, user, pass) => {
    fs.createReadStream("../Data/NHSNoMap.csv")
        .pipe(csv())
        .on('data', (row) => {
            if (fakeNhsNo.includes(row["NATIVE_NHS_NUMBER"])) {
                nhsNos.push(row["PROVIDER_NHS_NUMBER"]);
            }
        })
        .on('end', () => {
            console.log('Nhs No CSV file successfully processed');
            nhsNos.forEach(
                nhsNo => retrievePatient(demoServerBaseUrl, nhsNo)
                .then(patient => storePatient(patient, testBaseUrl, user, pass))
                .catch(error => console.log(error))
            );
        });

    storePatient(deadPatient, testBaseUrl, user, pass);
};