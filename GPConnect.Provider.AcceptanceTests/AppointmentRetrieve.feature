﻿Feature: AppointmentRetrieve

Background:
	Given I have the test patient codes
	Given I have the test ods codes

Scenario: Appointment retrieve success valid id where appointment resource returned is not required
	Given I am using the default server
		And I perform a patient search for patient "patient12NoAppointments" and store the first returned resources against key "tom"
	Given I am using the default server
		And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:search:patient_appointments" interaction
	When I search for "tom" from the list of patients and make a get request for their appointments
	Then the response status code should indicate success
		And the response body should be FHIR JSON
		And the response should be a Bundle resource of type "searchset"
		And there are zero appointment resources

Scenario Outline: Appointment retrieve success valid id where single appointment resource should be returned
Given I find or create "1" appointments for patient "<patient>" at organization "ORG1" and save bundle of appintment resources to "Patient1AppointmentsInBundle"
	Given I am using the default server
		And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:search:patient_appointments" interaction
	When I search for "<patient>" and make a get request for their appointments
	Then the response status code should indicate success
		And the response body should be FHIR JSON
		And the response should be a Bundle resource of type "searchset"
	Examples:
		| patient  |
		| patient1 |
		| patient2 |
		| patient3 |

Scenario Outline: Appointment retrieve multiple appointment retrived
Given I find or create "2" appointments for patient "<patient>" at organization "ORG1" and save bundle of appintment resources to "Patient1AppointmentsInBundle"
	Given I am using the default server
		And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:search:patient_appointments" interaction
	When I search for "<patient>" and make a get request for their appointments
	Then the response status code should indicate success
		And the response body should be FHIR JSON
		And the response should be a Bundle resource of type "searchset"
	Examples:
		| patient  |
		| patient4 |
		| patient5 |
		| patient6 |
		
Scenario Outline: Appointment retrieve fail due to invalid patient logical id
	Given I am using the default server
		And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:search:patient_appointments" interaction
	When I make a GET request to "/Patient/<id>/Appointment"
	Then the response status code should be "404"
		And the response body should be FHIR JSON
		And the response should be a OperationOutcome resource
	Examples:
		| id  |
		| **  |
		| dd  |
		|     |
		| null|
	
Scenario: Appointment retrieve book appointment then request appointment and check it is returned
	Given I create "1" appointments for patient "patient1" at organization "ORG1" and save bundle of appintment resources to "Patient1AppointmentsInBundle"
	Given I am using the default server
		And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:search:patient_appointments" interaction
	When I search for "patient1" and request the most recently booked appointment
	Then the response status code should indicate success
		And the response body should be FHIR JSON
		And the response should be a Bundle resource of type "searchset"
		And the response total should be at least 1
	
Scenario Outline: Appointment retrieve send request with date variations which are invalid
	Given I find or create "1" appointments for patient "patient1" at organization "ORG1" and save bundle of appintment resources to "Patient1AppointmentsInBundle"
	Given I am using the default server
		And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:search:patient_appointments" interaction
	When I search for "patient1" and make a get request for their appointments searching with the date "<startDate>"
	Then the response status code should indicate failure
		And the response body should be FHIR JSON
		And the response should be a OperationOutcome resource
	Examples:
		| startDate                 |
		| 16-02-2016                |
		| 16/02/2016                |
		| 99-99-99999               |
		| 99999                     |
		| 201                       |
		| 2016-13                   |
		| 2016-13-14                |
		| 2016-13-08T09:22:16       |
		| 2016-13-08T23:59:59+00:00 |
		| 2016-08-05T08:16          |
		| 2016-08-                  |
		| 2016-08-05 08:16:07       |


Scenario: Appointment retrieve send request and find request using equal to prefix
	Given I create "1" appointments for patient "patient1" at organization "ORG1" and save bundle of appintment resources to "Patient1AppointmentsInBundle"
		Given I am using the default server
		And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:search:patient_appointments" interaction
	When I search for "patient1" and make a get request for their appointments with the date "startDate" and prefix "eq"
	Then the response status code should indicate success
		And the response body should be FHIR JSON
		And the response should be a Bundle resource of type "searchset"
		And the response total should be 1
	   
