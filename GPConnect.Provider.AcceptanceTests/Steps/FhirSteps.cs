﻿namespace GPConnect.Provider.AcceptanceTests.Steps
{
    using System.Linq;
    using System.Xml.Linq;
    using Constants;
    using Context;
    using Hl7.Fhir.Model;
    using Hl7.Fhir.Serialization;
    using Logger;
    using Newtonsoft.Json.Linq;
    using NUnit.Framework;
    using Shouldly;
    using TechTalk.SpecFlow;

    [Binding]
    public class FhirSteps : Steps
    {
        private readonly HttpContext _httpContext;

        // Constructor
        public FhirSteps(HttpContext httpContext)
        {
            Log.WriteLine("FhirSteps() Constructor");
            _httpContext = httpContext;            
        }

        [Then(@"the response body should be FHIR JSON")]
        public void ThenTheResponseBodyShouldBeFHIRJSON()
        {
            _httpContext.HttpResponse.ContentType.ShouldStartWith(FhirConst.ContentTypes.kJsonFhir);
            Log.WriteLine("Response ContentType={0}", _httpContext.HttpResponse.ContentType);
            _httpContext.HttpResponse.ResponseJSON = JObject.Parse(_httpContext.HttpResponse.Body);
            FhirJsonParser fhirJsonParser = new FhirJsonParser();
            _httpContext.FhirResponse.Resource = fhirJsonParser.Parse<Resource>(_httpContext.HttpResponse.Body);
        }

        [Then(@"the response should be the format FHIR JSON")]
        public void TheResponseShouldBeTheFormatFHIRJSON()
        {
            _httpContext.HttpResponse.ContentType.ShouldStartWith(FhirConst.ContentTypes.kJsonFhir);
        }

        [Then(@"the response should be the format FHIR XML")]
        public void TheResponseShouldBeTheFormatXMLJSON()
        {
            _httpContext.HttpResponse.ContentType.ShouldStartWith(FhirConst.ContentTypes.kXmlFhir);
        }

        [Then(@"the response body should be empty")]
        public void ThenTheResponseBodyShouldBeEmpty()
        {
            _httpContext.HttpResponse.Body.ShouldBeNullOrEmpty("The response should not contain a payload but the response was not null or empty");
        }

        [Then(@"the response body should be FHIR XML")]
        public void ThenTheResponseBodyShouldBeFHIRXML()
        {
            _httpContext.HttpResponse.ContentType.ShouldStartWith(FhirConst.ContentTypes.kXmlFhir);
            Log.WriteLine("Response ContentType={0}", _httpContext.HttpResponse.ContentType);
            // TODO Move XML Parsing Out Of Here
            _httpContext.HttpResponse.ResponseXML = XDocument.Parse(_httpContext.HttpResponse.Body);
            FhirXmlParser fhirXmlParser = new FhirXmlParser();
            _httpContext.FhirResponse.Resource = fhirXmlParser.Parse<Resource>(_httpContext.HttpResponse.Body);
        }

        [Then(@"the response bundle should contain ""([^""]*)"" entries")]
        public void ThenResponseBundleEntryShouldNotBeEmpty(int expectedSize)
        {
            Bundle bundle = _httpContext.FhirResponse.Bundle;
            bundle.Entry.Count.ShouldBe(expectedSize, "The response bundle does not contain the expected number of entries");
        }

        [Then(@"the response bundle entry ""([^""]*)"" should contain element ""([^""]*)""")]
        public void ThenResponseBundleEntryShouldContainElement(string entryResourceType, string jsonPath)
        {
            var resourceEntry = _httpContext.HttpResponse.ResponseJSON.SelectToken($"$.entry[?(@.resource.resourceType == '{entryResourceType}')]");
            resourceEntry.SelectToken(jsonPath).ShouldNotBeNull();
        }

        [Then(@"the response bundle ""([^""]*)"" entries should contain element ""([^""]*)""")]
        public void ThenResponseBundleEntriesShouldContainElement(string entryResourceType, string jsonPath)
        {
            var resourceEntries = _httpContext.HttpResponse.ResponseJSON.SelectTokens($"$.entry[?(@.resource.resourceType == '{entryResourceType}')]");

            foreach (var resourceEntry in resourceEntries)
            {
                resourceEntry.SelectToken(jsonPath).ShouldNotBeNull();
            }
        }

        [Then(@"the response bundle entry ""([^""]*)"" should optionally contain element ""([^""]*)"" and that element should reference a resource in the bundle")]
        public void ThenResponseBundleEntryShouldContainElementAndThatElementShouldReferenceAResourceInTheBundle(string entryResourceType, string jsonPath)
        {
            var resourceEntry = _httpContext.HttpResponse.ResponseJSON.SelectToken($"$.entry[?(@.resource.resourceType == '{entryResourceType}')]");

            if (resourceEntry.SelectToken(jsonPath) != null)
            {
                var internalReference = resourceEntry.SelectToken(jsonPath).Value<string>();
                _httpContext.HttpResponse.ResponseJSON.SelectToken("$.entry[?(@.fullUrl == '" + internalReference + "')]").ShouldNotBeNull();
            }
        }

        [Then(@"the conformance profile should contain the ""([^""]*)"" operation")]
        public void ThenTheConformanceProfileShouldContainTheOperation(string operationName)
        {
            Log.WriteLine("Conformance profile should contain operation = {0}", operationName);
            var passed = false;
            foreach (var rest in _httpContext.HttpResponse.ResponseJSON.SelectToken("rest"))
            {
                foreach (var operation in rest.SelectToken("operation"))
                {
                    if (operationName.Equals(operation["name"].Value<string>()) && operation.SelectToken("definition.reference") != null)
                    {
                        passed = true;
                        break;
                    }
                }
                if (passed) { break; }
            }
            passed.ShouldBeTrue();
        }

       [Then(@"the conformance profile should contain the ""([^""]*)"" resource with a ""([^""]*)"" interaction")]
        public void ThenTheConformanceProfileShouldContainTheResourceWithInteraction(string resourceName, string interaction)
        {
            Log.WriteLine("Conformance profile should contain resource = {0} with interaction = {1}", resourceName, interaction);

            foreach (var rest in _httpContext.HttpResponse.ResponseJSON.SelectToken("rest"))
            {
                foreach (var resource in rest.SelectToken("resource"))
                {
                    if (resourceName.Equals(resource["type"].Value<string>()) && null != resource.SelectToken("interaction[?(@.code == '" + interaction + "')]"))
                    {
                        return;
                    }
                }
            }

            Assert.Fail("No interaction " + interaction + " for " + resourceName + " resource found.");
        }
        
        [Then(@"all search response entities in bundle should contain a logical identifier")]
        public void AllSearchResponseEntitiesShouldContainALogicalIdentifier()
        {
            _httpContext.FhirResponse.Bundle
                .Entry
                .Where(x => string.IsNullOrWhiteSpace(x.Resource.Id))
                .ShouldBeEmpty("Found an empty (or non-existant) logical id");
        }

        [Then(@"the returned resource shall contains a logical id")]
        public void ThenTheReturnedResourceShallContainALogicalId()
        {
            _httpContext.FhirResponse.Resource.Id.ShouldNotBeNullOrEmpty("The returned resource should contain a logical Id but does not.");
        }

        [Then(@"the returned resource shall contain a logical id matching the requested read logical identifier")]
        public void ThenTheReturnedResourceShallContainALogicalIdMatchingTheRequestedReadLogicalIdentifier()
        {
            _httpContext.FhirResponse.Resource.Id.ShouldNotBeNullOrEmpty("The returned resource should contain a logical Id but does not.");
            _httpContext.FhirResponse.Resource.Id.ShouldBe(_httpContext.HttpRequestConfiguration.GetRequestId, "The returned resource logical id did not match the requested id");
        }
    }
}
