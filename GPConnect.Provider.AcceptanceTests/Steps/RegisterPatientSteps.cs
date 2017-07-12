﻿using System.Collections.Generic;
using GPConnect.Provider.AcceptanceTests.Context;
using GPConnect.Provider.AcceptanceTests.Helpers;
using Hl7.Fhir.Model;
using Shouldly;
using TechTalk.SpecFlow;
using static Hl7.Fhir.Model.Bundle;
using System.Net.Http;
using Hl7.Fhir.Serialization;
using RestSharp;
using GPConnect.Provider.AcceptanceTests.Data;
using GPConnect.Provider.AcceptanceTests.Constants;
using NUnit.Framework;

namespace GPConnect.Provider.AcceptanceTests.Steps
{
    using System.Linq;

    [Binding]
    public class RegisterPatientSteps : TechTalk.SpecFlow.Steps
    {
        private readonly FhirContext FhirContext;
        private readonly HttpSteps HttpSteps;
        private readonly HttpContext HttpContext;
        private readonly PatientSteps _patientSteps;
        // Headers Helper
        public HttpHeaderHelper Headers { get; }

        public RegisterPatientSteps(HttpHeaderHelper headerHelper, FhirContext fhirContext, HttpSteps httpSteps, HttpContext httpContext, PatientSteps patientSteps)
        {
            // Helpers
            FhirContext = fhirContext;
            Headers = headerHelper;
            HttpSteps = httpSteps;
            HttpContext = httpContext;
            _patientSteps = patientSteps;
        }

        [Given(@"I create a patient to register which does not exist on PDS and store the Patient Resource against key ""([^""]*)""")]
        public void GivenICreateAPatientToRegisterWhichDoesNoteExistOnPDSAndStoreThePatientResourceAgainstKey(string patientResourceKey)
        {
            Patient returnPatient = new Patient();
            returnPatient.Identifier.Add(new Identifier(FhirConst.IdentifierSystems.kNHSNumber, "9019546082"));
            HumanName name = new HumanName();
            name.FamilyElement.Add(new FhirString("GPConnectFamilyName"));
            name.GivenElement.Add(new FhirString("GPConnectGivenName"));
            returnPatient.Name = new List<HumanName>();
            returnPatient.Name.Add(name);
            returnPatient.Gender = AdministrativeGender.Other;
            returnPatient.BirthDateElement = new Date("2017-05-05");
            if (HttpContext.StoredFhirResources.ContainsKey(patientResourceKey)) HttpContext.StoredFhirResources.Remove(patientResourceKey);
            HttpContext.StoredFhirResources.Add(patientResourceKey, returnPatient);
        }
        
        [Given(@"I find the next patient to register and store the Patient Resource against key ""([^""]*)""")]
        public void GivenIFindTheNextPatientToRegisterAndStoreThePatientResourceAgainstKey(string patientResourceKey)
        {
            Patient returnPatient = null;
            List<RegisterPatient> registerPatients = GlobalContext.RegisterPatients;
            for (int index = 0; index < registerPatients.Count; index++) {
                RegisterPatient registerPatient = registerPatients[index];
                // Search for patient
                Given($@"I perform a patient search for patient with NHSNumber ""{registerPatient.SPINE_NHS_NUMBER}"" and store the response bundle against key ""registerPatient""");
                // See if number of returned patients is > zero, ie patient already registered, else use patient
                Bundle patientSearchBundle = (Bundle)HttpContext.StoredFhirResources["registerPatient"];
                if (patientSearchBundle.Entry.Count == 0) {
                    // Patient not registered yet
                    returnPatient = new Patient();
                    returnPatient.Identifier.Add(new Identifier(FhirConst.IdentifierSystems.kNHSNumber, registerPatient.SPINE_NHS_NUMBER));
                    HumanName name = new HumanName();
                    name.FamilyElement.Add(new FhirString(registerPatient.NAME_FAMILY));
                    name.GivenElement.Add(new FhirString(registerPatient.NAME_GIVEN));
                    returnPatient.Name = new List<HumanName>();
                    returnPatient.Name.Add(name);
                    switch (registerPatient.GENDER) {
                        case "MALE":
                            returnPatient.Gender = AdministrativeGender.Male;
                            break;
                        case "FEMALE":
                            returnPatient.Gender = AdministrativeGender.Female;
                            break;
                        case "OTHER":
                            returnPatient.Gender = AdministrativeGender.Other;
                            break;
                        case "UNKNOWN":
                            returnPatient.Gender = AdministrativeGender.Unknown;
                            break;
                    }
                    returnPatient.BirthDateElement = new Date(registerPatient.DOB);
                    break; // Stop looking for the next patient
                }
            }
            if (returnPatient != null)
            {
                // Store the created patient
                if (HttpContext.StoredFhirResources.ContainsKey(patientResourceKey)) HttpContext.StoredFhirResources.Remove(patientResourceKey);
                HttpContext.StoredFhirResources.Add(patientResourceKey, returnPatient);
            }
            else {
                Assert.Fail("No patients left to register patient with");
            }
        }

