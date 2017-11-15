﻿@practitioner
Feature: PractitionerSearch

# Common
# JWT is hard coded value and it should probably be considered what JWT requested resource should be, organization but which?
# Compress successful tests into one possibly // For clarity it may be better to keep successful seperated as if one failes it is easier to see where the problem is

Scenario Outline: Practitioner search success and validate the practitioner identifiers
	Given I configure the default "PractitionerSearch" request		
		And I add a Practitioner Identifier parameter with SDS User Id System and Value "<Value>"
	When I make the "PractitionerSearch" request
	Then the response status code should indicate success
		And the response bundle should contain "<EntrySize>" entries
		And the response should be a Bundle resource of type "searchset" 
		And the Practitioner Id should be valid
		And the Practitioner Identifiers should be valid fixed values
		And the Practitioner SDS User Identifier should be valid for Value "<Value>"
		And the Practitioner SDS Role Profile Identifier should be valid for "<RoleSize>" Role Profile Identifiers
	Examples:
		| Value         | EntrySize | RoleSize |
		| practitioner1 | 1         | 0        |
		| practitioner2 | 1         | 1        |
		| practitioner3 | 1         | 2        |
		| practitioner4 | 0         | 0        |
		| practitioner5 | 2         | 3        |

Scenario Outline: Practitioner search with failure due to invalid identifier
	Given I configure the default "PractitionerSearch" request
		And I add a Practitioner Identifier parameter with System "<System>" and Value "<Value>"
	When I make the "PractitionerSearch" request
	Then the response status code should be "422"
		And the response should be a OperationOutcome resource with error code "INVALID_PARAMETER"
	Examples:
		| System                                     | Value         |
		| https://fhir.nhs.uk/Id/sds-user-id         |               |
		|                                            | practitioner2 |

Scenario: Practitioner search without the identifier parameter
	Given I configure the default "PractitionerSearch" request
	When I make the "PractitionerSearch" request
	Then the response status code should be "400"
		And the response body should be FHIR JSON
		And the response should be a OperationOutcome resource with error code "BAD_REQUEST"

Scenario Outline: Practitioner search where identifier contains the incorrect case or spelling
	Given I configure the default "PractitionerSearch" request
		And I add a Practitioner "<ParameterName>" parameter with System "https://fhir.nhs.uk/Id/sds-user-id" and Value "practitioner2"
	When I make the "PractitionerSearch" request
	Then the response status code should be "400"
		And the response should be a OperationOutcome resource with error code "BAD_REQUEST"
	Examples:
		| ParameterName |
		| Identifier    |

Scenario Outline: Practitioner search testing paramater validity before adding identifier
	Given I configure the default "PractitionerSearch" request
		And I add the parameter "<Param1Name>" with the value "<Param1Value>"
		And I add a Practitioner Identifier parameter with SDS User Id System and Value "practitioner2"
	When I make the "PractitionerSearch" request
	Then the response status code should indicate success
		And the response body should be FHIR <BodyFormat>
		And the response should be a Bundle resource of type "searchset"
		And the Practitioner Identifiers should be valid fixed values
		And the Practitioner PractitionerRoles Roles should be valid
		And the Practitioner Name should be valid
		And the Practitioner should exclude disallowed elements
		And the Practitioner nhsCommunication should be valid
		And the Practitioner PractitionerRoles ManagingOrganization should be valid and resolvable
	Examples:
		| Param1Name | Param1Value           | BodyFormat |
		| _format    | application/json+fhir | JSON       |
		| _format    | application/xml+fhir  | XML        |

Scenario Outline: Practitioner search testing paramater validity after adding identifier
	Given I configure the default "PractitionerSearch" request
		And I add a Practitioner Identifier parameter with SDS User Id System and Value "practitioner2"
		And I add the parameter "<Param1Name>" with the value "<Param1Value>"
	When I make the "PractitionerSearch" request
	Then the response status code should indicate success
		And the response body should be FHIR <BodyFormat>
		And the response should be a Bundle resource of type "searchset"
		And the Practitioner Identifiers should be valid fixed values
		And the Practitioner PractitionerRoles Roles should be valid
		And the Practitioner Name should be valid
		And the Practitioner should exclude disallowed elements
		And the Practitioner nhsCommunication should be valid
		And the Practitioner PractitionerRoles ManagingOrganization should be valid and resolvable
	Examples:
		| Param1Name | Param1Value           | BodyFormat |
		| _format    | application/json+fhir | JSON       |
		| _format    | application/xml+fhir  | XML        |


