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
    [NUnit.Framework.DescriptionAttribute("Patient")]
    [NUnit.Framework.CategoryAttribute("http")]
    public partial class PatientFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Patient.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Patient", null, ProgrammingLanguage.CSharp, new string[] {
                        "http"});
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
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "NHSNumber"});
            table1.AddRow(new string[] {
                        "patientNotInSystem",
                        "9999999999"});
            table1.AddRow(new string[] {
                        "patient1",
                        "9000000001"});
            table1.AddRow(new string[] {
                        "patient2",
                        "9000000002"});
            table1.AddRow(new string[] {
                        "patient16",
                        "9000000016"});
#line 5
 testRunner.Given("I have the following patient records", ((string)(null)), table1, "Given ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("The provider system should accept the search parameter URL encoded")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        public virtual void TheProviderSystemShouldAcceptTheSearchParameterURLEncoded()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("The provider system should accept the search parameter URL encoded", new string[] {
                        "ignore"});
#line 13
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Returned patients should contain a logical identifier")]
        public virtual void ReturnedPatientsShouldContainALogicalIdentifier()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Returned patients should contain a logical identifier", ((string[])(null)));
#line 17
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 18
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 19
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:search:patient\" i" +
                    "nteraction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
  testRunner.And("I set the JWT requested record NHS number to config patient \"patient2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
 testRunner.When("I search for Patient \"patient2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 22
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 23
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
  testRunner.And("the JSON response should be a Bundle resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
  testRunner.And("all search response entities in bundle should contain a logical identifier", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Provider should return a patient resource when a valid request is sent")]
        public virtual void ProviderShouldReturnAPatientResourceWhenAValidRequestIsSent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Provider should return a patient resource when a valid request is sent", ((string[])(null)));
#line 27
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 28
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 29
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:search:patient\" i" +
                    "nteraction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
  testRunner.And("I set the JWT requested record NHS number to config patient \"patient1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
 testRunner.When("I search for Patient \"patient1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 32
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 33
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
  testRunner.And("the JSON response should be a Bundle resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Provider should return an error when an invalid system is supplied in the identif" +
            "ier parameter")]
        public virtual void ProviderShouldReturnAnErrorWhenAnInvalidSystemIsSuppliedInTheIdentifierParameter()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Provider should return an error when an invalid system is supplied in the identif" +
                    "ier parameter", ((string[])(null)));
#line 36
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 37
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 38
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:search:patient\" i" +
                    "nteraction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
  testRunner.And("I set the JWT requested record NHS number to config patient \"patient1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
 testRunner.When("I search for Patient \"patient1\" with system \"http://test.net/types/internalIdenti" +
                    "fier\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 41
 testRunner.Then("the response status code should be \"400\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 42
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
  testRunner.And("the JSON response should be a OperationOutcome resource with error code \"INVALID_" +
                    "PARAMETER\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Provider should return an error when no system is supplied in the identifier para" +
            "meter")]
        public virtual void ProviderShouldReturnAnErrorWhenNoSystemIsSuppliedInTheIdentifierParameter()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Provider should return an error when no system is supplied in the identifier para" +
                    "meter", ((string[])(null)));
#line 45
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 46
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 47
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:search:patient\" i" +
                    "nteraction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
  testRunner.And("I set the JWT requested record NHS number to config patient \"patient1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
 testRunner.When("I search for Patient \"patient1\" without system in identifier parameter", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 50
 testRunner.Then("the response status code should be \"422\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 51
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
  testRunner.And("the JSON response should be a OperationOutcome resource with error code \"INVALID_" +
                    "PARAMETER\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Provider should return an error when a blank system is supplied in the identifier" +
            " parameter")]
        public virtual void ProviderShouldReturnAnErrorWhenABlankSystemIsSuppliedInTheIdentifierParameter()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Provider should return an error when a blank system is supplied in the identifier" +
                    " parameter", ((string[])(null)));
#line 54
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 55
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 56
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:search:patient\" i" +
                    "nteraction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
  testRunner.And("I set the JWT requested record NHS number to config patient \"patient1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
 testRunner.When("I search for Patient \"patient1\" with system \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 59
 testRunner.Then("the response status code should be \"422\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 60
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
  testRunner.And("the JSON response should be a OperationOutcome resource with error code \"INVALID_" +
                    "PARAMETER\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("When a patient is not found on the provider system an empty bundle should be retu" +
            "rned")]
        public virtual void WhenAPatientIsNotFoundOnTheProviderSystemAnEmptyBundleShouldBeReturned()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("When a patient is not found on the provider system an empty bundle should be retu" +
                    "rned", ((string[])(null)));
#line 63
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 64
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 65
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:search:patient\" i" +
                    "nteraction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 66
  testRunner.And("I set the JWT requested record NHS number to config patient \"patientNotInSystem\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
 testRunner.When("I search for Patient \"patientNotInSystem\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 68
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 69
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
  testRunner.And("the JSON response should be a Bundle resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 71
  testRunner.And("response bundle should contain \"0\" entries", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Patient search should fail if no identifier parameter is include")]
        public virtual void PatientSearchShouldFailIfNoIdentifierParameterIsInclude()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Patient search should fail if no identifier parameter is include", ((string[])(null)));
#line 73
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 74
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 75
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:search:patient\" i" +
                    "nteraction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
  testRunner.And("I set the JWT requested record NHS number to config patient \"patient2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
 testRunner.When("I make a GET request to \"/Patient\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 78
 testRunner.Then("the response status code should be \"400\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 79
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 80
  testRunner.And("the JSON response should be a OperationOutcome resource with error code \"BAD_REQU" +
                    "EST\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("The identifier parameter should be rejected if the case is incorrect")]
        public virtual void TheIdentifierParameterShouldBeRejectedIfTheCaseIsIncorrect()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("The identifier parameter should be rejected if the case is incorrect", ((string[])(null)));
#line 82
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 83
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 84
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:search:patient\" i" +
                    "nteraction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 85
  testRunner.And("I set the JWT requested record NHS number to config patient \"patient2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
 testRunner.When("I search for Patient \"patient2\" with parameter name \"IdentIfier\" and system \"http" +
                    "://fhir.nhs.net/Id/nhs-number\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 87
 testRunner.Then("the response status code should be \"400\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 88
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 89
  testRunner.And("the JSON response should be a OperationOutcome resource with error code \"BAD_REQU" +
                    "EST\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("The response should be an error if parameter is not identifier")]
        public virtual void TheResponseShouldBeAnErrorIfParameterIsNotIdentifier()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("The response should be an error if parameter is not identifier", ((string[])(null)));
#line 91
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 92
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 93
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:search:patient\" i" +
                    "nteraction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 94
  testRunner.And("I set the JWT requested record NHS number to config patient \"patient2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 95
 testRunner.When("I search for Patient \"patient2\" with parameter name \"nhsNumberParam\" and system \"" +
                    "http://fhir.nhs.net/Id/nhs-number\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 96
 testRunner.Then("the response status code should be \"400\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 97
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 98
  testRunner.And("the JSON response should be a OperationOutcome resource with error code \"BAD_REQU" +
                    "EST\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("The response should be an error if no value is sent in the identifier parameter")]
        public virtual void TheResponseShouldBeAnErrorIfNoValueIsSentInTheIdentifierParameter()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("The response should be an error if no value is sent in the identifier parameter", ((string[])(null)));
#line 100
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 101
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 102
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:search:patient\" i" +
                    "nteraction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 103
  testRunner.And("I set the JWT requested record NHS number to config patient \"patient2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 104
  testRunner.And("I add the parameter \"identifier\" with the value \"http://fhir.nhs.net/Id/nhs-numbe" +
                    "r|\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 105
 testRunner.When("I make a GET request to \"/Patient\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 106
 testRunner.Then("the response status code should be \"422\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 107
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 108
  testRunner.And("the JSON response should be a OperationOutcome resource with error code \"INVALID_" +
                    "PARAMETER\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("The patient search endpoint should accept the format parameter after the identifi" +
            "er parameter")]
        [NUnit.Framework.TestCaseAttribute("application/xml+fhir", "application/xml+fhir", "patient2", "XML", new string[0])]
        [NUnit.Framework.TestCaseAttribute("application/json+fhir", "application/xml+fhir", "patient2", "XML", new string[0])]
        [NUnit.Framework.TestCaseAttribute("application/json+fhir", "application/json+fhir", "patient2", "JSON", new string[0])]
        [NUnit.Framework.TestCaseAttribute("application/xml+fhir", "application/json+fhir", "patient2", "JSON", new string[0])]
        public virtual void ThePatientSearchEndpointShouldAcceptTheFormatParameterAfterTheIdentifierParameter(string acceptHeader, string formatParam, string patient, string resultFormat, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("The patient search endpoint should accept the format parameter after the identifi" +
                    "er parameter", exampleTags);
#line 110
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 111
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 112
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:search:patient\" i" +
                    "nteraction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 113
  testRunner.And(string.Format("I set the JWT requested record NHS number to config patient \"{0}\"", patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 114
  testRunner.And(string.Format("I set the Accept header to \"{0}\"", acceptHeader), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 115
  testRunner.And(string.Format("I add the parameter \"identifier\" with system \"http://fhir.nhs.net/Id/nhs-number\" " +
                        "for patient \"{0}\"", patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 116
  testRunner.And(string.Format("I add the parameter \"_format\" with the value \"{0}\"", formatParam), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 117
 testRunner.When("I make a GET request to \"/Patient\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 118
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 119
  testRunner.And(string.Format("the response body should be FHIR {0}", resultFormat), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 120
  testRunner.And("the JSON response should be a Bundle resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 121
  testRunner.And("response bundle should contain \"1\" entries", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("The patient search endpoint should accept the format parameter before the identif" +
            "ier parameter")]
        [NUnit.Framework.TestCaseAttribute("application/xml+fhir", "application/xml+fhir", "patient2", "XML", new string[0])]
        [NUnit.Framework.TestCaseAttribute("application/json+fhir", "application/xml+fhir", "patient2", "XML", new string[0])]
        [NUnit.Framework.TestCaseAttribute("application/json+fhir", "application/json+fhir", "patient2", "JSON", new string[0])]
        [NUnit.Framework.TestCaseAttribute("application/xml+fhir", "application/json+fhir", "patient2", "JSON", new string[0])]
        public virtual void ThePatientSearchEndpointShouldAcceptTheFormatParameterBeforeTheIdentifierParameter(string acceptHeader, string formatParam, string patient, string resultFormat, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("The patient search endpoint should accept the format parameter before the identif" +
                    "ier parameter", exampleTags);
#line 129
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 130
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 131
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:search:patient\" i" +
                    "nteraction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 132
  testRunner.And(string.Format("I set the JWT requested record NHS number to config patient \"{0}\"", patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 133
  testRunner.And(string.Format("I set the Accept header to \"{0}\"", acceptHeader), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 134
  testRunner.And(string.Format("I add the parameter \"_format\" with the value \"{0}\"", formatParam), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 135
  testRunner.And(string.Format("I add the parameter \"identifier\" with system \"http://fhir.nhs.net/Id/nhs-number\" " +
                        "for patient \"{0}\"", patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 136
 testRunner.When("I make a GET request to \"/Patient\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 137
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 138
  testRunner.And(string.Format("the response body should be FHIR {0}", resultFormat), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 139
  testRunner.And("the JSON response should be a Bundle resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 140
  testRunner.And("response bundle should contain \"1\" entries", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
