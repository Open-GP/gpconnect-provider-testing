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
    [NUnit.Framework.DescriptionAttribute("LocationSearch")]
    [NUnit.Framework.CategoryAttribute("location")]
    public partial class LocationSearchFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "LocationSearch.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "LocationSearch", null, ProgrammingLanguage.CSharp, new string[] {
                        "location"});
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
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("if location contains status elements")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        public virtual void IfLocationContainsStatusElements()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("if location contains status elements", new string[] {
                        "ignore"});
#line 5
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("if location contains description elements")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        public virtual void IfLocationContainsDescriptionElements()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("if location contains description elements", new string[] {
                        "ignore"});
#line 10
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("if location contains address")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        public virtual void IfLocationContainsAddress()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("if location contains address", new string[] {
                        "ignore"});
#line 15
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("if location contains telecom")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        public virtual void IfLocationContainsTelecom()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("if location contains telecom", new string[] {
                        "ignore"});
#line 20
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Location search success")]
        [NUnit.Framework.TestCaseAttribute("SIT1", "1", new string[0])]
        [NUnit.Framework.TestCaseAttribute("SIT2", "2", new string[0])]
        [NUnit.Framework.TestCaseAttribute("SIT3", "8", new string[0])]
        public virtual void LocationSearchSuccess(string value, string entrySize, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Location search success", exampleTags);
#line 25
this.ScenarioSetup(scenarioInfo);
#line 26
 testRunner.Given("I configure the default \"LocationSearch\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 27
  testRunner.And(string.Format("I add a Location Identifier parameter with default System and Value \"{0}\"", value), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
 testRunner.When("I make the \"LocationSearch\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 29
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 30
  testRunner.And("the response should be the format FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
  testRunner.And("the response should be a Bundle resource of type \"searchset\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
  testRunner.And(string.Format("the response bundle should contain \"{0}\" entries", entrySize), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
  testRunner.And("all search response entities in bundle should contain a logical identifier", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
  testRunner.And("if the response bundle contains a location resource it should contain meta data p" +
                    "rofile and version id", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
  testRunner.And("the response bundle Location entries should contain a maximum of one ODS Site Cod" +
                    "e and one other identifier", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
  testRunner.And("the response bundle Location entries should contain a name element", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
  testRunner.And("the response bundle location entries should contain valid system code and display" +
                    " if the PhysicalType coding is included in the resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
  testRunner.And("if the response bundle location entries contain managingOrganization element the " +
                    "reference should exist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
  testRunner.And("if the response bundle location entries contain partOf element the reference shou" +
                    "ld exist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
  testRunner.And("the response bundle location entries should contain system code and display if th" +
                    "e Type coding is included in the resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Location search no entrys found")]
        public virtual void LocationSearchNoEntrysFound()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Location search no entrys found", ((string[])(null)));
#line 47
this.ScenarioSetup(scenarioInfo);
#line 48
 testRunner.Given("I configure the default \"LocationSearch\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 49
  testRunner.And("I add a Location Identifier parameter with default System and Value \"SIT4\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
 testRunner.When("I make the \"LocationSearch\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 51
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 52
  testRunner.And("the response should be a Bundle resource of type \"searchset\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
  testRunner.And("the response bundle should contain \"0\" entries", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Location search failure invalid system")]
        [NUnit.Framework.TestCaseAttribute("http://fhir.nhs.net/Id/ods-site-code9", new string[0])]
        [NUnit.Framework.TestCaseAttribute("http://fhir.nhs.net/Id/sds-role-profile-id", new string[0])]
        [NUnit.Framework.TestCaseAttribute("http://fhir.nh5555555555555555555/555555555555", new string[0])]
        public virtual void LocationSearchFailureInvalidSystem(string system, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Location search failure invalid system", exampleTags);
#line 55
this.ScenarioSetup(scenarioInfo);
#line 56
 testRunner.Given("I configure the default \"LocationSearch\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 57
  testRunner.And(string.Format("I add a Location Identifier parameter with System \"{0}\" and Value \"SIT1\"", system), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
 testRunner.When("I make the \"LocationSearch\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 59
 testRunner.Then("the response status code should be \"400\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 60
  testRunner.And("the response should be a OperationOutcome resource with error code \"INVALID_IDENT" +
                    "IFIER_SYSTEM\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Location search failure missing identifier")]
        public virtual void LocationSearchFailureMissingIdentifier()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Location search failure missing identifier", ((string[])(null)));
#line 67
this.ScenarioSetup(scenarioInfo);
#line 68
 testRunner.Given("I configure the default \"LocationSearch\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 69
 testRunner.When("I make the \"LocationSearch\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 70
 testRunner.Then("the response status code should be \"400\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 71
  testRunner.And("the response should be a OperationOutcome resource with error code \"BAD_REQUEST\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Location search failure due to invalid identifier name")]
        [NUnit.Framework.TestCaseAttribute("IDENTIFIER", new string[0])]
        [NUnit.Framework.TestCaseAttribute("identiffer", new string[0])]
        [NUnit.Framework.TestCaseAttribute("identifiers", new string[0])]
        public virtual void LocationSearchFailureDueToInvalidIdentifierName(string identifier, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Location search failure due to invalid identifier name", exampleTags);
#line 73
this.ScenarioSetup(scenarioInfo);
#line 74
 testRunner.Given("I configure the default \"LocationSearch\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 75
  testRunner.And(string.Format("I add a Location Identifier parameter with parameter name \"{0}\" and Value \"SIT1\"", identifier), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
 testRunner.When("I make the \"LocationSearch\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 77
 testRunner.Then("the response status code should be \"400\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 78
  testRunner.And("the response should be a OperationOutcome resource with error code \"BAD_REQUEST\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Location search parameter order test")]
        [NUnit.Framework.TestCaseAttribute("_format", "application/json+fhir", "identifier", "http://fhir.nhs.net/Id/ods-site-code|SIT1", "JSON", new string[0])]
        [NUnit.Framework.TestCaseAttribute("_format", "application/xml+fhir", "identifier", "http://fhir.nhs.net/Id/ods-site-code|SIT1", "XML", new string[0])]
        [NUnit.Framework.TestCaseAttribute("identifier", "http://fhir.nhs.net/Id/ods-site-code|SIT1", "_format", "application/json+fhir", "JSON", new string[0])]
        [NUnit.Framework.TestCaseAttribute("identifier", "http://fhir.nhs.net/Id/ods-site-code|SIT1", "_format", "application/xml+fhir", "XML", new string[0])]
        public virtual void LocationSearchParameterOrderTest(string parameter1Name, string parameter1, string parameter2Name, string parameter2, string responseFormat, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Location search parameter order test", exampleTags);
#line 85
this.ScenarioSetup(scenarioInfo);
#line 86
 testRunner.Given("I configure the default \"LocationSearch\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 87
  testRunner.And(string.Format("I add the parameter \"{0}\" with the value or sitecode \"{1}\"", parameter1Name, parameter1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 88
  testRunner.And(string.Format("I add the parameter \"{0}\" with the value or sitecode \"{1}\"", parameter2Name, parameter2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 89
 testRunner.When("I make the \"LocationSearch\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 90
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 91
  testRunner.And(string.Format("the response should be the format FHIR {0}", responseFormat), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 92
  testRunner.And("the response should be a Bundle resource of type \"searchset\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 93
  testRunner.And("the response bundle Location entries should contain a maximum of one ODS Site Cod" +
                    "e and one other identifier", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Location Search using the accept header to request response format")]
        [NUnit.Framework.TestCaseAttribute("application/json+fhir", "JSON", new string[0])]
        [NUnit.Framework.TestCaseAttribute("application/xml+fhir", "XML", new string[0])]
        public virtual void LocationSearchUsingTheAcceptHeaderToRequestResponseFormat(string header, string responseFormat, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Location Search using the accept header to request response format", exampleTags);
#line 101
this.ScenarioSetup(scenarioInfo);
#line 102
 testRunner.Given("I configure the default \"LocationSearch\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 103
  testRunner.And("I add a Location Identifier parameter with default System and Value \"SIT3\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 104
  testRunner.And(string.Format("I set the Accept header to \"{0}\"", header), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 105
 testRunner.When("I make the \"LocationSearch\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 106
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 107
  testRunner.And(string.Format("the response should be the format FHIR {0}", responseFormat), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 108
  testRunner.And("the response should be a Bundle resource of type \"searchset\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 109
  testRunner.And("all search response entities in bundle should contain a logical identifier", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 110
  testRunner.And("if the response bundle contains a location resource it should contain meta data p" +
                    "rofile and version id", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 111
  testRunner.And("the response bundle Location entries should contain a maximum of one ODS Site Cod" +
                    "e and one other identifier", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 112
  testRunner.And("the response bundle Location entries should contain a name element", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 113
  testRunner.And("the response bundle should contain \"8\" entries", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Location Search using the _format parameter to request response format")]
        [NUnit.Framework.TestCaseAttribute("application/json+fhir", "JSON", new string[0])]
        [NUnit.Framework.TestCaseAttribute("application/xml+fhir", "XML", new string[0])]
        public virtual void LocationSearchUsingThe_FormatParameterToRequestResponseFormat(string parameter, string responseFormat, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Location Search using the _format parameter to request response format", exampleTags);
#line 119
this.ScenarioSetup(scenarioInfo);
#line 120
 testRunner.Given("I configure the default \"LocationSearch\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 121
  testRunner.And("I add a Location Identifier parameter with default System and Value \"SIT2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 122
  testRunner.And(string.Format("I add the parameter \"_format\" with the value \"{0}\"", parameter), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 123
 testRunner.When("I make the \"LocationSearch\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 124
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 125
  testRunner.And(string.Format("the response should be the format FHIR {0}", responseFormat), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 126
  testRunner.And("the response should be a Bundle resource of type \"searchset\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 127
  testRunner.And("all search response entities in bundle should contain a logical identifier", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 128
  testRunner.And("if the response bundle contains a location resource it should contain meta data p" +
                    "rofile and version id", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 129
  testRunner.And("the response bundle Location entries should contain a maximum of one ODS Site Cod" +
                    "e and one other identifier", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 130
  testRunner.And("the response bundle Location entries should contain a name element", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 131
  testRunner.And("the response bundle should contain \"2\" entries", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Location Search using the accept header and _format parameter to request response" +
            " format")]
        [NUnit.Framework.TestCaseAttribute("application/json+fhir", "application/json+fhir", "JSON", new string[0])]
        [NUnit.Framework.TestCaseAttribute("application/json+fhir", "application/xml+fhir", "XML", new string[0])]
        [NUnit.Framework.TestCaseAttribute("application/xml+fhir", "application/json+fhir", "JSON", new string[0])]
        [NUnit.Framework.TestCaseAttribute("application/xml+fhir", "application/xml+fhir", "XML", new string[0])]
        public virtual void LocationSearchUsingTheAcceptHeaderAnd_FormatParameterToRequestResponseFormat(string header, string parameter, string responseFormat, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Location Search using the accept header and _format parameter to request response" +
                    " format", exampleTags);
#line 137
this.ScenarioSetup(scenarioInfo);
#line 138
 testRunner.Given("I configure the default \"LocationSearch\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 139
  testRunner.And("I add a Location Identifier parameter with default System and Value \"SIT3\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 140
  testRunner.And(string.Format("I set the Accept header to \"{0}\"", header), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 141
  testRunner.And(string.Format("I add the parameter \"_format\" with the value \"{0}\"", parameter), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 142
 testRunner.When("I make the \"LocationSearch\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 143
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 144
  testRunner.And(string.Format("the response should be the format FHIR {0}", responseFormat), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 145
  testRunner.And("the response should be a Bundle resource of type \"searchset\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 146
  testRunner.And("all search response entities in bundle should contain a logical identifier", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 147
  testRunner.And("if the response bundle contains a location resource it should contain meta data p" +
                    "rofile and version id", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 148
  testRunner.And("the response bundle Location entries should contain a maximum of one ODS Site Cod" +
                    "e and one other identifier", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 149
  testRunner.And("the response bundle Location entries should contain a name element", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 150
  testRunner.And("the response bundle should contain \"8\" entries", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Location search failure due to missing header")]
        [NUnit.Framework.TestCaseAttribute("Ssp-TraceID", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Ssp-From", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Ssp-To", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Ssp-InteractionId", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Authorization", new string[0])]
        public virtual void LocationSearchFailureDueToMissingHeader(string header, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Location search failure due to missing header", exampleTags);
#line 158
this.ScenarioSetup(scenarioInfo);
#line 159
 testRunner.Given("I configure the default \"LocationSearch\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 160
  testRunner.And("I add a Location Identifier parameter with default System and Value \"SIT1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 161
  testRunner.And(string.Format("I do not send header \"{0}\"", header), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 162
 testRunner.When("I make the \"LocationSearch\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 163
 testRunner.Then("the response status code should be \"400\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 164
  testRunner.And("the response should be a OperationOutcome resource with error code \"BAD_REQUEST\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Location search failure due to invalid interactionId")]
        [NUnit.Framework.TestCaseAttribute("urn:nhs:namet45t45s:services:gpconnect:fhir:rest:search:location", new string[0])]
        [NUnit.Framework.TestCaseAttribute("InvalidInteractionId", new string[0])]
        [NUnit.Framework.TestCaseAttribute("", new string[0])]
        public virtual void LocationSearchFailureDueToInvalidInteractionId(string interactionId, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Location search failure due to invalid interactionId", exampleTags);
#line 173
this.ScenarioSetup(scenarioInfo);
#line 174
 testRunner.Given("I configure the default \"LocationSearch\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 175
  testRunner.And("I add a Location Identifier parameter with default System and Value \"SIT1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 176
  testRunner.And(string.Format("I am performing the \"{0}\" interaction", interactionId), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 177
 testRunner.When("I make the \"LocationSearch\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 178
 testRunner.Then("the response status code should be \"400\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 179
  testRunner.And("the response should be a OperationOutcome resource with error code \"BAD_REQUEST\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Conformance profile supports the Location search operation")]
        public virtual void ConformanceProfileSupportsTheLocationSearchOperation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Conformance profile supports the Location search operation", ((string[])(null)));
#line 186
this.ScenarioSetup(scenarioInfo);
#line 187
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 188
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:metadata\" in" +
                    "teraction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 189
 testRunner.When("I make a GET request to \"/metadata\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 190
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 191
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 192
  testRunner.And("the conformance profile should contain the \"Location\" resource with a \"search-typ" +
                    "e\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Location search send multiple identifiers in the request")]
        public virtual void LocationSearchSendMultipleIdentifiersInTheRequest()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Location search send multiple identifiers in the request", ((string[])(null)));
#line 194
this.ScenarioSetup(scenarioInfo);
#line 195
 testRunner.Given("I configure the default \"LocationSearch\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 196
  testRunner.And("I add a Location Identifier parameter with default System and Value \"SIT1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 197
  testRunner.And("I add a Location Identifier parameter with default System and Value \"SIT2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 198
 testRunner.When("I make the \"LocationSearch\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 199
 testRunner.Then("the response status code should be \"400\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 200
  testRunner.And("the response should be a OperationOutcome resource with error code \"BAD_REQUEST\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Location search send duplicate siteCodes in the request")]
        public virtual void LocationSearchSendDuplicateSiteCodesInTheRequest()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Location search send duplicate siteCodes in the request", ((string[])(null)));
#line 202
this.ScenarioSetup(scenarioInfo);
#line 203
 testRunner.Given("I configure the default \"LocationSearch\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 204
  testRunner.And("I add a Location Identifier parameter with default System and Value \"SIT1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 205
  testRunner.And("I add a Location Identifier parameter with default System and Value \"SIT1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 206
 testRunner.When("I make the \"LocationSearch\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 207
 testRunner.Then("the response status code should be \"400\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 208
  testRunner.And("the response should be a OperationOutcome resource with error code \"BAD_REQUEST\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Location search send site identifier and organization identifier in the request")]
        public virtual void LocationSearchSendSiteIdentifierAndOrganizationIdentifierInTheRequest()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Location search send site identifier and organization identifier in the request", ((string[])(null)));
#line 210
this.ScenarioSetup(scenarioInfo);
#line 211
 testRunner.Given("I configure the default \"LocationSearch\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 212
  testRunner.And("I add a Location Identifier parameter with default System and Value \"SIT1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 213
  testRunner.And("I add an Organization Identifier parameter with Organization Code System and Valu" +
                    "e \"ORG2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 214
 testRunner.When("I make the \"LocationSearch\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 215
 testRunner.Then("the response status code should be \"400\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 216
  testRunner.And("the response should be a OperationOutcome resource with error code \"BAD_REQUEST\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Location search send organization identifier in the request")]
        public virtual void LocationSearchSendOrganizationIdentifierInTheRequest()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Location search send organization identifier in the request", ((string[])(null)));
#line 218
this.ScenarioSetup(scenarioInfo);
#line 219
 testRunner.Given("I configure the default \"LocationSearch\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 220
  testRunner.And("I add an Organization Identifier parameter with Organization Code System and Valu" +
                    "e \"ORG2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 221
 testRunner.When("I make the \"LocationSearch\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 222
 testRunner.Then("the response status code should be \"400\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 223
  testRunner.And("the response should be a OperationOutcome resource with error code \"INVALID_IDENT" +
                    "IFIER_SYSTEM\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Location search send additional invalid parameter")]
        public virtual void LocationSearchSendAdditionalInvalidParameter()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Location search send additional invalid parameter", ((string[])(null)));
#line 225
this.ScenarioSetup(scenarioInfo);
#line 226
 testRunner.Given("I configure the default \"LocationSearch\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 227
  testRunner.And("I add a Location Identifier parameter with default System and Value \"SIT1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 228
  testRunner.And("I add the parameter \"additionalParam\" with the value \"invalidParameter\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 229
 testRunner.When("I make the \"LocationSearch\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 230
 testRunner.Then("the response status code should be \"400\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 231
  testRunner.And("the response should be a OperationOutcome resource with error code \"BAD_REQUEST\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Ensure out of date site codes are no longer returning any resource")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        [NUnit.Framework.CategoryAttribute("Manual")]
        public virtual void EnsureOutOfDateSiteCodesAreNoLongerReturningAnyResource()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Ensure out of date site codes are no longer returning any resource", new string[] {
                        "ignore",
                        "Manual"});
#line 235
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Check that the optional fields are populated in the Location resource if they are" +
            " available in the provider system")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        [NUnit.Framework.CategoryAttribute("Manual")]
        public virtual void CheckThatTheOptionalFieldsArePopulatedInTheLocationResourceIfTheyAreAvailableInTheProviderSystem()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check that the optional fields are populated in the Location resource if they are" +
                    " available in the provider system", new string[] {
                        "Manual",
                        "ignore"});
#line 240
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