        [Given(@"I build the register patient from stored patient resource against key ""(.*)""")]
        public void GivenIBuildTheRegisterPatientFromStoredPatientResourceAgainstKey(string storedPatientKey)
        {
            HttpContext.registerPatient.Add(storedPatientKey, (Patient)HttpContext.StoredFhirResources[storedPatientKey]);
        }
        
        [Given(@"I remove the patients identifiers from the stored patient")]
        public void GivenIRemoveThePatientsIdentifiersFromTheStoredPatient()
        {
            HttpContext.StoredPatient.Identifier = null;
        }

        [Given(@"I remove the name element from the stored patient")]
        public void GivenIRemoveTheNameElementFromTheStoredPatient()
        {
            HttpContext.StoredPatient.Name = null;
        }

        [Given(@"I remove the gender element from the stored patient")]
        public void GivenIRemoveTheGenderElementFromTheStoredPatient()
        {
            HttpContext.StoredPatient.Gender = null;
        }

        [Given(@"I remove the DOB element from the stored patient")]
        public void GivenIRemoveTheDOBElementFromTheStoredPatient()
        {
            HttpContext.StoredPatient.BirthDate = null;
        }

        [Given(@"I add the NHS Number identifier ""([^""]*)"" to the stored patient")]
        public void GivenIAddTheNHSNumberIdentifierToTheStoredPatient(string nhsNumber)
        {
            HttpContext.StoredPatient.Identifier.Add(new Identifier(FhirConst.IdentifierSystems.kNHSNumber, nhsNumber));
        }

        [Given(@"I add the registration period with start date ""([^""]*)""")]
        public void GivenIAddTheRegistrationPeriodWithStartDateTo(string regStartDate)
        {
            Extension registrationPeriod = new Extension();
            registrationPeriod.Url = "http://fhir.nhs.net/StructureDefinition/extension-registration-period-1";
            Period period = new Period();
            period.Start = regStartDate;
            registrationPeriod.Value = period;
            HttpContext.StoredPatient.Extension.Add(registrationPeriod);
        }

        [Given(@"I set the stored Patient registration period with start date ""([^""]*)"" and end date ""([^""]*)""")]
        public void GivenISetTheStoredPatientRegistrationPeriodWithStartDateAndEndDateTo(string regStartDate, string regEndDate)
        {
            Extension registrationPeriod = new Extension();
            registrationPeriod.Url = "http://fhir.nhs.net/StructureDefinition/extension-registration-period-1";
            Period period = new Period();
            if (!string.IsNullOrEmpty(regStartDate)) { period.Start = regStartDate; }
            if (!string.IsNullOrEmpty(regEndDate)) { period.End = regEndDate; }
            registrationPeriod.Value = period;
            HttpContext.StoredPatient.Extension.Add(registrationPeriod);
        }
        
        [Given(@"I add the resource stored against key ""([^""]*)"" as a parameter named ""([^""]*)"" to the request")]
        public void GivenIAddTheResourceStoredAgainstKeyAsAParameternamedToTheRequest(string storedPatientKey, string parameterName)
        {
            FhirContext.FhirRequestParameters.Add(parameterName, HttpContext.StoredFhirResources[storedPatientKey]);
        }

        [Then(@"the bundle should contain a registration type")]
        public void ThenTheBundleShouldContainARegistrationType()
        {
            foreach (EntryComponent entry in ((Bundle)FhirContext.FhirResponseResource).Entry)
            {
                if (entry.Resource.ResourceType.Equals(ResourceType.Patient)) {
                    Patient patient = (Patient)entry.Resource;
                    bool regTypePresent = false;
                    foreach (Extension ext in patient.Extension)
                    {
                        string url = ext.Url.ToString();
                        if (url == "http://fhir.nhs.net/StructureDefinition/extension-registration-type-1")
                        {
                            regTypePresent = true;
                            ext.Value.ShouldNotBeNull();

                        }
                  
                     }
                    regTypePresent.ShouldBe(true);
                 }
            }
        }