Scenario Outline: Appointment retrieve send request with date variations and greater than and less than prefix
	Given I create "1" appointments for patient "patient1" at organization "ORG1" and save bundle of appintment resources to "Patient1AppointmentsInBundle"
	Given I am using the default server
		And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:search:patient_appointments" interaction
	When I search for "patient1" and make a get request for their appointments with the date "<startDate>" and prefix "<prefix>"
	Then the response status code should indicate success
		And the response body should be FHIR JSON
		And the response should be a Bundle resource of type "searchset"
		And the response total should be at least 1
	Examples:
		| startDate                 | prefix |
		| 2014                      | gt     |
		| 2014-02                   | gt     |
		| 2014-10-05                | gt     |
		| 2014-05                   | gt     |
		| 2014-05-01T11:08:32       | gt     |
		| 2015-10-23T11:08:32+00:00 | gt     |
		| 2044                      | lt     |
		| 2044-02                   | lt     |
		| 2044-10-05                | lt     |
		| 2044-05                   | lt     |
		| 2044-05-01T11:08:32       | lt     |
		| 2044-10-23T11:08:32+00:00 | lt     |
		| 2014                      | ge     |
		| 2014-02                   | ge     |
		| 2014-10-05                | ge     |
		| 2014-05                   | ge     |
		| 2014-05-01T11:08:32       | ge     |
		| 2015-10-23T11:08:32+00:00 | ge     |
		| 2044                      | le     |
		| 2044-02                   | le     |
		| 2044-10-05                | le     |
		| 2044-05                   | le     |
		| 2044-05-01T11:08:32       | le     |
		| 2044-10-23T11:08:32+00:00 | le     |


 ##Unknown comparator: NOT_EQUAL
@ignore
Scenario Outline: Appointment retrieve send request with date variations and not equal to prefix
	Given I create "1" appointments for patient "patient1" at organization "ORG1" and save bundle of appintment resources to "Patient1AppointmentsInBundle"
	Given I am using the default server
		And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:search:patient_appointments" interaction
	When I search for "patient1" and make a eqget request for their appointments with the date "startDate" and prefix "<prefix>"
	Then the response status code should indicate success
		And the response body should be FHIR JSON
		And the response should be a Bundle resource of type "searchset"
		And the response total should be at least 1
	Examples:
		| startDate                 | prefix |
		| 2013                      | ne     |
		| 2013-02                   | ne     |
		| 2013-10-05                | ne     |
		| 2013-05                   | ne     |
		| 2013-05-01T11:08:32       | ne     |
		| 2013-10-23T11:08:32+00:00 | ne     |
	
##"Unknown comparator: STARTS_AFTER"
@ignore
Scenario Outline: Appointment retrieve send request with date variations and starts after to prefix
	Given I create "1" appointments for patient "patient1" at organization "ORG1" and save bundle of appintment resources to "Patient1AppointmentsInBundle"
	Given I am using the default server
		And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:search:patient_appointments" interaction
	When I search for "patient1" and make a get request for their appointments with the date "startDate" and prefix "<prefix>"
	Then the response status code should indicate success
		And the response body should be FHIR JSON
		And the response should be a Bundle resource of type "searchset"
		And the response total should be at least 1
	Examples:
		| startDate                 | prefix |
		| 2013                      | sa     |
		| 2013-02                   | sa     |
		| 2013-10-05                | sa     |
		| 2013-05                   | sa     |
		| 2013-05-01T11:08:32       | sa     |
		| 2013-10-23T11:08:32+00:00 | sa     |
##Unknown comparator: ENDS_BEFORE"
@ignore
Scenario Outline: Appointment retrieve send request with date variations and ends before prefix
	Given I create "1" appointments for patient "patient1" at organization "ORG1" and save bundle of appintment resources to "Patient1AppointmentsInBundle"
	Given I am using the default server
		And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:search:patient_appointments" interaction
	When I search for "patient1" and make a get request for their appointments with the date "startDate" and prefix "<prefix>"
	Then the response status code should indicate success
		And the response body should be FHIR JSON
		And the response should be a Bundle resource of type "searchset"
		And the response total should be at least 1
	Examples:
		| startDate                 | prefix |
		| 2013                      | eb     |
		| 2013-02                   | eb     |
		| 2013-10-05                | eb     |
		| 2013-05                   | eb     |
		| 2013-05-01T11:08:32       | eb     |
		| 2013-10-23T11:08:32+00:00 | eb     |
