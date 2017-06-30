﻿@organization
Feature: OrganizationRead

#Set JWT for all tests in the organization tests
#Combine bottom tests into 1 and use scenario outline to test all organizations
#Given I get organization "<Organization>" id and save it as "ORG1ID" is not correct and should be replaced to represent what it does
#Refactor When I get organization "ORG1ID" and use the id to make a get request to the url "Organization" to make its fucntion more clear
#Change URL to have a slash so its clear it a URL

# Add a test validating that all organizations resources should contain a logical identifier

Scenario Outline: Organization Read successful request
	Given I get the Organization for Organization Code "<Organization>"
		And I store the Organization Id
		#Set RR on JWT to <Organization> ???
	Given I configure the default "OrganizationRead" request
	When I make the "OrganizationRead" request
	Then the response status code should indicate success
		And the response should be an Organization resource
		And the returned resource shall contains a logical id
		#Match id requested with
		#Match buisness identifiers that searched with
	Examples:
		| Organization |
		| ORG1         |
		| ORG2         |
		| ORG3         |

#Change the name of the test to be more clear	
Scenario Outline: Organization read invalid request invalid id
	#Remove first step
	Given I get organization "ORG1" id and save it as "ORG1ID"
	Given I am using the default server
		And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:read:organization" interaction
	When I make a GET request for a organization using an invalid id of "<InvalidId>"
	Then the response status code should be "404"
	Examples:
		| InvalidId |
		| 1@        |
		| 9i        |
		| 40-9      |

Scenario Outline: Organization read invalid request invalid URL
	Given I get organization "ORG1" id and save it as "ORG1ID"
	Given I am using the default server
		And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:read:organization" interaction
	When I get organization "ORG1ID" and use the id to make a get request to the url "<InvalidURL>"
	Then the response status code should be "404"
	Examples:
		| InvalidURL    |
		| Organizations |
		| Organization! |
		| Organization2 |

Scenario Outline: Organization read failure due to missing header
	Given I get organization "ORG1" id and save it as "ORG1ID"
	Given I am using the default server
		And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:read:organization" interaction
		And I do not send header "<Header>"
	When I get organization "ORG1ID" and use the id to make a get request to the url "Organization"
	Then the response status code should be "400"
		And the response body should be FHIR JSON
		And the response should be a OperationOutcome resource with error code "BAD_REQUEST"
	Examples:
		| Header            |
		| Ssp-TraceID       |
		| Ssp-From          |
		| Ssp-To            |
		| Ssp-InteractionId |
		| Authorization     |

Scenario Outline: Organization read failure with incorrect interaction id
	Given I get organization "ORG1" id and save it as "ORG1ID"
	Given I am using the default server
		And I am performing the "<interactionId>" interaction
	When I get organization "ORG1ID" and use the id to make a get request to the url "Organization"
	Then the response status code should be "400"
		And the response body should be FHIR JSON
		And the response should be a OperationOutcome resource with error code "BAD_REQUEST"
	Examples:
		| interactionId                                                     |
		| urn:nhs:names:services:gpconnect:fhir:rest:read:practitioner3     |
		| urn:nhs:names:services:gpconnect:fhir:rest:read:practitioners     |
		| urn:nhs:names:services:gpconnect:fhir:operation:gpc.getcarerecord |
		|                                                                   |
		| null                                                              |

#Change scenario name, not descriptive enough
Scenario Outline: 2
	Given I get organization "ORG1" id and save it as "ORG1ID"
	Given I am using the default server
		And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:read:organization" interaction
		And I add the parameter "_format" with the value "<Parameter>"
	When I get organization "ORG1ID" and use the id to make a get request to the url "Organization"
	Then the response status code should indicate success
		And the response body should be FHIR <BodyFormat>
		And the response should be an Organization resource
		#Check for ids and mandatory fields of returned resource
	Examples:
		| Parameter             | BodyFormat |
		| application/json+fhir | JSON       |
		| application/xml+fhir  | XML        |