        [Given(@"I convert patient stored in ""([^""]*)"" to a register temporary patient against key ""([^""]*)""")]
        public void GivenIConvertPatientStoredInToARegisterTemporaryPatientAgainsKey(string storedPatientKey, string returnPatientKey)
        {
            Patient storedPatient = (Patient) HttpContext.StoredFhirResources[storedPatientKey];
            Patient returnPatient = new Patient();

            foreach(var identifier in storedPatient.Identifier) {
                if (string.Equals(identifier.System, FhirConst.IdentifierSystems.kNHSNumber))
                {
                    returnPatient.Identifier.Add(new Identifier(FhirConst.IdentifierSystems.kNHSNumber, identifier.Value));
                    break;
                }
            }

            string familyName = "GPConnectFamilyName";
            string givenName = "GPConnectGivenName";
            foreach (var storedPatientName in storedPatient.Name)
            {
                foreach (var storedPatientFamilyName in storedPatientName.Family)
                {
                    familyName = storedPatientFamilyName;
                    break;
                }
                foreach (var storedPatientGivenName in storedPatientName.Given)
                {
                    givenName = storedPatientGivenName;
                    break;
                }
            }
            HumanName name = new HumanName();
            name.FamilyElement.Add(new FhirString(familyName));
            name.GivenElement.Add(new FhirString(givenName));
            returnPatient.Name = new List<HumanName>();
            returnPatient.Name.Add(name);

            returnPatient.Gender = storedPatient.Gender != null ? storedPatient.Gender : AdministrativeGender.Unknown;
            returnPatient.BirthDateElement = storedPatient.BirthDateElement != null ? storedPatient.BirthDateElement : new Date();
            
            if (HttpContext.StoredFhirResources.ContainsKey(returnPatientKey)) HttpContext.StoredFhirResources.Remove(returnPatientKey);
            HttpContext.StoredFhirResources.Add(returnPatientKey, returnPatient);
        }

        [Given(@"I add the family name ""([^""]*)"" to the patient stored against key ""([^""]*)""")]
        public void GivenIAddTheFamilyNameToThePatientStoredAgainstKey(string familyName, string storedPatientKey)
        {
            Patient storedPatient = (Patient)HttpContext.StoredFhirResources[storedPatientKey];
            foreach (var name in storedPatient.Name) {
                name.FamilyElement.Add(new FhirString(familyName));
            }

        }

        [Given(@"I add the given name ""([^""]*)"" to the patient stored against key ""([^""]*)""")]
        public void GivenIAddTheGivenNameToThePatientStoredAgainstKey(string givenName, string storedPatientKey)
        {
            Patient storedPatient = (Patient)HttpContext.StoredFhirResources[storedPatientKey];
            foreach (var name in storedPatient.Name)
            {
                name.GivenElement.Add(new FhirString(givenName));
            }
        }

        [Given(@"I add a name with given name ""([^""]*)"" and family name ""([^""]*)"" to the patient stored against key ""([^""]*)""")]
        public void GivenIAddTheGivenNameAndFamilyNameToThePatientStoredAgainstKey(string givenName, string familyName, string storedPatientKey)
        {
            Patient storedPatient = (Patient)HttpContext.StoredFhirResources[storedPatientKey];
            var name = new HumanName();
            name.GivenElement.Add(new FhirString(givenName));
            name.FamilyElement.Add(new FhirString(familyName));
            storedPatient.Name.Add(name);
        }

        [Given(@"I add an identifier with no system element to stored patient ""([^""]*)""")]
        public void GivenIAddAnIdentifierWithNoSystemElementToStoredPatient(string storedPatientKey)
        {
            Patient storedPatient = (Patient)HttpContext.StoredFhirResources[storedPatientKey];
            var identifier = new Identifier();
            identifier.Value = "NewIdentifierNoSystem";
            storedPatient.Identifier.Add(identifier);
        }

        [Given(@"I add a telecom element to patient stored against ""([^""]*)""")]
        public void GivenIAddATelecomElementToPatientStoredAgainst(string storedPatientKey)
        {
            Patient storedPatient = (Patient)HttpContext.StoredFhirResources[storedPatientKey];
            storedPatient.Telecom.Add(new ContactPoint(ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Home, "01234567891"));
        }

