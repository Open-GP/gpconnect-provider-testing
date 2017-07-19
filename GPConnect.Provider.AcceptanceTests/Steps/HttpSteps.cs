﻿using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using GPConnect.Provider.AcceptanceTests.Constants;
using GPConnect.Provider.AcceptanceTests.Context;
using GPConnect.Provider.AcceptanceTests.Helpers;
using GPConnect.Provider.AcceptanceTests.Logger;
using Newtonsoft.Json.Linq;
using RestSharp;
using Shouldly;
using TechTalk.SpecFlow;
using Hl7.Fhir.Serialization;
using Hl7.Fhir.Model;
using System.Text;
using RestSharp.Extensions.MonoHttp;

// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable InconsistentNaming

namespace GPConnect.Provider.AcceptanceTests.Steps
{
    using System.Linq;
    using Enum;
    using Factories;

    [Binding]
    public class HttpSteps : TechTalk.SpecFlow.Steps
    {
        private readonly HttpContext HttpContext;
        private readonly FhirContext FhirContext;
        private readonly JwtHelper JwtHelper;
        private readonly SecuritySteps _securitySteps;
        // Constructor

        public HttpSteps(HttpContext httpContext, FhirContext fhirContext, JwtHelper jwtHelper, SecuritySteps securitySteps)
        {
            Log.WriteLine("HttpSteps() Constructor");
            HttpContext = httpContext;
            FhirContext = fhirContext;
            JwtHelper = jwtHelper;
            _securitySteps = securitySteps;
        }

        internal void HttpRequest(object post, string v1, object p, bool v2)
        {
            throw new NotImplementedException();
        }

        // Before Scenarios

        [BeforeScenario(Order = 3)]
        public void LoadAppConfig()
        {
            HttpContext.LoadAppConfig();
        }

        [BeforeScenario(Order = 3)]
        public void ClearHeaders()
        {
            HttpContext.RequestHeaders.Clear();
        }

        [BeforeScenario(Order = 3)]
        public void ClearParameters()
        {
            HttpContext.RequestParameters.ClearParameters();
        }

        // Security Validation Steps

        [Then(@"the response status code should indicate authentication failure")]
        public void ThenTheResponseStatusCodeShouldIndicateAuthenticationFailure()
        {
            HttpContext.ResponseStatusCode.ShouldBe(HttpStatusCode.Forbidden);
            Log.WriteLine("Response HttpStatusCode={0}", HttpContext.ResponseStatusCode);
        }

        [Then(@"the response status code should be ""(.*)""")]
        public void ThenTheResponseStatusCodeShouldBe(string statusCode)
        {
            ((int)HttpContext.ResponseStatusCode).ToString().ShouldBe(statusCode);
            Log.WriteLine("Response HttpStatusCode should be {0} but was {1}", statusCode, HttpContext.ResponseStatusCode);
        }

        // Provider Configuration Steps

        [Given(@"I am using the default server")]
        public void GivenIAmUsingTheDefaultServer()
        {
            // Clear down headers for pre-steps which get resources for use within the test scenario
            HttpContext.RequestHeaders.Clear();
            HttpContext.RequestUrl = "";
            HttpContext.RequestParameters.ClearParameters();
            HttpContext.RequestBody = null;
            FhirContext.FhirRequestParameters = new Parameters();

            HttpContext.RequestParameters.ClearParameters();

            HttpContext.ResponseTimeInMilliseconds = -1;
            //HttpContext.ResponseStatusCode = null;
            HttpContext.ResponseContentType = null;
            HttpContext.ResponseBody = null;
            HttpContext.ResponseHeaders.Clear();
            FhirContext.FhirResponseResource = null;

            // Load The Default Settings From The App.config File
            HttpContext.LoadAppConfig();

            Given(@"I configure server certificate and ssl");
            And($@"I am using ""{FhirConst.ContentTypes.kJsonFhir}"" to communicate with the server");
            And(@"I am generating a random message trace identifier");
            And($@"I am accredited system ""{HttpContext.ConsumerASID}""");
            And($@"I am connecting to accredited system ""{HttpContext.ProviderASID}""");
            And(@"I set the default JWT");
        }

        [Given(@"I am connecting to server on port ""([^\s]*)""")]
        public void GivenIAmConnectingToServerOnPort(string serverPort)
        {
            HttpContext.FhirServerPort = serverPort;
        }

        // Http Header Configuration Steps

        [Given(@"I am using ""(.*)"" to communicate with the server")]
        public void GivenIAmUsingToCommunicateWithTheServer(string requestContentType)
        {
            HttpContext.RequestHeaders.ReplaceHeader(HttpConst.Headers.kAccept, requestContentType);
            HttpContext.RequestContentType = requestContentType;
        }

