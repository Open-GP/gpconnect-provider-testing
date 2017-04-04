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
    [NUnit.Framework.DescriptionAttribute("Practitioner")]
    [NUnit.Framework.CategoryAttribute("Practitioner")]
    public partial class PractitionerFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Practitioner.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Practitioner", null, ProgrammingLanguage.CSharp, new string[] {
                        "Practitioner"});
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
 testRunner.Given("I have the test practitioner codes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Practitioner search success")]
        [NUnit.Framework.TestCaseAttribute("practitioner1", "1", new string[0])]
        [NUnit.Framework.TestCaseAttribute("practitioner2", "0", new string[0])]
        public virtual void PractitionerSearchSuccess(string value, string expectedSize, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Practitioner search success", exampleTags);
#line 7
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 8
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:search:practition" +
                    "er\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
  testRunner.And(string.Format("I add the practitioner identifier parameter with system \"http://fhir.nhs.net/Id/s" +
                        "ds-user-id\" and value \"{0}\"", value), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.When("I make a GET request to \"/Practitioner\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 13
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
  testRunner.And(string.Format("response bundle should contain \"{0}\" entries", expectedSize), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
  testRunner.And("the response should be a Bundle resource of type \"searchset\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Practitioner search with failure due to invalid identifier")]
        [NUnit.Framework.TestCaseAttribute("http://fhir.nhs.net/Id/sds-user-id", "", new string[0])]
        [NUnit.Framework.TestCaseAttribute("", "practitioner1", new string[0])]
        public virtual void PractitionerSearchWithFailureDueToInvalidIdentifier(string system, string value, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Practitioner search with failure due to invalid identifier", exampleTags);
#line 21
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 22
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 23
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:search:practition" +
                    "er\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
  testRunner.And(string.Format("I add the parameter \"identifier\" with the value \"{0}|{1}\"", system, value), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
 testRunner.When("I make a GET request to \"/Practitioner\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 26
 testRunner.Then("the response status code should be \"422\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 27
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Practitioner search failure due to invalid system id in identifier")]
        [NUnit.Framework.TestCaseAttribute("http://fhir.nhs.net/Id/sds-user-id9", new string[0])]
        [NUnit.Framework.TestCaseAttribute("http://fhir.nhs.net/Id/sds-role-profile-id", new string[0])]
        [NUnit.Framework.TestCaseAttribute("null", new string[0])]
        public virtual void PractitionerSearchFailureDueToInvalidSystemIdInIdentifier(string system, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Practitioner search failure due to invalid system id in identifier", exampleTags);
#line 33
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 34
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 35
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:search:practition" +
                    "er\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
  testRunner.And(string.Format("I add the parameter \"identifier\" with the value \"{0}|practitioner1\"", system), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
 testRunner.When("I make a GET request to \"/Practitioner\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 38
 testRunner.Then("the response status code should be \"400\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 39
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Practitioner search without the identifier parameter")]
        public virtual void PractitionerSearchWithoutTheIdentifierParameter()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Practitioner search without the identifier parameter", ((string[])(null)));
#line 46
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 47
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 48
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:search:practition" +
                    "er\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
 testRunner.When("I make a GET request to \"/Practitioner\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 50
 testRunner.Then("the response status code should be \"400\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Practitioner search where identifier contains the incorrect case or spelling")]
        [NUnit.Framework.TestCaseAttribute("idenddstifier", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Idenddstifier", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Identifier", new string[0])]
        public virtual void PractitionerSearchWhereIdentifierContainsTheIncorrectCaseOrSpelling(string parameterName, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Practitioner search where identifier contains the incorrect case or spelling", exampleTags);
#line 52
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 53
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 54
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:search:practition" +
                    "er\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
  testRunner.And(string.Format("I add the parameter \"{0}\" with the value \"http://fhir.nhs.net/Id/sds-user-id|prac" +
                        "titioner1\"", parameterName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
 testRunner.When("I make a GET request to \"/Practitioner\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 57
 testRunner.Then("the response status code should be \"400\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 58
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Practitioner search parameter order test")]
        [NUnit.Framework.TestCaseAttribute("_format", "identifier", "application/json+fhir", "http://fhir.nhs.net/Id/sds-user-id|practitioner1", "JSON", new string[0])]
        [NUnit.Framework.TestCaseAttribute("_format", "identifier", "application/xml+fhir", "http://fhir.nhs.net/Id/sds-user-id|practitioner1", "XML", new string[0])]
        [NUnit.Framework.TestCaseAttribute("identifier", "_format", "http://fhir.nhs.net/Id/sds-user-id|practitioner1", "application/json+fhir", "JSON", new string[0])]
        [NUnit.Framework.TestCaseAttribute("identifier", "_format", "http://fhir.nhs.net/Id/sds-user-id|practitioner1", "application/xml+fhir", "XML", new string[0])]
        public virtual void PractitionerSearchParameterOrderTest(string header1, string header2, string parameter1, string parameter2, string bodyFormat, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Practitioner search parameter order test", exampleTags);
#line 65
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 66
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 67
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:search:practition" +
                    "er\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
  testRunner.And(string.Format("I add the parameter \"{0}\" with the value \"{1}\"", header1, parameter1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
  testRunner.And(string.Format("I add the parameter \"{0}\" with the value \"{1}\"", header2, parameter2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
 testRunner.When("I make a GET request to \"/Practitioner\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 71
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 72
  testRunner.And(string.Format("the response body should be FHIR {0}", bodyFormat), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 73
  testRunner.And("the response should be a Bundle resource of type \"searchset\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Practitioner search accept header")]
        [NUnit.Framework.TestCaseAttribute("application/json+fhir", "JSON", new string[0])]
        [NUnit.Framework.TestCaseAttribute("application/xml+fhir", "XML", new string[0])]
        public virtual void PractitionerSearchAcceptHeader(string header, string bodyFormat, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Practitioner search accept header", exampleTags);
#line 81
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 82
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 83
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:search:practition" +
                    "er\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 84
  testRunner.And("I add the practitioner identifier parameter with system \"http://fhir.nhs.net/Id/s" +
                    "ds-user-id\" and value \"practitioner1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 85
  testRunner.And(string.Format("I set the Accept header to \"{0}\"", header), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
 testRunner.When("I make a GET request to \"/Practitioner\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 87
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 88
  testRunner.And(string.Format("the response body should be FHIR {0}", bodyFormat), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 89
  testRunner.And("the response should be a Bundle resource of type \"searchset\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Practitioner search accept header and _format parameter")]
        [NUnit.Framework.TestCaseAttribute("application/json+fhir", "application/json+fhir", "JSON", new string[0])]
        [NUnit.Framework.TestCaseAttribute("application/json+fhir", "application/xml+fhir", "XML", new string[0])]
        [NUnit.Framework.TestCaseAttribute("application/xml+fhir", "application/json+fhir", "JSON", new string[0])]
        [NUnit.Framework.TestCaseAttribute("application/xml+fhir", "application/xml+fhir", "XML", new string[0])]
        public virtual void PractitionerSearchAcceptHeaderAnd_FormatParameter(string header, string parameter, string bodyFormat, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Practitioner search accept header and _format parameter", exampleTags);
#line 95
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 96
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 97
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:search:practition" +
                    "er\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 98
  testRunner.And("I add the practitioner identifier parameter with system \"http://fhir.nhs.net/Id/s" +
                    "ds-user-id\" and value \"practitioner1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
  testRunner.And(string.Format("I set the Accept header to \"{0}\"", header), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 100
  testRunner.And(string.Format("I add the parameter \"_format\" with the value \"{0}\"", parameter), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 101
 testRunner.When("I make a GET request to \"/Practitioner\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 102
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 103
  testRunner.And(string.Format("the response body should be FHIR {0}", bodyFormat), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 104
  testRunner.And("the response should be a Bundle resource of type \"searchset\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Practitioner search failure due to missing header")]
        [NUnit.Framework.TestCaseAttribute("Ssp-TraceID", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Ssp-From", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Ssp-To", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Ssp-InteractionId", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Authorization", new string[0])]
        public virtual void PractitionerSearchFailureDueToMissingHeader(string header, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Practitioner search failure due to missing header", exampleTags);
#line 112
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 113
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 114
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:search:practition" +
                    "er\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 115
  testRunner.And("I add the practitioner identifier parameter with system \"http://fhir.nhs.net/Id/s" +
                    "ds-user-id\" and value \"practitioner1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 116
  testRunner.And(string.Format("I do not send header \"{0}\"", header), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 117
 testRunner.When("I make a GET request to \"/Practitioner\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 118
 testRunner.Then("the response status code should be \"400\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 119
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 120
  testRunner.And("the response should be a OperationOutcome resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Practitioner search failure due to invalid interactionId")]
        [NUnit.Framework.TestCaseAttribute("urn:nhs:names:services:gpconnect:fhir:operation:gpc.getcarerecord", new string[0])]
        [NUnit.Framework.TestCaseAttribute("InvalidInteractionId", new string[0])]
        [NUnit.Framework.TestCaseAttribute("", new string[0])]
        public virtual void PractitionerSearchFailureDueToInvalidInteractionId(string interactionId, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Practitioner search failure due to invalid interactionId", exampleTags);
#line 129
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 130
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 131
  testRunner.And(string.Format("I am performing the \"{0}\" interaction", interactionId), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 132
  testRunner.And("I add the practitioner identifier parameter with system \"http://fhir.nhs.net/Id/s" +
                    "ds-user-id\" and value \"practitioner1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 133
 testRunner.When("I make a GET request to \"/Practitioner\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 134
 testRunner.Then("the response status code should be \"400\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 135
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 136
  testRunner.And("the response should be a OperationOutcome resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Practitioner search multiple practitioners contains metadata and populated fields" +
            "")]
        public virtual void PractitionerSearchMultiplePractitionersContainsMetadataAndPopulatedFields()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Practitioner search multiple practitioners contains metadata and populated fields" +
                    "", ((string[])(null)));
#line 143
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 144
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 145
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:search:practition" +
                    "er\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 146
  testRunner.And("I add the practitioner identifier parameter with system \"http://fhir.nhs.net/Id/s" +
                    "ds-user-id\" and value \"practitioner1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 147
 testRunner.When("I make a GET request to \"/Practitioner\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 148
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 149
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 150
  testRunner.And("the response should be a Bundle resource of type \"searchset\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 151
  testRunner.And("if the response bundle contains a practitioner resource it should contain meta da" +
                    "ta profile and version id", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Practitioner search returns back user with name element")]
        public virtual void PractitionerSearchReturnsBackUserWithNameElement()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Practitioner search returns back user with name element", ((string[])(null)));
#line 153
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 154
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 155
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:search:practition" +
                    "er\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 156
  testRunner.And("I add the practitioner identifier parameter with system \"http://fhir.nhs.net/Id/s" +
                    "ds-user-id\" and value \"practitioner1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 157
 testRunner.When("I make a GET request to \"/Practitioner\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 158
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 159
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 160
  testRunner.And("the response should be a Bundle resource of type \"searchset\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 161
  testRunner.And("practitioner resources should contain a single name element", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Practitioner search returns user with only one family name")]
        public virtual void PractitionerSearchReturnsUserWithOnlyOneFamilyName()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Practitioner search returns user with only one family name", ((string[])(null)));
#line 163
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 164
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 165
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:search:practition" +
                    "er\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 166
  testRunner.And("I add the practitioner identifier parameter with system \"http://fhir.nhs.net/Id/s" +
                    "ds-user-id\" and value \"practitioner1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 167
 testRunner.When("I make a GET request to \"/Practitioner\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 168
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 169
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 170
  testRunner.And("the response should be a Bundle resource of type \"searchset\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 171
  testRunner.And("practitioner should only have one family name", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Practitioner search returns practitioner role element with valid parameters")]
        public virtual void PractitionerSearchReturnsPractitionerRoleElementWithValidParameters()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Practitioner search returns practitioner role element with valid parameters", ((string[])(null)));
#line 173
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 174
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 175
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:search:practition" +
                    "er\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 176
  testRunner.And("I add the practitioner identifier parameter with system \"http://fhir.nhs.net/Id/s" +
                    "ds-user-id\" and value \"practitioner1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 177
 testRunner.When("I make a GET request to \"/Practitioner\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 178
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 179
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 180
  testRunner.And("the response should be a Bundle resource of type \"searchset\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 181
  testRunner.And("if practitionerRole has role element which contains a coding then the system, cod" +
                    "e and display must exist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 182
  testRunner.And("if practitionerRole has managingOrganization element then reference must exist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Practitioner search should not contain photo or qualification information")]
        public virtual void PractitionerSearchShouldNotContainPhotoOrQualificationInformation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Practitioner search should not contain photo or qualification information", ((string[])(null)));
#line 184
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 185
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 186
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:search:practition" +
                    "er\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 187
  testRunner.And("I add the practitioner identifier parameter with system \"http://fhir.nhs.net/Id/s" +
                    "ds-user-id\" and value \"practitioner1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 188
 testRunner.When("I make a GET request to \"/Practitioner\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 189
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 190
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 191
  testRunner.And("the response should be a Bundle resource of type \"searchset\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 192
        testRunner.And("the practitioner resource should not contain the fhir fields photo or qualificati" +
                    "on", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Practitioner search contains communication element")]
        public virtual void PractitionerSearchContainsCommunicationElement()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Practitioner search contains communication element", ((string[])(null)));
#line 194
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 195
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 196
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:search:practition" +
                    "er\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 197
  testRunner.And("I add the practitioner identifier parameter with system \"http://fhir.nhs.net/Id/s" +
                    "ds-user-id\" and value \"practitioner1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 198
 testRunner.When("I make a GET request to \"/Practitioner\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 199
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 200
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 201
  testRunner.And("the response should be a Bundle resource of type \"searchset\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 202
  testRunner.And("if the practitioner has communicaiton elemenets containing a coding then there mu" +
                    "st be a system, code and display element", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Conformance profile supports the Practitioner search operation")]
        public virtual void ConformanceProfileSupportsThePractitionerSearchOperation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Conformance profile supports the Practitioner search operation", ((string[])(null)));
#line 204
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 205
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 206
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:metadata\" in" +
                    "teraction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 207
 testRunner.When("I make a GET request to \"/metadata\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 208
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 209
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 210
  testRunner.And("the conformance profile should contain the \"Practitioner\" resource with a \"search" +
                    "-type\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