        [Given(@"I add a address element to patient stored against ""([^""]*)""")]
        public void GivenIAddAAddressElementToPatientStoredAgainst(string storedPatientKey)
        {
            Patient storedPatient = (Patient)HttpContext.StoredFhirResources[storedPatientKey];
            var address = new Address();
            address.LineElement.Add(new FhirString("1 Trevelyan Square"));
            address.LineElement.Add(new FhirString("Boar Lane"));
            address.CityElement = new FhirString("Leeds");
            address.PostalCode = "LS1 6AE";
            storedPatient.Address.Add(address);
        }

        [Given(@"I add a active element to patient stored against ""([^""]*)""")]
        public void GivenIAddAActiveElementToPatientStoredAgainst(string storedPatientKey)
        {
            Patient storedPatient = (Patient)HttpContext.StoredFhirResources[storedPatientKey];
            storedPatient.Active = true;
        }

        [Given(@"I add a deceased element to patient stored against ""([^""]*)""")]
        public void GivenIAddADeceasedElementToPatientStoredAgainst(string storedPatientKey)
        {
            Patient storedPatient = (Patient)HttpContext.StoredFhirResources[storedPatientKey];
            storedPatient.Deceased = new FhirBoolean(false);
        }
        
        [Given(@"I add a marital element to patient stored against ""([^""]*)""")]
        public void GivenIAddAMaritalElementToPatientStoredAgainst(string storedPatientKey)
        {
            Patient storedPatient = (Patient)HttpContext.StoredFhirResources[storedPatientKey];
            storedPatient.MaritalStatus = new CodeableConcept("http://hl7.org/fhir/v3/MaritalStatus", "M");
        }

        [Given(@"I add a births element to patient stored against ""([^""]*)""")]
        public void GivenIAddABirthsElementToPatientStoredAgainst(string storedPatientKey)
        {
            Patient storedPatient = (Patient)HttpContext.StoredFhirResources[storedPatientKey];
            storedPatient.MultipleBirth = new FhirBoolean(true);
        }
        
        [Given(@"I add a photo element to patient stored against ""([^""]*)""")]
        public void GivenIAddAPhotoElementToPatientStoredAgainst(string storedPatientKey)
        {
            Patient storedPatient = (Patient)HttpContext.StoredFhirResources[storedPatientKey];
            var attachment = new Attachment();
            attachment.Url = "Test Photo Element";
            storedPatient.Photo.Add(attachment);
        }

        [Given(@"I add a contact element to patient stored against ""([^""]*)""")]
        public void GivenIAddAContactElementToPatientStoredAgainst(string storedPatientKey)
        {
            Patient storedPatient = (Patient)HttpContext.StoredFhirResources[storedPatientKey];
            var contact = new Patient.ContactComponent();
            contact.Name = new HumanName();
            contact.Name.GivenElement.Add(new FhirString("TestGiven"));
            contact.Name.FamilyElement.Add(new FhirString("TestFamily"));
            storedPatient.Contact.Add(contact);
        }

        [Given(@"I add a animal element to patient stored against ""([^""]*)""")]
        public void GivenIAddAAnimalElementToPatientStoredAgainst(string storedPatientKey)
        {
            Patient storedPatient = (Patient)HttpContext.StoredFhirResources[storedPatientKey];
            storedPatient.Animal = new Patient.AnimalComponent();
            storedPatient.Animal.Species = new CodeableConcept("AllSpecies", "Human");
        }

        [Given(@"I add a communication element to patient stored against ""([^""]*)""")]
        public void GivenIAddACommunicationElementToPatientStoredAgainst(string storedPatientKey)
        {
            Patient storedPatient = (Patient)HttpContext.StoredFhirResources[storedPatientKey];
            var com = new Patient.CommunicationComponent();
            com.Language = new CodeableConcept("https://tools.ietf.org/html/bcp47", "en");
            storedPatient.Communication.Add(com);
        }
        
        [Given(@"I add a careprovider element to patient stored against ""([^""]*)""")]
        public void GivenIAddACareProviderElementToPatientStoredAgainst(string storedPatientKey)
        {
            Patient storedPatient = (Patient)HttpContext.StoredFhirResources[storedPatientKey];
            var reference = new ResourceReference();
            reference.Display = "Test Care Provider";
            storedPatient.CareProvider.Add(reference);
        }

