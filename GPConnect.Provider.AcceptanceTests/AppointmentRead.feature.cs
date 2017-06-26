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
    [NUnit.Framework.DescriptionAttribute("AppointmentRead")]
    [NUnit.Framework.CategoryAttribute("appointment")]
    public partial class AppointmentReadFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "AppointmentRead.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "AppointmentRead", null, ProgrammingLanguage.CSharp, new string[] {
                        "appointment"});
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
        [NUnit.Framework.DescriptionAttribute("I perform a successful Read appointment")]
        [NUnit.Framework.TestCaseAttribute("patient1", new string[0])]
        [NUnit.Framework.TestCaseAttribute("patient2", new string[0])]
        [NUnit.Framework.TestCaseAttribute("patient3", new string[0])]
        public virtual void IPerformASuccessfulReadAppointment(string patientName, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("I perform a successful Read appointment", exampleTags);
#line 4
this.ScenarioSetup(scenarioInfo);
#line 5
 testRunner.Given(string.Format("I find or create \"1\" appointments for patient \"{0}\" at organization \"ORG1\" and sa" +
                        "ve bundle of appintment resources to \"Patient1AppointmentsInBundle\"", patientName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 6
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:appointment\"" +
                    " interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 8
 testRunner.When(string.Format("I perform an appointment read for the first appointment saved in the bundle of re" +
                        "sources stored against key \"Patient1AppointmentsInBundle\" for patient \"{0}\"", patientName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 9
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 10
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
  testRunner.And("the response should be an Appointment resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Read appointment invalid appointment id")]
        [NUnit.Framework.TestCaseAttribute("Invalid4321", new string[0])]
        [NUnit.Framework.TestCaseAttribute("8888888888", new string[0])]
        [NUnit.Framework.TestCaseAttribute("", new string[0])]
        public virtual void ReadAppointmentInvalidAppointmentId(string id, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Read appointment invalid appointment id", exampleTags);
#line 18
this.ScenarioSetup(scenarioInfo);
#line 19
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 20
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:appointment\"" +
                    " interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
        testRunner.And("I set the JWT requested record NHS number to config patient \"patient1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
        testRunner.And("I set the JWT requested scope to \"patient/*.read\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.When(string.Format("I make a GET request to \"/Appointment/{0}\"", id), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 24
 testRunner.Then("the response status code should be \"404\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 25
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Read appointment failure due to missing header")]
        [NUnit.Framework.TestCaseAttribute("Ssp-TraceID", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Ssp-From", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Ssp-To", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Ssp-InteractionId", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Authorization", new string[0])]
        public virtual void ReadAppointmentFailureDueToMissingHeader(string header, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Read appointment failure due to missing header", exampleTags);
#line 32
this.ScenarioSetup(scenarioInfo);
#line 33
 testRunner.Given("I find or create \"1\" appointments for patient \"patient1\" at organization \"ORG1\" a" +
                    "nd save bundle of appintment resources to \"Patient1AppointmentsInBundle\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 34
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 35
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:appointment\"" +
                    " interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
  testRunner.And(string.Format("I do not send header \"{0}\"", header), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
 testRunner.When("I perform an appointment read for the first appointment saved in the bundle of re" +
                    "sources stored against key \"Patient1AppointmentsInBundle\" for patient \"patient1\"" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 38
 testRunner.Then("the response status code should be \"400\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 39
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
  testRunner.And("the response should be a OperationOutcome resource with error code \"BAD_REQUEST\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Read appointment failure with incorrect interaction id")]
        [NUnit.Framework.TestCaseAttribute("urn:nhs:names:services:gpconnect:fhir:rest:search:organization", new string[0])]
        [NUnit.Framework.TestCaseAttribute("urn:nhs:names:services:gpconnect:fhir:operation:gpc.getcarerecord", new string[0])]
        [NUnit.Framework.TestCaseAttribute("", new string[0])]
        [NUnit.Framework.TestCaseAttribute("null", new string[0])]
        public virtual void ReadAppointmentFailureWithIncorrectInteractionId(string interactionId, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Read appointment failure with incorrect interaction id", exampleTags);
#line 49
this.ScenarioSetup(scenarioInfo);
#line 50
 testRunner.Given("I find or create \"1\" appointments for patient \"patient1\" at organization \"ORG1\" a" +
                    "nd save bundle of appintment resources to \"Patient1AppointmentsInBundle\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 51
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 52
  testRunner.And(string.Format("I am performing the \"{0}\" interaction", interactionId), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.When("I perform an appointment read for the first appointment saved in the bundle of re" +
                    "sources stored against key \"Patient1AppointmentsInBundle\" for patient \"patient1\"" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 54
 testRunner.Then("the response status code should be \"400\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 55
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
  testRunner.And("the response should be a OperationOutcome resource with error code \"BAD_REQUEST\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Read appointment _format parameter only")]
        [NUnit.Framework.TestCaseAttribute("application/json+fhir", "JSON", new string[0])]
        [NUnit.Framework.TestCaseAttribute("application/xml+fhir", "XML", new string[0])]
        public virtual void ReadAppointment_FormatParameterOnly(string parameter, string bodyFormat, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Read appointment _format parameter only", exampleTags);
#line 64
this.ScenarioSetup(scenarioInfo);
#line 65
 testRunner.Given("I find or create \"1\" appointments for patient \"patient1\" at organization \"ORG1\" a" +
                    "nd save bundle of appintment resources to \"Patient1AppointmentsInBundle\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 66
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 67
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:appointment\"" +
                    " interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
  testRunner.And(string.Format("I add the parameter \"_format\" with the value \"{0}\"", parameter), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
 testRunner.When("I perform an appointment read for the first appointment saved in the bundle of re" +
                    "sources stored against key \"Patient1AppointmentsInBundle\" for patient \"patient1\"" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 70
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 71
  testRunner.And(string.Format("the response body should be FHIR {0}", bodyFormat), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 72
  testRunner.And("the response should be an Appointment resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Read appointment accept header and _format parameter")]
        [NUnit.Framework.TestCaseAttribute("application/json+fhir", "application/json+fhir", "JSON", new string[0])]
        [NUnit.Framework.TestCaseAttribute("application/json+fhir", "application/xml+fhir", "XML", new string[0])]
        [NUnit.Framework.TestCaseAttribute("application/xml+fhir", "application/json+fhir", "JSON", new string[0])]
        [NUnit.Framework.TestCaseAttribute("application/xml+fhir", "application/xml+fhir", "XML", new string[0])]
        public virtual void ReadAppointmentAcceptHeaderAnd_FormatParameter(string header, string parameter, string bodyFormat, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Read appointment accept header and _format parameter", exampleTags);
#line 78
this.ScenarioSetup(scenarioInfo);
#line 79
 testRunner.Given("I find or create \"1\" appointments for patient \"patient1\" at organization \"ORG1\" a" +
                    "nd save bundle of appintment resources to \"Patient1AppointmentsInBundle\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 80
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 81
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:appointment\"" +
                    " interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 82
  testRunner.And(string.Format("I set the Accept header to \"{0}\"", header), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 83
  testRunner.And(string.Format("I add the parameter \"_format\" with the value \"{0}\"", parameter), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 84
 testRunner.When("I perform an appointment read for the first appointment saved in the bundle of re" +
                    "sources stored against key \"Patient1AppointmentsInBundle\" for patient \"patient1\"" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 85
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 86
  testRunner.And(string.Format("the response body should be FHIR {0}", bodyFormat), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 87
  testRunner.And("the response should be an Appointment resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Read appointment valid request shall include id and structure definition profile")]
        public virtual void ReadAppointmentValidRequestShallIncludeIdAndStructureDefinitionProfile()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Read appointment valid request shall include id and structure definition profile", ((string[])(null)));
#line 95
this.ScenarioSetup(scenarioInfo);
#line 96
 testRunner.Given("I find or create \"1\" appointments for patient \"patient1\" at organization \"ORG1\" a" +
                    "nd save bundle of appintment resources to \"Patient1AppointmentsInBundle\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 97
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 98
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:appointment\"" +
                    " interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
 testRunner.When("I perform an appointment read for the first appointment saved in the bundle of re" +
                    "sources stored against key \"Patient1AppointmentsInBundle\" for patient \"patient1\"" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 100
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 101
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 102
  testRunner.And("the returned resource shall contains a logical id", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 103
  testRunner.And("the returned appointment resource should contain meta data profile and version id" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Read appointment check response contains required elements")]
        [NUnit.Framework.TestCaseAttribute("Booked", "application/json+fhir", "JSON", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Booked", "application/xml+fhir", "XML", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Cancelled", "application/json+fhir", "JSON", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Cancelled", "application/xml+fhir", "XML", new string[0])]
        public virtual void ReadAppointmentCheckResponseContainsRequiredElements(string appointmentStatus, string header, string bodyFormat, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Read appointment check response contains required elements", exampleTags);
#line 105
this.ScenarioSetup(scenarioInfo);
#line 106
 testRunner.Given(string.Format("I find or create an appointment with status {0} for patient \"patient1\" at organiz" +
                        "ation \"ORG1\" and save the appointment resources to \"{0}Appointment{1}\"", appointmentStatus, bodyFormat), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 107
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 108
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:appointment\"" +
                    " interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 109
  testRunner.And(string.Format("I set the Accept header to \"{0}\"", header), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 110
 testRunner.When(string.Format("I perform an appointment read appointment stored against key \"{0}Appointment{1}\" " +
                        "for patient \"patient1\"", appointmentStatus, bodyFormat), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 111
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 112
  testRunner.And(string.Format("the response body should be FHIR {0}", bodyFormat), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 113
  testRunner.And("the response should be an Appointment resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 114
  testRunner.And("the appointment response resource contains a status with a valid value", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 115
  testRunner.And("the appointment response resource contains an start date", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 116
  testRunner.And("the appointment response resource contains an end date", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 117
  testRunner.And("the appointment response resource contains a slot reference", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 118
  testRunner.And("the appointment response resource contains atleast 2 participants a practitioner " +
                    "and a patient", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Read appointment if resource contains identifier then the value is mandatory")]
        public virtual void ReadAppointmentIfResourceContainsIdentifierThenTheValueIsMandatory()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Read appointment if resource contains identifier then the value is mandatory", ((string[])(null)));
#line 126
this.ScenarioSetup(scenarioInfo);
#line 127
 testRunner.Given("I find or create \"1\" appointments for patient \"patient1\" at organization \"ORG1\" a" +
                    "nd save bundle of appintment resources to \"Patient1AppointmentsInBundle\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 128
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 129
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:appointment\"" +
                    " interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 130
 testRunner.When("I perform an appointment read for the first appointment saved in the bundle of re" +
                    "sources stored against key \"Patient1AppointmentsInBundle\" for patient \"patient1\"" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 131
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 132
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 133
  testRunner.And("if the appointment response resource contains any identifiers they must have a va" +
                    "lue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Read appointment if reason is included in response check that it conforms to one " +
            "of the three valid types")]
        public virtual void ReadAppointmentIfReasonIsIncludedInResponseCheckThatItConformsToOneOfTheThreeValidTypes()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Read appointment if reason is included in response check that it conforms to one " +
                    "of the three valid types", ((string[])(null)));
#line 135
this.ScenarioSetup(scenarioInfo);
#line 136
 testRunner.Given("I find or create \"1\" appointments for patient \"patient1\" at organization \"ORG1\" a" +
                    "nd save bundle of appintment resources to \"Patient1AppointmentsInBundle\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 137
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 138
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:appointment\"" +
                    " interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 139
 testRunner.When("I perform an appointment read for the first appointment saved in the bundle of re" +
                    "sources stored against key \"Patient1AppointmentsInBundle\" for patient \"patient1\"" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 140
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 141
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 142
  testRunner.And("the response should be an Appointment resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 143
  testRunner.And("if the appointment response resource contains a reason element and coding the cod" +
                    "ings must be one of the three allowed with system code and display elements", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Read appointment containing a priority element and check that the priority is val" +
            "id")]
        public virtual void ReadAppointmentContainingAPriorityElementAndCheckThatThePriorityIsValid()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Read appointment containing a priority element and check that the priority is val" +
                    "id", ((string[])(null)));
#line 145
this.ScenarioSetup(scenarioInfo);
#line 146
 testRunner.Given("I create an appointment for patient \"patient1\" at organization \"ORG1\" with priori" +
                    "ty \"0\" and save appintment resources to \"Patient1PriorityAppointment\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 147
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 148
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:appointment\"" +
                    " interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 149
 testRunner.When("I perform an appointment read appointment stored against key \"Patient1PriorityApp" +
                    "ointment\" for patient \"patient1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 150
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 151
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 152
  testRunner.And("the response should be an Appointment resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 153
  testRunner.And("if the appointment contains a priority element it should be a valid value", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Read appointment and all participants must have a type or actor element")]
        public virtual void ReadAppointmentAndAllParticipantsMustHaveATypeOrActorElement()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Read appointment and all participants must have a type or actor element", ((string[])(null)));
#line 155
this.ScenarioSetup(scenarioInfo);
#line 156
 testRunner.Given("I find or create \"1\" appointments for patient \"patient1\" at organization \"ORG1\" a" +
                    "nd save bundle of appintment resources to \"Patient1AppointmentsInBundle\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 157
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 158
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:appointment\"" +
                    " interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 159
 testRunner.When("I perform an appointment read for the first appointment saved in the bundle of re" +
                    "sources stored against key \"Patient1AppointmentsInBundle\" for patient \"patient1\"" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 160
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 161
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 162
  testRunner.And("the response should be an Appointment resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 163
  testRunner.And("the returned appointment participants must contain a type or actor element", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Read appointment if extensions are included they should be valid")]
        [NUnit.Framework.TestCaseAttribute("Booked", "application/json+fhir", "JSON", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Booked", "application/xml+fhir", "XML", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Cancelled", "application/json+fhir", "JSON", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Cancelled", "application/xml+fhir", "XML", new string[0])]
        public virtual void ReadAppointmentIfExtensionsAreIncludedTheyShouldBeValid(string appointmentStatus, string header, string bodyFormat, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Read appointment if extensions are included they should be valid", exampleTags);
#line 165
this.ScenarioSetup(scenarioInfo);
#line 166
 testRunner.Given(string.Format("I find or create an appointment with status {0} for patient \"patient1\" at organiz" +
                        "ation \"ORG1\" and save the appointment resources to \"{0}Appointment{1}\"", appointmentStatus, bodyFormat), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 167
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 168
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:appointment\"" +
                    " interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 169
  testRunner.And(string.Format("I set the Accept header to \"{0}\"", header), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 170
 testRunner.When(string.Format("I perform an appointment read appointment stored against key \"{0}Appointment{1}\" " +
                        "for patient \"patient1\"", appointmentStatus, bodyFormat), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 171
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 172
  testRunner.And(string.Format("the response body should be FHIR {0}", bodyFormat), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 173
  testRunner.And("the response should be an Appointment resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 174
  testRunner.And("if the returned appointment contains appointmentCategory extension the value shou" +
                    "ld be valid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 175
  testRunner.And("if the returned appointment contains appointmentBookingMethod extension the value" +
                    " should be valid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 176
  testRunner.And("if the returned appointment contains appointmentContactMethod extension the value" +
                    " should be valid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 177
  testRunner.And("if the returned appointment contains appointmentCancellationReason extension the " +
                    "value should be valid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Read appointment and response should contain an ETag header")]
        public virtual void ReadAppointmentAndResponseShouldContainAnETagHeader()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Read appointment and response should contain an ETag header", ((string[])(null)));
#line 185
this.ScenarioSetup(scenarioInfo);
#line 186
 testRunner.Given("I find or create \"1\" appointments for patient \"patient1\" at organization \"ORG1\" a" +
                    "nd save bundle of appintment resources to \"Patient1AppointmentsInBundle\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 187
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 188
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:appointment\"" +
                    " interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 189
 testRunner.When("I perform an appointment read for the first appointment saved in the bundle of re" +
                    "sources stored against key \"Patient1AppointmentsInBundle\" for patient \"patient1\"" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 190
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 191
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 192
  testRunner.And("the response should be an Appointment resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 193
  testRunner.And("the response should contain the ETag header matching the resource version", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("VRead an appointment for a valid version of the patient appointment resource")]
        public virtual void VReadAnAppointmentForAValidVersionOfThePatientAppointmentResource()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("VRead an appointment for a valid version of the patient appointment resource", ((string[])(null)));
#line 195
this.ScenarioSetup(scenarioInfo);
#line 196
 testRunner.Given("I create an appointment for patient \"patient1\" at organization \"ORG1\" with priori" +
                    "ty \"0\" and save appintment resources to \"Patient1Appointment\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 197
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 198
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:appointment\"" +
                    " interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 199
        testRunner.And("I set the JWT requested record NHS number to config patient \"patient1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 200
        testRunner.And("I set the JWT requested scope to \"patient/*.read\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 201
 testRunner.When("I perform an appointment vread with history for appointment stored against key \"P" +
                    "atient1Appointment\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 202
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 203
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 204
  testRunner.And("the response should be an Appointment resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("VRead an appointment for a invalid version of the patient appoint resource")]
        public virtual void VReadAnAppointmentForAInvalidVersionOfThePatientAppointResource()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("VRead an appointment for a invalid version of the patient appoint resource", ((string[])(null)));
#line 206
this.ScenarioSetup(scenarioInfo);
#line 207
 testRunner.Given("I create an appointment for patient \"patient1\" at organization \"ORG1\" with priori" +
                    "ty \"0\" and save appintment resources to \"Patient1Appointment\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 208
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 209
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:appointment\"" +
                    " interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 210
        testRunner.And("I set the JWT requested record NHS number to config patient \"patient1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 211
        testRunner.And("I set the JWT requested scope to \"patient/*.read\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 212
 testRunner.When("I perform an appointment vread with version id \"NotARealVersionId\" for appointmen" +
                    "t stored against key \"Patient1Appointment\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 213
 testRunner.Then("the response status code should be \"404\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 214
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 215
  testRunner.And("the response should be a OperationOutcome resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
