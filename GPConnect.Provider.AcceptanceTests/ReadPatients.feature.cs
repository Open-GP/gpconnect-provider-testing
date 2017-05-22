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
    [NUnit.Framework.DescriptionAttribute("ReadPatient")]
    public partial class ReadPatientFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ReadPatients.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "ReadPatient", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
#line 3
#line 4
 testRunner.Given("I have the test patient codes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Read patient 404 if patient not found")]
        public virtual void ReadPatient404IfPatientNotFound()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Read patient 404 if patient not found", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 7
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:patient\" int" +
                    "eraction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
 testRunner.When("I make a GET request to \"/Patient/123\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
 testRunner.Then("the response status code should be \"404\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 11
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
  testRunner.And("the response should be a OperationOutcome resource with error code \"PATIENT_NOT_F" +
                    "OUND\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Read patient _format parameter only")]
        [NUnit.Framework.TestCaseAttribute("application/json+fhir", "JSON", new string[0])]
        [NUnit.Framework.TestCaseAttribute("application/xml+fhir", "XML", new string[0])]
        public virtual void ReadPatient_FormatParameterOnly(string parameter, string bodyFormat, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Read patient _format parameter only", exampleTags);
#line 14
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 15
 testRunner.Given("I perform the searchPatient operation for patient \"patient1\" and store the return" +
                    "ed patient", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 16
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 17
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:patient\" int" +
                    "eraction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
        testRunner.And(string.Format("I add the parameter \"_format\" with the value \"{0}\"", parameter), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.When("I make a GET request for patient \"patient1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 20
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 21
  testRunner.And(string.Format("the response body should be FHIR {0}", bodyFormat), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
  testRunner.And("the response should be a Patient resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Read patient accept header and _format parameter")]
        [NUnit.Framework.TestCaseAttribute("application/json+fhir", "application/json+fhir", "JSON", new string[0])]
        [NUnit.Framework.TestCaseAttribute("application/json+fhir", "application/xml+fhir", "XML", new string[0])]
        [NUnit.Framework.TestCaseAttribute("application/xml+fhir", "application/json+fhir", "JSON", new string[0])]
        [NUnit.Framework.TestCaseAttribute("application/xml+fhir", "application/xml+fhir", "XML", new string[0])]
        public virtual void ReadPatientAcceptHeaderAnd_FormatParameter(string header, string parameter, string bodyFormat, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Read patient accept header and _format parameter", exampleTags);
#line 28
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 29
 testRunner.Given("I perform the searchPatient operation for patient \"patient1\" and store the return" +
                    "ed patient", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 30
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 31
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:patient\" int" +
                    "eraction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
  testRunner.And(string.Format("I set the Accept header to \"{0}\"", header), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
        testRunner.And(string.Format("I add the parameter \"_format\" with the value \"{0}\"", parameter), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
 testRunner.When("I make a GET request for patient \"patient1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 35
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 36
  testRunner.And(string.Format("the response body should be FHIR {0}", bodyFormat), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
  testRunner.And("the response should be a Patient resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Read patient should contain correct logical identifier")]
        public virtual void ReadPatientShouldContainCorrectLogicalIdentifier()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Read patient should contain correct logical identifier", ((string[])(null)));
#line 45
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 46
 testRunner.Given("I perform the searchPatient operation for patient \"patient1\" and store the return" +
                    "ed patient", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 47
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 48
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:patient\" int" +
                    "eraction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
 testRunner.When("I make a GET request for patient \"patient1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 50
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 51
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
  testRunner.And("the response should be a Patient resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
  testRunner.And("the response patient logical identifier should match that of stored patient \"pati" +
                    "ent1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Read patient should contain ETag")]
        public virtual void ReadPatientShouldContainETag()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Read patient should contain ETag", ((string[])(null)));
#line 55
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 56
 testRunner.Given("I perform the searchPatient operation for patient \"patient1\" and store the return" +
                    "ed patient", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 57
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 58
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:patient\" int" +
                    "eraction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
 testRunner.When("I make a GET request for patient \"patient1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 60
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 61
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
  testRunner.And("the response should be a Patient resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
  testRunner.And("the response should contain the ETag header matching the resource version", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Read patient If-None-Match should return a 304 on match")]
        public virtual void ReadPatientIf_None_MatchShouldReturnA304OnMatch()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Read patient If-None-Match should return a 304 on match", ((string[])(null)));
#line 65
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 66
 testRunner.Given("I perform the searchPatient operation for patient \"patient1\" and store the return" +
                    "ed patient", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 67
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 68
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:patient\" int" +
                    "eraction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
 testRunner.When("I make a GET request for patient \"patient1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 70
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 71
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 72
  testRunner.And("the response should be a Patient resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 73
  testRunner.And("the response ETag is saved as \"etagPatientRead\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 74
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 75
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:patient\" int" +
                    "eraction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
  testRunner.And("I set \"If-None-Match\" request header to \"etagPatientRead\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
 testRunner.When("I make a GET request for patient \"patient1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 78
 testRunner.Then("the response status code should be \"304\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Read patient If-None-Match should return full resource if no match")]
        public virtual void ReadPatientIf_None_MatchShouldReturnFullResourceIfNoMatch()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Read patient If-None-Match should return full resource if no match", ((string[])(null)));
#line 80
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 81
 testRunner.Given("I perform the searchPatient operation for patient \"patient1\" and store the return" +
                    "ed patient", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 82
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 83
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:patient\" int" +
                    "eraction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 84
  testRunner.And("I set the If-None-Match header to \"W/\\\"somethingincorrect\\\"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 85
 testRunner.When("I make a GET request for patient \"patient1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 86
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 87
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 88
  testRunner.And("the response should be a Patient resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 89
  testRunner.And("the response should contain the ETag header matching the resource version", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
