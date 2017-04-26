﻿using System;
using GPConnect.Provider.AcceptanceTests.Context;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using RestSharp;
using Shouldly;
using TechTalk.SpecFlow;
using static Hl7.Fhir.Model.Bundle;
using GPConnect.Provider.AcceptanceTests.Logger;

namespace GPConnect.Provider.AcceptanceTests.Steps
{
    [Binding]
    class GetScheduleSteps : TechTalk.SpecFlow.Steps
    {

        private readonly FhirContext FhirContext;
        private readonly HttpContext HttpContext;
        private readonly HttpSteps HttpSteps;
        private readonly AccessRecordSteps AccessRecordSteps;

        public GetScheduleSteps(FhirContext fhirContext, HttpContext httpContext, HttpSteps httpSteps, AccessRecordSteps accessRecordSteps)
        {
            FhirContext = fhirContext;
            HttpContext = httpContext;
            HttpSteps = httpSteps;
            AccessRecordSteps = accessRecordSteps;
        }

        [Given(@"I search for the organization ""([^""]*)"" on the providers system and save the first response to ""([^""]*)""")]
        public void GivenISearchForTheOrganizationOnTheProviderSystemAndSaveTheFirstResponseTo(string organizaitonName, string storeKey)
        {
            var relativeUrl = "Organization?identifier=http://fhir.nhs.net/Id/ods-organization-code|" + FhirContext.FhirOrganizations[organizaitonName];
            var returnedResourceBundle = HttpSteps.getReturnedResourceForRelativeURL("urn:nhs:names:services:gpconnect:fhir:rest:search:organization", relativeUrl);
            returnedResourceBundle.GetType().ShouldBe(typeof(Bundle));
            ((Bundle)returnedResourceBundle).Entry.Count.ShouldBeGreaterThan(0);
            var returnedFirstResource = (Organization)((Bundle)returnedResourceBundle).Entry[0].Resource;
            returnedFirstResource.GetType().ShouldBe(typeof(Organization));
            if (HttpContext.StoredFhirResources.ContainsKey(storeKey)) HttpContext.StoredFhirResources.Remove(storeKey);
            HttpContext.StoredFhirResources.Add(storeKey, returnedFirstResource);
         
        }

        [Given(@"I add period request parameter with a start date of today and an end date ""([^""]*)"" days later")]
        public void GivenIAddPeriodRequestParameterWithAStartDateOfTodayAndAnEndDateDaysLater(double numberOfDaysRange) {
            DateTime currentDateTime = DateTime.Now;
            Period period = new Period(new FhirDateTime(currentDateTime), new FhirDateTime(currentDateTime.AddDays(numberOfDaysRange)));
            FhirContext.FhirRequestParameters.Add("timePeriod", period);
        }

        [Given(@"I add period request parameter with only a start date")]
        public void GivenIAddPeriodRequestParameterWithOnlyAStartDate()
        {
            Period period = new Period();
            period.StartElement = FhirDateTime.Now();
            FhirContext.FhirRequestParameters.Add("timePeriod", period);
        }

        [Given(@"I add period request parameter with only an end date")]
        public void GivenIAddPeriodRequestParameterWithOnlyAnEndDate()
        {
            Period period = new Period();
            period.EndElement = new FhirDateTime(DateTime.Now.AddDays(2));
            FhirContext.FhirRequestParameters.Add("timePeriod", period);
        }

        [Given(@"I add period request parameter with start date ""([^""]*)"" and end date ""([^""]*)""")]
        public void GivenIAddPeriodRequestParameterWithStartDateAndEndDate(string startDate, string endDate)
        {
            Period period = new Period();
            period.Start = startDate;
            period.End = endDate;
            FhirContext.FhirRequestParameters.Add("timePeriod", period);
        }