        [Given(@"I add a managingorg element to patient stored against ""([^""]*)""")]
        public void GivenIAddAManagingOrgElementToPatientStoredAgainst(string storedPatientKey)
        {
            Patient storedPatient = (Patient)HttpContext.StoredFhirResources[storedPatientKey];
            var reference = new ResourceReference();
            reference.Display = "Test Managing Org";
            storedPatient.ManagingOrganization = reference;
        }

        [Given(@"I add a link element to patient stored against ""([^""]*)""")]
        public void GivenIAddALinkElementToPatientStoredAgainst(string storedPatientKey)
        {
            Patient storedPatient = (Patient)HttpContext.StoredFhirResources[storedPatientKey];
            var reference = new ResourceReference();
            reference.Display = "Test Care Provider";
            var link = new Patient.LinkComponent();
            link.Other = reference;
            link.Type = Patient.LinkType.Refer;
            storedPatient.Link.Add(link);
        }

        [Then(@"the bundle should contain a registration status")]
        public void ThenTheBundleShouldContainARegistrationStatus()
        {
            foreach (EntryComponent entry in ((Bundle)FhirContext.FhirResponseResource).Entry)
            {
                if (entry.Resource.ResourceType.Equals(ResourceType.Patient))
                {
                    Patient patient = (Patient)entry.Resource;
                    bool regTypePresent = false;
                    foreach (Extension ext in patient.Extension)
                    {
                        string url = ext.Url.ToString();
                        if (url == "http://fhir.nhs.net/StructureDefinition/extension-registration-status-1")
                        {
                            regTypePresent = true;
                            ext.Value.ShouldNotBeNull();
                        }
                    }
                    regTypePresent.ShouldBe(true);
                }
            }
        }


        [Then(@"the bundle should contain a registration period")]
        public void ThenTheBundleShouldContainARegistrationPeriod()
        {
            foreach (EntryComponent entry in ((Bundle)FhirContext.FhirResponseResource).Entry)
            {
                if (entry.Resource.ResourceType.Equals(ResourceType.Patient))
                {
                    Patient patient = (Patient)entry.Resource;
                    bool regTypePresent = false;
                    foreach (Extension ext in patient.Extension)
                    {
                        string url = ext.Url.ToString();
                        if (url == "http://fhir.nhs.net/StructureDefinition/extension-registration-period-1")
                        {
                            regTypePresent = true;
                            ext.Value.ShouldNotBeNull();
                        }
                    }
                    regTypePresent.ShouldBe(true);
                    
                }
            }
        }

        [Then(@"the response bundle should contain a patient resource which contains atleast a single NHS number identifier matching patient stored against key ""([^""]*)""")]
        public void ThenTheResponseBundleShouldContainAPatientResourceWhichContainsAtleastASingleNHSNumberIdentifier(string storedPatientKey)
        {
            Patient storedPatient = (Patient)HttpContext.StoredFhirResources[storedPatientKey];
            string storedPatientNHSNumber = null;
            foreach (Identifier identifier in storedPatient.Identifier) {
                if (identifier.System != null && string.Equals(identifier.System, FhirConst.IdentifierSystems.kNHSNumber)) {
                    storedPatientNHSNumber = identifier.Value;
                }
            }
            foreach (EntryComponent entry in ((Bundle)FhirContext.FhirResponseResource).Entry)
            {
                if (entry.Resource.ResourceType.Equals(ResourceType.Patient))
                {
                    int nhsNumberIdentifierCount = 0;
                    string patientNHSNumber = null;
                    Patient patient = (Patient)entry.Resource;
                    foreach (Identifier identifier in patient.Identifier)
                    {
                        if (identifier.System != null && string.Equals(identifier.System, FhirConst.IdentifierSystems.kNHSNumber))
                        {
                            identifier.Value.ShouldNotBeNullOrEmpty("The NHS Number identifier must have a value element.");
                            patientNHSNumber = identifier.Value;
                            nhsNumberIdentifierCount++;
                        }
                    }
                    nhsNumberIdentifierCount.ShouldBe(1, "The returned Patient Resource should contain a single NHS Number identifier");
                    if (storedPatientNHSNumber != null)
                    {
                        storedPatientNHSNumber.ShouldBe(patientNHSNumber, "The patient NHS Number does not match the created patient NHS number");
                    }
                }
            }

        }
        
