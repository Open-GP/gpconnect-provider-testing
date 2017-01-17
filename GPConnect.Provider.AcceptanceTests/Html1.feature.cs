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
    [NUnit.Framework.DescriptionAttribute("Html")]
    [NUnit.Framework.CategoryAttribute("http")]
    public partial class HtmlFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Html.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Html", null, ProgrammingLanguage.CSharp, new string[] {
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
                        "patient1",
                        "9476719931"});
            table1.AddRow(new string[] {
                        "patient2",
                        "9476719974"});
            table1.AddRow(new string[] {
                        "patientNotInSystem",
                        "9999999999"});
            table1.AddRow(new string[] {
                        "patientNoSharingConsent",
                        "9476719958"});
#line 5
 testRunner.Given("I have the following patient records", ((string)(null)), table1, "Given ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("HTML does not contain disallowed elements")]
        [NUnit.Framework.TestCaseAttribute("ADM", new string[0])]
        [NUnit.Framework.TestCaseAttribute("ALL", new string[0])]
        [NUnit.Framework.TestCaseAttribute("CLI", new string[0])]
        [NUnit.Framework.TestCaseAttribute("ENC", new string[0])]
        [NUnit.Framework.TestCaseAttribute("IMM", new string[0])]
        [NUnit.Framework.TestCaseAttribute("MED", new string[0])]
        [NUnit.Framework.TestCaseAttribute("OBS", new string[0])]
        [NUnit.Framework.TestCaseAttribute("PRB", new string[0])]
        [NUnit.Framework.TestCaseAttribute("SUM", new string[0])]
        public virtual void HTMLDoesNotContainDisallowedElements(string code, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("HTML does not contain disallowed elements", exampleTags);
#line 12
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 13
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 14
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:operation:gpc.getcarer" +
                    "ecord\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
  testRunner.And(string.Format("I author a request for the \"{0}\" care record section for config patient \"patient1" +
                        "\"", code), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.When("I request the FHIR \"gpc.getcarerecord\" Patient Type operation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 18
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
  testRunner.And("the JSON response should be a Bundle resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
  testRunner.And("the html should be valid xhtml", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
  testRunner.And("the html should not contain \"head\" tags", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
  testRunner.And("the html should not contain \"body\" tags", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
  testRunner.And("the html should not contain \"script\" tags", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
  testRunner.And("the html should not contain \"style\" tags", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
  testRunner.And("the html should not contain \"iframe\" tags", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
  testRunner.And("the html should not contain \"form\" tags", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
  testRunner.And("the html should not contain \"a\" tags", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
  testRunner.And("the html should not contain any attributes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("section headers present")]
        [NUnit.Framework.TestCaseAttribute("ADM", "Administrative Items", new string[0])]
        [NUnit.Framework.TestCaseAttribute("ALL", "Current Allergies and Adverse Reactions,Historical Allergies and Adverse Reaction" +
            "s", new string[0])]
        [NUnit.Framework.TestCaseAttribute("CLI", "Clinical Items", new string[0])]
        [NUnit.Framework.TestCaseAttribute("ENC", "Encounters", new string[0])]
        [NUnit.Framework.TestCaseAttribute("IMM", "Immunisations", new string[0])]
        [NUnit.Framework.TestCaseAttribute("MED", "Current Medication Issues,Current Repeat Medications,Past Medications", new string[0])]
        [NUnit.Framework.TestCaseAttribute("OBS", "Observations", new string[0])]
        [NUnit.Framework.TestCaseAttribute("PRB", "Active Problems and Issues,Inactive Problems and Issues", new string[0])]
        [NUnit.Framework.TestCaseAttribute("SUM", "Active Problems and Issues,Current Medication Issues,Current Repeat Medications,C" +
            "urrent Allergies and Adverse Reactions,Encounters", new string[0])]
        public virtual void SectionHeadersPresent(string code, string headers, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("section headers present", exampleTags);
#line 44
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 45
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 46
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:operation:gpc.getcarer" +
                    "ecord\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
  testRunner.And(string.Format("I author a request for the \"{0}\" care record section for config patient \"patient1" +
                        "\"", code), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
 testRunner.When("I request the FHIR \"gpc.getcarerecord\" Patient Type operation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 49
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 50
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
  testRunner.And("the JSON response should be a Bundle resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
  testRunner.And(string.Format("the html should not contain headers in coma seperated list \"{0}\"", headers), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("content table headers present")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        public virtual void ContentTableHeadersPresent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("content table headers present", new string[] {
                        "ignore"});
#line 69
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("filtered sections should contain date range section banner")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        public virtual void FilteredSectionsShouldContainDateRangeSectionBanner()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("filtered sections should contain date range section banner", new string[] {
                        "ignore"});
#line 72
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("System does not support section html response where appropriate")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        [NUnit.Framework.CategoryAttribute("Manual")]
        public virtual void SystemDoesNotSupportSectionHtmlResponseWhereAppropriate()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("System does not support section html response where appropriate", new string[] {
                        "ignore",
                        "Manual"});
#line 75
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