##"Unknown comparator: APPROXIMATE"
@ignore
Scenario Outline: Appointment retrieve send request with date variations and approximately prefix
	Given I create "1" appointments for patient "patient1" at organization "ORG1" and save bundle of appintment resources to "Patient1AppointmentsInBundle"
	Given I am using the default server
		And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:search:patient_appointments" interaction
	When I search for "patient1" and make a get request for their appointments with the date "startDate" and prefix "<prefix>"
	Then the response status code should indicate success
		And the response body should be FHIR JSON
		And the response should be a Bundle resource of type "searchset"
		And the response total should be at least 1
	Examples:
		| startDate                 | prefix |
		| 2013                      | ap     |
		| 2013-02                   | ap     |
		| 2013-10-05                | ap     |
		| 2013-05                   | ap     |
		| 2013-05-01T11:08:32       | ap     |
		| 2013-10-23T11:08:32+00:00 | ap     |
	

Scenario Outline: Appointment retrieve failure due to missing header
	Given I find or create "1" appointments for patient "patient1" at organization "ORG1" and save bundle of appintment resources to "Patient1AppointmentsInBundle"
	Given I am using the default server
		And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:search:patient_appointments" interaction
		And I do not send header "<Header>"
	When I search for "patient1" and make a get request for their appointments
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

Scenario Outline: Appointment retrieve interaction id incorrect fail
	Given I find or create "1" appointments for patient "patient1" at organization "ORG1" and save bundle of appintment resources to "Patient1AppointmentsInBundle"
    Given I am using the default server
        And I am performing the "<interactionId>" interaction
    When I search for "patient1" and make a get request for their appointments
    Then the response status code should be "400"
        And the response body should be FHIR JSON
		And the response should be a OperationOutcome resource with error code "BAD_REQUEST"
    Examples:
       | id | interactionId                                                     |
       | 1  | urn:nhs:names:services:gpconnect:fhir:rest:search:organization    |
       | 1  | urn:nhs:names:services:gpconnect:fhir:operation:gpc.getcarerecord |
       | 1  |                                                                   |
       | 1  | null                                                              |
	
Scenario Outline: Appointment retrieve accept header and _format parameter
    Given I find or create "1" appointments for patient "patient1" at organization "ORG1" and save bundle of appintment resources to "Patient1AppointmentsInBundle"
	Given I am using the default server
        And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:search:patient_appointments" interaction
        And I set the Accept header to "<Header>"
        And I add the parameter "_format" with the value "<Parameter>"
    When I search for "patient1" and make a get request for their appointments
    Then the response status code should indicate success
        And the response body should be FHIR <BodyFormat>
        And the response should be a Bundle resource of type "searchset"
    Examples:
       | Header                | Parameter             | BodyFormat |
       | application/json+fhir | application/json+fhir | JSON       |
       | application/json+fhir | application/xml+fhir  | XML        |
       | application/xml+fhir  | application/json+fhir | JSON       |
       | application/xml+fhir  | application/xml+fhir  | XML        |  

Scenario Outline: Appointment retrieve accept header
	Given I find or create "1" appointments for patient "patient1" at organization "ORG1" and save bundle of appintment resources to "Patient1AppointmentsInBundle"
	Given I am using the default server
		And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:search:patient_appointments" interaction
		And I set the Accept header to "<Header>"
	When I search for "patient1" and make a get request for their appointments
	Then the response status code should indicate success
		And the response body should be FHIR <BodyFormat>
		And the response should be a Bundle resource of type "searchset"
	Examples:
		| Header                | BodyFormat |
		| application/json+fhir | JSON       |
		| application/xml+fhir  | XML        |

