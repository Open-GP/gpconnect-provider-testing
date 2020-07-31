import {getHeaders} from "./demoServerSetup.js";

import csv from "csv-parser";
import fs from "fs";
import axios from "axios";

const seedLocation = (location, testBaseUrl, user, pass) => {
    const body = {
        resourceType: "Parameters",
        parameter: [
            {
                name: "location",
                resource: location
            }
        ]
    };

    axios
        .post(`${testBaseUrl}/Location/$setup`, body,
            {auth: {username: user, password: pass},
                headers: {"Content-Type": "application/json"}})
        .then(result => {
            console.log("Location Success", location.id);
        })
        .catch(err => {
            console.log("Location Error", location.id);
        });
};

const seedLocations = (config) => {
    const {testBaseUrl, user, pass} = config
    const locationData = JSON.parse(fs.readFileSync('./data/locations.json', 'utf-8'))
    console.log("Seeding Location Data:")
    locationData.forEach(location => seedLocation(location, testBaseUrl, user, pass))
}

const getLocationFromGPConnectApi = async (demoServerBaseUrl, locationId) => {

    const config = {
        headers: getHeaders(demoServerBaseUrl, "urn:nhs:names:services:gpconnect:fhir:rest:read:location-1")
    };

    try {
        const result = await axios
            .get(`${demoServerBaseUrl}/Location/${locationId}`, config);
        return result.data;
    }
    catch (err) {
        console.log("error retrieving for:", locationId, err);
    }
};

const getLocationsFromGPConnectApi = (demoServerBaseUrl, locationIds) => {
    return Promise.all(locationIds.map(
        locationId => getLocationFromGPConnectApi(demoServerBaseUrl, locationId)
        .catch(console.log)))
}

const saveLocationsToFile = (locations) => {
    fs.writeFileSync('./data/locations.json', JSON.stringify(locations) , 'utf-8');
    console.log("-- Location Data Saved --")
}

const downloadandSeedLocations = (config) => {
    const {demoServerBaseUrl} = config
    const locationIds = [];
    fs.createReadStream("../Data/LocationLogicalIdentifierMap.csv")
        .pipe(csv())
        .on('data', (row) => {
            locationIds.push(row["LogicalIdentifier"]);
        })
        .on('end', () => {
            console.log("-- Downloading Location Data --")
            return getLocationsFromGPConnectApi(demoServerBaseUrl, locationIds)
                .then(locations => {
                    saveLocationsToFile(locations);
                    seedLocations(config);
                })
                .catch(console.log)
        });    
};


export const setupLocations = (config) =>{
    const {updateLocalData} = config;
    if(updateLocalData){
        downloadandSeedLocations(config)
    }else{
        seedLocations(config)
    }
}

