﻿namespace GPConnect.Provider.AcceptanceTests.Steps
{
    using Constants;
    using Context;
    using Helpers;
    using Logger;
    using TechTalk.SpecFlow;
    using Hl7.Fhir.Model;
    using Enum;
    using Factories;
    using Http;

    [Binding]
    public class HttpSteps : Steps
    {
        private readonly HttpContext _httpContext;
        private readonly JwtHelper _jwtHelper;
        private readonly SecuritySteps _securitySteps;
        private readonly SecurityContext _securityContext;

        public HttpSteps(HttpContext httpContext, JwtHelper jwtHelper, SecuritySteps securitySteps, SecurityContext securityContext)
        {
            Log.WriteLine("HttpSteps() Constructor");
            _httpContext = httpContext;
            _jwtHelper = jwtHelper;
            _securitySteps = securitySteps;
            _securityContext = securityContext;
        }
        
        [Given(@"I configure the default ""(.*)"" request")]
        public void ConfigureRequest(GpConnectInteraction interaction)
        {
            var httpContextFactory = new HttpContextFactory(interaction);

            _httpContext.SetDefaults();

            httpContextFactory.ConfigureHttpContext(_httpContext);

            var jwtFactory = new JwtFactory(interaction);

            jwtFactory.ConfigureJwt(_jwtHelper, _httpContext);

            _securitySteps.ConfigureServerCertificatesAndSsl();
        }

        [When(@"I make the ""(.*)"" request")]
        public void MakeRequest(GpConnectInteraction interaction)
        {
            var requestFactory = new RequestFactory(interaction);

            requestFactory.ConfigureBody(_httpContext);

            if (!string.IsNullOrEmpty(_httpContext.HttpRequestConfiguration.RequestHeaders.GetHeaderValue(HttpConst.Headers.kAuthorization)))
            {
                _httpContext.HttpRequestConfiguration.RequestHeaders.ReplaceHeader(HttpConst.Headers.kAuthorization, _jwtHelper.GetBearerToken());
            }

            var httpRequest = new HttpRequest(_httpContext, _securityContext);

            httpRequest.MakeHttpRequest();
        }

        [When(@"I make the ""(.*)"" request with an unencoded JWT Bearer Token")]
        public void MakeRequestWithAnUnencodedJwtBearerToken(GpConnectInteraction interaction)
        {
            var requestFactory = new RequestFactory(interaction);

            requestFactory.ConfigureBody(_httpContext);

            _httpContext.HttpRequestConfiguration.RequestHeaders.ReplaceHeader(HttpConst.Headers.kAuthorization, _jwtHelper.GetBearerTokenWithoutEncoding());

            var httpRequest = new HttpRequest(_httpContext, _securityContext);

            httpRequest.MakeHttpRequest();
        }

        [When(@"I make the ""(.*)"" request with invalid Resource type")]
        public void MakeRequestWithInvalidResourceType(GpConnectInteraction interaction)
        {
            var requestFactory = new RequestFactory(interaction);

            requestFactory.ConfigureBody(_httpContext);
            requestFactory.ConfigureInvalidResourceType(_httpContext);

            _httpContext.HttpRequestConfiguration.RequestHeaders.ReplaceHeader(HttpConst.Headers.kAuthorization, _jwtHelper.GetBearerToken());

            var httpRequest = new HttpRequest(_httpContext, _securityContext);

            httpRequest.MakeHttpRequest();
        }

        [When(@"I make the ""(.*)"" request with Invalid Additional Field in the Resource")]
        public void MakeRequestWithInvalidAdditionalFieldInTheResource(GpConnectInteraction interaction)
        {
            var requestFactory = new RequestFactory(interaction);

            requestFactory.ConfigureBody(_httpContext);
            requestFactory.ConfigureAdditionalInvalidFieldInResource(_httpContext);

            _httpContext.HttpRequestConfiguration.RequestHeaders.ReplaceHeader(HttpConst.Headers.kAuthorization, _jwtHelper.GetBearerToken());

            var httpRequest = new HttpRequest(_httpContext, _securityContext);

            httpRequest.MakeHttpRequest();
        }

        [When(@"I make the ""(.*)"" request with invalid parameter Resource type")]
        public void MakeRequestWithInvalidParameterResourceType(GpConnectInteraction interaction)
        {
            var requestFactory = new RequestFactory(interaction);
            requestFactory.ConfigureBody(_httpContext);
            requestFactory.ConfigureInvalidParameterResourceType(_httpContext);
            _httpContext.HttpRequestConfiguration.RequestHeaders.ReplaceHeader(HttpConst.Headers.kAuthorization, _jwtHelper.GetBearerToken());

            var httpRequest = new HttpRequest(_httpContext, _securityContext);

            httpRequest.MakeHttpRequest();
        }

        [When(@"I make the ""(.*)"" request with additional field in parameter Resource")]
        public void MakeRequestWithAdditionalFieldInParameterResource(GpConnectInteraction interaction)
        {
            var requestFactory = new RequestFactory(interaction);
            requestFactory.ConfigureBody(_httpContext);
            requestFactory.ConfigureParameterResourceWithAdditionalField(_httpContext);
            _httpContext.HttpRequestConfiguration.RequestHeaders.ReplaceHeader(HttpConst.Headers.kAuthorization, _jwtHelper.GetBearerToken());

            var httpRequest = new HttpRequest(_httpContext, _securityContext);

            httpRequest.MakeHttpRequest();
        }

        public Resource GetResourceForRelativeUrl(GpConnectInteraction gpConnectInteraction, string relativeUrl)
        {
            var httpContext = new HttpContext();
            httpContext.SetDefaults();
            httpContext.HttpRequestConfiguration.SetDefaultHeaders();

            var httpContextFactory = new HttpContextFactory(gpConnectInteraction);
            httpContextFactory.ConfigureHttpContext(httpContext);

            var jwtHelper = new JwtHelper();
            var jwtFactory = new JwtFactory(gpConnectInteraction);

            jwtFactory.ConfigureJwt(jwtHelper, httpContext);

            if (relativeUrl.Contains("Patient"))
            {
                var patient = relativeUrl.ToLower().Replace("/", string.Empty);
                jwtHelper.RequestedPatientNHSNumber = GlobalContext.PatientNhsNumberMap[patient];
            }

            _securitySteps.ConfigureServerCertificatesAndSsl();

            httpContext.HttpRequestConfiguration.RequestUrl = relativeUrl;

            var requestFactory = new RequestFactory(gpConnectInteraction);
            requestFactory.ConfigureBody(httpContext);

            httpContext.HttpRequestConfiguration.RequestHeaders.ReplaceHeader(HttpConst.Headers.kAuthorization, jwtHelper.GetBearerToken());

            var httpRequest = new HttpRequest(httpContext, _securityContext);

            httpRequest.MakeHttpRequest();

            return httpContext.FhirResponse.Resource;
        }
    }
}
