// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:3.0.0.0
//      SpecFlow Generator Version:3.0.0.0
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
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("StructuredConsultations")]
    [NUnit.Framework.CategoryAttribute("structuredrecord")]
    public partial class StructuredConsultationsFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "StructuredConsultations.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "StructuredConsultations", null, ProgrammingLanguage.CSharp, new string[] {
                        "structuredrecord"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
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
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify Consultations structured record for a Patient")]
        [NUnit.Framework.CategoryAttribute("1.3.1")]
        [NUnit.Framework.CategoryAttribute("WIP")]
        public virtual void VerifyConsultationsStructuredRecordForAPatient()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify Consultations structured record for a Patient", null, new string[] {
                        "1.3.1",
                        "WIP"});
#line 5
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 6
 testRunner.Given("I configure the default \"GpcGetStructuredRecord\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
  testRunner.And("I add an NHS Number parameter for \"patient2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 8
  testRunner.And("I add the Consultations parameter", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
 testRunner.When("I make the \"GpcGetStructuredRecord\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 11
  testRunner.And("the response should be a Bundle resource of type \"collection\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
  testRunner.And("the response meta profile should be for \"structured\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
  testRunner.And("the patient resource in the bundle should contain meta data profile and version i" +
                    "d", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
  testRunner.And("if the response bundle contains a practitioner resource it should contain meta da" +
                    "ta profile and version id", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
  testRunner.And("if the response bundle contains an organization resource it should contain meta d" +
                    "ata profile and version id", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
  testRunner.And("the Bundle should be valid for patient \"patient2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
  testRunner.And("the Patient Id should be valid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
  testRunner.And("the Practitioner Id should be valid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
  testRunner.And("the Organization Id should be valid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
  testRunner.And("I Check the Consultations List", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
  testRunner.And("I Check the Consultation Lists", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
  testRunner.And("I Check All The Consultation Lists Do Not Include Not In Use Fields", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
  testRunner.And("I Check the Topic Lists", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Retrieve consultations structured record for a patient that has no consultation d" +
            "ata")]
        [NUnit.Framework.CategoryAttribute("1.3.1")]
        public virtual void RetrieveConsultationsStructuredRecordForAPatientThatHasNoConsultationData()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Retrieve consultations structured record for a patient that has no consultation d" +
                    "ata", null, new string[] {
                        "1.3.1"});
#line 32
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 33
 testRunner.Given("I configure the default \"GpcGetStructuredRecord\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 34
  testRunner.And("I add an NHS Number parameter for \"patient4\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
  testRunner.And("I add the Consultations parameter", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
 testRunner.When("I make the \"GpcGetStructuredRecord\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 37
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 38
  testRunner.And("the response should be a Bundle resource of type \"collection\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
  testRunner.And("the response meta profile should be for \"structured\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
  testRunner.And("the patient resource in the bundle should contain meta data profile and version i" +
                    "d", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
  testRunner.And("if the response bundle contains a practitioner resource it should contain meta da" +
                    "ta profile and version id", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
  testRunner.And("if the response bundle contains an organization resource it should contain meta d" +
                    "ata profile and version id", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
  testRunner.And("the Bundle should be valid for patient \"patient4\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
  testRunner.And("the Patient Id should be valid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
  testRunner.And("the Practitioner Id should be valid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
  testRunner.And("the Organization Id should be valid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
  testRunner.And("check the response does not contain an operation outcome", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
  testRunner.And("check structured list contains a note and emptyReason when no data in section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Retrieve consultations structured record section for an invalid NHS number")]
        [NUnit.Framework.CategoryAttribute("1.3.1")]
        public virtual void RetrieveConsultationsStructuredRecordSectionForAnInvalidNHSNumber()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Retrieve consultations structured record section for an invalid NHS number", null, new string[] {
                        "1.3.1"});
#line 51
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 52
 testRunner.Given("I configure the default \"GpcGetStructuredRecord\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 53
  testRunner.And("I add an NHS Number parameter for an invalid NHS Number", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
  testRunner.And("I add the Consultations parameter", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
 testRunner.When("I make the \"GpcGetStructuredRecord\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 56
 testRunner.Then("the response status code should indicate failure", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 57
  testRunner.And("the response should be a OperationOutcome resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Retrieve consultations structured record section for an empty NHS number")]
        [NUnit.Framework.CategoryAttribute("1.3.1")]
        public virtual void RetrieveConsultationsStructuredRecordSectionForAnEmptyNHSNumber()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Retrieve consultations structured record section for an empty NHS number", null, new string[] {
                        "1.3.1"});
#line 60
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 61
 testRunner.Given("I configure the default \"GpcGetStructuredRecord\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 62
  testRunner.And("I add an NHS Number parameter with an empty NHS Number", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
  testRunner.And("I add the Consultations parameter", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
 testRunner.When("I make the \"GpcGetStructuredRecord\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 65
 testRunner.Then("the response status code should indicate failure", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 66
  testRunner.And("the response should be a OperationOutcome resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Retrieve consultations structured record section for an invalid Identifier System" +
            "")]
        [NUnit.Framework.CategoryAttribute("1.3.1")]
        public virtual void RetrieveConsultationsStructuredRecordSectionForAnInvalidIdentifierSystem()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Retrieve consultations structured record section for an invalid Identifier System" +
                    "", null, new string[] {
                        "1.3.1"});
#line 69
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 70
 testRunner.Given("I configure the default \"GpcGetStructuredRecord\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 71
  testRunner.And("I add an NHS Number parameter for \"patient1\" with an invalid Identifier System", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 72
  testRunner.And("I add the Consultations parameter", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 73
 testRunner.When("I make the \"GpcGetStructuredRecord\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 74
 testRunner.Then("the response status code should indicate failure", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 75
  testRunner.And("the response should be a OperationOutcome resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Retrieve consultations structured record section for an empty Identifier System")]
        [NUnit.Framework.CategoryAttribute("1.3.1")]
        public virtual void RetrieveConsultationsStructuredRecordSectionForAnEmptyIdentifierSystem()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Retrieve consultations structured record section for an empty Identifier System", null, new string[] {
                        "1.3.1"});
#line 78
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 79
testRunner.Given("I configure the default \"GpcGetStructuredRecord\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 80
  testRunner.And("I add an NHS Number parameter for \"patient1\" with an empty Identifier System", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 81
  testRunner.And("I add the Consultations parameter", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 82
 testRunner.When("I make the \"GpcGetStructuredRecord\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 83
 testRunner.Then("the response status code should indicate failure", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 84
  testRunner.And("the response should be a OperationOutcome resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Retrieve consultations structured record for a patient that has sensitive flag")]
        [NUnit.Framework.CategoryAttribute("1.3.1")]
        public virtual void RetrieveConsultationsStructuredRecordForAPatientThatHasSensitiveFlag()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Retrieve consultations structured record for a patient that has sensitive flag", null, new string[] {
                        "1.3.1"});
#line 87
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 88
 testRunner.Given("I configure the default \"GpcGetStructuredRecord\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 89
 testRunner.And("I add an NHS Number parameter for \"patient9\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 90
 testRunner.And("I add the Consultations parameter", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 91
 testRunner.When("I make the \"GpcGetStructuredRecord\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 92
 testRunner.Then("the response status code should indicate failure", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 93
  testRunner.And("the response status code should be \"404\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 94
  testRunner.And("the response should be a OperationOutcome resource with error code \"PATIENT_NOT_F" +
                    "OUND\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