        [Then(@"the response bundle should contain a patient resource which contains exactly 1 family name matching the patient stored against key ""([^""]*)""")]
        public void ThenTheResponseBundleShouldContainAPatientResourceWhichContainsExactly1FamilyName(string storedPatientKey)
        {
            Patient storedPatient = (Patient)HttpContext.StoredFhirResources[storedPatientKey];
            string storedFamilyName = "";
            foreach (HumanName name in storedPatient.Name)
            {
                foreach (var familyname in name.Family)
                {
                    storedFamilyName = familyname;
                }
            }
            foreach (EntryComponent entry in ((Bundle)FhirContext.FhirResponseResource).Entry)
            {
                if (entry.Resource.ResourceType.Equals(ResourceType.Patient))
                {
                    Patient patient = (Patient)entry.Resource;
                    patient.Name.Count.ShouldBe(1, "There should be a single name element within the returned patient resource");
                    foreach (HumanName name in patient.Name)
                    {
                        name.Family.ShouldNotBeNull();
                        int count = 0;
                        foreach (var familyname in name.Family)
                        {
                            familyname.ShouldBe(storedFamilyName, "Returned patient family name does not match created patient family name", StringCompareShould.IgnoreCase);
                            count++;
                        }
                        count.ShouldBe(1, "The returned Patient Resource should contain a single family name");
                    }
                    
                }
            }
        }

     
        [Then(@"the response bundle should contain a patient resource which contains exactly 1 given name matching the patient stored against key ""([^""]*)""")]
        public void ThenTheResponseBundleShouldContainAPatientResourceWhichContainsExactly1GivenName(string storedPatientKey)
        {
            Patient storedPatient = (Patient)HttpContext.StoredFhirResources[storedPatientKey];
            string storedGivenName = "";
            foreach (HumanName name in storedPatient.Name)
            {
                foreach (var givenname in name.Given)
                {
                    storedGivenName = givenname;
                }
            }
            foreach (EntryComponent entry in ((Bundle)FhirContext.FhirResponseResource).Entry)
            {
                if (entry.Resource.ResourceType.Equals(ResourceType.Patient))
                {
                    Patient patient = (Patient)entry.Resource;
                    patient.Name.Count.ShouldBe(1, "There should be a single name element within the returned patient resource");
                    foreach (HumanName name in patient.Name)
                    {
                        name.Given.ShouldNotBeNull();
                        int count = 0;
                        foreach (var givenname in name.Given)
                        {
                            givenname.ShouldBe(storedGivenName, "Returned patient given name does not match created patient family name", StringCompareShould.IgnoreCase);
                            count++;
                        }
                        count.ShouldBe(1, "The returned Patient Resource should contain a single given name");
                    }
                }
            }
        }

        [Then(@"the response bundle should contain a patient resource which contains exactly 1 gender element matching the patient stored against key ""([^""]*)""")]
        public void ThenTheResponseBundleShouldContainAPatientResourceWhichContainsExactly1GenderElement(string storedPatientKey)
        {
            Patient storedPatient = (Patient)HttpContext.StoredFhirResources[storedPatientKey];
            foreach (EntryComponent entry in ((Bundle)FhirContext.FhirResponseResource).Entry)
            {
                if (entry.Resource.ResourceType.Equals(ResourceType.Patient))
                {
                    Patient patient = (Patient)entry.Resource;
                    patient.Gender.ShouldNotBeNull("The patient resource should contain a gender element");
                    patient.Gender.ShouldBe(storedPatient.Gender, "The returned patient gender does not match the creted patient gender");
                }
            }
        }

        [Then(@"the response bundle should contain a patient resource which contains exactly 1 birthDate element matching the patient stored against key ""([^""]*)""")]
        public void ThenTheResponseBundleShouldContainAPatientResourceWhichContainsExactly1BirthDateElement(string storedPatientKey)
        {
            Patient storedPatient = (Patient)HttpContext.StoredFhirResources[storedPatientKey];
            foreach (EntryComponent entry in ((Bundle)FhirContext.FhirResponseResource).Entry)
            {
                if (entry.Resource.ResourceType.Equals(ResourceType.Patient))
                {
                    Patient patient = (Patient)entry.Resource;
                    patient.BirthDate.ShouldNotBeNull();
                    patient.BirthDate.ShouldBe(storedPatient.BirthDate, "The returned patient DOB does not match the creted patient DOB");
                }
            }
        }
        
