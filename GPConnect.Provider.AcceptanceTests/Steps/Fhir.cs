﻿using TechTalk.SpecFlow;
using GPConnect.Provider.AcceptanceTests.tools;
using Shouldly;
using System;
using System.Collections.Generic;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Serialization;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using NUnit.Framework;

namespace GPConnect.Provider.AcceptanceTests.Steps
{

    [Binding]
    public class Fhir : TechTalk.SpecFlow.Steps
    {
        private readonly ScenarioContext _scenarioContext;
        private HeaderController _headerController;
        private JwtHelper _jwtHelper;

        public Fhir(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _headerController = HeaderController.Instance;
            _jwtHelper = JwtHelper.Instance;
        }
        
        // FHIR Operation Steps

        [Given(@"I author a request for the ""(.*)"" care record section for patient with NHS Number ""(.*)""")]
        public void IAuthorARequestForTheCareRecordSection(string recordSectionCode, string nhsNumber)
        {
            var parameters = new Parameters();
            parameters.Add("nhsNumber", new Identifier("http://fhir.nhs.net/Id/nhs-number", nhsNumber));
            parameters.Add("recordSection", new CodeableConcept("http://fhir.nhs.net/ValueSet/gpconnect-record-section-1-0", recordSectionCode));
            _scenarioContext.Set(parameters, "fhirRequestParameters");

            Given(@"I set the JWT requested scope to ""patient/*.read""");
            And(@"I set the JWT requested record patient NHS number to """ + nhsNumber + "\"");
        }

        [When(@"I request the FHIR ""(.*)"" Patient Type operation")]
        public void IRequestTheFHIROperation(string operation)
        {
            string httpProtocol = _scenarioContext.Get<bool>("useTLS") ? "https://" : "http://";
            string spineProxyUrl = _scenarioContext.Get<bool>("useSpineProxy") ? spineProxyUrl = httpProtocol + _scenarioContext.Get<string>("spineProxyUrl") + ":" + _scenarioContext.Get<string>("spineProxyPort") + "/" : "";
            string serverUrl = httpProtocol + _scenarioContext.Get<string>("serverUrl") + ":" + _scenarioContext.Get<string>("serverPort") + _scenarioContext.Get<string>("fhirServerFhirBase");

            Console.WriteLine("SpineProxyURL = " + spineProxyUrl);
            Console.WriteLine("ServerURL = " + serverUrl);

            var preferredFormat = ResourceFormat.Json;
            if (!_headerController.getHeaderValue("Accept").Equals("application/json+fhir"))
            {
                preferredFormat = ResourceFormat.Xml;
            }
            var fhirClient = new FhirClient(spineProxyUrl + serverUrl)
            {
                PreferredFormat = preferredFormat
            };
            fhirClient.OnBeforeRequest += (sender, args) =>
            {
                // Add Headers
                foreach (var header in _headerController.getRequestHeaders())
                {
                    Console.WriteLine("Header - {0} -> {1}", header.Key, header.Value);
                    if (header.Key != "Accept")
                        args.RawRequest.Headers.Add(header.Key, header.Value);
                }

                if (_scenarioContext.Get<bool>("sendClientCert"))
                {
                    try
                    {
                        X509Certificate2 clientCertificate = _scenarioContext.Get<X509Certificate2>("clientCertificate");
                        args.RawRequest.ClientCertificates.Add(clientCertificate);
                    }
                    catch (KeyNotFoundException e)
                    {
                        // No client certificate found in scenario context
                        Console.WriteLine("No client certificate found in scenario context");
                    }
                }

            };
            fhirClient.OnAfterResponse += (sender, args) =>
            {
                _scenarioContext.Set(fhirClient.LastResponse.StatusCode, "responseStatusCode");
                Console.Out.WriteLine("Response StatusCode={0}", fhirClient.LastResponse.StatusCode);
                _scenarioContext.Set(fhirClient.LastResponse.ContentType, "responseContentType");
                Console.Out.WriteLine("Response ContentType={0}", fhirClient.LastResponse.ContentType);
            };
            _scenarioContext.Set(fhirClient, "fhirClient");

            try
            {
                var fhirResource = fhirClient.TypeOperation<Patient>(operation, _scenarioContext.Get<Parameters>("fhirRequestParameters"));
                _scenarioContext.Set(fhirResource, "fhirResource");
                var fhirResponse = FhirSerializer.SerializeResourceToJson(fhirResource);
                _scenarioContext.Set(fhirResponse, "responseBody");
                Console.Out.WriteLine("Response Content={0}", fhirResponse);
            }
            catch (Exception e) {
                Console.WriteLine("Operation Error = " + e.StackTrace);
            }
        }

        // Response Validation Steps

        [Then(@"the response body should be FHIR JSON")]
        public void ThenTheResponseBodyShouldBeFHIRJSON()
        {
            _scenarioContext.Get<string>("responseContentType").ShouldStartWith("application/json+fhir");
            Console.Out.WriteLine("Response ContentType={0}", _scenarioContext.Get<string>("responseContentType"));
            _scenarioContext.Set(JObject.Parse(_scenarioContext.Get<string>("responseBody")), "responseJSON");
        }

        [Then(@"the response body should be FHIR XML")]
        public void ThenTheResponseBodyShouldBeFHIRXML()
        {
            _scenarioContext.Get<string>("responseContentType").ShouldStartWith("application/xml+fhir");
            Console.Out.WriteLine("Response ContentType={0}", _scenarioContext.Get<string>("responseContentType"));
            _scenarioContext.Set(JObject.Parse(_scenarioContext.Get<string>("responseBody")), "responseJSON");
        }

        [Then(@"the JSON value ""(.*)"" should be ""(.*)""")]
        public void ThenTheJSONValueShouldBe(string key, string value)
        {
            var json = _scenarioContext.Get<JObject>("responseJSON");
            Console.Out.WriteLine("Json Key={0} Value={1} Expect={2}", key, json[key], value);
            json[key].ShouldBe(value);
        }

        [Then(@"the JSON array ""([^""]*)"" should contain ""([^""]*)""")]
        public void ThenTheJSONArrayShouldContain(string key, string value)
        {
            var json = _scenarioContext.Get<JObject>("responseJSON");
            Console.WriteLine("Array " + json[key] + "should contain " + value);
            var passed = false;
            foreach (var entry in json[key]) {
                if (String.Equals(entry.Value<string>(), value)) {
                    passed = true;
                    break;
                }
            }
            passed.ShouldBeTrue();
        }

        [Then(@"the JSON array ""([^""]*)"" should contain ""([^""]*)"" or ""([^""]*)""")]
        public void ThenTheJSONArrayShouldContain(string key, string value1, string value2)
        {
            var json = _scenarioContext.Get<JObject>("responseJSON");
            Console.WriteLine("Array " + json[key] + "should contain " + value1 + " or " + value2);
            var passed = false;
            foreach (var entry in json[key])
            {
                if (String.Equals(entry.Value<string>(), value1) || String.Equals(entry.Value<string>(), value2))
                {
                    passed = true;
                    break;
                }
            }
            passed.ShouldBeTrue();
        }

    }
}
