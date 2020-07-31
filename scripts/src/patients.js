import {getHeaders} from "./demoServerSetup.js";
import {deadPatient} from "../data/dead-patient.js";

import csv from "csv-parser";
import fs from "fs";
import axios from "axios";

//missing patient9 and patient10 as they have the sensitive flag and cant be retrieved from the system
const fakeNhsNo = [
    "patient1", "patient2",
    "patient3", "patient4", "patient5",
    "patient6", "patient7", "patient8",
    "patient11", "patient12", "patient13", "patient14", "patient15"
];

const seedPatient = (patient, testBaseUrl, user, pass) => {
    const body = {
        resourceType: "Parameters",
        parameter: [
            {
                name: "patient",
                resource: patient
            }
        ]
    };
    axios
        .post(`${testBaseUrl}/Patient/$setup`, body,{auth: {username: user, password: pass}})
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

const seedPatients = (config) => {
    const {testBaseUrl, user, pass} = config
    const patientData = JSON.parse(fs.readFileSync('./data/patients.json', 'utf-8'))
    console.log("Seeding Patient Data:")
    patientData.forEach(patient => seedPatient(patient, testBaseUrl, user, pass))
}

const getPatientFromGPConnectApi = async(demoServerBaseUrl, nhsNo) => {
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

const getPatientsFromGPConnectApi = (demoServerBaseUrl, nhsNumbers) => {
    return Promise.all(
        nhsNumbers.map( nhsNumber => 
            getPatientFromGPConnectApi(demoServerBaseUrl, nhsNumber)
                .then(patient => {delete patient["id"]; return patient})
                .catch(error => console.log(error))
        )
    )
}

const savePatientsToFile = (patients) => {
    fs.writeFileSync('./data/patients.json', JSON.stringify(patients) , 'utf-8');
    console.log("-- Patients Data Saved --")
}

export const downloadandSeedPatients = (config) => {
    const {demoServerBaseUrl} = config;
    const nhsNumbers = [];
    fs.createReadStream("../Data/NHSNoMap.csv")
        .pipe(csv())
        .on('data', (row) => {
            if (fakeNhsNo.includes(row["NATIVE_NHS_NUMBER"])) {
                nhsNumbers.push(row["PROVIDER_NHS_NUMBER"]);
            }
        })
        .on('end', () => {
            console.log('Nhs No CSV file successfully processed');
            console.log("-- Downloading Patient Data --")
            return getPatientsFromGPConnectApi(demoServerBaseUrl, nhsNumbers)
                .then(patients => {
                    patients.push(deadPatient);
                    savePatientsToFile(patients);
                    seedPatients(config);
                })
                .catch(console.log)
        });
};

export const setupPatients = (config) =>{
    const {updateLocalData} = config;
    if(updateLocalData){
        downloadandSeedPatients(config)
    }else{
        seedPatients(config)
    }
}