        [When(@"I send a gpc.getschedule operation for the organization stored as ""([^""]*)""")]
        public void ISendAGpcGetScheduleOperationForTheOrganizationStoredAs(string storeKey)
        {
            Organization organization = (Organization)HttpContext.StoredFhirResources[storeKey];
            ISendAGpcGetScheduleOperationForTheOrganizationWithLogicalId(organization.Id);
        }

        [When(@"I send a gpc.getschedule operation for the organization stored as ""([^""]*)"" to the wrong endpoint")]
        public void ISendAGpcGetScheduleOperationForTheOrganizationStoredAsToTheWrongEndpoint(string storeKey)
        {
            Organization organization = (Organization)HttpContext.StoredFhirResources[storeKey];
            string body = null;
            if (HttpContext.RequestContentType.Contains("xml"))
            {
                body = FhirSerializer.SerializeToXml(FhirContext.FhirRequestParameters);
            }
            else
            {
                body = FhirSerializer.SerializeToJson(FhirContext.FhirRequestParameters);
            }
            HttpSteps.RestRequest(Method.POST, "/" + organization.Id + "/$gpc.getschedule", body);
        }

        [When(@"I send a gpc.getschedule operation for the organization with locical id ""([^""]*)""")]
        public void ISendAGpcGetScheduleOperationForTheOrganizationWithLogicalId(string logicalId)
        {
            string body = null;
            if (HttpContext.RequestContentType.Contains("xml"))
            {
                body = FhirSerializer.SerializeToXml(FhirContext.FhirRequestParameters);
            } else
            {
                body = FhirSerializer.SerializeToJson(FhirContext.FhirRequestParameters);
            }
            HttpSteps.RestRequest(Method.POST, "/Organization/" + logicalId + "/$gpc.getschedule", body);
        }

        [Then(@"the response bundle should include slot resources")]
        public void ThenTheResponseBundlleShouldIncludeSlotResources()
        {
            bool slotResourceFoundInResponse = false;
            foreach (EntryComponent entry in ((Bundle)FhirContext.FhirResponseResource).Entry)
            {
                if (entry.Resource.ResourceType.Equals(ResourceType.Slot))
                {
                    slotResourceFoundInResponse = true;
                    break;
                }
            }
            slotResourceFoundInResponse.ShouldBeTrue("No Slots Resources were found in the response bundle.");
        }

        [Then(@"the slots resources within the response bundle should be free")]
        public void ThenTheSlotsResourcesWithinTheResponseBundleShouldBeFree()
        {
            foreach (EntryComponent entry in ((Bundle)FhirContext.FhirResponseResource).Entry)
            {
                if (entry.Resource.ResourceType.Equals(ResourceType.Slot))
                {
                    ((Slot)entry.Resource).FreeBusyType.ShouldBe(Slot.SlotStatus.Free, "Slot freeBusy element sould be Free but is not");
                }
            }
        }

        [Then(@"the bundle resources should contain required meta data elements")]
        public void ThenTheBundleResourcesShouldContainRequiredMetaDataElements()
        {
            Bundle bundle = (Bundle)FhirContext.FhirResponseResource;
            bundle.Meta.ShouldNotBeNull();
            foreach (string profile in bundle.Meta.Profile)
            {
                profile.ShouldBe("http://fhir.nhs.net/StructureDefinition/gpconnect-getschedule-bundle-1");
            }
        }

        [Then(@"the slot resources in the response bundle should contain meta data information")]
        public void ThenTheSlotResourcesInTheResponseBundleShouldContainMetaDataInformation()
        {
            foreach (EntryComponent entry in ((Bundle)FhirContext.FhirResponseResource).Entry)
            {
                if (entry.Resource.ResourceType.Equals(ResourceType.Slot))
                {
                    Slot slot = (Slot)entry.Resource;
                    slot.Meta.ShouldNotBeNull("All Slot resources should contain MetaDate elements");
                    slot.Meta.VersionId.ShouldNotBeNull("All Slot resource MetaData versionId should be populated");
                    slot.Meta.VersionId.ShouldNotBeEmpty("All Slot resource MetaData versionId should be populated");
                    int slotMetaProfileCount = 0;
                    foreach (string profile in slot.Meta.Profile)
                    {
                        profile.ShouldBe("http://fhir.nhs.net/StructureDefinition/gpconnect-slot-1", "The Slot MetaData profile is invalid");
                        slotMetaProfileCount++;
                    }
                    slotMetaProfileCount.ShouldBeGreaterThanOrEqualTo(1,"A Slot Resource is missing the profile within the MetaData element.");
                }
            }
        }

