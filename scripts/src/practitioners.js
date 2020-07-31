import {getHeaders} from "./demoServerSetup.js";

import csv from "csv-parser";
import fs from "fs";
import axios from "axios";

const seedPractitioner = (practitioner, testBaseUrl, user, pass) => {
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

const seedPractitioners = (config) => {
    const {testBaseUrl, user, pass} = config
    const practitionerData = JSON.parse(fs.readFileSync('./data/practitioners.json', 'utf-8'))
    console.log("Seeding Practitioner Data:")
    practitionerData.forEach(practitioner => seedPractitioner(practitioner, testBaseUrl, user, pass))
}

const getPractitionerFromGPConnectApi = async (demoServerBaseUrl, practitionerCode) => {
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
            console.log("error retrieving for:", practitionerCode);
        });
};

const getPractitionersFromGPConnectApi = (demoServerBaseUrl, practitionerCodes) => {
    return Promise.all(
        practitionerCodes.map(practitionerCode => 
            getPractitionerFromGPConnectApi(demoServerBaseUrl, practitionerCode)
                .catch(error => console.log(error))
        )
    )
}

const savePractitionersToFile = (practitioners) => {
    fs.writeFileSync('./data/practitioners.json', JSON.stringify(practitioners) , 'utf-8');
    console.log("-- Practitioner Data Saved --")
}

const downloadandSeedPractitioners = (config) => {3
    const {demoServerBaseUrl} = config
    const practitionerCodes = [];
    fs.createReadStream("../Data/PractitionerCodeMap.csv")
        .pipe(csv())
        .on('data', (row) => {
            practitionerCodes.push(row["PROVIDER_PRACTITIONER_CODE"]);
        })
        .on('end', () => {
            console.log('Practitioner CSV file successfully processed');
            console.log("-- Downloading Practitioners Data --")
            return getPractitionersFromGPConnectApi(demoServerBaseUrl, practitionerCodes)
                .then(practitioners => {
                    const existingPractitioners = practitioners.filter(practitionerCode => practitionerCode !== undefined);
                    savePractitionersToFile(existingPractitioners);
                    seedPractitioners(config);
                })
                .catch(console.log)
        });
};

export const setupPractitioners = (config) =>{
    const {updateLocalData} = config;
    if(updateLocalData){
        downloadandSeedPractitioners(config)
    }else{
        seedPractitioners(config)
    }
}