        [When(@"I send a gpc.registerpatient to create patient stored against key ""([^""]*)""")]
        public void ISendAGpcRegisterPatientToCreatepatientStoredAgainstKey(string storedPatientKey)
        {
            IRegisterPatientStoredAgainstKeyWithURL(storedPatientKey, "/Patient/$gpc.registerpatient");
        }

        [When(@"I register patient stored against key ""(.*)"" with url ""(.*)""")]
        public void IRegisterPatientStoredAgainstKeyWithURL(string storedPatientKey, string url)
        {
            Patient patient = (Patient)HttpContext.StoredFhirResources[storedPatientKey];
            FhirContext.FhirRequestParameters.Add("registerPatient", patient);
            IRegisterPatientWithURL(url);
        }

        [When(@"I send a gpc.registerpatient to create patient")]
        public void ISendAGPCRegisterPatientToCreatePatient()
        {
            IRegisterPatientWithURL("/Patient/$gpc.registerpatient");
        }

        [When(@"I register patient with url ""(.*)""")]
        public void IRegisterPatientWithURL(string url)
        {
            string body = null;
            if (HttpContext.RequestContentType.Contains("xml"))
            {
                body = FhirSerializer.SerializeToXml(FhirContext.FhirRequestParameters);
            }
            else
            {
                body = FhirSerializer.SerializeToJson(FhirContext.FhirRequestParameters);
            }
            HttpSteps.RestRequest(Method.POST, url, body);
        }

        [When(@"I register Patient stored against key ""(.*)"" using JSON but change the patient resource type to INVALIDRESOURCE")]
        public void IRegisterPatientStoredAgainstKeyUsingJSONButChangeThePatientResourceTypeToINVaLIDRESOURCE(string storedPatientKey)
        {
            Resource patient = HttpContext.StoredFhirResources[storedPatientKey];
            string patientString = FhirSerializer.SerializeToJson(patient);
            patientString = FhirHelper.ChangeResourceTypeString(patientString, "INVALIDRESOURCE");
            string body = "{\"resourceType\":\"Parameters\",\"parameter\":[{\"name\":\"registerPatient\",\"resource\":" + patientString + "}]}";
            HttpSteps.RestRequest(Method.POST, "/Patient/$gpc.registerpatient", body);
        }

        [When(@"I register Patient stored against key ""(.*)"" using JSON but add an additional invalid field to the patient resource")]
        public void IRegisterPatientStoredAgainstKeyUsingJSONButAddAnAdditionalInvalidFieldToThepatientResource(string storedPatientKey)
        {
            Resource patient = HttpContext.StoredFhirResources[storedPatientKey];
            string patientString = FhirSerializer.SerializeToJson(patient);
            patientString = FhirHelper.AddInvalidFieldToResourceJson(patientString);
            string body = "{\"resourceType\":\"Parameters\",\"parameter\":[{\"name\":\"registerPatient\",\"resource\":" + patientString + "}]}";
            HttpSteps.RestRequest(Method.POST, "/Patient/$gpc.registerpatient", body);
        }

        [When(@"I register Patient stored against key ""(.*)"" using JSON but change the bundle resource type to INVALIDRESOURCE")]
        public void IRegisterPatientStoredAgainstKeyUsingJSONButChangeTheBundleResourceTypeToINVaLIDRESOURCE(string storedPatientKey)
        {
            Resource patient = HttpContext.StoredFhirResources[storedPatientKey];
            FhirContext.FhirRequestParameters.Add("registerPatient", patient);
            string body = FhirSerializer.SerializeToJson(FhirContext.FhirRequestParameters);
            body = FhirHelper.ChangeResourceTypeString(body, "INVALIDRESOURCE");
            HttpSteps.RestRequest(Method.POST, "/Patient/$gpc.registerpatient", body);
        }

