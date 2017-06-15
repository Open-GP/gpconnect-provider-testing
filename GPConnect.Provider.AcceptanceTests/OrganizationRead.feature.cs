﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.1.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace GPConnect.Provider.AcceptanceTests
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("OrganizationRead")]
    [NUnit.Framework.CategoryAttribute("organization")]
    public partial class OrganizationReadFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "OrganizationRead.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "OrganizationRead", null, ProgrammingLanguage.CSharp, new string[] {
                        "organization"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 4
#line 5
 testRunner.Given("I have the test ods codes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Organization Read successful request")]
        [NUnit.Framework.TestCaseAttribute("ORG1", new string[0])]
        [NUnit.Framework.TestCaseAttribute("ORG2", new string[0])]
        [NUnit.Framework.TestCaseAttribute("ORG3", new string[0])]
        public virtual void OrganizationReadSuccessfulRequest(string organization, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Organization Read successful request", exampleTags);
#line 7
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 8
 testRunner.Given(string.Format("I get organization \"{0}\" id and save it as \"ORG1ID\"", organization), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:organization" +
                    "\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.When("I get organization \"ORG1ID\" and use the id to make a get request to the url \"Orga" +
                    "nization\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 13
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
  testRunner.And("the response should be an Organization resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
  testRunner.And("the returned resource shall contains a logical id", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Organization read invalid request invalid id")]
        [NUnit.Framework.TestCaseAttribute("1@", new string[0])]
        [NUnit.Framework.TestCaseAttribute("9i", new string[0])]
        [NUnit.Framework.TestCaseAttribute("40-9", new string[0])]
        public virtual void OrganizationReadInvalidRequestInvalidId(string invalidId, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Organization read invalid request invalid id", exampleTags);
#line 22
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 23
 testRunner.Given("I get organization \"ORG1\" id and save it as \"ORG1ID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 24
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 25
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:organization" +
                    "\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.When(string.Format("I make a GET request for a organization using an invalid id of \"{0}\"", invalidId), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 27
 testRunner.Then("the response status code should be \"404\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Organization read invalid request invalid URL")]
        [NUnit.Framework.TestCaseAttribute("Organizations", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Organization!", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Organization2", new string[0])]
        public virtual void OrganizationReadInvalidRequestInvalidURL(string invalidURL, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Organization read invalid request invalid URL", exampleTags);
#line 34
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 35
 testRunner.Given("I get organization \"ORG1\" id and save it as \"ORG1ID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 36
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 37
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:organization" +
                    "\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
 testRunner.When(string.Format("I get organization \"ORG1ID\" and use the id to make a get request to the url \"{0}\"" +
                        "", invalidURL), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 39
 testRunner.Then("the response status code should be \"400\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Organization read failure due to missing header")]
        [NUnit.Framework.TestCaseAttribute("Ssp-TraceID", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Ssp-From", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Ssp-To", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Ssp-InteractionId", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Authorization", new string[0])]
        public virtual void OrganizationReadFailureDueToMissingHeader(string header, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Organization read failure due to missing header", exampleTags);
#line 46
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 47
 testRunner.Given("I get organization \"ORG1\" id and save it as \"ORG1ID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 48
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 49
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:organization" +
                    "\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
  testRunner.And(string.Format("I do not send header \"{0}\"", header), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
 testRunner.When("I get organization \"ORG1ID\" and use the id to make a get request to the url \"Orga" +
                    "nization\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 52
 testRunner.Then("the response status code should be \"400\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 53
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
  testRunner.And("the response should be a OperationOutcome resource with error code \"BAD_REQUEST\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Organization read failure with incorrect interaction id")]
        [NUnit.Framework.TestCaseAttribute("urn:nhs:names:services:gpconnect:fhir:rest:read:practitioner3", new string[0])]
        [NUnit.Framework.TestCaseAttribute("urn:nhs:names:services:gpconnect:fhir:rest:read:practitioners", new string[0])]
        [NUnit.Framework.TestCaseAttribute("urn:nhs:names:services:gpconnect:fhir:operation:gpc.getcarerecord", new string[0])]
        [NUnit.Framework.TestCaseAttribute("", new string[0])]
        [NUnit.Framework.TestCaseAttribute("null", new string[0])]
        public virtual void OrganizationReadFailureWithIncorrectInteractionId(string interactionId, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Organization read failure with incorrect interaction id", exampleTags);
#line 63
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 64
 testRunner.Given("I get organization \"ORG1\" id and save it as \"ORG1ID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 65
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 66
  testRunner.And(string.Format("I am performing the \"{0}\" interaction", interactionId), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
 testRunner.When("I get organization \"ORG1ID\" and use the id to make a get request to the url \"Orga" +
                    "nization\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 68
 testRunner.Then("the response status code should be \"400\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 69
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
  testRunner.And("the response should be a OperationOutcome resource with error code \"BAD_REQUEST\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Organization read _format parameter only")]
        [NUnit.Framework.TestCaseAttribute("application/json+fhir", "JSON", new string[0])]
        [NUnit.Framework.TestCaseAttribute("application/xml+fhir", "XML", new string[0])]
        public virtual void OrganizationRead_FormatParameterOnly(string parameter, string bodyFormat, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Organization read _format parameter only", exampleTags);
#line 79
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 80
 testRunner.Given("I get organization \"ORG1\" id and save it as \"ORG1ID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 81
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 82
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:organization" +
                    "\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 83
  testRunner.And(string.Format("I add the parameter \"_format\" with the value \"{0}\"", parameter), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 84
 testRunner.When("I get organization \"ORG1ID\" and use the id to make a get request to the url \"Orga" +
                    "nization\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 85
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 86
  testRunner.And(string.Format("the response body should be FHIR {0}", bodyFormat), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 87
  testRunner.And("the response should be an Organization resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Organization read accept header and _format")]
        [NUnit.Framework.TestCaseAttribute("application/json+fhir", "application/json+fhir", "JSON", new string[0])]
        [NUnit.Framework.TestCaseAttribute("application/json+fhir", "application/xml+fhir", "XML", new string[0])]
        [NUnit.Framework.TestCaseAttribute("application/xml+fhir", "application/json+fhir", "JSON", new string[0])]
        [NUnit.Framework.TestCaseAttribute("application/xml+fhir", "application/xml+fhir", "XML", new string[0])]
        public virtual void OrganizationReadAcceptHeaderAnd_Format(string header, string parameter, string bodyFormat, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Organization read accept header and _format", exampleTags);
#line 93
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 94
 testRunner.Given("I get organization \"ORG2\" id and save it as \"ORG2ID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 95
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 96
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:organization" +
                    "\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
  testRunner.And(string.Format("I set the Accept header to \"{0}\"", header), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 98
  testRunner.And(string.Format("I add the parameter \"_format\" with the value \"{0}\"", parameter), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
 testRunner.When("I get organization \"ORG2ID\" and use the id to make a get request to the url \"Orga" +
                    "nization\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 100
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 101
  testRunner.And(string.Format("the response body should be FHIR {0}", bodyFormat), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 102
  testRunner.And("the response should be an Organization resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 103
  testRunner.And("the returned resource shall contains a logical id", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Conformance profile supports the Organization read operation")]
        public virtual void ConformanceProfileSupportsTheOrganizationReadOperation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Conformance profile supports the Organization read operation", ((string[])(null)));
#line 111
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 112
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 113
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:metadata\" in" +
                    "teraction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 114
 testRunner.When("I make a GET request to \"/metadata\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 115
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 116
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 117
  testRunner.And("the conformance profile should contain the \"Organization\" resource with a \"read\" " +
                    "interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Organization read check meta data profile and version id")]
        public virtual void OrganizationReadCheckMetaDataProfileAndVersionId()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Organization read check meta data profile and version id", ((string[])(null)));
#line 119
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 120
 testRunner.Given("I get organization \"ORG1\" id and save it as \"ORG1ID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 121
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 122
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:organization" +
                    "\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 123
 testRunner.When("I get organization \"ORG1ID\" and use the id to make a get request to the url \"Orga" +
                    "nization\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 124
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 125
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 126
  testRunner.And("the response should be an Organization resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 127
  testRunner.And("the organization resource it should contain meta data profile and version id", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Organization read organization contains identifier it is valid")]
        public virtual void OrganizationReadOrganizationContainsIdentifierItIsValid()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Organization read organization contains identifier it is valid", ((string[])(null)));
#line 129
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 130
 testRunner.Given("I get organization \"ORG3\" id and save it as \"ORG3ID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 131
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 132
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:organization" +
                    "\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 133
 testRunner.When("I get organization \"ORG3ID\" and use the id to make a get request to the url \"Orga" +
                    "nization\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 134
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 135
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 136
  testRunner.And("the response should be an Organization resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 137
  testRunner.And("if the organization resource contains an identifier it is valid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Organization read organization contains valid partOf element with a valid referen" +
            "ce")]
        public virtual void OrganizationReadOrganizationContainsValidPartOfElementWithAValidReference()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Organization read organization contains valid partOf element with a valid referen" +
                    "ce", ((string[])(null)));
#line 139
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 140
 testRunner.Given("I get organization \"ORG1\" id and save it as \"ORG1ID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 141
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 142
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:organization" +
                    "\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 143
 testRunner.When("I get organization \"ORG1ID\" and use the id to make a get request to the url \"Orga" +
                    "nization\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 144
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 145
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 146
  testRunner.And("the response should be an Organization resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 147
  testRunner.And("if the organization resource contains a partOf reference it is valid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Organization read organization contains valid Type element it must contain code s" +
            "ystem and display")]
        public virtual void OrganizationReadOrganizationContainsValidTypeElementItMustContainCodeSystemAndDisplay()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Organization read organization contains valid Type element it must contain code s" +
                    "ystem and display", ((string[])(null)));
#line 149
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 150
 testRunner.Given("I get organization \"ORG2\" id and save it as \"ORG2ID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 151
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 152
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:organization" +
                    "\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 153
 testRunner.When("I get organization \"ORG2ID\" and use the id to make a get request to the url \"Orga" +
                    "nization\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 154
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 155
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 156
  testRunner.And("the response should be an Organization resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 157
  testRunner.And("if the organization resource contains type it is valid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Organization read response should contain ETag header")]
        public virtual void OrganizationReadResponseShouldContainETagHeader()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Organization read response should contain ETag header", ((string[])(null)));
#line 159
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 160
 testRunner.Given("I get organization \"ORG1\" id and save it as \"ORG1ID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 161
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 162
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:organization" +
                    "\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 163
 testRunner.When("I get organization \"ORG1ID\" and use the id to make a get request to the url \"Orga" +
                    "nization\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 164
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 165
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 166
  testRunner.And("the response should be an Organization resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 167
  testRunner.And("the response should contain the ETag header matching the resource version", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("VRead of current resource should return resource")]
        public virtual void VReadOfCurrentResourceShouldReturnResource()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("VRead of current resource should return resource", ((string[])(null)));
#line 169
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 170
 testRunner.Given("I get organization \"ORG3\" id and save it as \"ORGID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 171
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 172
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:organization" +
                    "\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 173
 testRunner.When("I perform a vread for organizaiton \"ORGID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 174
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 175
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 176
  testRunner.And("the response should be an Organization resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("VRead of non existant version should return an error")]
        public virtual void VReadOfNonExistantVersionShouldReturnAnError()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("VRead of non existant version should return an error", ((string[])(null)));
#line 178
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 179
 testRunner.Given("I get organization \"ORG2\" id and save it as \"storedOrganization\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 180
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 181
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:organization" +
                    "\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 182
 testRunner.When("I perform an organization vread with version \"NotARealVersionId\" for organization" +
                    " stored against key \"storedOrganization\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 183
 testRunner.Then("the response status code should be \"404\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 184
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 185
  testRunner.And("the response should be a OperationOutcome resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("If-None-Match read organization on a matching version")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        public virtual void If_None_MatchReadOrganizationOnAMatchingVersion()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("If-None-Match read organization on a matching version", new string[] {
                        "ignore"});
#line 188
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("If-None-Match read organization on a non matching version")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        public virtual void If_None_MatchReadOrganizationOnANonMatchingVersion()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("If-None-Match read organization on a non matching version", new string[] {
                        "ignore"});
#line 192
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("If provider supports versioning test that once a resource is updated that the old" +
            " version can be retrieved")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        [NUnit.Framework.CategoryAttribute("Manual")]
        public virtual void IfProviderSupportsVersioningTestThatOnceAResourceIsUpdatedThatTheOldVersionCanBeRetrieved()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("If provider supports versioning test that once a resource is updated that the old" +
                    " version can be retrieved", new string[] {
                        "Manual",
                        "ignore"});
#line 197
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Check that the optional fields are populated in the Organization resource if they" +
            " are available in the provider system")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        [NUnit.Framework.CategoryAttribute("Manual")]
        public virtual void CheckThatTheOptionalFieldsArePopulatedInTheOrganizationResourceIfTheyAreAvailableInTheProviderSystem()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check that the optional fields are populated in the Organization resource if they" +
                    " are available in the provider system", new string[] {
                        "Manual",
                        "ignore"});
#line 201
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