        [Then(@"the slot resources can contain a maximum of one identifier with a populated value")]
        public void ThenTheSlotResourcesCanContainAMaximumOfOneIdentifierWithAPopulatedValue()
        {
            foreach (EntryComponent entry in ((Bundle)FhirContext.FhirResponseResource).Entry)
            {
                if (entry.Resource.ResourceType.Equals(ResourceType.Slot))
                {
                    Slot slot = (Slot)entry.Resource;
                    int slotIdentifierCount = 0;
                    foreach (Identifier identifier in slot.Identifier) {
                        identifier.Value.ShouldNotBeNull("If an identifier is present in a Slot resource it must have a value.");
                        identifier.Value.ShouldNotBeEmpty("If an identifier is present in a Slot resource it must have a value.");
                        slotIdentifierCount++;
                    }
                    slotIdentifierCount.ShouldBeLessThanOrEqualTo(1, "There is more than one identifier within a Slot resource when there sould be a maximum of one");
                }
            }
        }

        [Then(@"the schedule reference within the slots resources should be resolvable in the response bundle")]
        public void ThenTheScheduleReferenceWithinTheSlotsResourcesShouldBeResolvableInTheResponseBundle()
        {
            foreach (EntryComponent entry in ((Bundle)FhirContext.FhirResponseResource).Entry)
            {
                if (entry.Resource.ResourceType.Equals(ResourceType.Slot))
                {
                    Slot slot = (Slot)entry.Resource;
                    slot.Schedule.Reference.ShouldNotBeNull("There must be a Schedule reference within all slots.");
                    slot.Schedule.Reference.ShouldNotBeEmpty("There must be a Schedule reference within all slots.");
                    AccessRecordSteps.responseBundleContainsReferenceOfType(slot.Schedule.Reference, ResourceType.Schedule);
                }
            }
        }

        [Then(@"the schedule resources in the response bundle should contain meta data information")]
        public void ThenTheScheduleResourcesInTheResponseBundleShouldContainMetaDataInformation()
        {
            foreach (EntryComponent entry in ((Bundle)FhirContext.FhirResponseResource).Entry)
            {
                if (entry.Resource.ResourceType.Equals(ResourceType.Schedule))
                {
                    Schedule schedule = (Schedule)entry.Resource;
                    schedule.Meta.ShouldNotBeNull("All Schedule resources should contain MetaDate elements");
                    schedule.Meta.VersionId.ShouldNotBeNull("All Schedule resource MetaData versionId should be populated");
                    schedule.Meta.VersionId.ShouldNotBeEmpty("All Schedule resource MetaData versionId should be populated");
                    int scheduleMetaProfileCount = 0;
                    foreach (string profile in schedule.Meta.Profile)
                    {
                        profile.ShouldBe("http://fhir.nhs.net/StructureDefinition/gpconnect-schedule-1", "The Schedule MetaData profile is invalid");
                        scheduleMetaProfileCount++;
                    }
                    scheduleMetaProfileCount.ShouldBeGreaterThanOrEqualTo(1, "A Schedule Resource is missing the profile within the MetaData element.");
                }
            }
        }