        [Given(@"I set ""(.*)"" request header to resource stored ""(.*)""")]
        public void GivenISetRequestHeaderToResourceStored(string headerName, string kstoredValueKey)
        {
            GivenISetRequestHeaderTo(headerName, HttpContext.resourceNameStored[kstoredValueKey]);
        }

        [Given(@"I set ""(.*)"" request header to ""(.*)""")]
        public void GivenISetRequestHeaderTo(string headerName, string headerValue)
        {
            HttpContext.RequestHeaders.ReplaceHeader(headerName, headerValue);
        }

        [Given(@"I set ""(.*)"" request header to created appointment version")]
        public void GivenISetRequestHeaderToVersion(string headerKey)
        {
            Resource value = HttpContext.CreatedAppointment;
            HttpContext.RequestHeaders.ReplaceHeader(headerKey, "W/\"" + value.VersionId + "\"");
        }

        [Given(@"I set If-Match request header to ""(.*)""")]
        public void GivenISetRequestHeaderToNotStored(string headerValue)
        {
            HttpContext.RequestHeaders.ReplaceHeader("If-Match", "W/\"" + headerValue + "\"");
        }

        [Given(@"I am accredited system ""(.*)""")]
        public void GivenIAmAccreditedSystem(string fromASID)
        {
            HttpContext.RequestHeaders.ReplaceHeader(HttpConst.Headers.kSspFrom, fromASID);
        }

        [Given(@"I am performing the ""(.*)"" interaction")]
        public void GivenIAmPerformingTheInteraction(string interactionId)
        {
            HttpContext.RequestHeaders.ReplaceHeader(HttpConst.Headers.kSspInteractionId, interactionId);
        }

        [Given(@"I am connecting to accredited system ""(.*)""")]
        public void GivenIConnectingToAccreditedSystem(string toASID)
        {
            HttpContext.RequestHeaders.ReplaceHeader(HttpConst.Headers.kSspTo, toASID);
        }

        [Given(@"I am generating a random message trace identifier")]
        public void GivenIAmGeneratingARandomMessageTraceIdentifier()
        {
            HttpContext.RequestHeaders.ReplaceHeader(HttpConst.Headers.kSspTraceId, Guid.NewGuid().ToString(""));
        }

        [Given(@"I am generating an organization JWT header")]
        public void GivenIAmGeneratingAnOrganizationAuthorizationHeader()
        {
            HttpContext.RequestHeaders.ReplaceHeader(HttpConst.Headers.kAuthorization, HttpContext.Jwt.GetBearerToken());
        }

        [Given(@"I do not send header ""(.*)""")]
        public void GivenIDoNotSendHeader(string headerKey)
        {
            HttpContext.RequestHeaders.RemoveHeader(headerKey);
        }

        [Given(@"I ask for the contents to be gzip encoded")]
        public void GivenIAskForTheContentsToBeGZipEncoded()
        {
            HttpContext.RequestHeaders.AddHeader(HttpConst.Headers.kAcceptEncoding, "gzip");
        }

        // Http Request Steps

        [Given(@"I set the request content type to ""(.*)""")]
        public void GivenISetTheRequestTypeTo(string requestContentType)
        {
            HttpContext.RequestContentType = requestContentType;
        }

        [Given(@"I set the Accept header to ""(.*)""")]
        public void GivenISetTheAcceptHeaderTo(string acceptContentType)
        {
            HttpContext.RequestHeaders.ReplaceHeader(HttpConst.Headers.kAccept, acceptContentType);
        }

        [Given(@"I set the Prefer header to ""(.*)""")]
        public void GivenISetThePreferHeaderTo(string preferHeaderContent)
        {
            HttpContext.RequestHeaders.ReplaceHeader(HttpConst.Headers.kPrefer, preferHeaderContent);
        }

        [Given(@"I set the If-None-Match header to ""(.*)""")]
        public void GivenISetTheIfNoneMatchheaderHeaderTo(string ifNoneMatchHeaderContent)
        {
            HttpContext.RequestHeaders.ReplaceHeader(HttpConst.Headers.kIfNoneMatch, ifNoneMatchHeaderContent);
        }

        [Given(@"I set the If-Match header to ""([^""]*)""")]
        public void SetTheIfMatchHeaderTo(string value)
        {
            HttpContext.RequestHeaders.ReplaceHeader(HttpConst.Headers.kIfMatch, value);
        }

        [Given(@"I set the If-None-Match header with the version from the stored ""([^""]*)"" Resource")]
        public void GivenISetTheIfNoneMatchHeaderWithTheVersionFromTheStoredResource(string resourceName)
        {
            Resource resource = null;
            HttpContext.StoredFhirResources.TryGetValue(resourceName, out resource);
            if(resource != null && resource.Id != null) {
                HttpContext.RequestHeaders.ReplaceHeader(HttpConst.Headers.kIfNoneMatch, "W/\""+resource.Id+"\"");
            }
        }