Scenario Outline: Appointment retrieve _format parameter only
	Given I find or create "1" appointments for patient "patient1" at organization "ORG1" and save bundle of appintment resources to "Patient1AppointmentsInBundle"
	Given I am using the default server
		And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:search:patient_appointments" interaction
        And I add the parameter "_format" with the value "<Parameter>"
	When I search for "patient1" and make a get request for their appointments
	Then the response status code should indicate success
		And the response body should be FHIR <BodyFormat>
		And the response should be a Bundle resource of type "searchset"
    Examples:
        | Parameter             | BodyFormat |
        | application/json+fhir | JSON       |
        | application/xml+fhir  | XML        |

Scenario: Appointment retrieve bundle resource with empty appointment resource
	Given I am using the default server
		And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:search:patient_appointments" interaction
	When I search for "patientNoAppointments" and make a get request for their appointments
	Then the response status code should indicate success
		And the response body should be FHIR JSON
        And the response should be a Bundle resource of type "searchset"
		And there are zero appointment resources

Scenario: Appointment retrieve appointment which contains all mandatory resources
	Given I find or create "1" appointments for patient "patient1" at organization "ORG1" and save bundle of appintment resources to "Patient1AppointmentsInBundle"
	Given I am using the default server
		And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:search:patient_appointments" interaction
	When I search for "patient1" and make a get request for their appointments
	Then the response status code should indicate success
		And the response body should be FHIR JSON
        And the response should be a Bundle resource of type "searchset"
		And the bundle of appointments should all contain a single status element
		And the bundle of appointments should all contain a single start element
		And the bundle of appointments should all contain a single end element
		And the bundle of appointments should all contain at least one slot reference
		And the bundle of appointments should all contain at least one participant
	
Scenario: Appointment retrieve bundle resource must contain status with valid value
	Given I find or create "1" appointments for patient "patient1" at organization "ORG1" and save bundle of appintment resources to "Patient1AppointmentsInBundle"
	Given I am using the default server
		And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:search:patient_appointments" interaction
	When I search for "patient1" and make a get request for their appointments
	Then the response status code should indicate success
		And the response body should be FHIR JSON
        And the response should be a Bundle resource of type "searchset"
		And the appointment resource within the bundle should contain a single status element
		And the appointment status element should be valid


Scenario: Appointment retrieve bundle resource must contain participant with type or actor present
	Given I find or create "1" appointments for patient "patient1" at organization "ORG1" and save bundle of appintment resources to "Patient1AppointmentsInBundle"
	Given I am using the default server
		And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:search:patient_appointments" interaction
	When I search for "patient1" and make a get request for their appointments
	Then the response status code should indicate success
		And the response body should be FHIR JSON
		And the response should be a Bundle resource of type "searchset"
	Then if appointment is present the single or multiple participant must contain a type or actor


Scenario: Appointment retrieve bundle participant actor contains valid references
	Given I find or create "1" appointments for patient "patient1" at organization "ORG1" and save bundle of appintment resources to "Patient1AppointmentsInBundle"
	Given I am using the default server
		And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:search:patient_appointments" interaction
	When I search for "patient1" and make a get request for their appointments
	Then the response status code should indicate success
		And the response body should be FHIR JSON
		And if actor returns a practitioner resource the resource is valid
		And if actor returns a location resource the resource is valid
		And if actor returns a patient resource the resource is valid

Scenario: Appointment retrieve bundle participant type contains valid references
	Given I find or create "1" appointments for patient "patient1" at organization "ORG1" and save bundle of appintment resources to "Patient1AppointmentsInBundle"
	Given I am using the default server
		And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:search:patient_appointments" interaction
	When I search for "patient1" and make a get request for their appointments
	Then the response status code should indicate success
		And the response body should be FHIR JSON
		And the response should be a Bundle resource of type "searchset"
		And if the appointment participant contains a type is should have a valid system and code

Scenario: Appointment retrieve bundle contains appointment with identifer with correct system and value
	Given I find or create "1" appointments for patient "patient1" at organization "ORG1" and save bundle of appintment resources to "Patient1AppointmentsInBundle"
	Given I am using the default server
		And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:search:patient_appointments" interaction
	When I search for "patient1" and make a get request for their appointments
	Then the response status code should indicate success
		And the response body should be FHIR JSON
		And if the appointment resource contains an identifier it contains a valid system and value

