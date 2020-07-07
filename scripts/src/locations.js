import {getHeaders} from "./demoServerSetup.js";

import csv from "csv-parser";
import fs from "fs";
import axios from "axios";

const retrieveLocation = (demoServerBaseUrl, locationId) => {

    const config = {
        headers: getHeaders(demoServerBaseUrl, "urn:nhs:names:services:gpconnect:fhir:rest:read:location-1")
    };

    return axios
        .get(`${demoServerBaseUrl}/Location/${locationId}`, config)
        .then(result => {
            return result.data;
        })
        .catch(err => {
            console.log("error retrieving for:", locationId, err);
        });
};

const storeLocation = (location, testBaseUrl, user, pass) => {
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

export const setupLocations = (demoServerBaseUrl, testBaseUrl, user, pass) => {
    const locationIds = [];
    fs.createReadStream("../Data/LocationLogicalIdentifierMap.csv")
        .pipe(csv())
        .on('data', (row) => {
            locationIds.push(row["LogicalIdentifier"]);
        })
        .on('end', () => {
            locationIds.forEach(
                locationId => retrieveLocation(demoServerBaseUrl, locationId)
                    .then(location => storeLocation(location, testBaseUrl, user, pass))
                    .catch(console.log)
            )
        });
};