        [Given(@"I add the parameter ""(.*)"" with the value ""(.*)""")]
        public void GivenIAddTheParameterWithTheValue(string parameterName, string parameterValue)
        {
            HttpContext.RequestParameters.AddParameter(parameterName, parameterValue);
        }

        [Given(@"I add the parameter ""(.*)"" with the value or sitecode ""(.*)""")]
        public void GivenIAddTheParameterWithTheSiteCode(string parameterName, string parameterValue)
        {
            if (parameterValue.Contains("http://fhir.nhs.net/Id/ods-site-code"))
            {
                var result = parameterValue.LastIndexOf('|');
                var siteCode = parameterValue.Substring(parameterValue.LastIndexOf('|') + 1);
                string mappedSiteValue = GlobalContext.OdsCodeMap[siteCode];
                HttpContext.RequestParameters.AddParameter(parameterName, "http://fhir.nhs.net/Id/ods-site-code|" + mappedSiteValue);
                return;
            }

            HttpContext.RequestParameters.AddParameter(parameterName, parameterValue);
        }

        [Given(@"I add the parameter ""([^""]*)"" with system ""([^""]*)"" for patient ""([^""]*)""")]
        public void GivenIAddTheParameterWithSystemForPatient(string parameterName, string parameterSystem, string patient)
        {
            HttpContext.RequestParameters.AddParameter(parameterName, parameterSystem + "|" + GlobalContext.PatientNhsNumberMap[patient]);
        }

        [When(@"I make a GET request to ""(.*)""")]
        public void WhenIMakeAGETRequestTo(string relativeUrl)
        {
            RestRequest(Method.GET, relativeUrl);
        }

        [When(@"I make a POST request to ""(.*)""")]
        public void WhenIMakeAPOSTRequestTo(string relativeUrl)
        {
            RestRequest(Method.POST, relativeUrl);
        }

        [When(@"I make a PUT request to ""(.*)""")]
        public void WhenIMakeAPUTRequestTo(string relativeUrl)
        {
            RestRequest(Method.PUT, relativeUrl);
        }

        [When(@"I make a PATCH request to ""(.*)""")]
        public void WhenIMakeAPATCHRequestTo(string relativeUrl)
        {
            RestRequest(Method.PATCH, relativeUrl);
        }

        [When(@"I make a DELETE request to ""(.*)""")]
        public void WhenIMakeADELETERequestTo(string relativeUrl)
        {
            RestRequest(Method.DELETE, relativeUrl);
        }

        [When(@"I make a OPTIONS request to ""(.*)""")]
        public void WhenIMakeAOPTIONSRequestTo(string relativeUrl)
        {
            RestRequest(Method.OPTIONS, relativeUrl);
        }

        public Resource getReturnedResourceForRelativeURL(string interactionID, string relativeUrl)
        {
            // Store current state
            var preRequestHeaders = HttpContext.RequestHeaders.GetRequestHeaders();
            HttpContext.RequestHeaders.Clear();
            var preRequestUrl = HttpContext.RequestUrl;
            HttpContext.RequestUrl = "";
            var preRequestParameters = HttpContext.RequestParameters;
            HttpContext.RequestParameters.ClearParameters();
            var preRequestMethod = HttpContext.RequestMethod;
            var preRequestContentType = HttpContext.RequestContentType;
            var preRequestBody = HttpContext.RequestBody;
            HttpContext.RequestBody = null;

            var preResponseTimeInMilliseconds = HttpContext.ResponseTimeInMilliseconds;
            var preResponseStatusCode = HttpContext.ResponseStatusCode;
            var preResponseContentType = HttpContext.ResponseContentType;
            var preResponseBody = HttpContext.ResponseBody;
            var preResponseHeaders = HttpContext.ResponseHeaders;
            HttpContext.ResponseHeaders.Clear();

            JObject preResponseJSON = null;
            try
            {
                preResponseJSON = HttpContext.ResponseJSON;
            }
            catch (Exception) { }
            XDocument preResponseXML = null;
            try
            {
                preResponseXML = HttpContext.ResponseXML;
            }
            catch (Exception) { }

            var preFhirResponseResource = FhirContext.FhirResponseResource;

            // Setup configuration
            Given($@"I am using the default server");

            And($@"I set the default JWT");
            And($@"I am performing the ""{interactionID}"" interaction");
            if (relativeUrl.Contains("Patient"))
            {
               string removedSlash = relativeUrl.Replace(@"/", "");
                string patientName = removedSlash.ToLower();
                And($@"I set the JWT requested record NHS number to config patient ""{patientName}""");
                And($@"I set the JWT requested scope to ""patient/*.read""");
            }
            // Make Call
            RestRequest(Method.GET, relativeUrl);

            // Check the response
            HttpContext.ResponseStatusCode.ShouldBe(HttpStatusCode.OK);
            Then($@"the response body should be FHIR JSON"); // Create resource object from returned JSON
            var returnResource = FhirContext.FhirResponseResource; // Store the found resource for use in the calling system

            // Restore state
            HttpContext.RequestHeaders.SetRequestHeaders(preRequestHeaders);
            HttpContext.RequestUrl = preRequestUrl;
            HttpContext.RequestParameters = preRequestParameters;
            HttpContext.RequestMethod = preRequestMethod;
            HttpContext.RequestContentType = preRequestContentType;
            HttpContext.RequestBody = preRequestBody;

            HttpContext.ResponseTimeInMilliseconds = preResponseTimeInMilliseconds;
            HttpContext.ResponseStatusCode = preResponseStatusCode;
            HttpContext.ResponseContentType = preResponseContentType;
            HttpContext.ResponseBody = preResponseBody;
            HttpContext.ResponseHeaders = preResponseHeaders;
            HttpContext.ResponseJSON = preResponseJSON;
            HttpContext.ResponseXML = preResponseXML;
            FhirContext.FhirResponseResource = preFhirResponseResource;

            return returnResource;
        }