        [Then(@"the response location header should resolve to a patient resource with matching details to stored patient ""([^""]*)""")]
        public void ThenTheResponseLocationHeaderShouldResolveToAPatientResourceWithMatchingDetailsToStoredPatient(string storedPatientKey)
        {
            string patientResourceLocationHeader = HttpContext.RequestHeaders.GetHeaderValue(HttpConst.Headers.kLocation);
            patientResourceLocationHeader.ShouldNotBeNullOrEmpty();
            Patient returnedResource = (Patient)HttpSteps.getReturnedResourceForRelativeURL("urn:nhs:names:services:gpconnect:fhir:rest:read:patient", patientResourceLocationHeader);
            returnedResource.GetType().ShouldBe(typeof(Patient));
            Patient storedPatient = (Patient)HttpContext.StoredFhirResources[storedPatientKey];
            returnedResource.Name.Count.ShouldBe(storedPatient.Name.Count);
            // Check names match in resources
            foreach (var returnedName in returnedResource.Name)
            {
                foreach (var storedName in storedPatient.Name)
                {
                    foreach (var givenName in storedName.Given)
                    {
                        returnedName.Given.ShouldContain(givenName, "The create patient name is not in the returned patient when read from the resource location.");
                    }
                    foreach (var familyName in storedName.Family)
                    {
                        returnedName.Family.ShouldContain(familyName, "The create patient name is not in the returned patient when read from the resource location.");
                    }
                }
            }
            // Check DOB matches
            returnedResource.BirthDate.ShouldBe(storedPatient.BirthDate);
            // Check Gender matches
            returnedResource.Gender.ShouldBe(storedPatient.Gender);
        }

        [Given(@"I get the next Patient to register and store it")]
        public void GetTheNextPatientToRegisterAndStoreIt()
        {
            var registerPatients = GlobalContext.RegisterPatients;

            foreach (var registerPatient in registerPatients)
            {
                _patientSteps.GetThePatientForPatientNhsNumber(registerPatient.SPINE_NHS_NUMBER);

                var entries = FhirContext.Entries;

                if (!entries.Any())
                {
                    var name = new HumanName
                    {
                        FamilyElement = new List<FhirString> {new FhirString(registerPatient.NAME_FAMILY)},
                        GivenElement = new List<FhirString> {new FhirString(registerPatient.NAME_GIVEN)}
                    };

                    var patientToRegister = new Patient
                    {
                        BirthDateElement = new Date(registerPatient.DOB),
                        Name = new List<HumanName>
                        {
                            name
                        },
                        Identifier = new List<Identifier>
                        {
                            new Identifier(FhirConst.IdentifierSystems.kNHSNumber, registerPatient.SPINE_NHS_NUMBER)
                        }
                    };

                    switch (registerPatient.GENDER)
                    {
                        case "MALE":
                            patientToRegister.Gender = AdministrativeGender.Male;
                            break;
                        case "FEMALE":
                            patientToRegister.Gender = AdministrativeGender.Female;
                            break;
                        case "OTHER":
                            patientToRegister.Gender = AdministrativeGender.Other;
                            break;
                        case "UNKNOWN":
                            patientToRegister.Gender = AdministrativeGender.Unknown;
                            break;
                    }


                    HttpContext.StoredPatient = patientToRegister;

                    return;
                }
            }
        }

        [Given(@"I set the stored Patient Registration Period to ""([^""]*)""")]
        public void SetTheStorePatientRegistrationPeriodTo(string startDate)
        {
            var registrationPeriod = new Extension
            {
                Url = "http://fhir.nhs.net/StructureDefinition/extension-registration-period-1",
                Value = new Period {Start = startDate }
                
            };

            HttpContext.StoredPatient.Extension.Add(registrationPeriod);
        }

        [Given(@"I set the stored Patient Registration Status to ""([^""]*)""")]
        public void SetTheStorePatientRegistrationStatusTo(string code)
        {
            var codableConcept = new CodeableConcept
            {
                Coding = new List<Coding>
                {
                    new Coding { Code = code }
                }
            };

            var registrationStatus = new Extension
            {
                Url = "http://fhir.nhs.net/StructureDefinition/extension-registration-status-1",
                Value = codableConcept
            };

            HttpContext.StoredPatient.Extension.Add(registrationStatus);
        }

        [Given(@"I set the stored Patient Registration Type to ""([^""]*)""")]
        public void SetTheStorePatientRegistrationTypeTo(string code)
        {
            var codableConcept = new CodeableConcept
            {
                Coding = new List<Coding>
                {
                    new Coding { Code = code }
                }
            };

            var registrationType = new Extension
            {
                Url = "http://fhir.nhs.net/StructureDefinition/extension-registration-type-1",
                Value = codableConcept
            };

            HttpContext.StoredPatient.Extension.Add(registrationType);
        }
    }
}