Scenario Outline: Practitioner search add accept header to request and check for correct response format
	Given I configure the default "PractitionerSearch" request
		And I add a Practitioner Identifier parameter with SDS User Id System and Value "practitioner2"
		And I set the Accept header to "<Header>"
	When I make the "PractitionerSearch" request
	Then the response status code should indicate success
		And the response body should be FHIR <BodyFormat>
		And the response should be a Bundle resource of type "searchset"
		And the Practitioner Identifiers should be valid fixed values
		And the Practitioner PractitionerRoles Roles should be valid
		And the Practitioner Name should be valid
		And the Practitioner should exclude disallowed elements
		And the Practitioner nhsCommunication should be valid
		And the Practitioner PractitionerRoles ManagingOrganization should be valid and resolvable
	Examples:
		| Header                | BodyFormat |
		| application/json+fhir | JSON       |
		| application/xml+fhir  | XML        |

Scenario Outline: Practitioner search add accept header and _format parameter to the request and check for correct response format
	Given I configure the default "PractitionerSearch" request
		And I add a Practitioner Identifier parameter with SDS User Id System and Value "practitioner2"
		And I set the Accept header to "<Header>"
		And I add a Format parameter with the Value "<Parameter>"
	When I make the "PractitionerSearch" request
	Then the response status code should indicate success
		And the response body should be FHIR <BodyFormat>
		And the response should be a Bundle resource of type "searchset"
		And the Practitioner Identifiers should be valid fixed values
		And the Practitioner PractitionerRoles Roles should be valid
		And the Practitioner Name should be valid
		And the Practitioner should exclude disallowed elements
		And the Practitioner nhsCommunication should be valid
		And the Practitioner PractitionerRoles ManagingOrganization should be valid and resolvable
	Examples:
		| Header                | Parameter             | BodyFormat |
		| application/json+fhir | application/json+fhir | JSON       |
		| application/json+fhir | application/xml+fhir  | XML        |
		| application/xml+fhir  | application/json+fhir | JSON       |
		| application/xml+fhir  | application/xml+fhir  | XML        |

Scenario Outline: Practitioner search failure due to missing header
	Given I configure the default "PractitionerSearch" request
		And I add a Practitioner Identifier parameter with SDS User Id System and Value "practitioner2"
	When I make the "PractitionerSearch" request with missing Header "<Header>"
	Then the response status code should be "400"
		And the response should be a OperationOutcome resource with error code "BAD_REQUEST"
	Examples:
		| Header            |
		| Ssp-TraceID       |
		| Ssp-From          |
		| Ssp-To            |
		| Ssp-InteractionId |
		| Authorization     |

Scenario Outline: Practitioner search failure due to invalid interactionId
	Given I configure the default "PractitionerSearch" request
		And I set the Interaction Id header to "<InteractionId>"
		And I add a Practitioner Identifier parameter with SDS User Id System and Value "practitioner2"
	When I make the "PractitionerSearch" request
	Then the response status code should be "400"
		And the response should be a OperationOutcome resource with error code "BAD_REQUEST"
	Examples:
		| InteractionId                                                     |
		| urn:nhs:names:services:gpconnect:fhir:operation:gpc.getcarerecord |
		| InvalidInteractionId                                              |
		|                                                                   |

Scenario: Practitioner search multiple practitioners contains metadata and populated fields
	Given I configure the default "PractitionerSearch" request
		And I add a Practitioner Identifier parameter with SDS User Id System and Value "practitioner2"
	When I make the "PractitionerSearch" request
	Then the response status code should indicate success
		And the response should be a Bundle resource of type "searchset"
		And the Practitioner Metadata should be valid