        [Then(@"the schedule resources in the response bundle should contain an actor which references a location within the response bundle")]
        public void ThenTheScheduleResourcesInTheResponseBundleShouldContainAnActorWhichReferencesALocationWithinTheResponseBundle()
        {
            foreach (EntryComponent entry in ((Bundle)FhirContext.FhirResponseResource).Entry)
            {
                if (entry.Resource.ResourceType.Equals(ResourceType.Schedule))
                {
                    Schedule schedule = (Schedule)entry.Resource;
                    schedule.Actor.ShouldNotBeNull();
                    schedule.Actor.Reference.ShouldNotBeNull();
                    schedule.Actor.Reference.ShouldStartWith("Location/");
                    AccessRecordSteps.responseBundleContainsReferenceOfType(schedule.Actor.Reference, ResourceType.Location);
                }
            }
        }

        [Then(@"the schedule resources can contain a single identifier but must have a value if present")]
        public void ThenTheScheduleResourcesCanContainASingleIdentifierButMustHaveAValueIfPresent()
        {
            foreach (EntryComponent entry in ((Bundle)FhirContext.FhirResponseResource).Entry)
            {
                if (entry.Resource.ResourceType.Equals(ResourceType.Schedule))
                {
                    Schedule schedule = (Schedule)entry.Resource;
                    int identifierCount = 0;
                    foreach (var identifier in schedule.Identifier) {
                        identifier.Value.ShouldNotBeNull("If a schedule identifier is included it should have a value");
                        identifier.Value.ShouldNotBeEmpty();
                        identifierCount++;
                    }
                    identifierCount.ShouldBeLessThanOrEqualTo(1, "There should be a maximum of one identifier in a schedule resource.");
                }
            }
        }
        
        [Then(@"the schedule resources can contain a planningHorizon but it must contain a valid start date")]
        public void ThenTheScheduleResourcesCanContainAPlanningHorizonButItMustContainAValidStartDate()
        {
            foreach (EntryComponent entry in ((Bundle)FhirContext.FhirResponseResource).Entry)
            {
                if (entry.Resource.ResourceType.Equals(ResourceType.Schedule))
                {
                    Schedule schedule = (Schedule)entry.Resource;
                    if (schedule.PlanningHorizon != null)
                    {
                        schedule.PlanningHorizon.Start.ShouldNotBeNull();
                    }
                }
            }
        }

        [Then(@"the schedule resources can contain a single type element")]
        public void ThenTheScheduleResourcesCanContainASingleTypeElement()
        {
            foreach (EntryComponent entry in ((Bundle)FhirContext.FhirResponseResource).Entry)
            {
                if (entry.Resource.ResourceType.Equals(ResourceType.Schedule))
                {
                    Schedule schedule = (Schedule)entry.Resource;
                    if (schedule.Type != null)
                    {
                        schedule.Type.Count.ShouldBeLessThanOrEqualTo(1);
                    }
                }
            }
        }

        [Then(@"the schedule resources can contain extensions which references practitioner resources within the bundle")]
        public void ThenTheScheduleResourcesCanContainExtensionsWhichReferencesPractitionerResourcesWithinTheBundle()
        {
            foreach (EntryComponent entry in ((Bundle)FhirContext.FhirResponseResource).Entry)
            {
                if (entry.Resource.ResourceType.Equals(ResourceType.Schedule))
                {
                    Schedule schedule = (Schedule)entry.Resource;
                    foreach (var extension in schedule.Extension) {
                        extension.Url.ShouldBe("http://fhir.nhs.net/StructureDefinition/extension-gpconnect-practitioner-1");
                        extension.Value.ShouldNotBeNull("Practitioner reference extension must have a reference.");
                        var practitionerReference = ((ResourceReference)extension.Value).Reference;
                        practitionerReference.ShouldNotBeNull();
                        practitionerReference.ShouldStartWith("Practitioner/");
                        AccessRecordSteps.responseBundleContainsReferenceOfType(practitionerReference, ResourceType.Practitioner);
                    }
                }
            }
        }

    }
}