        // Rest Request Helper

        public void RestRequest(Method method, string relativeUrl, string body = null)
        {
            var timer = new System.Diagnostics.Stopwatch();

            Log.WriteLine("{0} relative URL = {1}", method, relativeUrl);

            // Save The Request Details
            HttpContext.RequestMethod = method.ToString();
            HttpContext.RequestUrl = relativeUrl;
            HttpContext.RequestBody = body;

            // Build The Rest Request
            var restClient = new RestClient(HttpContext.EndpointAddress);

            // Setup The Web Proxy
            if (HttpContext.UseWebProxy)
            {
                restClient.Proxy = new WebProxy(new Uri(HttpContext.WebProxyAddress, UriKind.Absolute));
            }

            // Setup The Client Certificate
            if (HttpContext.SecurityContext.SendClientCert)
            {
                var clientCert = HttpContext.SecurityContext.ClientCert;
                if (restClient.ClientCertificates == null)
                {
                    restClient.ClientCertificates = new X509CertificateCollection();
                }
                restClient.ClientCertificates.Clear();
                restClient.ClientCertificates.Add(clientCert);
            }

            // Remove default handlers to stop it sending default Accept header
            restClient.ClearHandlers();

            // Add Parameters
            String requestParamString = "?";
            foreach (var parameter in HttpContext.RequestParameters.GetRequestParameters())
            {
                Log.WriteLine("Parameter - {0} -> {1}", parameter.Key, parameter.Value);
                requestParamString = requestParamString + HttpUtility.UrlEncode(parameter.Key, Encoding.UTF8) + "=" + HttpUtility.UrlEncode(parameter.Value, Encoding.UTF8) + "&";
            }
            requestParamString = requestParamString.Substring(0, requestParamString.Length - 1);

            var restRequest = new RestRequest(relativeUrl + requestParamString, method);

            // Set the Content-Type header
            restRequest.AddParameter(HttpContext.RequestContentType, body, ParameterType.RequestBody);
            HttpContext.RequestHeaders.AddHeader(HttpConst.Headers.kContentType, HttpContext.RequestContentType);

            // Add The Headers
            foreach (var header in HttpContext.RequestHeaders.GetRequestHeaders())
            {
                Log.WriteLine("Header - {0} -> {1}", header.Key, header.Value);
                restRequest.AddHeader(header.Key, header.Value);
            }

            // Execute The Request
            IRestResponse restResponse = null;
            try
            {
                // Start The Performance Timer Running
                timer.Start();

                // Perform The Rest Request
                restResponse = restClient.Execute(restRequest);
            }
            catch (Exception e)
            {
                Log.WriteLine(e.StackTrace);
            }
            finally
            {
                // Always Stop The Performance Timer Running
                timer.Stop();
            }

            // Save The Time Taken To Perform The Request
            HttpContext.ResponseTimeInMilliseconds = timer.ElapsedMilliseconds;

            // TODO Save The Error Message And Exception Details
            Log.WriteLine("Error Message = " + restResponse.ErrorMessage);
            Log.WriteLine("Error Exception = " + restResponse.ErrorException);

            // Save The Response Details
            HttpContext.ResponseStatusCode = restResponse.StatusCode;
            HttpContext.ResponseContentType = restResponse.ContentType;
            HttpContext.ResponseBody = restResponse.Content;

            HttpContext.ResponseHeaders.Clear();
            foreach (var parameter in restResponse.Headers)
            {
                HttpContext.ResponseHeaders.Add(parameter.Name, (string)parameter.Value);
            }
            
        }

