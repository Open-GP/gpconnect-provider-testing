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
    [NUnit.Framework.DescriptionAttribute("RegisterPatient")]
    public partial class RegisterPatientFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "RegisterPatient.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "RegisterPatient", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("Successful registration of a temporary patient")]
        public virtual void SuccessfulRegistrationOfATemporaryPatient()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Successful registration of a temporary patient", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 7
 testRunner.Given("I find the next patient to register and store the Patient Resource against key \"r" +
                    "egisterPatient\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:operation:gpc.register" +
                    "patient\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
  testRunner.And("I add the registration period with start date \"2017-05-05\" and end date \"2018-03-" +
                    "12\" to \"registerPatient\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
  testRunner.And("I add the registration status with code \"A\" to \"registerPatient\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
  testRunner.And("I add the registration type with code \"T\" to \"registerPatient\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.When("I send a gpc.registerpatient to create patient stored against key \"registerPatien" +
                    "t\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 14
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 15
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
  testRunner.And("the response should be a Bundle resource of type \"searchset\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Register patient send request to incorrect URL")]
        [NUnit.Framework.TestCaseAttribute("2017-05-05", "/Patient/$gpc.registerpatien", new string[0])]
        [NUnit.Framework.TestCaseAttribute("2016-12-05", "/PAtient/$gpc.registerpatient", new string[0])]
        [NUnit.Framework.TestCaseAttribute("1999-01-22", "/Patient/$gpc.registerpati#ent", new string[0])]
        [NUnit.Framework.TestCaseAttribute("2017-08-12", "/Patient", new string[0])]
        public virtual void RegisterPatientSendRequestToIncorrectURL(string regStartDate, string url, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Register patient send request to incorrect URL", exampleTags);
#line 18
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 19
 testRunner.Given("I find the next patient to register and store the Patient Resource against key \"r" +
                    "egisterPatient\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 20
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 21
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:operation:gpc.register" +
                    "patient\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
  testRunner.And(string.Format("I add the registration period with start date \"{0}\" to \"registerPatient\"", regStartDate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
  testRunner.And("I add the registration status with code \"A\" to \"registerPatient\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
  testRunner.And("I add the registration type with code \"T\" to \"registerPatient\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
 testRunner.When(string.Format("I register patient stored against key \"registerPatient\" with url \"{0}\"", url), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 26
 testRunner.Then("the response status code should be \"404\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 27
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
  testRunner.And("the response should be a OperationOutcome resource with error code \"REFERENCE_NOT" +
                    "_FOUND\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Register patient with invalid interactionIds")]
        [NUnit.Framework.TestCaseAttribute("urn:nhs:names:services:gpconnect:fhir:rest:search:patient_appointments", new string[0])]
        [NUnit.Framework.TestCaseAttribute("urn:nhs:names:services:gpconnect:fhir:operation:gpc.registerpatsssient", new string[0])]
        [NUnit.Framework.TestCaseAttribute("urn:nhs:names:services:gpconnect:fhir:rest:create:appointment", new string[0])]
        [NUnit.Framework.TestCaseAttribute("", new string[0])]
        [NUnit.Framework.TestCaseAttribute("null", new string[0])]
        public virtual void RegisterPatientWithInvalidInteractionIds(string interactionId, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Register patient with invalid interactionIds", exampleTags);
#line 36
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 37
 testRunner.Given("I find the next patient to register and store the Patient Resource against key \"r" +
                    "egisterPatient\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 38
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 39
  testRunner.And(string.Format("I am performing the \"{0}\" interaction", interactionId), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
  testRunner.And("I add the registration period with start date \"2017-05-05\" and end date \"2018-03-" +
                    "12\" to \"registerPatient\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
  testRunner.And("I add the registration status with code \"A\" to \"registerPatient\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
  testRunner.And("I add the registration type with code \"T\" to \"registerPatient\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
 testRunner.When("I send a gpc.registerpatient to create patient stored against key \"registerPatien" +
                    "t\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 44
 testRunner.Then("the response status code should be \"400\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 45
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
  testRunner.And("the response should be a OperationOutcome resource with error code \"BAD_REQUEST\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Register patient with missing header")]
        [NUnit.Framework.TestCaseAttribute("Ssp-TraceID", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Ssp-From", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Ssp-To", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Ssp-InteractionId", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Authorization", new string[0])]
        public virtual void RegisterPatientWithMissingHeader(string header, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Register patient with missing header", exampleTags);
#line 55
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 56
 testRunner.Given("I find the next patient to register and store the Patient Resource against key \"r" +
                    "egisterPatient\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 57
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 58
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:operation:gpc.register" +
                    "patient\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
  testRunner.And("I add the registration period with start date \"2017-04-12\" and end date \"2017-12-" +
                    "24\" to \"registerPatient\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
  testRunner.And("I add the registration status with code \"A\" to \"registerPatient\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
  testRunner.And("I add the registration type with code \"T\" to \"registerPatient\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
  testRunner.And(string.Format("I do not send header \"{0}\"", header), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
 testRunner.When("I send a gpc.registerpatient to create patient stored against key \"registerPatien" +
                    "t\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 64
 testRunner.Then("the response status code should be \"400\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 65
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 66
  testRunner.And("the response should be a OperationOutcome resource with error code \"BAD_REQUEST\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Register patient and set identifier to null before sending the request")]
        [NUnit.Framework.TestCaseAttribute("patient23", "tom", "johnson", "345554", "1993-03-03", "2017-05-05", new string[0])]
        public virtual void RegisterPatientAndSetIdentifierToNullBeforeSendingTheRequest(string patient, string firstName, string secondName, string nhsNumber, string birthDate, string regStartDate, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Register patient and set identifier to null before sending the request", exampleTags);
#line 75
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 76
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 77
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:operation:gpc.register" +
                    "patient\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 78
  testRunner.And(string.Format("I register patient \"{0}\" with first name \"{1}\" and family name \"{2}\" with NHS num" +
                        "ber \"{3}\" and birth date \"{4}\"", patient, firstName, secondName, nhsNumber, birthDate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 79
  testRunner.And(string.Format("I add the registration period with start date \"{0}\" to \"{1}\"", regStartDate, patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 80
  testRunner.And(string.Format("I add the registration status with code \"A\" to \"{0}\"", patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 81
  testRunner.And(string.Format("I add the registration type with code \"T\" to \"{0}\"", patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 82
  testRunner.And(string.Format("I set the identifier from \"{0}\" to null", patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 83
 testRunner.When(string.Format("I send a gpc.registerpatients to register \"{0}\"", patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 84
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 85
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
  testRunner.And("the response should be a Bundle resource of type \"searchset\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Register patient and set active element to null before sending the request")]
        [NUnit.Framework.TestCaseAttribute("patient23", "tom", "johnson", "345554", "1993-03-03", "2017-05-05", new string[0])]
        public virtual void RegisterPatientAndSetActiveElementToNullBeforeSendingTheRequest(string patient, string firstName, string secondName, string nhsNumber, string birthDate, string regStartDate, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Register patient and set active element to null before sending the request", exampleTags);
#line 91
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 92
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 93
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:operation:gpc.register" +
                    "patient\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 94
  testRunner.And(string.Format("I register patient \"{0}\" with first name \"{1}\" and family name \"{2}\" with NHS num" +
                        "ber \"{3}\" and birth date \"{4}\"", patient, firstName, secondName, nhsNumber, birthDate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 95
  testRunner.And(string.Format("I add the registration period with start date \"{0}\" to \"{1}\"", regStartDate, patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 96
  testRunner.And(string.Format("I add the registration status with code \"A\" to \"{0}\"", patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
  testRunner.And(string.Format("I add the registration type with code \"T\" to \"{0}\"", patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 98
  testRunner.And(string.Format("I set the active element from \"{0}\" to null", patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
 testRunner.When(string.Format("I send a gpc.registerpatients to register \"{0}\"", patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 100
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 101
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 102
  testRunner.And("the response should be a Bundle resource of type \"searchset\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Register patient and set name element to null before sending the request")]
        [NUnit.Framework.TestCaseAttribute("patient23", "tom", "johnson", "345554", "1993-03-03", "2017-05-05", new string[0])]
        public virtual void RegisterPatientAndSetNameElementToNullBeforeSendingTheRequest(string patient, string firstName, string secondName, string nhsNumber, string birthDate, string regStartDate, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Register patient and set name element to null before sending the request", exampleTags);
#line 107
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 108
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 109
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:operation:gpc.register" +
                    "patient\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 110
  testRunner.And(string.Format("I register patient \"{0}\" with first name \"{1}\" and family name \"{2}\" with NHS num" +
                        "ber \"{3}\" and birth date \"{4}\"", patient, firstName, secondName, nhsNumber, birthDate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 111
  testRunner.And(string.Format("I add the registration period with start date \"{0}\" to \"{1}\"", regStartDate, patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 112
  testRunner.And(string.Format("I add the registration status with code \"A\" to \"{0}\"", patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 113
  testRunner.And(string.Format("I add the registration type with code \"T\" to \"{0}\"", patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 114
  testRunner.And(string.Format("I set the name element from \"{0}\" to null", patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 115
 testRunner.When(string.Format("I send a gpc.registerpatients to register \"{0}\"", patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 116
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 117
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 118
  testRunner.And("the response should be a Bundle resource of type \"searchset\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Register patient and set gender element to null before sending the request")]
        [NUnit.Framework.TestCaseAttribute("patient23", "tom", "johnson", "345554", "1993-03-03", "2017-05-05", new string[0])]
        public virtual void RegisterPatientAndSetGenderElementToNullBeforeSendingTheRequest(string patient, string firstName, string secondName, string nhsNumber, string birthDate, string regStartDate, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Register patient and set gender element to null before sending the request", exampleTags);
#line 123
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 124
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 125
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:operation:gpc.register" +
                    "patient\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 126
  testRunner.And(string.Format("I register patient \"{0}\" with first name \"{1}\" and family name \"{2}\" with NHS num" +
                        "ber \"{3}\" and birth date \"{4}\"", patient, firstName, secondName, nhsNumber, birthDate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 127
  testRunner.And(string.Format("I add the registration period with start date \"{0}\" to \"{1}\"", regStartDate, patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 128
  testRunner.And(string.Format("I add the registration status with code \"A\" to \"{0}\"", patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 129
  testRunner.And(string.Format("I add the registration type with code \"T\" to \"{0}\"", patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 130
  testRunner.And(string.Format("I set the gender element from \"{0}\" to null", patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 131
 testRunner.When(string.Format("I send a gpc.registerpatients to register \"{0}\"", patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 132
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 133
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 134
  testRunner.And("the response should be a Bundle resource of type \"searchset\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Register patient without manadatory values and send request")]
        [NUnit.Framework.TestCaseAttribute("patient25", "tom", "johnson", "3455545", "1993-03-03", "2017-05-05", "active", new string[0])]
        [NUnit.Framework.TestCaseAttribute("patient26", "tom", "johnson", "3455544", "1993-03-03", "2017-05-05", "gender", new string[0])]
        [NUnit.Framework.TestCaseAttribute("patient27", "tom", "johnson", "3455546", "1993-03-03", "2017-05-05", "birthDate", new string[0])]
        [NUnit.Framework.TestCaseAttribute("patient28", "tom", "johnson", "3455547", "1993-03-03", "2017-05-05", "name", new string[0])]
        public virtual void RegisterPatientWithoutManadatoryValuesAndSendRequest(string patient, string firstName, string secondName, string nhsNumber, string birthDate, string regStartDate, string doNotSet, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Register patient without manadatory values and send request", exampleTags);
#line 139
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 140
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 141
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:operation:gpc.register" +
                    "patient\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 142
  testRunner.And(string.Format("I do not set \"{0}\" and register patient \"{1}\" with first name \"{2}\" and family na" +
                        "me \"{3}\" with NHS number \"{4}\" and birth date \"{5}\"", doNotSet, patient, firstName, secondName, nhsNumber, birthDate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 143
  testRunner.And(string.Format("I add the registration period with start date \"{0}\" to \"{1}\"", regStartDate, patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 144
  testRunner.And(string.Format("I add the registration status with code \"A\" to \"{0}\"", patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 145
  testRunner.And(string.Format("I add the registration type with code \"T\" to \"{0}\"", patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 146
  testRunner.And(string.Format("I set the gender element from \"{0}\" to null", patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 147
 testRunner.When(string.Format("I send a gpc.registerpatients to register \"{0}\"", patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 148
 testRunner.Then("the response status code should indicate failure", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 149
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 150
  testRunner.And("the response should be a OperationOutcome resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Register patient without identifier and send request")]
        [NUnit.Framework.TestCaseAttribute("patient24", "tom", "johnson", "3455543", "1993-03-03", "2017-05-05", "Identifier", new string[0])]
        public virtual void RegisterPatientWithoutIdentifierAndSendRequest(string patient, string firstName, string secondName, string nhsNumber, string birthDate, string regStartDate, string doNotSet, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Register patient without identifier and send request", exampleTags);
#line 158
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 159
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 160
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:operation:gpc.register" +
                    "patient\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 161
  testRunner.And(string.Format("I do not set \"{0}\" and register patient \"{1}\" with first name \"{2}\" and family na" +
                        "me \"{3}\" with NHS number \"{4}\" and birth date \"{5}\"", doNotSet, patient, firstName, secondName, nhsNumber, birthDate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 162
  testRunner.And(string.Format("I add the registration period with start date \"{0}\" to \"{1}\"", regStartDate, patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 163
  testRunner.And(string.Format("I add the registration status with code \"A\" to \"{0}\"", patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 164
  testRunner.And(string.Format("I add the registration type with code \"T\" to \"{0}\"", patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 165
  testRunner.And(string.Format("I set the gender element from \"{0}\" to null", patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 166
 testRunner.When(string.Format("I send a gpc.registerpatients to register \"{0}\"", patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 167
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 168
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 169
  testRunner.And("the response should be a Bundle resource of type \"searchset\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Register patient with an invalid NHS number")]
        [NUnit.Framework.TestCaseAttribute("patient23", "tom", "johnson", "34555##4", "1993-03-03", "2017-05-05", new string[0])]
        [NUnit.Framework.TestCaseAttribute("patient23", "tom", "johnson", "", "1993-03-03", "2017-05-05", new string[0])]
        [NUnit.Framework.TestCaseAttribute("patient23", "tom", "johnson", "hello", "1993-03-03", "2017-05-05", new string[0])]
        public virtual void RegisterPatientWithAnInvalidNHSNumber(string patient, string firstName, string secondName, string nhsNumber, string birthDate, string regStartDate, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Register patient with an invalid NHS number", exampleTags);
#line 174
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 175
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 176
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:operation:gpc.register" +
                    "patient\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 177
  testRunner.And(string.Format("I register patient \"{0}\" with first name \"{1}\" and family name \"{2}\" with NHS num" +
                        "ber \"{3}\" and birth date \"{4}\"", patient, firstName, secondName, nhsNumber, birthDate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 178
  testRunner.And(string.Format("I add the registration period with start date \"{0}\" to \"{1}\"", regStartDate, patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 179
  testRunner.And(string.Format("I add the registration status with code \"A\" to \"{0}\"", patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 180
  testRunner.And(string.Format("I add the registration type with code \"T\" to \"{0}\"", patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 181
 testRunner.When(string.Format("I send a gpc.registerpatients to register \"{0}\"", patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 182
 testRunner.Then("the response status code should indicate failure", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 183
  testRunner.And("the response should be a OperationOutcome resource with error code \"400\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Register patient and check registration period is not null")]
        [NUnit.Framework.TestCaseAttribute("patient23", "tom", "johnson", "34555455", "1993-03-03", "2017-05-05", new string[0])]
        public virtual void RegisterPatientAndCheckRegistrationPeriodIsNotNull(string patient, string firstName, string secondName, string nhsNumber, string birthDate, string regStartDate, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Register patient and check registration period is not null", exampleTags);
#line 190
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 191
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 192
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:operation:gpc.register" +
                    "patient\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 193
  testRunner.And(string.Format("I register patient \"{0}\" with first name \"{1}\" and family name \"{2}\" with NHS num" +
                        "ber \"{3}\" and birth date \"{4}\"", patient, firstName, secondName, nhsNumber, birthDate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 194
  testRunner.And(string.Format("I add the registration period with start date \"{0}\" to \"{1}\"", regStartDate, patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 195
  testRunner.And(string.Format("I add the registration status with code \"A\" to \"{0}\"", patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 196
  testRunner.And(string.Format("I add the registration type with code \"T\" to \"{0}\"", patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 197
 testRunner.When(string.Format("I send a gpc.registerpatients to register \"{0}\"", patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 198
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 199
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 200
  testRunner.And("the bundle should contain a registration type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 201
  testRunner.And("the bundle should contain a registration status", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 202
  testRunner.And("the bundle should contain a registration period", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Register patient and validate patient response contains the correct quantity of e" +
            "lements")]
        [NUnit.Framework.TestCaseAttribute("patient23", "tom", "johnson", "34555455", "1993-03-03", "2017-05-05", new string[0])]
        public virtual void RegisterPatientAndValidatePatientResponseContainsTheCorrectQuantityOfElements(string patient, string firstName, string secondName, string nhsNumber, string birthDate, string regStartDate, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Register patient and validate patient response contains the correct quantity of e" +
                    "lements", exampleTags);
#line 207
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 208
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 209
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:operation:gpc.register" +
                    "patient\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 210
  testRunner.And(string.Format("I register patient \"{0}\" with first name \"{1}\" and family name \"{2}\" with NHS num" +
                        "ber \"{3}\" and birth date \"{4}\"", patient, firstName, secondName, nhsNumber, birthDate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 211
  testRunner.And(string.Format("I add the registration period with start date \"{0}\" to \"{1}\"", regStartDate, patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 212
  testRunner.And(string.Format("I add the registration status with code \"A\" to \"{0}\"", patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 213
  testRunner.And(string.Format("I add the registration type with code \"T\" to \"{0}\"", patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 214
 testRunner.When(string.Format("I send a gpc.registerpatients to register \"{0}\"", patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 215
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 216
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 217
  testRunner.And("the bundle patient response should contain exactly 1 family name", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 218
  testRunner.And("the bundle patient response should contain exactly 1 given name", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 219
  testRunner.And("the bundle patient response should contain exactly 1 gender element", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 220
  testRunner.And("the bundle patient response should contain exactly 1 birthDate element", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