Scenario: Practitioner search returns back user with name element
	Given I configure the default "PractitionerSearch" request
		And I add a Practitioner Identifier parameter with SDS User Id System and Value "practitioner2"
	When I make the "PractitionerSearch" request
	Then the response status code should indicate success
		And the response should be a Bundle resource of type "searchset"
		And the Practitioner Name should be valid

Scenario: Practitioner search returns practitioner role element with valid parameters
	Given I configure the default "PractitionerSearch" request
		  And I add a Practitioner Identifier parameter with SDS User Id System and Value "practitioner2"
	When I make the "PractitionerSearch" request
	Then the response status code should indicate success
		And the response should be a Bundle resource of type "searchset"
		And the Practitioner PractitionerRoles Roles should be valid
		And the Practitioner PractitionerRoles ManagingOrganization should be valid and resolvable

Scenario: Practitioner search should not contain photo or qualification information
	Given I configure the default "PractitionerSearch" request
		And I add a Practitioner Identifier parameter with SDS User Id System and Value "practitioner2"
	When I make the "PractitionerSearch" request
	Then the response status code should indicate success
		And the response should be a Bundle resource of type "searchset"
		And the Practitioner should exclude disallowed elements

Scenario: Practitioner search contains nhsCommunication element
	Given I configure the default "PractitionerSearch" request
		And I add a Practitioner Identifier parameter with SDS User Id System and Value "practitioner2"
	When I make the "PractitionerSearch" request
	Then the response status code should indicate success
		And the response should be a Bundle resource of type "searchset"
		And the Practitioner nhsCommunication should be valid

Scenario: Practitioner search multiple identifier parameter failure
	Given I configure the default "PractitionerSearch" request
		And I add a Practitioner Identifier parameter with SDS User Id System and Value "practitioner2"
		And I add a Practitioner Identifier parameter with SDS User Id System and Value "practitioner2"
	When I make the "PractitionerSearch" request
	Then the response status code should be "400"
		And the response should be a OperationOutcome resource with error code "BAD_REQUEST"

Scenario: Practitioner search multiple multiple identifiers for different practitioner parameter failure
	Given I configure the default "PractitionerSearch" request
		And I add a Practitioner Identifier parameter with SDS User Id System and Value "practitioner1"
		And I add a Practitioner Identifier parameter with SDS User Id System and Value "practitioner2"
	When I make the "PractitionerSearch" request
	Then the response status code should be "400"
		And the response should be a OperationOutcome resource with error code "BAD_REQUEST"

Scenario: Practitioner search include count and sort parameters
	Given I configure the default "PractitionerSearch" request		
		And I add a Practitioner Identifier parameter with SDS User Id System and Value "practitioner1"
		And I add the parameter "_sort" with the value "practitioner.coding"
		And I add the parameter "_count" with the value "1"
	When I make the "PractitionerSearch" request
	Then the response status code should indicate success
		And the response bundle should contain "1" entries
		And the response should be a Bundle resource of type "searchset" 

Scenario: Conformance profile supports the Practitioner search operation
	Given I configure the default "MetadataRead" request
	When I make the "MetadataRead" request
	Then the response status code should indicate success
		And the Conformance REST Resources should contain the "Practitioner" Resource with the "SearchType" Interaction

Scenario:Practitioner search valid response check caching headers exist
	Given I configure the default "PractitionerSearch" request		
		And I add a Practitioner Identifier parameter with SDS User Id System and Value "practitioner1"
	When I make the "PractitionerSearch" request
	Then the response status code should indicate success
		And the response should be a Bundle resource of type "searchset" 
		And the required cacheing headers should be present in the response

Scenario:Practitioner search invalid response check caching headers exist
	Given I configure the default "PractitionerSearch" request
		And I set the Interaction Id header to "urn:nhs:names:services:gpconnect:fhir:operation:gpc.getcarerecord"
		And I add a Practitioner Identifier parameter with SDS User Id System and Value "practitioner2"
	When I make the "PractitionerSearch" request
	Then the response status code should be "400"
		And the response should be a OperationOutcome resource with error code "BAD_REQUEST"
		And the required cacheing headers should be present in the response
	