        private void HttpRequest(HttpMethod method, string relativeUrl, string body = null, bool decompressGzip = false)
        {
            var timer = new System.Diagnostics.Stopwatch();

            // Save The Request Details
            HttpContext.RequestMethod = method.ToString();
            HttpContext.RequestUrl = relativeUrl;
            HttpContext.RequestBody = body;

            WebRequestHandler handler = new WebRequestHandler();

            if (decompressGzip)
            {
                handler.AutomaticDecompression = DecompressionMethods.GZip;
            }

            // Setup The Client Certificate
            if (HttpContext.SecurityContext.SendClientCert)
            {
                var clientCert = HttpContext.SecurityContext.ClientCert;
                handler.ClientCertificates.Add(clientCert);
            }

            // Setup The Web Proxy
            if (HttpContext.UseWebProxy)
            {
                handler.Proxy = new WebProxy(new Uri(HttpContext.WebProxyAddress, UriKind.Absolute));
            }

            var sspAddress = HttpContext.UseSpineProxy ? HttpContext.SpineProxyAddress + "/" : string.Empty;
            string baseUrl = sspAddress + HttpContext.Protocol + HttpContext.FhirServerUrl + ":" + HttpContext.FhirServerPort + HttpContext.FhirServerFhirBase;
            // Move the forward slash or the HttpClient will remove everything after the port number
            if (baseUrl[baseUrl.Length - 1] != '/')
            {
                baseUrl = baseUrl + "/";
            }
            if (relativeUrl[0] == '/')
            {
                relativeUrl = relativeUrl.Substring(1);
            }

            // Build The Request
            var httpClient = new HttpClient(handler);
            httpClient.BaseAddress = new Uri(baseUrl);

            HttpRequestMessage requestMessage = new HttpRequestMessage(method, relativeUrl);
            if (body != null)
            {
                requestMessage.Content = new StringContent(body, System.Text.Encoding.UTF8, HttpContext.RequestContentType);
            }

            // Add The Headers
            HttpContext.RequestHeaders.AddHeader(HttpConst.Headers.kContentType, HttpContext.RequestContentType);
            foreach (var header in HttpContext.RequestHeaders.GetRequestHeaders())
            {
                try
                {
                    Log.WriteLine("Header - {0} -> {1}", header.Key, header.Value);
                    requestMessage.Headers.Add(header.Key, header.Value);
                }
                catch (Exception e)
                {
                    Log.WriteLine("Could not add header: " + header.Key + e);
                }
            }

            // Start The Performance Timer Running
            timer.Start();

            // Perform The Http Request
            var result = httpClient.SendAsync(requestMessage).ConfigureAwait(false).GetAwaiter().GetResult();

            // Always Stop The Performance Timer Running
            timer.Stop();

            // Save The Time Taken To Perform The Request
            HttpContext.ResponseTimeInMilliseconds = timer.ElapsedMilliseconds;

            // Save The Response Details
            HttpContext.ResponseStatusCode = result.StatusCode;
            HttpContext.ResponseContentType = result.Content.Headers.ContentType.MediaType;
            using (StreamReader reader = new StreamReader(result.Content.ReadAsStreamAsync().Result))
            {
                HttpContext.ResponseBody = reader.ReadToEnd();
            }

            // Add headers
            foreach (var headerKey in result.Headers)
            {
                foreach (var headerKeyValues in headerKey.Value)
                {
                    HttpContext.ResponseHeaders.Add(headerKey.Key, headerKeyValues);
                    Log.WriteLine("Header - " + headerKey.Key + " : " + headerKeyValues);
                }
            }
            foreach (var header in result.Content.Headers)
            {
                foreach (var headerValues in header.Value)
                {
                    HttpContext.ResponseHeaders.Add(header.Key, headerValues);
                    Log.WriteLine("Header - " + header.Key + " : " + headerValues);
                }
            }
            
        }

        [When(@"I send a gpc.getcarerecord operation request with invalid resource type payload")]
        public void ISendAGpcGetcarerecordOperationRequestWithInvalidResourceTypePayload()
        {
            var parameterPayload = FhirHelper.ChangeResourceTypeString(FhirSerializer.SerializeToJson(FhirContext.FhirRequestParameters), FhirConst.Resources.kInvalidResourceType);
            RestRequest(Method.POST, "/Patient/$gpc.getcarerecord", parameterPayload);
        }

        [When(@"I send a gpc.getcarerecord operation request WITH payload")]
        public void ISendAGpcGetcarerecordOperationRequestWithPayload()
        {
            HttpRequest(HttpMethod.Post, "/Patient/$gpc.getcarerecord", FhirSerializer.SerializeToJson(FhirContext.FhirRequestParameters), true);
        }

        [When(@"I send a gpc.getcarerecord operation request WITH payload but not decompressed")]
        public void ISendAGpcGetcarerecordOperationRequestWithPayloadButNotDecompressed()
        {
            HttpRequest(HttpMethod.Post, "/Patient/$gpc.getcarerecord", FhirSerializer.SerializeToJson(FhirContext.FhirRequestParameters), false);
        }

