﻿@http
Feature: Http

Background:
	Given I have the following patient records
		| Id                      | NHSNumber  |
		| PWTP2                   | 9990049416 |
		| PWTP3                   | 9990049424 |
		| patientNotInSystem      | 9999999999 |
		| patientNoSharingConsent | 9476719958 |

Scenario: Http Perform a successful GET request
	Given I am using server "fhirtest.uhn.ca" on port "80"
	And I am not using TLS Connection
	And I am not using the spine proxy server
	And I set base URL to "/baseDstu2"
	And I am using "application/json+fhir" to communicate with the server
	When I make a GET request to "/metadata"
	Then the response status code should indicate success
	And the response body should be FHIR JSON
	And the JSON value "resourceType" should be "Conformance"

Scenario: Http GET from invalid endpoint
	Given I am using the default server
	And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:read:metadata" interaction
	When I make a GET request to "/metadatas"
	Then the response status code should indicate failure

Scenario: Http POST to invalid endpoint
	Given I am using the default server
	And I am performing the "urn:nhs:names:services:gpconnect:fhir:operation:gpc.registerpatient" interaction
	When I make a POST request to "/Patients"
	Then the response status code should indicate failure

Scenario: Http PUT to invalid endpoint
	Given I am using the default server
	And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:update:appointment" interaction
	When I make a PUT request to "/Appointments/1"
	Then the response status code should indicate failure

Scenario: Http PATCH to valid endpoint
	Given I am using the default server
	And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:read:metadata" interaction
	When I make a PATCH request to "/metadata"
	Then the response status code should indicate failure

Scenario: Http DELETE to valid endpoint
	Given I am using the default server
	And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:read:metadata" interaction
	When I make a DELETE request to "/metadata"
	Then the response status code should indicate failure

Scenario: Http OPTIONS to valid endpoint
	Given I am using the default server
	And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:read:metadata" interaction
	When I make a OPTIONS request to "/metadata"
	Then the response status code should indicate failure

Scenario: Http incorrect case on url fhir resource
	Given I am using the default server
	And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:read:metadata" interaction
	When I make a OPTIONS request to "/Metadata"
	Then the response status code should indicate failure

Scenario: Http operation incorrect case
	Given I am using the default server
	And I am performing the "urn:nhs:names:services:gpconnect:fhir:operation:gpc.getcarerecord" interaction
	And I author a request for the "SUM" care record section for config patient "PWTP2"
	When I request the FHIR "gpc.getCareRecord" Patient Type operation
	Then the response status code should indicate failure

@ignore
Scenario: Allow and audit additional http headers

