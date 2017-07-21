﻿using GPConnect.Provider.AcceptanceTests.Constants;
using GPConnect.Provider.AcceptanceTests.Context;
using GPConnect.Provider.AcceptanceTests.Helpers;
using Hl7.Fhir.Model;
using NUnit.Framework;
using System;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using static Hl7.Fhir.Model.Bundle;
using static Hl7.Fhir.Model.Appointment;
using Hl7.Fhir.Serialization;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace GPConnect.Provider.AcceptanceTests.Steps
{
    using Enum;

    [Binding]
    public class AppointmentsSteps : BaseSteps
    {
        private readonly HttpContext HttpContext;
        private readonly JwtSteps _jwtSteps;
        private readonly PatientSteps _patientSteps;
        private readonly GetScheduleSteps _getScheduleSteps;
        private List<Appointment> Appointments => _fhirContext.Appointments;

        public AppointmentsSteps(FhirContext fhirContext, HttpSteps httpSteps, HttpContext httpContext, JwtSteps jwtSteps, PatientSteps patientSteps, GetScheduleSteps getScheduleSteps) 
            : base(fhirContext, httpSteps)
        {
            HttpContext = httpContext;
            _jwtSteps = jwtSteps;
            _patientSteps = patientSteps;
            _getScheduleSteps = getScheduleSteps;
        }

        [When(@"I search for ""([^""]*)"" from the list of patients and make a get request for their appointments")]
        public void searchAndGetAppointmentsFromPatientListData(string patient)
        {

            Patient patientResource = (Patient)HttpContext.StoredFhirResources[patient];
            string id = patientResource.Id.ToString();
            var url = "/Patient/"+ id+ "/Appointment";
            When($@"I make a GET request to ""{url}""");
        }

        [When(@"I search for ""([^""]*)"" and make a get request for their appointments")]
        public void searchAndGetAppointments(string patient)
        {
            Resource patient1 = (Patient)HttpContext.StoredFhirResources[patient];
            string id = patient1.Id.ToString();
            var url = "/Patient/" + id + "/Appointment";
            When($@"I make a GET request to ""{url}""");
        }

        [When(@"I search for patient ""([^""]*)"" and search for the most recently booked appointment ""([^""]*)"" using the stored startDate from the last booked appointment as a search parameter")]
        public void ISearchForPatientAndSearchForTheMostRecentlyBookedAppointmentUsingTheStoredStartDateFromTheLastBookedAppointmentAsASearchParameter(string patient, string appointmentKey)
        {
            Appointment appointment = (Appointment)HttpContext.StoredFhirResources[appointmentKey];
            Resource patient1 = (Patient)HttpContext.StoredFhirResources[patient];
            string id = patient1.Id.ToString();
            var url = "/Patient/" + id + "/Appointment?start=" + appointment.StartElement + "";
            When($@"I make a GET request to ""{url}""");
        }

        [When(@"I search for ""([^""]*)"" and make a get request for their appointments with the date ""([^""]*)""")]
        public void searchAndGetAppointmentsWithCustomStartDate(string patient, string startBoundry)
        {
           
            Resource patient1 = (Patient)HttpContext.StoredFhirResources[patient];    
            string id = patient1.Id.ToString();
            var url = "/Patient/" + id + "/Appointment?start=" + startBoundry + "";
            When($@"I make a GET request to ""{url}""");
        }

       
        [When(@"I search for ""([^""]*)"" and make a get request for their appointments with the saved slot start date ""([^""]*)"" and prefix ""([^""]*)""")]
        public void searchAndGetAppointmentsWithTheSavedSlotStartDateCustomStartDateandPrefix(string patient, string startBoundry, string prefix)
        {
            string time = HttpContext.StoredDate[startBoundry];
            Resource patient1 = (Patient)HttpContext.StoredFhirResources[patient];
            string id = patient1.Id.ToString();
            var url = "/Patient/" + id + "/Appointment?start=" + prefix + time + "";
            When($@"I make a GET request to ""{url}""");
        }
       
        [When(@"I search for ""([^""]*)"" and make a get request for their appointments with the date ""([^""]*)"" and prefix ""([^""]*)""")]
        public void searchAndGetAppointmentsWithCustomStartDateandPrefix(string patient, string startBoundry, string prefix)
        {
            Resource patient1 = (Patient)HttpContext.StoredFhirResources[patient];
            string id = patient1.Id.ToString();
            var url = "/Patient/" + id + "/Appointment?start="+prefix+ startBoundry + "";
            When($@"I make a GET request to ""{url}""");
        }

        [When(@"I search for ""([^""]*)"" and make a get request for their appointments with lower start date boundry ""([^""]*)"" with prefix ""([^""]*)"" and upper end date boundary ""([^""]*)"" with prefix ""([^""]*)""")]
        public void WhenISearchForAndMakeAGetRequestForTheirAppointmentsWithLowerStartDateBoundryWithPrefixAndUpperEndDateBoundaryWithPrefix(string patient, string startBoundry, string prefixStart, string endBoundry, string prefixEnd)
        {
            Resource patient1 = (Patient)HttpContext.StoredFhirResources[patient];
            string id = patient1.Id.ToString();
            var url = "/Patient/" + id + "/Appointment?start=" + prefixStart + startBoundry+ "&start="+prefixEnd+ endBoundry + "";
            When($@"I make a GET request to ""{url}""");
        }



        [Given(@"I get the slots avaliable slots for organization ""([^""]*)"" for the next 3 days")]
        public void BookSlots(string appointmentCode)
        {
            DateTime currentDateTime = DateTime.Now;
            Period period = new Period(new FhirDateTime(currentDateTime), new FhirDateTime(currentDateTime.AddDays(3)));
            _fhirContext.FhirRequestParameters.Add("timePeriod", period);
            Organization organization = (Organization)HttpContext.StoredFhirResources[appointmentCode];
            _httpSteps.RestRequest(Method.POST, "/Organization/" + organization.Id + "/$gpc.getschedule", FhirSerializer.SerializeToJson(_fhirContext.FhirRequestParameters));

            HttpContext.ResponseContentType.ShouldStartWith(FhirConst.ContentTypes.kJsonFhir);
            HttpContext.ResponseJSON = JObject.Parse(HttpContext.ResponseBody);
            FhirJsonParser fhirJsonParser = new FhirJsonParser();
            _fhirContext.FhirResponseResource = fhirJsonParser.Parse<Resource>(HttpContext.ResponseBody);

            List<Resource> slots = new List<Resource>();
            foreach (EntryComponent entry in ((Bundle)_fhirContext.FhirResponseResource).Entry)
            {
                if (entry.Resource.ResourceType.Equals(ResourceType.Organization))
                {
                    HttpContext.StoredFhirResources.Add("Organization", (Organization)entry.Resource);
                }
                if (entry.Resource.ResourceType.Equals(ResourceType.Location))
                {
                    HttpContext.StoredFhirResources.Add("Location", (Location)entry.Resource);
                }
                if (entry.Resource.ResourceType.Equals(ResourceType.Practitioner))
                {
                    HttpContext.StoredFhirResources.Remove("Practitioner");
                    HttpContext.StoredFhirResources.Add("Practitioner", (Practitioner)entry.Resource);
                }

                if (entry.Resource.ResourceType.Equals(ResourceType.Slot))
                {
                    string id = ((Slot)entry.Resource).Id.ToString();
                    slots.Add((Slot)entry.Resource);
                }
            }
            String here = slots.Count.ToString();
            HttpContext.StoredSlots.Add("Slot", slots);

        }

        [Given(@"I search for an appointments for patient ""([^""]*)"" on the provider system and save the first response to ""([^""]*)""")]
        public void GivenISearchForAnAppointmentOnTheProviderSystemAndSaveTheFirstResponseTo(int id, string storeKey)
        {
            var relativeUrl = "/Patient/" + id + "/Appointment";
            var returnedResourceBundle = _httpSteps.getReturnedResourceForRelativeURL("urn:nhs:names:services:gpconnect:fhir:rest:search:patient_appointments", relativeUrl);
            returnedResourceBundle.GetType().ShouldBe(typeof(Bundle));
            ((Bundle)returnedResourceBundle).Entry.Count.ShouldBeGreaterThan(0);
            var returnedFirstResource = (Appointment)((Bundle)returnedResourceBundle).Entry[0].Resource;
            string text = returnedFirstResource.ToString();
            returnedFirstResource.GetType().ShouldBe(typeof(Appointment));
            if (HttpContext.StoredFhirResources.ContainsKey(storeKey)) HttpContext.StoredFhirResources.Remove(storeKey);
            HttpContext.StoredFhirResources.Add(storeKey, returnedFirstResource);
        }

        [Then(@"there are zero appointment resources")]
        public void checkForEmptyAppointmentsBundle()
        {
            int count = 0;
            foreach (EntryComponent entry in ((Bundle)_fhirContext.FhirResponseResource).Entry)
            {
                if (entry.Resource.ResourceType.Equals(ResourceType.Appointment))
                {
                    count++;
                }
            }
            count.ShouldBe<int>(0);
        }

        

        [Then(@"there is one appointment resource")]
        public void checkForOneAppointmentsBundle()
        {
            int count = 0;
            foreach (EntryComponent entry in ((Bundle)_fhirContext.FhirResponseResource).Entry)
            {
                if (entry.Resource.ResourceType.Equals(ResourceType.Appointment))
                {
                    count++;
                }
            }
            count.ShouldBe<int>(1);
        }

        [Then(@"there are multiple appointment resources")]
        public void checkForMultipleAppointmentsBundle()
        {
            int appointmentCount = 0;
            foreach (EntryComponent entry in ((Bundle)_fhirContext.FhirResponseResource).Entry)
            {

                if (entry.Resource.ResourceType.Equals(ResourceType.Appointment))
                {
                    appointmentCount++;
                    Appointment appointment = (Appointment)entry.Resource;
                }
            }
            appointmentCount.ShouldBeGreaterThan<int>(1);
        }

        [Then(@"the response bundle should contain atleast ""([^""]*)"" appointment")]
        public void TheResponseBundleShouldContainAtleastAppointments (int minNumberOfAppointments)
        {
            int appointmentCount = 0;
            foreach (EntryComponent entry in ((Bundle)_fhirContext.FhirResponseResource).Entry)
            {

                if (entry.Resource.ResourceType.Equals(ResourceType.Appointment))
                {
                    appointmentCount++;
                    Appointment appointment = (Appointment)entry.Resource;
                }
            }
            appointmentCount.ShouldBeGreaterThanOrEqualTo(minNumberOfAppointments);
        }
        
        [Then(@"the appointment resource should contain a status element")]
        public void appointmentMustContainStatusElement()
        {
            ((Appointment)_fhirContext.FhirResponseResource).Status.ShouldNotBeNull("Appointment Status is a mandatory element and should be populated but is not in the returned resource.");
        }

        [Then(@"the appointment resource should contain a single start element")]
        public void appointmentMustContainStartElement()
        {

            Appointment appointment = (Appointment)_fhirContext.FhirResponseResource;
            appointment.Start.ShouldNotBeNull();


        }
        [Then(@"the appointment resource should contain a single end element")]
        public void appointmentMustContainEndElement()
        {
            Appointment appointment = (Appointment)_fhirContext.FhirResponseResource;
            appointment.End.ShouldNotBeNull();
        }

        [Then(@"the appointment resource should contain at least one slot reference")]
        public void appointmentMustContainSlotReference()
        {
            Appointment appointment = (Appointment)_fhirContext.FhirResponseResource;
            appointment.Slot.ShouldNotBeNull();

        }
        [Then(@"the appointment resource should contain at least one participant")]
        public void appointmentMustContainParticipant()
        {
            Appointment appointment = (Appointment)_fhirContext.FhirResponseResource;
            appointment.Participant.ShouldNotBeNull();


        }

        [Then(@"appointment status should have a valid value")]
        public void statusShouldHaveValidValue()
        {
            foreach (EntryComponent entry in ((Bundle)_fhirContext.FhirResponseResource).Entry)
            {
                if (entry.Resource.ResourceType.Equals(ResourceType.Appointment))
                {
                    Appointment appointment = (Appointment)entry.Resource;
                    appointment.Status.ShouldNotBeNull();

                }
            }
        }

        [Then(@"the bundle response should contain a participant element")]
        public void bundleResponseShouldContainParticipantElement()
        {
            int count = 0;
            foreach (EntryComponent entry in ((Bundle)_fhirContext.FhirResponseResource).Entry)
            {
                if (entry.Resource.ResourceType.Equals(ResourceType.Appointment))
                {
                    Appointment appointment = (Appointment)entry.Resource;
                    appointment.Participant.ShouldNotBeNull();
                    count++;

                }
            }
            count.ShouldBe<int>(1);
        }

        [Then(@"the appointment status element should be valid")]
        public void appointmentStatusElementShouldBeValid()
        {
            List<String> validAppointmentStatus = new List<string>();
            validAppointmentStatus.Add("Proposed");
            validAppointmentStatus.Add("Pending");
            validAppointmentStatus.Add("Booked");
            validAppointmentStatus.Add("Arrived");
            validAppointmentStatus.Add("Fulfilled");
            validAppointmentStatus.Add("Cancelled");
            validAppointmentStatus.Add("Noshow");

            foreach (EntryComponent entry in ((Bundle)_fhirContext.FhirResponseResource).Entry)
            {
                if (entry.Resource.ResourceType.Equals(ResourceType.Appointment))
                {
                    Appointment appointment = (Appointment)entry.Resource;
                    string status = appointment.Status.ToString();
                    validAppointmentStatus.ShouldContain(status);

                }
            }

        }

        [Then(@"the participant element should contain a single status element")]
        public void participantElementShouldContainASingleStatusElement()
        {
            foreach (EntryComponent entry in ((Bundle)_fhirContext.FhirResponseResource).Entry)
            {
                if (entry.Resource.ResourceType.Equals(ResourceType.Appointment))
                {
                    Appointment appointment = (Appointment)entry.Resource;
                }
            }
        }

        [Then(@"if appointment contains the resource coding READ V2 element the fields should match the fixed values of the specification")]
        public void reasonCodingSnomedCT()
        {
            foreach (EntryComponent entry in ((Bundle)_fhirContext.FhirResponseResource).Entry)
            {
                if (entry.Resource.ResourceType.Equals(ResourceType.Appointment))
                {
                    Appointment appointment = (Appointment)entry.Resource;
                    if (appointment.Type == null)
                    {
                      
                    }
                    else
                    {
                        if (appointment.Reason.Coding != null)
                        {
                            int codingCount = 0;
                            foreach (Coding coding in appointment.Reason.Coding)
                            {
                                codingCount++;
                                coding.System.ShouldBe("http://read.info/readv2");
                                coding.Code.ShouldBe("425173008");
                                coding.Display.ShouldBe("Default Appointment Type");
                            }
                            codingCount.ShouldBeLessThanOrEqualTo(1);
                        }

                        if (appointment.Reason.Text != null)
                        {
                            appointment.Reason.Text.ShouldBe("Default Appointment Type");
                        }
                    }
                }
            }
        }
        [Then(@"if appointment contains the resource coding SREAD CTV3 element the fields should match the fixed values of the specification")]
        public void reasonCodingReadV2()
        {
            foreach (EntryComponent entry in ((Bundle)_fhirContext.FhirResponseResource).Entry)
            {
                if (entry.Resource.ResourceType.Equals(ResourceType.Appointment))
                {
                    Appointment appointment = (Appointment)entry.Resource;

                 
                        if (appointment.Reason.Coding != null)
                        {
                            int codingCount = 0;
                            foreach (Coding coding in appointment.Reason.Coding)
                            {
                                codingCount++;
                                coding.System.ShouldBe("http://read.info/ctv3");
                                coding.Code.ShouldBe("425173008");
                                coding.Display.ShouldBe("Default Appointment Type");
                            }
                            codingCount.ShouldBeLessThanOrEqualTo(1);
                        }

                        if (appointment.Reason.Text != null)
                        {
                            appointment.Reason.Text.ShouldBe("Default Appointment Type");
                        }
                 }
            }
        }

        [Then(@"if appointment contains the resource coding SNOMED CT element the fields should match the fixed values of the specification")]
        public void reasonCodingReadCTV3()
        {
            foreach (EntryComponent entry in ((Bundle)_fhirContext.FhirResponseResource).Entry)
            {
                if (entry.Resource.ResourceType.Equals(ResourceType.Appointment))
                {
                    Appointment appointment = (Appointment)entry.Resource;

                    if (appointment.Reason.Coding == null)
                    {
                  
                    }
                    else
                    {
                        if (appointment.Reason.Coding != null)
                        {
                            int codingCount = 0;
                            foreach (Coding coding in appointment.Reason.Coding)
                            {
                                codingCount++;
                                coding.System.ShouldBe("http://snomed.info/sct");
                                coding.Code.ShouldBe("1");
                                coding.Display.ShouldBe("Default Appointment Type");
                            }
                            codingCount.ShouldBeLessThanOrEqualTo(1);
                        }

                        if (appointment.Reason.Text != null)
                        {
                            appointment.Reason.Text.ShouldBe("Default Appointment Type");
                        }
                    }
                }
            }
        }

        [Then(@"if the appointment resource contains an identifier it contains a valid system and value")]
        public void appointmentContainsValidIdentifierWithSystemAndValue()
        {
            foreach (EntryComponent entry in ((Bundle)_fhirContext.FhirResponseResource).Entry)
            {
                if (entry.Resource.ResourceType.Equals(ResourceType.Appointment))
                {
                    Appointment appointment = (Appointment)entry.Resource;
                    foreach (var identifier in appointment.Identifier)
                    {
                        identifier.Value.ShouldNotBeNullOrEmpty();
                    }
                }

            }
        }

        [Then(@"if the the start date must be before the end date")]
        public void startDateBeforeEndDate()
        {
            foreach (EntryComponent entry in ((Bundle)_fhirContext.FhirResponseResource).Entry)
            {
                if (entry.Resource.ResourceType.Equals(ResourceType.Appointment))
                {
                    Appointment appointment = (Appointment)entry.Resource;
                    DateTimeOffset? start = appointment.Start;
                    DateTimeOffset? end = appointment.End;

                    if (start > end)
                    {
                        { Assert.Fail(); }
                    }
                }
            }
        }


        [Then(@"the appointment response resource contains a status with a valid value")]
        public void ThenTheAppointmentResourceShouldContainAStatus()
        {
            Appointment appointment = (Appointment)_fhirContext.FhirResponseResource;
            appointment.Status.ShouldNotBeNull();
            string statusValue = appointment.Status.Value.ToString();
            if (statusValue != "Booked" && statusValue != "Pending" && statusValue != "Arrived" && statusValue != "Fulfilled" && statusValue != "Cancelled" && statusValue != "Noshow")
            {
                Assert.Fail("Appointment status value is invalid : " + statusValue);
            }
        }

        [Then(@"the appointment response resource contains an start date")]
        public void ThenTheAppointmentResourceShouldContainAStartDate()
        {
            Appointment appointment = (Appointment)_fhirContext.FhirResponseResource;
            appointment.Start.ShouldNotBeNull();
        }


        [Then(@"the appointment response resource contains an end date")]
        public void ThenTheAppointmentResourceShouldContainAEndDate()
        {
            Appointment appointment = (Appointment)_fhirContext.FhirResponseResource;
            appointment.End.ShouldNotBeNull();
        }

        [Then(@"the appointment response resource contains a slot reference")]
        public void ThenTheAppointmentResourceShouldContainASlotReference()
        {
            Appointment appointment = (Appointment)_fhirContext.FhirResponseResource;
            appointment.Slot.ShouldNotBeNull("The returned appointment does not contain a slot reference");
            appointment.Slot.Count.ShouldBeGreaterThanOrEqualTo(1, "The returned appointment does not contain a slot reference");
            foreach (var slotReference in appointment.Slot) {
                slotReference.Reference.ShouldStartWith("Slot/", "The returned appointment does not contain a valid slot reference");
            }
        }

        [Then(@"if appointment is present the single or multiple participant must contain a type or actor")]
        public void ThenTheAppointmentResourceShouldContainAParticipantWithATypeOrActor()
        {
            foreach (EntryComponent entry in ((Bundle)_fhirContext.FhirResponseResource).Entry)
            {
                if (entry.Resource.ResourceType.Equals(ResourceType.Appointment))
                {
                    Appointment appointment = (Appointment)entry.Resource;
                    foreach (ParticipantComponent participant in appointment.Participant)
                    {
                        var actor = participant.Actor;
                        var type = participant.Type;

                        if (null == actor && null == type)
                        {
                            Assert.Fail("Actor and type are null");
                        }
                        if (null != type)
                        {
                            int codableConceptCount = 0;
                            foreach (var typeCodableConcept in type)
                            {
                                codableConceptCount++;
                                int codingCount = 0;
                                foreach (var coding in typeCodableConcept.Coding)
                                {
                                    coding.System.ShouldBe("http://hl7.org/fhir/ValueSet/encounter-participant-type");
                                    string[] codes = new string[12] { "translator", "emergency", "ADM", "ATND", "CALLBCK", "CON", "DIS", "ESC", "REF", "SPRF", "PPRF", "PART" };
                                    string[] codeDisplays = new string[12] { "Translator", "Emergency", "admitter", "attender", "callback contact", "consultant", "discharger", "escort", "referrer", "secondary performer", "primary performer", "Participation" };
                                    coding.Code.ShouldBeOneOf(codes);
                                    coding.Display.ShouldBeOneOf(codeDisplays);
                                    for (int i = 0; i < codes.Length; i++)
                                    {
                                        if (string.Equals(coding.Code, codes[i]))
                                        {
                                            coding.Display.ShouldBe(codeDisplays[i], "The participant type code does not match the display element");
                                        }
                                    }
                                    codingCount++;
                                }
                                codingCount.ShouldBeLessThanOrEqualTo(1, "There should be a maximum of 1 participant type coding element for each participant");
                            }
                            codableConceptCount.ShouldBeLessThanOrEqualTo(1, "The participant type element may only contain one codable concept.");
                        }

                        if (actor != null && actor.Reference != null)
                        {
                            actor.Reference.ShouldNotBeEmpty();
                            if (!actor.Reference.StartsWith("Patient/") &&
                                !actor.Reference.StartsWith("Practitioner/") &&
                                !actor.Reference.StartsWith("Location/"))
                            {
                                Assert.Fail("The actor reference should be a Patient, Practitioner or Location");
                            }
                        }
                    }
                }
            }
        }

        [Then(@"the appointment response contains a type with a valid system code and display")]
        public void ThenTheAppointmentResourceContainsAType()
        {
            Appointment appointment = (Appointment)_fhirContext.FhirResponseResource;
            appointment.Type.ShouldNotBeNull();
            foreach (Coding coding in appointment.Type.Coding)
            {
                coding.System.ShouldBe("http://hl7.org/fhir/ValueSet/c80-practice-codes");
                coding.Code.ShouldNotBeNull();
            }

        }

        [Then(@"if the appointment participant contains a type is should have a valid system and code")]
        public void AppointmentParticipantValisType()
        {
            foreach (EntryComponent entry in ((Bundle)_fhirContext.FhirResponseResource).Entry)
            {
                if (entry.Resource.ResourceType.Equals(ResourceType.Appointment))
                {
                    Appointment appointment = (Appointment)entry.Resource;
                    foreach (ParticipantComponent part in appointment.Participant)
                    {

                        foreach (CodeableConcept codeConcept in part.Type)
                        {
                            foreach (Coding code in codeConcept.Coding)

                            {
                                code.System.ShouldBe("http://hl7.org/fhir/ValueSet/encounter-participant-type");
                                code.Code.ShouldNotBeNull();
                                code.Display.ShouldNotBeNull();
                            }
                        }
                    }
                }
            }
        }


        [Then(@"the appointment type should contain a valid system code and display")]
        public void ThenTheAppointmentResourceContainsTypeWithValidSystemCodeAndType()
        {
            Appointment appointment = (Appointment)_fhirContext.FhirResponseResource;
            appointment.Identifier.ShouldNotBeNull();
            String id = appointment.Id.ToString();
            foreach (Identifier identifier in appointment.Identifier)
            {
                identifier.System.ShouldNotBeNull();
                identifier.System.ShouldBe("http://fhir.nhs.net/Id/gpconnect-appointment-identifier");
                identifier.Value.ShouldNotBeNull();
                identifier.Value.ShouldBe(id);
            }
        }

        [Then(@"if the appointment resource contains a priority the value is valid")]
        public void ThenTheAppointmentResourceContainsPriorityAndTheValueIsValid()
        {
            Appointment appointment = (Appointment)_fhirContext.FhirResponseResource;

            if (null != appointment && (appointment.Priority < 0 || appointment.Priority > 9))
            {
                Assert.Fail("Invalid priority value: " + appointment.Priority);
            }
        }
        //Need to check the validity of the reference but currently no GET method
        [Then(@"the slot reference is present and valid")]
        public void checkingTheSlotReferenceIsValid()
        {

            Appointment appointment = (Appointment)_fhirContext.FhirResponseResource;
            foreach (ResourceReference slot in appointment.Slot)
            {
                slot.Reference.ShouldNotBeNull();
            }


        }

        [Then(@"all appointments must have an start element which is populated with a valid date")]
        public void appointmentPopulatedWithAValidStartDate()
        {
            foreach (EntryComponent entry in ((Bundle)_fhirContext.FhirResponseResource).Entry)
            {
                if (entry.Resource.ResourceType.Equals(ResourceType.Appointment))
                {
                    Appointment appointment = (Appointment)entry.Resource;
                    appointment.Start.ShouldNotBeNull();
                }
            }
        }

        [Then(@"all appointments must have a start element which is populated with a date that equals ""([^""]*)""")]
        public void appointmentPopulatedWithAStartDateEquals(string startBoundry)
        {
            //string time = HttpContext.StoredDate[startBoundry];
            DateTimeOffset time = DateTimeOffset.Parse(HttpContext.StoredDate[startBoundry]);

            foreach (EntryComponent entry in ((Bundle)_fhirContext.FhirResponseResource).Entry)
            {
                if (entry.Resource.ResourceType.Equals(ResourceType.Appointment))
                {
                    Appointment appointment = (Appointment)entry.Resource;
                    appointment.StartElement.Value.ShouldBe(time);
                }
            }
        }
        
        [Then(@"all appointments must have an end element which is populated vith a valid date")]
        public void appointmentPopulatedWithAValidEndDate()
        {
            foreach (EntryComponent entry in ((Bundle)_fhirContext.FhirResponseResource).Entry)
            {
                if (entry.Resource.ResourceType.Equals(ResourceType.Appointment))
                {
                    Appointment appointment = (Appointment)entry.Resource;
                    appointment.End.ShouldNotBeNull();
                }
            }
        }

        [Then(@"the practitioner resource returned in the appointments bundle is present")]
        public void actorPractitionerResourceValid()
        {
            foreach (EntryComponent entry in ((Bundle)_fhirContext.FhirResponseResource).Entry)
            {
                if (entry.Resource.ResourceType.Equals(ResourceType.Appointment))
                {
                    Appointment appointment = (Appointment)entry.Resource;
                    int countPractitioner = 0;
                    foreach (ParticipantComponent participant in appointment.Participant)
                    {
                        if (participant.Actor != null && participant.Actor.Reference != null)
                        {
                            string actor = participant.Actor.Reference.ToString();

                            if (actor.Contains("Practitioner"))
                            {
                                var practitioner = _httpSteps.getReturnedResourceForRelativeURL("urn:nhs:names:services:gpconnect:fhir:rest:read:practitioner", actor);
                                practitioner.ShouldNotBeNull();
                                countPractitioner++;
                            }
                        }
                    }
                    countPractitioner.ShouldBeGreaterThanOrEqualTo(1);
                }
            }
        }

        [Then(@"the location resource returned in the appointments bundle is present")]
        public void actorLocationResourceValid()
        {
            foreach (EntryComponent entry in ((Bundle)_fhirContext.FhirResponseResource).Entry)
            {
                if (entry.Resource.ResourceType.Equals(ResourceType.Appointment))
                {
                    int countLocation = 0; 
                    Appointment appointment = (Appointment)entry.Resource;
                    foreach (ParticipantComponent participant in appointment.Participant)
                    {
                        if (participant.Actor != null && participant.Actor.Reference != null)
                        {

                            string actor = participant.Actor.Reference.ToString();

                            if (actor.Contains("Location"))
                            {
                                var location = _httpSteps.getReturnedResourceForRelativeURL("urn:nhs:names:services:gpconnect:fhir:rest:read:location", actor);
                                location.ShouldNotBeNull();
                                countLocation++;
                            }
                        }
                    }
                    countLocation.ShouldBe(1);
                }
            }
        }
        
        [Then(@"the patient resource returned in the appointments bundle is present")]
        public void actorPatientResourceValid()
        {
            foreach (EntryComponent entry in ((Bundle)_fhirContext.FhirResponseResource).Entry)
            {
                if (entry.Resource.ResourceType.Equals(ResourceType.Appointment))
                {
                    Appointment appointment = (Appointment)entry.Resource;
                    int countPatient = 0;
                    foreach (ParticipantComponent participant in appointment.Participant)
                    {
                        if (participant.Actor != null && participant.Actor.Reference != null)
                        {
                            string actor = participant.Actor.Reference.ToString();

                            if (actor.Contains("Patient"))
                            {
                                countPatient++;
                                var patient = _httpSteps.getReturnedResourceForRelativeURL("urn:nhs:names:services:gpconnect:fhir:rest:read:patient", actor);
                                patient.ShouldNotBeNull();
                            }
                        }
                    }
                    countPatient.ShouldBeGreaterThanOrEqualTo(1);
                }
            }
        }
        
        [Then(@"patient ""(.*)"" should have ""(.*)"" appointments")]
        public void checkPatientHasTheCorrectAmountOfResources(int id, int numberOfAppointments)
        {
            int appointmentCount = 0;
            foreach (EntryComponent entry in ((Bundle)_fhirContext.FhirResponseResource).Entry)
            {
                if (entry.Resource.ResourceType.Equals(ResourceType.Appointment))
                {
                    appointmentCount++;
                    Appointment appointment = (Appointment)entry.Resource;
                }
            }
            appointmentCount.ShouldBe<int>(numberOfAppointments);
        }

        [Given(@"I create ""([^""]*)"" Appointments for Patient ""([^""]*)"" and Organization Code ""([^""]*)""")]
        public void CreateAppointmentsForPatientAndOrganizationCode(int appointments, string patient, string code)
        {
            while (appointments != 0)
            {
                CreateAnAppointmentForPatientAndOrganizationCode(patient, code);
                appointments--;
            }
        }


        [Given(@"I create an Appointment for Patient ""([^""]*)"" and Organization Code ""([^""]*)""")]
        public void CreateAnAppointmentForPatientAndOrganizationCode(string patient, string code)
        {
            _patientSteps.GetThePatientForPatientValue(patient);
            _patientSteps.StoreThePatient();

            _getScheduleSteps.GetTheScheduleForOrganizationCode(code);
            _getScheduleSteps.StoreTheSchedule();

            _httpSteps.ConfigureRequest(GpConnectInteraction.AppointmentCreate);

            _jwtSteps.SetTheJwtRequestedRecordToTheNhsNumberOfTheStoredPatient();

            CreateAnAppointmentFromTheStoredPatientAndStoredSchedule();

            _httpSteps.MakeRequest(GpConnectInteraction.AppointmentCreate);
        }

        [Given(@"I store the created Appointment")]
        public void StoreTheCreatedAppointment()
        {
            var appointment = _fhirContext.Appointments.FirstOrDefault();

            if (appointment != null)
                HttpContext.CreatedAppointment = appointment;
       
        }

        [Given(@"I store the Appointment")]
        public void StoreTheAppointment()
        {
            var appointment = _fhirContext.Appointments.FirstOrDefault();

            if (appointment != null)
                HttpContext.CreatedAppointment = appointment;
        }

        [Given(@"I store the Appointment Id")]
        public void StoreTheAppointmentId()
        {
            var appointment = _fhirContext.Appointments.FirstOrDefault();

            if (appointment != null)
                HttpContext.GetRequestId = appointment.Id;
        }

        [Given(@"I store the Appointment Version Id")]
        public void StoreThePractitionerVersionId()
        {
            var appointment = _fhirContext.Appointments.FirstOrDefault();
            if (appointment != null)
                HttpContext.GetRequestVersionId = appointment.VersionId;
        }

        [Given(@"I set the created Appointment status to ""([^""]*)""")]
        public void GivenISetCreatedAppointmentStatusTo(string status)
        {
            var appointment = _fhirContext.Appointments.FirstOrDefault();
            switch (status) {
                case "Booked":
                    appointment.Status = AppointmentStatus.Booked;
                    break;
                case "Cancelled":
                    appointment.Status = AppointmentStatus.Cancelled;
                    break;
            }

            if (appointment != null)
                HttpContext.CreatedAppointment = appointment;
        }

        [Given(@"I set the created Appointment priority to ""([^""]*)""")]
        public void  ISetTheCreatedAppointmentPriorityTo(int priority)
        {
            HttpContext.CreatedAppointment.Priority = priority;
        }


        [Given(@"I create an Appointment from the stored Patient and stored Schedule")]
        public void CreateAnAppointmentFromTheStoredPatientAndStoredSchedule()
        {
            var storedPatient = HttpContext.StoredPatient;
            var storedBundle = HttpContext.StoredBundle;

            var firstSlot = storedBundle.Entry
                .Where(entry => entry.Resource.ResourceType.Equals(ResourceType.Slot))
                .Select(entry => (Slot)entry.Resource)
                .First();

            var schedule = storedBundle.Entry
                .Where(entry =>
                        entry.Resource.ResourceType.Equals(ResourceType.Schedule) &&
                        entry.FullUrl == firstSlot.Schedule.Reference)
                .Select(entry => (Schedule) entry.Resource)
                .First();


            //Patient
            var patient = GetPatient(storedPatient);

            //Practitioners
            var practitionerReferences = schedule.Extension.Select(extension => ((ResourceReference)extension.Value).Reference);
            var practitioners = GetPractitioners(practitionerReferences);

            //Location
            var locationReference = schedule.Actor.Reference;
            var location = GetLocation(locationReference);

            //Participants
            var participants = new List<ParticipantComponent>();
            participants.Add(patient);
            participants.AddRange(practitioners);
            participants.Add(location);

            //Slots
            var slot = GetSlot(firstSlot);

            var slots = new List<ResourceReference>();
            slots.Add(slot);

            var appointment = new Appointment
            {
                Status = AppointmentStatus.Booked,
                Start = firstSlot.Start,
                End = firstSlot.End,
                Participant = participants,
                Slot = slots
            };

            HttpContext.CreatedAppointment = appointment;
        }

        private static ParticipantComponent GetLocation(string locationReference)
        {
            return new ParticipantComponent
            {
                Actor = new ResourceReference
                {
                    Reference = locationReference
                },
                Status = ParticipationStatus.Accepted
            };
        }

        private static ResourceReference GetSlot(Slot firstSlot)
        {
            return new ResourceReference
            {
                Reference = "Slot/" + firstSlot.Id
            };
        }

        private static ParticipantComponent GetPatient(Patient storedPatient)
        {
            return new ParticipantComponent
            {
                Actor = new ResourceReference
                {
                    Reference = "Patient/" + storedPatient.Id
                },
                Status = ParticipationStatus.Accepted,
                Type = new List<CodeableConcept>
                {
                    new CodeableConcept("http://hl7.org/fhir/ValueSet/encounter-participant-type", "SBJ", "patient", "patient")
                }
            };
        }

        private static List<ParticipantComponent> GetPractitioners(IEnumerable<string> practitionerReferences)
        {
            return practitionerReferences
                .Select(practitionerReference => new ParticipantComponent
                {
                    Actor = new ResourceReference
                    {
                        Reference = practitionerReference
                    },
                    Status = ParticipationStatus.Accepted,
                    Type = new List<CodeableConcept>
                    {
                        new CodeableConcept("http://hl7.org/fhir/ValueSet/encounter-participant-type", "PPRF", "practitioner", "practitioner")
                    }
                })
                .ToList();
        }

        [Given(@"I set the created Appointment Comment to ""([^""]*)""")]
        public void SetTheCreatedAppointmentComment(string comment)
        {
            HttpContext.CreatedAppointment.Comment = comment;
      
        }

        [Given(@"I set the created Appointment reason to ""([^""]*)""")]
        public void SetTheCreatedAppointmentReasonTo(string reason)
        {
            HttpContext.CreatedAppointment.Reason = new CodeableConcept();
            HttpContext.CreatedAppointment.Reason.Coding = new List<Coding>();
            HttpContext.CreatedAppointment.Reason.Coding.Add(new Coding("http://snomed.info/sct", reason, reason));
        }

        [Given(@"I set the created Appointment description to ""([^""]*)""")]
        public void SetTheCreatedAppointmentDescriptionTo(string description)
        {
            HttpContext.CreatedAppointment.Description = description;
      
        }

        [Given(@"I set the Created Appointment to Cancelled with Reason ""([^""]*)""")]
        public void SetTheCreatedAppointmentToCancelledWithReason(string reason)
        {
            var extension = GetCancellationReasonExtension(reason);

            if (HttpContext.CreatedAppointment.Extension == null)
                HttpContext.CreatedAppointment.Extension = new List<Extension>();

            HttpContext.CreatedAppointment.Extension.Add(extension);
            HttpContext.CreatedAppointment.Status = AppointmentStatus.Cancelled;
        }

        [Given(@"I set the Created Appointment to Cancelled with Url ""([^""]*)"" and Reason ""([^""]*)""")]
        public void SetTheCreatedAppointmentToCancelledWithUrlAndReason(string url, string reason)
        {
            var extension = GetStringExtension(url, reason);

            if (HttpContext.CreatedAppointment.Extension == null)
                HttpContext.CreatedAppointment.Extension = new List<Extension>();

            HttpContext.CreatedAppointment.Extension.Add(extension);
            HttpContext.CreatedAppointment.Status = AppointmentStatus.Cancelled;
        }


        [Given(@"I add a Category Extension with Code ""([^""]*)"" and Display ""([^""]*)"" to the Created Appointment")]
        public void AddACategoryExtensionWithCodeAndDisplayToTheCreatedAppointment(string code, string display)
        {
            var extension = GetCategoryExtension(code, display);

            if (HttpContext.CreatedAppointment.Extension == null)
                HttpContext.CreatedAppointment.Extension = new List<Extension>();

            HttpContext.CreatedAppointment.Extension.Add(extension);
        }

        [Given(@"I add a Booking Method Extension with Code ""([^""]*)"" and Display ""([^""]*)"" to the Created Appointment")]
        public void AddABookingMethodExtensionWithCodeAndDisplayToTheCreatedAppointment(string code, string display)
        {
            var extension = GetBookingMethodExtension(code, display);

            if (HttpContext.CreatedAppointment.Extension == null)
                HttpContext.CreatedAppointment.Extension = new List<Extension>();

            HttpContext.CreatedAppointment.Extension.Add(extension);
        }

        [Given(@"I add a Contact Method Extension with Code ""([^""]*)"" and Display ""([^""]*)"" to the Created Appointment")]
        public void AddAContactMethodExtensionWithCodeAndDisplayToTheCreatedAppointment(string code, string display)
        {
            var extension = GetContactMethodExtension(code, display);

            if (HttpContext.CreatedAppointment.Extension == null)
                HttpContext.CreatedAppointment.Extension = new List<Extension>();

            HttpContext.CreatedAppointment.Extension.Add(extension);
        }


        [Given("I set created appointment to a new appointment resource")]
        public void ISetTheAppointmentResourceToANewAppointmentResource()
        {
            HttpContext.CreatedAppointment = new Appointment();
        }
        private static Extension GetCategoryExtension(string code, string display)
        {
            return GetCodingExtension("http://fhir.nhs.net/StructureDefinition/extension-gpconnect-appointment-category-1", code, display);
        }
        private static Extension GetBookingMethodExtension(string code, string display)
        {
            return GetCodingExtension("http://fhir.nhs.net/StructureDefinition/extension-gpconnect-appointment-booking-method-1", code, display);
        }

        private static Extension GetContactMethodExtension(string code, string display)
        {
            return GetCodingExtension("http://fhir.nhs.net/StructureDefinition/extension-gpconnect-appointment-contact-method-1", code, display);
        }

        private static Extension GetCodingExtension(string url, string code, string display)
        {
            var coding = new Coding
            {
                Code = code,
                Display = display,
                System = url
            };

            var reason = new CodeableConcept();
            reason.Coding.Add(coding);

            return new Extension
            {
                Url = url,
                Value = reason
            };
        }

        private static Extension GetStringExtension(string url, string reason)
        {
            return new Extension
            {
                Url = url,
                Value = new FhirString(reason)
            };
        }

        private static Extension GetCancellationReasonExtension(string reason)
        {
            return GetStringExtension("http://fhir.nhs.net/StructureDefinition/extension-gpconnect-appointment-cancellation-reason-1", reason);
        }

        [Given(@"I read the Stored Appointment")]
        public void ReadTheStoredAppointment()
        {
            _httpSteps.ConfigureRequest(GpConnectInteraction.AppointmentRead);

            _jwtSteps.SetTheJwtRequestedRecordToTheNhsNumberOfTheStoredPatient();

            _httpSteps.MakeRequest(GpConnectInteraction.AppointmentRead);
        }

        [Given(@"I set the If-Match header to the Stored Appointment Version Id")]
        public void SetTheIfMatchHeaderToTheStoreAppointmentVersionId()
        {
            var versionId = HttpContext.CreatedAppointment.VersionId;
            var eTag = "W/\"" + versionId + "\"";

            _httpSteps.SetTheIfMatchHeaderTo(eTag);
        }

        [Then(@"the Appointment Metadata should be valid")]
        public void TheAppointmentMetadataShouldBeValid()
        {
            Appointments.ForEach(appointment =>
            {
                CheckForValidMetaDataInResource(appointment, "http://fhir.nhs.net/StructureDefinition/gpconnect-appointment-1");
            });
        }


        [Given(@"I add the ""([^""]*)"" Extensions to the Created Appointment")]
        public void AddTheExtensionsToTheCreatedAppointment(string extensionCombination)
        {
            var extensions = GetExtensions(extensionCombination);

            HttpContext.CreatedAppointment.Extension.AddRange(extensions);
        }

        private List<Extension> GetExtensions(string extensionCombination)
        {
            var extensions = new List<Extension>();
            switch (extensionCombination)
            {
                case "Category":
                    extensions.Add(GetCategoryExtension("CLI", "Clinical"));
                    break;
                case "BookingMethod":
                    extensions.Add(GetBookingMethodExtension("ONL", "Online"));
                    break;
                case "ContactMethod":
                    extensions.Add(GetContactMethodExtension("ONL", "Online"));
                    break;
                case "Category+BookingMethod":
                    extensions.Add(GetCategoryExtension("ADM", "Administrative"));
                    extensions.Add(GetBookingMethodExtension("TEL", "Telephone"));
                    break;
                case "Category+ContactMethod":
                    extensions.Add(GetCategoryExtension("MSG", "Message"));
                    extensions.Add(GetContactMethodExtension("PER", "In person"));
                    break;
                case "BookingMethod+ContactMethod":
                    extensions.Add(GetBookingMethodExtension("LET", "Letter"));
                    extensions.Add(GetContactMethodExtension("EMA", "Email"));
                    break;
                case "Category+BookingMethod+ContactMethod":
                    extensions.Add(GetCategoryExtension("VIR", "Virtual"));
                    extensions.Add(GetBookingMethodExtension("TEX", "Text"));
                    extensions.Add(GetContactMethodExtension("LET", "Letter"));
                    break;
            }

            return extensions;
        }


        private Extension buildAppointmentCategoryExtension(string url, string code, string display)
        {
            Extension extension = new Extension();
            extension.Url = url;
            CodeableConcept codeableConcept = new CodeableConcept();
            Coding coding = new Coding();
            coding.Code = code;
            coding.Display = display;
            codeableConcept.Coding.Add(coding);
            extension.Value = codeableConcept;
            return extension;
        }

        [Given(@"I set the appointment Priority to ""([^""]*)"" on appointment stored against key ""([^""]*)""")]
        public void GivenISetTheAppointmentPriorityToOnAppointmentStoredAgainstKey(int priority, string appointmentKey)
        {
            ((Appointment)HttpContext.StoredFhirResources[appointmentKey]).Priority = priority;
        }

        [When(@"I book the appointment called ""([^""]*)""")]
        public void WhenIBookTheAppointmentCalledString(string appointmentName)
        {
            var appointment = HttpContext.StoredFhirResources[appointmentName];
            if (HttpContext.RequestContentType.Contains("xml"))
            {
                _httpSteps.RestRequest(Method.POST, "/Appointment", FhirSerializer.SerializeToXml(appointment));
            }
            else
            {
                _httpSteps.RestRequest(Method.POST, "/Appointment", FhirSerializer.SerializeToJson(appointment));
            }
        }

        [When(@"I book an appointment for patient ""([^""]*)"" on the provider system using a slot from the getSchedule response bundle stored against key ""([^""]*)"" and store the appointment to ""([^""]*)""")]
        public void IBookAnAppointmentForPatientOnTheProviderSystemUsingASlotFromTheGetScheduleResponseBundleStoredAgainstKeyAndStoreTheAppointmentTo(string patientName, string getScheduleBundleKey, string storeAppointmentKey)
        {
            IBookAnAppointmentForPatientOnTheProviderSystemUsingASlotFromTheGetScheduleResponseBundleStoredAgainstKeyAndStoreTheAppointmentToWithPriority(patientName, getScheduleBundleKey, storeAppointmentKey, 1);
        }

        public void IBookAnAppointmentForPatientOnTheProviderSystemUsingASlotFromTheGetScheduleResponseBundleStoredAgainstKeyAndStoreTheAppointmentToWithPriority(string patientName, string getScheduleBundleKey, string storeAppointmentKey, int priority)
        {
            Given($@"I perform a patient search for patient ""{patientName}"" and store the first returned resources against key ""StoredPatientKey""");
            Given($@"I am using the default server");
            And($@"I set the JWT requested record NHS number to the NHS number of patient stored against key ""StoredPatientKey""");
            And($@"I set the JWT requested scope to ""patient/*.write""");
            And($@"I am performing the ""urn:nhs:names:services:gpconnect:fhir:rest:create:appointment"" interaction");
            Given($@"I create an appointment for patient ""StoredPatientKey"" called ""Appointment"" from schedule ""{getScheduleBundleKey}""");
            Given($@"I set the appointment Priority to ""{priority}"" on appointment stored against key ""Appointment""");
            When($@"I book the appointment called ""Appointment""");
            Then($@"the response status code should indicate created");
            Then($@"the response body should be FHIR JSON");
            And($@"the response should be an Appointment resource");
            if (HttpContext.StoredFhirResources.ContainsKey(storeAppointmentKey))
            {
                HttpContext.StoredFhirResources.Remove(storeAppointmentKey);
            }
            HttpContext.StoredFhirResources.Add(storeAppointmentKey, _fhirContext.FhirResponseResource);
        }

        [Given(@"I create an appointment for patient ""([^""]*)"" called ""([^""]*)"" from schedule ""([^""]*)""")]
        public void GivenICreateAnAppointmentForPatientCalledFromSchedule(string patientKey, string appointmentName, string getScheduleBundleKey)
        {
            Patient patientResource = (Patient)HttpContext.StoredFhirResources[patientKey];
            Bundle getScheduleResponseBundle = (Bundle)HttpContext.StoredFhirResources[getScheduleBundleKey];

            List<Slot> slotList = new List<Slot>();
            Dictionary<string, Practitioner> practitionerDictionary = new Dictionary<string, Practitioner>();
            Dictionary<string, Location> locationDictionary = new Dictionary<string, Location>();
            Dictionary<string, Schedule> scheduleDictionary = new Dictionary<string, Schedule>();

            foreach (EntryComponent entry in getScheduleResponseBundle.Entry)
            {
                if (entry.Resource.ResourceType.Equals(ResourceType.Slot))
                {
                    slotList.Add((Slot)entry.Resource);
                }
                else if (entry.Resource.ResourceType.Equals(ResourceType.Practitioner))
                {
                    if (!practitionerDictionary.ContainsKey(entry.FullUrl))
                    {
                        practitionerDictionary.Add(entry.FullUrl, (Practitioner)entry.Resource);
                    }
                }
                else if (entry.Resource.ResourceType.Equals(ResourceType.Location))
                {
                    if (!locationDictionary.ContainsKey(entry.FullUrl))
                    {
                        locationDictionary.Add(entry.FullUrl, (Location)entry.Resource);
                    }
                }
                else if (entry.Resource.ResourceType.Equals(ResourceType.Schedule))
                {
                    if (!scheduleDictionary.ContainsKey(entry.FullUrl))
                    {
                        scheduleDictionary.Add(entry.FullUrl, (Schedule)entry.Resource);
                    }
                }
            }

            // Select first slot
            Slot firstSlot = slotList[0];

            string scheduleReference = firstSlot.Schedule.Reference;
            Schedule schedule = null;
            scheduleDictionary.TryGetValue(scheduleReference, out schedule);

            string locationReferenceForSelectedSlot = schedule.Actor.Reference;

            List<string> practitionerReferenceForSelectedSlot = new List<string>();
            foreach (var practitionerReferenceExtension in schedule.Extension)
            {
                practitionerReferenceForSelectedSlot.Add(((ResourceReference)practitionerReferenceExtension.Value).Reference);
            }

            //Elements of the appointment
            CodeableConcept reason = null;
            List<Extension> extensionList = null;
            List<Identifier> identifiers = null;
            AppointmentStatus status = AppointmentStatus.Booked;
            int? priority = null;

            switch (appointmentName)
            {
                case "Appointment1":
                    extensionList = new List<Extension>();
                    extensionList.Add(buildAppointmentCategoryExtension("http://fhir.nhs.net/StructureDefinition/extension-gpconnect-appointment-category-1", "CLI", "Clinical"));
                    break;

                case "Appointment2":
                    extensionList = new List<Extension>();
                    extensionList.Add(buildAppointmentCategoryExtension("http://fhir.nhs.net/StructureDefinition/extension-gpconnect-appointment-booking-method-1", "ONL", "Online"));
                    break;

                case "Appointment3":
                    extensionList = new List<Extension>();
                    extensionList.Add(buildAppointmentCategoryExtension("http://fhir.nhs.net/StructureDefinition/extension-gpconnect-appointment-contact-method-1", "ONL", "Online"));
                    break;

                case "Appointment4":
                    extensionList = new List<Extension>();
                    extensionList.Add(buildAppointmentCategoryExtension("http://fhir.nhs.net/StructureDefinition/extension-gpconnect-appointment-category-1", "ADM", "Administrative"));
                    extensionList.Add(buildAppointmentCategoryExtension("http://fhir.nhs.net/StructureDefinition/extension-gpconnect-appointment-booking-method-1", "TEL", "Telephone"));
                    break;

                case "Appointment5":
                    extensionList = new List<Extension>();
                    extensionList.Add(buildAppointmentCategoryExtension("http://fhir.nhs.net/StructureDefinition/extension-gpconnect-appointment-contact-method-1", "PER", "In person"));
                    extensionList.Add(buildAppointmentCategoryExtension("http://fhir.nhs.net/StructureDefinition/extension-gpconnect-appointment-category-1", "MSG", "Message"));
                    break;

                case "Appointment6":
                    extensionList = new List<Extension>();
                    extensionList.Add(buildAppointmentCategoryExtension("http://fhir.nhs.net/StructureDefinition/extension-gpconnect-appointment-booking-method-1", "LET", "Letter"));
                    extensionList.Add(buildAppointmentCategoryExtension("http://fhir.nhs.net/StructureDefinition/extension-gpconnect-appointment-contact-method-1", "EMA", "Email"));
                    break;

                case "Appointment7":
                    extensionList = new List<Extension>();
                    extensionList.Add(buildAppointmentCategoryExtension("http://fhir.nhs.net/StructureDefinition/extension-gpconnect-appointment-booking-method-1", "TEX", "Text"));
                    extensionList.Add(buildAppointmentCategoryExtension("http://fhir.nhs.net/StructureDefinition/extension-gpconnect-appointment-category-1", "VIR", "Virtual"));
                    extensionList.Add(buildAppointmentCategoryExtension("http://fhir.nhs.net/StructureDefinition/extension-gpconnect-appointment-contact-method-1", "LET", "Letter"));
                    break;
            }

            Appointment appointment = new Appointment();
            appointment.Status = status;

            // Appointment Patient Resource
            ParticipantComponent patient = new ParticipantComponent();
            ResourceReference patientReference = new ResourceReference();
            patientReference.Reference = "Patient/" + patientResource.Id;
            patient.Actor = patientReference;
            patient.Status = ParticipationStatus.Accepted;
            patient.Type.Add(new CodeableConcept("http://hl7.org/fhir/ValueSet/encounter-participant-type", "SBJ", "patient", "patient"));
            appointment.Participant.Add(patient);

            // Appointment Practitioner Resource
            foreach (var practitionerSlotReference in practitionerReferenceForSelectedSlot)
            {
                ParticipantComponent practitioner = new ParticipantComponent();
                ResourceReference practitionerReference = new ResourceReference();
                practitionerReference.Reference = practitionerSlotReference;
                practitioner.Actor = practitionerReference;
                practitioner.Status = ParticipationStatus.Accepted;
                practitioner.Type.Add(new CodeableConcept("http://hl7.org/fhir/ValueSet/encounter-participant-type", "PPRF", "practitioner", "practitioner"));
                appointment.Participant.Add(practitioner);
            }

            // Appointment Location Resource
            ParticipantComponent location = new ParticipantComponent();
            ResourceReference locationReference = new ResourceReference();
            locationReference.Reference = locationReferenceForSelectedSlot;
            location.Actor = locationReference;
            location.Status = ParticipationStatus.Accepted;
            appointment.Participant.Add(location);

            // Appointment Slot Resource
            ResourceReference slot = new ResourceReference();
            slot.Reference = "Slot/" + firstSlot.Id;
            appointment.Slot.Add(slot);
            appointment.Start = firstSlot.Start;
            appointment.End = firstSlot.End;

            if (identifiers != null) appointment.Identifier = identifiers;
            if (priority != null) appointment.Priority = priority;
            if (reason != null) appointment.Reason = reason;
            if (extensionList != null) appointment.Extension = extensionList;

            // Store start date for use in other tests
            if (HttpContext.StoredDate.ContainsKey("slotStartDate")) HttpContext.StoredDate.Remove("slotStartDate");
            HttpContext.StoredDate.Add("slotStartDate", firstSlot.StartElement.ToString());

            // Now we have used the slot remove from it from the getScheduleBundle so it is not used to book other appointments same getSchedule is used
            EntryComponent entryToRemove = null;
            foreach (EntryComponent entry in getScheduleResponseBundle.Entry)
            {
                if (entry.Resource.ResourceType.Equals(ResourceType.Slot) && string.Equals(((Slot)entry.Resource).Id, firstSlot.Id))
                {
                    entryToRemove = entry;
                    break;
                }
            }
            getScheduleResponseBundle.Entry.Remove(entryToRemove);

            // Store appointment
            if (HttpContext.StoredFhirResources.ContainsKey(appointmentName)) HttpContext.StoredFhirResources.Remove(appointmentName);
            HttpContext.StoredFhirResources.Add(appointmentName, (Appointment)appointment);
        }
    }
}