Scenario: Appointment retrieve appointment response should contain meta data profile and version id
		Given I find or create "1" appointments for patient "patient1" at organization "ORG1" and save bundle of appintment resources to "Patient1AppointmentsInBundle"
	Given I am using the default server
		And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:search:patient_appointments" interaction
	When I search for "patient1" and make a get request for their appointments
	Then the response status code should indicate success
		And the response body should be FHIR JSON
		And the bundle of appointments should contain meta data profile and version id
	
Scenario: Appointment retrieve bundle of coding type SNOMED resource must contain coding with valid system and code and display
	Given I find or create "1" appointments for patient "patient1" at organization "ORG1" and save bundle of appintment resources to "Patient1AppointmentsInBundle"
	Given I am using the default server
		And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:search:patient_appointments" interaction
	When I search for "patient1" and make a get request for their appointments
	Then the response status code should indicate success
		And the response body should be FHIR JSON
		And if appointment contains the resource coding SNOMED CT element the fields should match the fixed values of the specification

	
Scenario: Appointment retrieve bundle of coding type READ V2 resource must contain coding with valid system and code and display
	Given I find or create "1" appointments for patient "patient1" at organization "ORG1" and save bundle of appintment resources to "Patient1AppointmentsInBundle"
	Given I am using the default server
		And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:search:patient_appointments" interaction
	When I search for "patient1" and make a get request for their appointments
	Then the response status code should indicate success
		And the response body should be FHIR JSON
		And if appointment contains the resource coding READ V2 element the fields should match the fixed values of the specification


Scenario: Appointment retrieve bundle of coding type SREAD CTV3 resource must contain coding with valid system and code and display
	Given I find or create "1" appointments for patient "patient1" at organization "ORG1" and save bundle of appintment resources to "Patient1AppointmentsInBundle"
	Given I am using the default server
		And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:search:patient_appointments" interaction
	When I search for "patient1" and make a get request for their appointments
	Then the response status code should indicate success
		And the response body should be FHIR JSON
		And if appointment contains the resource coding SREAD CTV3 element the fields should match the fixed values of the specification


Scenario: Appointment retrieve bundle contains appointment with slot 
	Given I find or create "1" appointments for patient "patient1" at organization "ORG1" and save bundle of appintment resources to "Patient1AppointmentsInBundle"
	Given I am using the default server
		And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:search:patient_appointments" interaction
	When I search for "patient1" and make a get request for their appointments
	Then the response status code should indicate success
		And the response body should be FHIR JSON
		And the appointments slot reference in the bundle is present and valid

	
Scenario: Appointment retrieve bundle contains appointment contact method
	Given I find or create "1" appointments for patient "patient1" at organization "ORG1" and save bundle of appintment resources to "Patient1AppointmentsInBundle"
	Given I am using the default server
		And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:search:patient_appointments" interaction
	When I search for "patient1" and make a get request for their appointments
	Then the response status code should indicate success
		And the response body should be FHIR JSON
		And if the appointment category element is present it is populated with the correct values
		And if the appointment booking element is present it is populated with the correct values
		And if the appointment contact element is present it is populated with the correct values
		And if the appointment cancellation reason element is present it is populated with the correct values

Scenario: Appointment retrieve bundle contains valid start and end dates
	Given I find or create "1" appointments for patient "patient1" at organization "ORG1" and save bundle of appintment resources to "Patient1AppointmentsInBundle"
	Given I am using the default server
		And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:search:patient_appointments" interaction
	When I search for "patient1" and make a get request for their appointments
	Then the response status code should indicate success
		And the response body should be FHIR JSON
		And all appointments must have an start element which is populated with a valid date
		And all appointments must have an end element which is populated vith a valid date

@ignore
Scenario Outline: Appointment retrieve JWT requesting scope claim should reflect the operation being performed
	Given I am using the default server
		And I am performing the "urn:nhs:names:services:gpconnect:fhir:rest:search:patient_appointments" interaction
		And I set the JWT requested record NHS number to config patient "patient2"
	When I search for Patient "/Patient/<id>/Appointment"
	Then the response status code should be "400"
		And the response body should be FHIR JSON
		And the response should be a OperationOutcome resource with error code "BAD_REQUEST"
		Examples:
        | id | 
		| 5  |