        [When(@"I send a metadata request but not decompressed")]
        public void ISendAMetadataRequestButNotDecompressed()
        {
            HttpRequest(HttpMethod.Get, "/metadata", null, false);
        }

        [When(@"I send a metadata request and decompressed")]
        public void ISendAMetadataRequestAndDecompressed()
        {
            HttpRequest(HttpMethod.Get, "/metadata", null, true);
        }

        // Response Validation Steps

        [Then(@"the response status code should indicate success")]
        public void ThenTheResponseStatusCodeShouldIndicateSuccess()
        {
            HttpContext.ResponseStatusCode.ShouldBe(HttpStatusCode.OK);
        }

        [Then(@"the response status code should indicate created")]
        public void ThenTheResponseStatusCodeShouldIndicateCreated()
        {
            HttpContext.ResponseStatusCode.ShouldBe(HttpStatusCode.Created);
        }

        [Then(@"the response status code should indicate failure")]
        public void ThenTheResponseStatusCodeShouldIndicateFailure()
        {
            HttpContext.ResponseStatusCode.ShouldNotBe(HttpStatusCode.OK);
        }

        [Then(@"the response status code should indicate unsupported media type error")]
        public void ThenTheResponseShouldIndicateUnsupportedMediaTypeError()
        {
            HttpContext.ResponseStatusCode.ShouldBe(HttpStatusCode.UnsupportedMediaType);
            Log.WriteLine("Response HttpStatusCode should be {0} but was {1}", HttpStatusCode.UnsupportedMediaType, HttpContext.ResponseStatusCode);
        }

        [Then(@"the response body should be JSON")]
        public void ThenTheResponseBodyShouldBeJSON()
        {
            HttpContext.ResponseContentType.ShouldStartWith(HttpConst.ContentTypes.kJson);
            HttpContext.ResponseJSON = JObject.Parse(HttpContext.ResponseBody);
            FhirJsonParser fhirJsonParser = new FhirJsonParser();
            FhirContext.FhirResponseResource = fhirJsonParser.Parse<Resource>(HttpContext.ResponseBody);
        }

        [Then(@"the response body should be XML")]
        public void ThenTheResponseBodyShouldBeXML()
        {
            HttpContext.ResponseContentType.ShouldStartWith(HttpConst.ContentTypes.kXml);
            HttpContext.ResponseXML = XDocument.Parse(HttpContext.ResponseBody);
            FhirXmlParser fhirXmlParser = new FhirXmlParser();
            FhirContext.FhirResponseResource = fhirXmlParser.Parse<Resource>(HttpContext.ResponseBody);
        }

        [Then(@"the response should be gzip encoded")]
        public void ThenTheResponseShouldBeGZipEncoded()
        {
            bool gZipHeaderFound = false;
            foreach (var header in HttpContext.ResponseHeaders)
            {
                if (header.Key.Equals(HttpConst.Headers.kContentEncoding, StringComparison.CurrentCultureIgnoreCase) && header.Value.Equals("gzip", StringComparison.CurrentCultureIgnoreCase))
                {
                    gZipHeaderFound = true;
                }
            }
            gZipHeaderFound.ShouldBeTrue();
        }

        [Then(@"the response should be chunked")]
        public void ThenReesponseShouldBeChunked()
        {
            bool chunkedHeaderFound = false;
            foreach (var header in HttpContext.ResponseHeaders)
            {
                if (header.Key.Equals(HttpConst.Headers.kTransferEncoding, StringComparison.CurrentCultureIgnoreCase) && header.Value.Equals("chunked", StringComparison.CurrentCultureIgnoreCase))
                {
                    chunkedHeaderFound = true;
                }
            }
            chunkedHeaderFound.ShouldBeTrue();
        }

        //Hayden
        [Given(@"I configure the default ""(.*)"" request")]
        public void ConfigureRequest(GpConnectInteraction interaction)
        {
            var httpContextFactory = new HttpContextFactory(interaction);

            httpContextFactory.ConfigureHttpContext(HttpContext);
            httpContextFactory.ConfigureFhirContext(FhirContext);

            var jwtFactory = new JwtFactory(interaction);

            jwtFactory.ConfigureJwt(JwtHelper, HttpContext);

            _securitySteps.ConfigureServerCertificatesAndSsl();
        }

        [Given(@"I set the GET request Id to ""([^""]*)""")]
        public void SetTheGetRequestIdTo(string id)
        {
            HttpContext.GetRequestId = id;
        }

        [Given(@"I set the GET request Version Id to ""([^""]*)""")]
        public void SetTheGetRequestVersionIdTo(string versionId)
        {
            HttpContext.GetRequestVersionId = versionId;
        }

