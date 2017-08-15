﻿@security
Feature: Security

#These tests expect some Apache/nginx specific http errors 495, 496 - need to consider providers not using Apache/nginx.

Scenario: Security - non ssl request
	Given I configure the default "GpcGetCareRecord" request
		And I am not using the SSP
		And I am not using TLS Connection
		And I am connecting to server on port "80"
		And I set the JWT Requested Record to the NHS Number for "patient2"
		And I add an NHS Number parameter for "patient2"		
		And I add a Record Section parameter for "SUM"
	When I make the "GpcGetCareRecord" request
	Then the response status code should indicate failure
		And the response should be a OperationOutcome resource

Scenario: Security - valid client certificate
	Given I configure the default "GpcGetCareRecord" request
		And I am not using the SSP
		And I am using the SSP client certificate
		And I set the JWT Requested Record to the NHS Number for "patient2"
		And I add an NHS Number parameter for "patient2"		
		And I add a Record Section parameter for "SUM"
	When I make the "GpcGetCareRecord" request
	Then the response status code should indicate success
		And the response should be a Bundle resource of type "searchset"

Scenario: Security - client certificate invalid FQDN
	Given I configure the default "GpcGetCareRecord" request
		And I am not using the SSP
		And I am using the SSP client certificate with invalid FQDN
		And I set the JWT Requested Record to the NHS Number for "patient2"
		And I add an NHS Number parameter for "patient2"		
		And I add a Record Section parameter for "SUM"
	When I make the "GpcGetCareRecord" request
	Then the response status code should be "495"
		And the response should be a OperationOutcome resource

Scenario: Security - client certificate not issued by the Spine CA
	Given I configure the default "GpcGetCareRecord" request
		And I am not using the SSP
		And I am using the SSP client certificate not signed by Spine CA
		And I set the JWT Requested Record to the NHS Number for "patient2"
		And I add an NHS Number parameter for "patient2"		
		And I add a Record Section parameter for "SUM"
	When I make the "GpcGetCareRecord" request
	Then the response status code should be "495"
		And the response should be a OperationOutcome resource

Scenario: Security - client certificate revoked
	Given I configure the default "GpcGetCareRecord" request
		And I am not using the SSP
		And I am using the SSP client certificate which has been revoked
		And I set the JWT Requested Record to the NHS Number for "patient2"
		And I add an NHS Number parameter for "patient2"		
		And I add a Record Section parameter for "SUM"
	When I make the "GpcGetCareRecord" request
	Then the response status code should be "495"
		And the response should be a OperationOutcome resource

Scenario: Security - client certificate out of date
	Given I configure the default "GpcGetCareRecord" request
		And I am not using the SSP
		And I am using the SSP client certificate which is out of date
		And I set the JWT Requested Record to the NHS Number for "patient2"
		And I add an NHS Number parameter for "patient2"		
		And I add a Record Section parameter for "SUM"
	When I make the "GpcGetCareRecord" request
	Then the response status code should be "495"
		And the response should be a OperationOutcome resource

Scenario: Security - no client certificate included in request
	Given I configure the default "GpcGetCareRecord" request
		And I am not using the SSP
		And I am not using a client certificate
		And I set the JWT Requested Record to the NHS Number for "patient2"
		And I add an NHS Number parameter for "patient2"		
		And I add a Record Section parameter for "SUM"
	When I make the "GpcGetCareRecord" request
	Then the response status code should be "496"
		And the response should be a OperationOutcome resource

Scenario Outline: Security - Connect with valid Cipher
	Given I configure the default "MetadataRead" cURL request
		And I am not using the SSP
		And I am using the SSP client certificate
		And I set the Cipher to "<Cipher>"
	When I make the "MetadataRead" cURL request
	Then the cURL Code should be "Ok"
		And the Response Resource should be a Conformance
	Examples: 
	| Cipher                      |
	| ECDHE-RSA-AES128-GCM-SHA256 |
	| ECDHE-RSA-AES256-GCM-SHA384 |
	| ECDHE-RSA-AES256-SHA384     |
	| ECDHE-RSA-AES256-SHA        |
	| DHE-RSA-AES128-GCM-SHA256   |
	| DHE-RSA-AES256-GCM-SHA384   |
	| DHE-RSA-AES256-SHA256       |
	| DHE-RSA-AES256-SHA          |

Scenario: Security - Connect with invalid nonexistent Cipher
	Given I configure the default "MetadataRead" cURL request
		And I am not using the SSP
		And I am using the SSP client certificate
		And I set the Cipher to "ABC-DEF"		
	When I make the "MetadataRead" cURL request
	Then the cURL Code should be "SslCipher"

Scenario: Security - Connect with invalid insecure Cipher
	Given I configure the default "MetadataRead" cURL request
		And I am not using the SSP
		And I am using the SSP client certificate
		And I set the Cipher to "NULL-MD5"
	When I make the "MetadataRead" cURL request
	Then the cURL Code should be "SslConnectError"

Scenario: Security - Connect with invalid secure Cipher
	Given I configure the default "MetadataRead" cURL request
		And I am not using the SSP
		And I am using the SSP client certificate
		And I set the Cipher to "AES128-SHA256"
	When I make the "MetadataRead" cURL request
	Then the cURL Code should be "SslConnectError"