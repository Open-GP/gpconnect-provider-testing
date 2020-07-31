import {setupPatients} from "./src/patients.js";
import {setupLocations} from "./src/locations.js";
import {setupPractitioners} from "./src/practitioners.js";

const demoServerBaseUrl = "https://orange.testlab.nhs.uk/gpconnect-demonstrator/v1/fhir";
const testBaseUrl = process.env.TEST_BASE_URL || "http://localhost:8080/openmrs/ms/gpconnect/gpconnectServlet";
const user = process.env.TEST_USERNAME;
const pass = process.env.PASS;
const updateLocalData = (process.env.UPDATE_LOCAL_DATA === 'true');

const config = {demoServerBaseUrl, testBaseUrl, user, pass, updateLocalData}

setupPatients(config);
setupLocations(config);
setupPractitioners(config);