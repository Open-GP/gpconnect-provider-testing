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
    [NUnit.Framework.DescriptionAttribute("StructuredImmunizations")]
    [NUnit.Framework.CategoryAttribute("structuredrecord")]
    public partial class StructuredImmunizationsFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "StructuredImmunizations.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "StructuredImmunizations", null, ProgrammingLanguage.CSharp, new string[] {
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
        [NUnit.Framework.DescriptionAttribute("Verify Immunizations structured record for a Patient with Immunizations")]
        [NUnit.Framework.CategoryAttribute("1.3.0")]
        [NUnit.Framework.TestCaseAttribute("patient2", null)]
        public virtual void VerifyImmunizationsStructuredRecordForAPatientWithImmunizations(string patient, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "1.3.0"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify Immunizations structured record for a Patient with Immunizations", null, @__tags);
#line 5
 this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 6
 testRunner.Given("I configure the default \"GpcGetStructuredRecord\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
  testRunner.And(string.Format("I add an NHS Number parameter for \"{0}\"", patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 8
  testRunner.And("I add the immunizations parameter", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
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
  testRunner.And(string.Format("the Bundle should be valid for patient \"{0}\"", patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
  testRunner.And("the Bundle should contain \"1\" lists", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
  testRunner.And("the Patient Id should be valid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
  testRunner.And("the Practitioner Id should be valid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
  testRunner.And("the Organization Id should be valid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Retrieve the immunizations structured record section for an invalid NHS number")]
        [NUnit.Framework.CategoryAttribute("1.3.0")]
        public virtual void RetrieveTheImmunizationsStructuredRecordSectionForAnInvalidNHSNumber()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Retrieve the immunizations structured record section for an invalid NHS number", null, new string[] {
                        "1.3.0"});
#line 43
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 44
 testRunner.Given("I configure the default \"GpcGetStructuredRecord\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 45
  testRunner.And("I add an NHS Number parameter for an invalid NHS Number", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
  testRunner.And("I add the immunizations parameter", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
 testRunner.When("I make the \"GpcGetStructuredRecord\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 48
 testRunner.Then("the response status code should indicate failure", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 49
  testRunner.And("the response should be a OperationOutcome resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Retrieve the immunizations structured record section for an empty NHS number")]
        [NUnit.Framework.CategoryAttribute("1.3.0")]
        public virtual void RetrieveTheImmunizationsStructuredRecordSectionForAnEmptyNHSNumber()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Retrieve the immunizations structured record section for an empty NHS number", null, new string[] {
                        "1.3.0"});
#line 52
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 53
 testRunner.Given("I configure the default \"GpcGetStructuredRecord\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 54
  testRunner.And("I add an NHS Number parameter with an empty NHS Number", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
  testRunner.And("I add the immunizations parameter", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
 testRunner.When("I make the \"GpcGetStructuredRecord\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 57
 testRunner.Then("the response status code should indicate failure", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 58
  testRunner.And("the response should be a OperationOutcome resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Retrieve the immunizations structured record section for an invalid Identifier Sy" +
            "stem")]
        [NUnit.Framework.CategoryAttribute("1.3.0")]
        public virtual void RetrieveTheImmunizationsStructuredRecordSectionForAnInvalidIdentifierSystem()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Retrieve the immunizations structured record section for an invalid Identifier Sy" +
                    "stem", null, new string[] {
                        "1.3.0"});
#line 61
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 62
 testRunner.Given("I configure the default \"GpcGetStructuredRecord\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 63
  testRunner.And("I add an NHS Number parameter for \"patient1\" with an invalid Identifier System", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
  testRunner.And("I add the immunizations parameter", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
 testRunner.When("I make the \"GpcGetStructuredRecord\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 66
 testRunner.Then("the response status code should indicate failure", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 67
  testRunner.And("the response should be a OperationOutcome resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Retrieve the immunizations structured record section for an empty Identifier Syst" +
            "em")]
        [NUnit.Framework.CategoryAttribute("1.3.0")]
        public virtual void RetrieveTheImmunizationsStructuredRecordSectionForAnEmptyIdentifierSystem()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Retrieve the immunizations structured record section for an empty Identifier Syst" +
                    "em", null, new string[] {
                        "1.3.0"});
#line 70
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 71
testRunner.Given("I configure the default \"GpcGetStructuredRecord\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 72
  testRunner.And("I add an NHS Number parameter for \"patient1\" with an empty Identifier System", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 73
  testRunner.And("I add the immunizations parameter", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 74
 testRunner.When("I make the \"GpcGetStructuredRecord\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 75
 testRunner.Then("the response status code should indicate failure", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 76
  testRunner.And("the response should be a OperationOutcome resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Retrieve the immunizations structured record for a patient that has sensitive fla" +
            "g")]
        [NUnit.Framework.CategoryAttribute("1.3.0")]
        public virtual void RetrieveTheImmunizationsStructuredRecordForAPatientThatHasSensitiveFlag()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Retrieve the immunizations structured record for a patient that has sensitive fla" +
                    "g", null, new string[] {
                        "1.3.0"});
#line 79
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 80
 testRunner.Given("I configure the default \"GpcGetStructuredRecord\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 81
 testRunner.And("I add an NHS Number parameter for \"patient9\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 82
 testRunner.And("I add the immunizations parameter", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 83
 testRunner.When("I make the \"GpcGetStructuredRecord\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 84
 testRunner.Then("the response status code should indicate failure", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 85
  testRunner.And("the response should be a OperationOutcome resource with error code \"PATIENT_NOT_F" +
                    "OUND\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Retrieve the immunizations structured record for a patient that has no immunizati" +
            "ons")]
        [NUnit.Framework.CategoryAttribute("1.3.0")]
        public virtual void RetrieveTheImmunizationsStructuredRecordForAPatientThatHasNoImmunizations()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Retrieve the immunizations structured record for a patient that has no immunizati" +
                    "ons", null, new string[] {
                        "1.3.0"});
#line 88
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 89
 testRunner.Given("I configure the default \"GpcGetStructuredRecord\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 90
  testRunner.And("I add an NHS Number parameter for \"patient4\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 91
  testRunner.And("I add the immunizations parameter", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 92
 testRunner.When("I make the \"GpcGetStructuredRecord\" request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 93
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 94
  testRunner.And("the response should be a Bundle resource of type \"collection\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 95
  testRunner.And("the response meta profile should be for \"structured\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 96
  testRunner.And("the patient resource in the bundle should contain meta data profile and version i" +
                    "d", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
  testRunner.And("if the response bundle contains a practitioner resource it should contain meta da" +
                    "ta profile and version id", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 98
  testRunner.And("if the response bundle contains an organization resource it should contain meta d" +
                    "ata profile and version id", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
  testRunner.And("the Bundle should be valid for patient \"patient4\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 100
  testRunner.And("the Bundle should contain \"1\" lists", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 101
  testRunner.And("the Patient Id should be valid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 102
  testRunner.And("the Practitioner Id should be valid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 103
  testRunner.And("the Organization Id should be valid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
