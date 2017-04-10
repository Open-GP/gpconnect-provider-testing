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
    [NUnit.Framework.DescriptionAttribute("SpecFlowFeature1")]
    public partial class SpecFlowFeature1Feature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "AppointmentRetrieve.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "SpecFlowFeature1", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        "patient3",
                        "9000000003"});
            table1.AddRow(new string[] {
                        "patient16",
                        "9000000016"});
            table1.AddRow(new string[] {
                        "DeceasedPatient",
                        "9000000017"});
#line 5
 testRunner.Given("I have the following patient records", ((string)(null)), table1, "Given ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Appointment retrieve success valid id")]
        [NUnit.Framework.CategoryAttribute("Appointment")]
        [NUnit.Framework.TestCaseAttribute("1", new string[0])]
        [NUnit.Framework.TestCaseAttribute("2", new string[0])]
        [NUnit.Framework.TestCaseAttribute("400000", new string[0])]
        public virtual void AppointmentRetrieveSuccessValidId(string id, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Appointment"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Appointment retrieve success valid id", @__tags);
#line 16
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 17
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 18
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:search:patient_ap" +
                    "pointments\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.When(string.Format("I make a GET request to \"/Patient/{0}/Appointment\"", id), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 20
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 21
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
  testRunner.And("the response should be a Bundle resource of type \"searchset\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Appointment retrieve fail invalid id")]
        [NUnit.Framework.TestCaseAttribute("**", new string[0])]
        [NUnit.Framework.TestCaseAttribute("dd", new string[0])]
        [NUnit.Framework.TestCaseAttribute("", new string[0])]
        [NUnit.Framework.TestCaseAttribute("null", new string[0])]
        public virtual void AppointmentRetrieveFailInvalidId(string id, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Appointment retrieve fail invalid id", exampleTags);
#line 29
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 30
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 31
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:search:patient_ap" +
                    "pointments\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
 testRunner.When(string.Format("I make a GET request to \"/Patient/{0}/Appointment\"", id), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 33
 testRunner.Then("the response status code should be \"400\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 34
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
  testRunner.And("the response should be a OperationOutcome resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Appointment retrieve failure due to missing header")]
        [NUnit.Framework.TestCaseAttribute("Ssp-TraceID", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Ssp-From", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Ssp-To", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Ssp-InteractionId", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Authorization", new string[0])]
        public virtual void AppointmentRetrieveFailureDueToMissingHeader(string header, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Appointment retrieve failure due to missing header", exampleTags);
#line 43
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 44
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 45
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:search:patient_ap" +
                    "pointments\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
  testRunner.And(string.Format("I do not send header \"{0}\"", header), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
 testRunner.When("I make a GET request to \"/Patient/1/Appointment\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 48
 testRunner.Then("the response status code should be \"400\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 49
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
  testRunner.And("the response should be a OperationOutcome resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Appointment retrieve interaction id incorrect fail")]
        [NUnit.Framework.TestCaseAttribute("urn:nhs:names:services:gpconnect:fhir:rest:search:organization", new string[0])]
        [NUnit.Framework.TestCaseAttribute("urn:nhs:names:services:gpconnect:fhir:operation:gpc.getcarerecord", new string[0])]
        [NUnit.Framework.TestCaseAttribute("", new string[0])]
        [NUnit.Framework.TestCaseAttribute("null", new string[0])]
        public virtual void AppointmentRetrieveInteractionIdIncorrectFail(string interactionId, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Appointment retrieve interaction id incorrect fail", exampleTags);
#line 59
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 60
    testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 61
        testRunner.And(string.Format("I am performing the \"{0}\" interaction", interactionId), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
    testRunner.When("I make a GET request to \"/Patient/1/Appointment\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 63
    testRunner.Then("the response status code should be \"400\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 64
        testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
        testRunner.And("the response should be a OperationOutcome resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Appointment retrieve accept header and _format parameter")]
        [NUnit.Framework.TestCaseAttribute("application/json+fhir", "application/json+fhir", "JSON", new string[0])]
        [NUnit.Framework.TestCaseAttribute("application/json+fhir", "application/xml+fhir", "XML", new string[0])]
        [NUnit.Framework.TestCaseAttribute("application/xml+fhir", "application/json+fhir", "JSON", new string[0])]
        [NUnit.Framework.TestCaseAttribute("application/xml+fhir", "application/xml+fhir", "XML", new string[0])]
        public virtual void AppointmentRetrieveAcceptHeaderAnd_FormatParameter(string header, string parameter, string bodyFormat, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Appointment retrieve accept header and _format parameter", exampleTags);
#line 73
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 74
    testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 75
        testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:search:patient_ap" +
                    "pointments\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
        testRunner.And(string.Format("I set the Accept header to \"{0}\"", header), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
        testRunner.And(string.Format("I add the parameter \"_format\" with the value \"{0}\"", parameter), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 78
    testRunner.When("I make a GET request to \"/Patient/1/Appointment\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 79
    testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 80
        testRunner.And(string.Format("the response body should be FHIR {0}", bodyFormat), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 81
        testRunner.And("the response should be a Bundle resource of type \"searchset\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Appointment retrieve accept header")]
        [NUnit.Framework.TestCaseAttribute("application/json+fhir", "JSON", new string[0])]
        [NUnit.Framework.TestCaseAttribute("application/xml+fhir", "XML", new string[0])]
        public virtual void AppointmentRetrieveAcceptHeader(string header, string bodyFormat, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Appointment retrieve accept header", exampleTags);
#line 90
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 91
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 92
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:search:patient_ap" +
                    "pointments\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 93
  testRunner.And(string.Format("I set the Accept header to \"{0}\"", header), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 94
 testRunner.When("I make a GET request to \"/Patient/2/Appointment\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 95
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 96
  testRunner.And(string.Format("the response body should be FHIR {0}", bodyFormat), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
  testRunner.And("the response should be a Bundle resource of type \"searchset\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Appointment retrieve bundle resource with empty appointment resource")]
        [NUnit.Framework.TestCaseAttribute("1", new string[0])]
        [NUnit.Framework.TestCaseAttribute("1000", new string[0])]
        [NUnit.Framework.TestCaseAttribute("45", new string[0])]
        [NUnit.Framework.TestCaseAttribute("99", new string[0])]
        public virtual void AppointmentRetrieveBundleResourceWithEmptyAppointmentResource(string id, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Appointment retrieve bundle resource with empty appointment resource", exampleTags);
#line 105
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 106
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 107
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:search:patient_ap" +
                    "pointments\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 108
 testRunner.When(string.Format("I make a GET request to \"/Patient/{0}/Appointment\"", id), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 109
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 110
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 111
        testRunner.And("the response should be a Bundle resource of type \"searchset\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 112
  testRunner.And("there are zero appointment resources", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Appointment retrieve bundle resource with multiple appointment resources")]
        [NUnit.Framework.TestCaseAttribute("2", new string[0])]
        public virtual void AppointmentRetrieveBundleResourceWithMultipleAppointmentResources(string id, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Appointment retrieve bundle resource with multiple appointment resources", exampleTags);
#line 120
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 121
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 122
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:search:patient_ap" +
                    "pointments\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 123
 testRunner.When(string.Format("I make a GET request to \"/Patient/{0}/Appointment\"", id), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 124
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 125
  testRunner.And("the response should be a Bundle resource of type \"JSON\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 126
        testRunner.And("the response should be a Bundle resource of type \"searchset\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 127
  testRunner.And("there are multiple appointment resources", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 128
 testRunner.Then("the bundle appointment resource should contain contain a single status element", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 129
  testRunner.And("status should have a valid value", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Appointment retrieve bundle resource must contain status and participant")]
        public virtual void AppointmentRetrieveBundleResourceMustContainStatusAndParticipant()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Appointment retrieve bundle resource must contain status and participant", ((string[])(null)));
#line 134
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 135
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 136
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:search:patient_ap" +
                    "pointments\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 137
 testRunner.When("I make a GET request to \"/Patient/2/Appointment\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 138
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 139
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 140
        testRunner.And("the response should be a Bundle resource of type \"searchset\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 141
 testRunner.Then("the bundle appointment resource should contain contain a single status element", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 142
  testRunner.And("the appointment status element should be valid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Appointment retrieve bundle of coding type SNOMED resource must contain coding wi" +
            "th valid system and code and display")]
        public virtual void AppointmentRetrieveBundleOfCodingTypeSNOMEDResourceMustContainCodingWithValidSystemAndCodeAndDisplay()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Appointment retrieve bundle of coding type SNOMED resource must contain coding wi" +
                    "th valid system and code and display", ((string[])(null)));
#line 144
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 145
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 146
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:search:patient_ap" +
                    "pointments\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 147
 testRunner.When("I make a GET request to \"/Patient/2/Appointment\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 148
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 149
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 150
  testRunner.And("if appointment contains the resource coding SNOMED CT element the fields should m" +
                    "atch the fixed values of the specification", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Appointment retrieve bundle of coding type READ V2 resource must contain coding w" +
            "ith valid system and code and display")]
        public virtual void AppointmentRetrieveBundleOfCodingTypeREADV2ResourceMustContainCodingWithValidSystemAndCodeAndDisplay()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Appointment retrieve bundle of coding type READ V2 resource must contain coding w" +
                    "ith valid system and code and display", ((string[])(null)));
#line 152
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 153
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 154
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:search:patient_ap" +
                    "pointments\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 155
 testRunner.When("I make a GET request to \"/Patient/2/Appointment\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 156
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 157
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 158
  testRunner.And("if appointment contains the resource coding READ V2 element the fields should mat" +
                    "ch the fixed values of the specification", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Appointment retrieve bundle of coding type SREAD CTV3 resource must contain codin" +
            "g with valid system and code and display")]
        public virtual void AppointmentRetrieveBundleOfCodingTypeSREADCTV3ResourceMustContainCodingWithValidSystemAndCodeAndDisplay()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Appointment retrieve bundle of coding type SREAD CTV3 resource must contain codin" +
                    "g with valid system and code and display", ((string[])(null)));
#line 160
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 161
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 162
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:search:patient_ap" +
                    "pointments\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 163
 testRunner.When("I make a GET request to \"/Patient/2/Appointment\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 164
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 165
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 166
  testRunner.And("if appointment contains the resource coding SREAD CTV3 element the fields should " +
                    "match the fixed values of the specification", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Appointment retrieve bundle contains appointment with identifer with correct syst" +
            "em and value")]
        public virtual void AppointmentRetrieveBundleContainsAppointmentWithIdentiferWithCorrectSystemAndValue()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Appointment retrieve bundle contains appointment with identifer with correct syst" +
                    "em and value", ((string[])(null)));
#line 168
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 169
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 170
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:search:patient_ap" +
                    "pointments\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 171
 testRunner.When("I make a GET request to \"/Patient/2/Appointment\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 172
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 173
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 174
  testRunner.And("if the appointment resource contains an identifier it contains a valid system and" +
                    " value", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Appointment retrieve bundle contains appointment with valid start and end date fo" +
            "rmat")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        [NUnit.Framework.CategoryAttribute("Checks")]
        [NUnit.Framework.CategoryAttribute("the")]
        [NUnit.Framework.CategoryAttribute("ranges")]
        [NUnit.Framework.CategoryAttribute("are")]
        [NUnit.Framework.CategoryAttribute("sensible")]
        [NUnit.Framework.CategoryAttribute("but")]
        [NUnit.Framework.CategoryAttribute("can")]
        [NUnit.Framework.CategoryAttribute("probably")]
        [NUnit.Framework.CategoryAttribute("be")]
        [NUnit.Framework.CategoryAttribute("removed")]
        [NUnit.Framework.CategoryAttribute("as")]
        [NUnit.Framework.CategoryAttribute("an")]
        [NUnit.Framework.CategoryAttribute("appointment")]
        [NUnit.Framework.CategoryAttribute("is")]
        [NUnit.Framework.CategoryAttribute("lokely")]
        [NUnit.Framework.CategoryAttribute("no")]
        [NUnit.Framework.CategoryAttribute("longer")]
        [NUnit.Framework.CategoryAttribute("then")]
        [NUnit.Framework.CategoryAttribute("an")]
        [NUnit.Framework.CategoryAttribute("hour,")]
        [NUnit.Framework.CategoryAttribute("NEEDS")]
        [NUnit.Framework.CategoryAttribute("FURTHER")]
        [NUnit.Framework.CategoryAttribute("THINKING")]
        [NUnit.Framework.TestCaseAttribute("1", "1", "1", new string[0])]
        [NUnit.Framework.TestCaseAttribute("0", "0", "0", new string[0])]
        [NUnit.Framework.TestCaseAttribute("4", "12", "3", new string[0])]
        [NUnit.Framework.TestCaseAttribute("9", "1", "4", new string[0])]
        public virtual void AppointmentRetrieveBundleContainsAppointmentWithValidStartAndEndDateFormat(string days, string months, string years, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Ignore",
                    "Checks",
                    "the",
                    "ranges",
                    "are",
                    "sensible",
                    "but",
                    "can",
                    "probably",
                    "be",
                    "removed",
                    "as",
                    "an",
                    "appointment",
                    "is",
                    "lokely",
                    "no",
                    "longer",
                    "then",
                    "an",
                    "hour,",
                    "NEEDS",
                    "FURTHER",
                    "THINKING"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Appointment retrieve bundle contains appointment with valid start and end date fo" +
                    "rmat", @__tags);
#line 178
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 179
testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 180
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:search:patient_ap" +
                    "pointments\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 181
 testRunner.When("I make a GET request to \"/Patient/2/Appointment\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 182
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 183
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 184
  testRunner.And(string.Format("if the bundle contains a appointment resource the start and end date days are wit" +
                        "hin range \"{0}\" days", days), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 185
  testRunner.And(string.Format("if the bundle contains a appointment resource the start and end date months are w" +
                        "ithin range \"{0}\" months", months), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 186
  testRunner.And(string.Format("if the bundle contains a appointment resource the start and end date years are wi" +
                        "thin range \"{0}\" years", years), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 187
  testRunner.And("if the the start date must be before the end date", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Appointment retrieve bundle contains appointment with slot")]
        public virtual void AppointmentRetrieveBundleContainsAppointmentWithSlot()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Appointment retrieve bundle contains appointment with slot", ((string[])(null)));
#line 196
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 197
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 198
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:search:patient_ap" +
                    "pointments\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 199
 testRunner.When("I make a GET request to \"/Patient/2/Appointment\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 200
  testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 201
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 202
  testRunner.And("the appointment shall contain a slot or multiple slots", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