#Test name requires more detail
Scenario Outline: Organization read accept header and _format
	Given I get organization "ORG2" id and save it as "ORG2ID"
	Given I am using the default server
		And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:read:organization" interaction
		And I set the Accept header to "<Header>"
		And I add the parameter "_format" with the value "<Parameter>"
	When I get organization "ORG2ID" and use the id to make a get request to the url "Organization"
	Then the response status code should indicate success
		And the response body should be FHIR <BodyFormat>
		And the response should be an Organization resource
		And the returned resource shall contains a logical id
		#Check for ids and mandatory fields of returned resource
	Examples:
		| Header                | Parameter             | BodyFormat |
		| application/json+fhir | application/json+fhir | JSON       |
		| application/json+fhir | application/xml+fhir  | XML        |
		| application/xml+fhir  | application/json+fhir | JSON       |
		| application/xml+fhir  | application/xml+fhir  | XML        |

#Add test for just accept header	
Scenario: Conformance profile supports the Organization read operation
	Given I am using the default server
		And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:read:metadata" interaction
	When I make a GET request to "/metadata"
	Then the response status code should indicate success
		And the response body should be FHIR JSON
		And the conformance profile should contain the "Organization" resource with a "read" interaction

Scenario: Organization read check meta data profile and version id
	Given I get organization "ORG1" id and save it as "ORG1ID"
	Given I am using the default server
		And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:read:organization" interaction
	When I get organization "ORG1ID" and use the id to make a get request to the url "Organization"
	Then the response status code should indicate success
		And the response body should be FHIR JSON
		And the response should be an Organization resource
		And the organization resource it should contain meta data profile and version id

Scenario: Organization read organization contains identifier it is valid
	Given I get organization "ORG3" id and save it as "ORG3ID"
	Given I am using the default server
		And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:read:organization" interaction
	When I get organization "ORG3ID" and use the id to make a get request to the url "Organization"
	Then the response status code should indicate success
		And the response body should be FHIR JSON
		And the response should be an Organization resource
		And if the organization resource contains an identifier it is valid
		#Check for ids and mandatory fields of returned resource and valid site / ORG code

Scenario: Organization read organization contains valid partOf element with a valid reference
	Given I get organization "ORG1" id and save it as "ORG1ID"
	Given I am using the default server
		And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:read:organization" interaction
	When I get organization "ORG1ID" and use the id to make a get request to the url "Organization"
	Then the response status code should indicate success
		And the response body should be FHIR JSON
		And the response should be an Organization resource
		#Make step name clearer to show it will resolve url if included
		And if the organization resource contains a partOf reference it is valid

Scenario: Organization read organization contains valid Type element it must contain code system and display
	Given I get organization "ORG2" id and save it as "ORG2ID"
	Given I am using the default server
		And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:read:organization" interaction
	When I get organization "ORG2ID" and use the id to make a get request to the url "Organization"
	Then the response status code should indicate success
		And the response body should be FHIR JSON
		And the response should be an Organization resource
		#Change step name to include further detail
		And if the organization resource contains type it is valid

Scenario: Organization read response should contain ETag header
	Given I get organization "ORG1" id and save it as "ORG1ID"
	Given I am using the default server
		And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:read:organization" interaction
	When I get organization "ORG1ID" and use the id to make a get request to the url "Organization"
	Then the response status code should indicate success
		And the response body should be FHIR JSON
		And the response should be an Organization resource
		And the response should contain the ETag header matching the resource version

#Potentially out of scope, needs verifiying
Scenario: VRead of current resource should return resource
	Given I get organization "ORG3" id and save it as "ORGID"
	Given I am using the default server
		And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:read:organization" interaction
	When I perform a vread for organizaiton "ORGID"
	Then the response status code should indicate success
		And the response body should be FHIR JSON
		And the response should be an Organization resource

Scenario: VRead of non existant version should return an error
	Given I get organization "ORG2" id and save it as "storedOrganization"
	Given I am using the default server
		And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:read:organization" interaction
	When I perform an organization vread with version "NotARealVersionId" for organization stored against key "storedOrganization"
	Then the response status code should be "404"
		And the response body should be FHIR JSON
		And the response should be a OperationOutcome resource

@ignore
Scenario: If-None-Match read organization on a matching version
	# Need to check if this is supported

@ignore
Scenario: If-None-Match read organization on a non matching version
	# Need to check if this is supported

@Manual
@ignore
Scenario: If provider supports versioning test that once a resource is updated that the old version can be retrieved

@Manual
@ignore
Scenario: Check that the optional fields are populated in the Organization resource if they are available in the provider system
	# name - Organization Name
	# telecom - Telecom information for the Organization, can be multiple instances for different types.
	# address - Address(s) for the Organization.
	# contact - the details of a person, telecom or address for contact with the organizaiton.