        [Given(@"I set the request URL to ""([^""]*)""")]
        public void SetTheRequestUrlTo(string url)
        {
            HttpContext.RequestUrl = url;
        }

        [Given(@"I set the Interaction Id header to ""([^""]*)""")]
        public void SetTheInteractionIdHeaderTo(string interactionId)
        {
            HttpContext.RequestHeaders.ReplaceHeader(HttpConst.Headers.kSspInteractionId, interactionId);
        }

        [Given(@"I set the Read Operation logical identifier used in the request to ""([^""]*)""")]
        public void SetTheReadOperationLogicalIdentifierUsedInTheRequestTo(string logicalId)
        {
            HttpContext.GetRequestId = logicalId;
            HttpContext.RequestUrl = HttpContext.RequestUrl.Substring(0, HttpContext.RequestUrl.LastIndexOf('/') + 1) + HttpContext.GetRequestId;
        }
        
        [Given(@"I set the Read Operation relative path to ""([^""]*)"" and append the resource logical identifier")]
        public void SetTheReadOperationRelativePathToAndAppendTheResourceLogicalIdentifier(string relativePath)
        {
            HttpContext.RequestUrl = relativePath + "/" + HttpContext.GetRequestId;
        }

        [When(@"I make the ""(.*)"" request")]
        public void MakeRequest(GpConnectInteraction interaction)
        {
            var requestFactory = new RequestFactory(interaction);

            requestFactory.ConfigureBody(HttpContext);

            if (!string.IsNullOrEmpty(HttpContext.RequestHeaders.GetHeaderValue(HttpConst.Headers.kAuthorization)))
            {
                HttpContext.RequestHeaders.ReplaceHeader(HttpConst.Headers.kAuthorization, JwtHelper.GetBearerToken());
            }

            HttpRequest();
        }

        [When(@"I make the ""(.*)"" request with an unencoded JWT Bearer Token")]
        public void MakeRequestWithAnUnencodedJwtBearerToken(GpConnectInteraction interaction)
        {
            var requestFactory = new RequestFactory(interaction);

            requestFactory.ConfigureBody(HttpContext);

            HttpContext.RequestHeaders.ReplaceHeader(HttpConst.Headers.kAuthorization, JwtHelper.GetBearerTokenWithoutEncoding());
            HttpRequest();
        }

        [When(@"I make the ""(.*)"" request with invalid Resource type")]
        public void MakeRequestWithInvalidResourceType(GpConnectInteraction interaction)
        {
            var requestFactory = new RequestFactory(interaction);

            requestFactory.ConfigureBody(HttpContext);
            requestFactory.ConfigureInvalidResourceType(HttpContext);

            HttpContext.RequestHeaders.ReplaceHeader(HttpConst.Headers.kAuthorization, JwtHelper.GetBearerToken());
            HttpRequest();
        }

        [When(@"I make the ""(.*)"" request with invalid parameter Resource type")]
        public void MakeRequestWithInvalidParameterResourceType(GpConnectInteraction interaction)
        {
            var requestFactory = new RequestFactory(interaction);
            requestFactory.ConfigureBody(HttpContext);
            requestFactory.ConfigureInvalidParameterResourceType(HttpContext);
            HttpContext.RequestHeaders.ReplaceHeader(HttpConst.Headers.kAuthorization, JwtHelper.GetBearerToken());
            HttpRequest();
        }

        [When(@"I make the ""(.*)"" request with additional field in parameter Resource")]
        public void MakeRequestWithAdditionalFieldInParameterResource(GpConnectInteraction interaction)
        {
            var requestFactory = new RequestFactory(interaction);
            requestFactory.ConfigureBody(HttpContext);
            requestFactory.ConfigureParameterResourceWithAdditionalField(HttpContext);
            HttpContext.RequestHeaders.ReplaceHeader(HttpConst.Headers.kAuthorization, JwtHelper.GetBearerToken());
            HttpRequest();
        }

        private void HttpRequest(bool decompressGzip = false)
        {
            var httpClient = GetHttpClient(decompressGzip);

            var requestMessage = GetHttpRequestMessage();

            var timer = new System.Diagnostics.Stopwatch();

            // Start The Performance Timer Running
            timer.Start();

            // Perform The Http Request
            var result = httpClient.SendAsync(requestMessage).Result;

            // Always Stop The Performance Timer Running
            timer.Stop();

            // Save The Time Taken To Perform The Request
            HttpContext.ResponseTimeInMilliseconds = timer.ElapsedMilliseconds;

            // Save The Response Details
            HttpContext.ResponseStatusCode = result.StatusCode;

            // Some HTTP responses will have no content e.g. 304
            if (result.Content.Headers.ContentType != null)
            {
                HttpContext.ResponseContentType = result.Content.Headers.ContentType.MediaType;
            }

            using (var reader = new StreamReader(result.Content.ReadAsStreamAsync().Result))
            {
                HttpContext.ResponseBody = reader.ReadToEnd();
            }

            ParseResponse();
           
            // Add headers
            foreach (var headerKey in result.Headers)
            {
                foreach (var headerKeyValues in headerKey.Value)
                {
                    HttpContext.ResponseHeaders.Add(headerKey.Key, headerKeyValues);
                    Log.WriteLine("Header - " + headerKey.Key + " : " + headerKeyValues);
                }
            }

            foreach (var header in result.Content.Headers)
            {
                foreach (var headerValues in header.Value)
                {
                    HttpContext.ResponseHeaders.Add(header.Key, headerValues);
                    Log.WriteLine("Header - " + header.Key + " : " + headerValues);
                }
            }
        }

        private HttpRequestMessage GetHttpRequestMessage()
        {
            var queryStringParameters = GetQueryStringParameters();

            var requestMessage = new HttpRequestMessage(HttpContext.HttpMethod, HttpContext.RequestUrl + queryStringParameters);
            if (HttpContext.RequestBody != null)
            {
                requestMessage.Content = new StringContent(HttpContext.RequestBody, Encoding.UTF8, HttpContext.RequestContentType);
            }

            // Add The Headers
            HttpContext.RequestHeaders.AddHeader(HttpConst.Headers.kContentType, HttpContext.RequestContentType);
            foreach (var header in HttpContext.RequestHeaders.GetRequestHeaders())
            {
                try
                {
                    Log.WriteLine("Header - {0} -> {1}", header.Key, header.Value);
                    requestMessage.Headers.Add(header.Key, header.Value);
                }
                catch (Exception e)
                {
                    Log.WriteLine("Could not add header: " + header.Key + e);
                }
            }

            return requestMessage;
        }

        private string GetQueryStringParameters()
        {
            if (!HttpContext.RequestParameters.GetRequestParameters().Any())
            {
                return string.Empty;
            }

            var requestParamString = "?";

            foreach (var parameter in HttpContext.RequestParameters.GetRequestParameters())
            {
                Log.WriteLine("Parameter - {0} -> {1}", parameter.Key, parameter.Value);
                requestParamString = requestParamString + HttpUtility.UrlEncode(parameter.Key, Encoding.UTF8) + "=" + HttpUtility.UrlEncode(parameter.Value, Encoding.UTF8) + "&";
            }

            return requestParamString.Substring(0, requestParamString.Length - 1);
        }

        private void ParseResponse()
        {
            switch (HttpContext.ResponseContentType)
            {
                case FhirConst.ContentTypes.kJsonFhir:
                    HttpContext.ResponseJSON = JObject.Parse(HttpContext.ResponseBody);
                    var jsonParser = new FhirJsonParser();
                    FhirContext.FhirResponseResource = jsonParser.Parse<Resource>(HttpContext.ResponseBody);
                    break;
                case FhirConst.ContentTypes.kXmlFhir:
                    HttpContext.ResponseXML = XDocument.Parse(HttpContext.ResponseBody);
                    var xmlParser = new FhirXmlParser();
                    FhirContext.FhirResponseResource = xmlParser.Parse<Resource>(HttpContext.ResponseBody);
                    break;
            }
        }

        private WebRequestHandler ConfigureHandler(bool decompressGzip)
        {
            var handler = new WebRequestHandler();

            if (decompressGzip)
            {
                handler.AutomaticDecompression = DecompressionMethods.GZip;
            }

            if (HttpContext.SecurityContext.SendClientCert)
            {
                var clientCert = HttpContext.SecurityContext.ClientCert;
                handler.ClientCertificates.Add(clientCert);
            }

            if (HttpContext.UseWebProxy)
            {
                handler.Proxy = new WebProxy(new Uri(HttpContext.WebProxyAddress, UriKind.Absolute));
            }

            return handler;
        }

        private HttpClient GetHttpClient(bool decompressGzip)
        {
            var handler = ConfigureHandler(decompressGzip);

            return new HttpClient(handler)
            {
                BaseAddress = new Uri(HttpContext.BaseUrl)
            };
        }

        [Then(@"the Response should contain the ETag header matching the Resource Version Id")]
        public void TheResponseShouldContainTheETagHeaderMatchingTheResourceVersionId()
        {
            var versionId = FhirContext.FhirResponseResource.VersionId;

            string eTag;
            HttpContext.ResponseHeaders.TryGetValue("ETag", out eTag);

            eTag.ShouldStartWith("W/\"", "The ETag header should start with W/\"");

            eTag.ShouldEndWith(versionId + "\"", "The ETag header should contain the resource version enclosed within speech marks");

            eTag.ShouldBe("W/\"" + versionId + "\"", "The ETag header contains invalid characters");
        }
    }
}
