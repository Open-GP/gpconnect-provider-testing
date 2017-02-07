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
                        "PWTP2",
                        "9990049416"});
            table1.AddRow(new string[] {
                        "PWTP3",
                        "9990049424"});
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
        [NUnit.Framework.TestCaseAttribute("REF", new string[0])]
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
  testRunner.And(string.Format("I author a request for the \"{0}\" care record section for config patient \"PWTP2\"", code), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
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
        [NUnit.Framework.DescriptionAttribute("html section headers present")]
        [NUnit.Framework.TestCaseAttribute("PWTP2", "ADM", "Administrative Items", new string[0])]
        [NUnit.Framework.TestCaseAttribute("PWTP2", "ALL", "Current Allergies and Adverse Reactions,Historical Allergies and Adverse Reaction" +
            "s", new string[0])]
        [NUnit.Framework.TestCaseAttribute("PWTP2", "CLI", "Clinical Items", new string[0])]
        [NUnit.Framework.TestCaseAttribute("PWTP2", "ENC", "Encounters", new string[0])]
        [NUnit.Framework.TestCaseAttribute("PWTP2", "IMM", "Immunisations", new string[0])]
        [NUnit.Framework.TestCaseAttribute("PWTP2", "MED", "Current Medication Issues,Current Repeat Medications,Past Medications", new string[0])]
        [NUnit.Framework.TestCaseAttribute("PWTP2", "OBS", "Observations", new string[0])]
        [NUnit.Framework.TestCaseAttribute("PWTP2", "PRB", "Active Problems and Issues,Inactive Problems and Issues", new string[0])]
        [NUnit.Framework.TestCaseAttribute("PWTP2", "REF", "Referrals", new string[0])]
        [NUnit.Framework.TestCaseAttribute("PWTP2", "SUM", "Active Problems and Issues,Current Medication Issues,Current Repeat Medications,C" +
            "urrent Allergies and Adverse Reactions,Encounters", new string[0])]
        public virtual void HtmlSectionHeadersPresent(string patient, string code, string headers, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("html section headers present", exampleTags);
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
  testRunner.And(string.Format("I author a request for the \"{0}\" care record section for config patient \"{1}\"", code, patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
 testRunner.When("I request the FHIR \"gpc.getcarerecord\" Patient Type operation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 49
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 50
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
  testRunner.And("the JSON response should be a Bundle resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
  testRunner.And(string.Format("the html should contain headers in coma seperated list \"{0}\"", headers), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("html table headers present and in order that is expected")]
        [NUnit.Framework.TestCaseAttribute("PWTP2", "ADM", "Date,Entry,Details", "1", new string[0])]
        [NUnit.Framework.TestCaseAttribute("PWTP2", "ALL", "Start Date,Details", "1", new string[0])]
        [NUnit.Framework.TestCaseAttribute("PWTP2", "ALL", "Start Date,End Date,Details", "2", new string[0])]
        [NUnit.Framework.TestCaseAttribute("PWTP2", "CLI", "Date,Entry,Details", "1", new string[0])]
        [NUnit.Framework.TestCaseAttribute("PWTP2", "ENC", "Date,Title,Details", "1", new string[0])]
        [NUnit.Framework.TestCaseAttribute("PWTP2", "IMM", "Date,Vaccination,Part,Contents,Details", "1", new string[0])]
        [NUnit.Framework.TestCaseAttribute("PWTP2", "MED", "Start Date,Medication Item,Type,Scheduled End Date,Days Duration,Details", "1", new string[0])]
        [NUnit.Framework.TestCaseAttribute("PWTP2", "MED", "Last Issued,Medication Item,Start Date,Review Date,Number Issued,Max Issues,Detai" +
            "ls", "2", new string[0])]
        [NUnit.Framework.TestCaseAttribute("PWTP2", "MED", "Start Date,Medication Item,Type,Last Issued,Review Date,Number Issued,Max Issued," +
            "Details", "3", new string[0])]
        [NUnit.Framework.TestCaseAttribute("PWTP2", "OBS", "Date,Entry,Value,Details", "1", new string[0])]
        [NUnit.Framework.TestCaseAttribute("PWTP2", "PRB", "Start Date,Entry,Significance,Details", "1", new string[0])]
        [NUnit.Framework.TestCaseAttribute("PWTP2", "PRB", "Start Date,End Date,Entry,Significance,Details", "2", new string[0])]
        [NUnit.Framework.TestCaseAttribute("PWTP2", "REF", "Date,From,To,Priority,Details", "1", new string[0])]
        [NUnit.Framework.TestCaseAttribute("PWTP2", "SUM", "Start Date,Entry,Significance,Details", "1", new string[0])]
        [NUnit.Framework.TestCaseAttribute("PWTP2", "SUM", "Start Date,Medication Item,Type,Scheduled End Date,Days Duration,Details", "2", new string[0])]
        [NUnit.Framework.TestCaseAttribute("PWTP2", "SUM", "Last Issued,Medication Item,Start Date,Review Date,Number Issued,Max Issues,Detai" +
            "ls", "3", new string[0])]
        [NUnit.Framework.TestCaseAttribute("PWTP2", "SUM", "Start Date,Details", "4", new string[0])]
        [NUnit.Framework.TestCaseAttribute("PWTP2", "SUM", "Date,Title,Details", "5", new string[0])]
        public virtual void HtmlTableHeadersPresentAndInOrderThatIsExpected(string patient, string code, string headers, string pageSectionIndex, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("html table headers present and in order that is expected", exampleTags);
#line 70
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 71
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 72
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:operation:gpc.getcarer" +
                    "ecord\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 73
  testRunner.And(string.Format("I author a request for the \"{0}\" care record section for config patient \"{1}\"", code, patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 74
 testRunner.When("I request the FHIR \"gpc.getcarerecord\" Patient Type operation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 75
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 76
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
  testRunner.And("the JSON response should be a Bundle resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 78
  testRunner.And(string.Format("the html should contain table headers in coma seperated list order \"{0}\" for the " +
                        "\"{1}\"", headers, pageSectionIndex), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("filtered sections should contain date range section banner")]
        [NUnit.Framework.TestCaseAttribute("ADM", "PWTP2", "2014-05-03", "2016-09-14", "03-May-2014", "14-Sep-2016", new string[0])]
        [NUnit.Framework.TestCaseAttribute("CLI", "PWTP2", "2014-02-03", "2016-01-24", "04-Feb-2014", "24-Jan-2016", new string[0])]
        [NUnit.Framework.TestCaseAttribute("ENC", "PWTP2", "1982-10-05", "2016-09-01", "05-Oct-1982", "01-Sep-2016", new string[0])]
        [NUnit.Framework.TestCaseAttribute("SUM", "PWTP2", "2014-03-21", "2016-12-14", "21-Mar-2014", "14-Dec-2016", new string[0])]
        [NUnit.Framework.TestCaseAttribute("REF", "PWTP2", "2014-03-21", "2016-12-14", "21-Mar-2014", "14-Dec-2016", new string[0])]
        [NUnit.Framework.TestCaseAttribute("ADM", "PWTP2", "2014-05", "2016-09", "01-May-2014", "01-Sep-2016", new string[0])]
        [NUnit.Framework.TestCaseAttribute("CLI", "PWTP2", "2014-02", "2016-01", "01-Feb-2014", "01-Jan-2016", new string[0])]
        [NUnit.Framework.TestCaseAttribute("ENC", "PWTP2", "2014-10", "2016-09", "01-Oct-2014", "01-Sep-2016", new string[0])]
        [NUnit.Framework.TestCaseAttribute("SUM", "PWTP2", "2014-03", "2016-12", "01-Mar-2014", "01-Dec-2016", new string[0])]
        [NUnit.Framework.TestCaseAttribute("REF", "PWTP2", "2014-03", "2016-12", "01-Mar-2014", "01-Dec-2016", new string[0])]
        [NUnit.Framework.TestCaseAttribute("ADM", "PWTP2", "1992", "2016", "01-Jan-1992", "01-Jan-2016", new string[0])]
        [NUnit.Framework.TestCaseAttribute("CLI", "PWTP2", "2014", "2017", "01-Jan-2014", "01-Jan-2017", new string[0])]
        [NUnit.Framework.TestCaseAttribute("ENC", "PWTP2", "2012", "2014", "01-Jan-2012", "01-Jan-2014", new string[0])]
        [NUnit.Framework.TestCaseAttribute("SUM", "PWTP2", "2015", "2015", "01-Jan-2015", "01-Jan-2015", new string[0])]
        [NUnit.Framework.TestCaseAttribute("REF", "PWTP2", "2016", "2016", "01-Jan-2016", "01-Jan-2016", new string[0])]
        public virtual void FilteredSectionsShouldContainDateRangeSectionBanner(string code, string patient, string startDateTime, string endDateTime, string textStartDate, string textEndDate, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("filtered sections should contain date range section banner", exampleTags);
#line 102
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 103
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 104
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:operation:gpc.getcarer" +
                    "ecord\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 105
  testRunner.And(string.Format("I author a request for the \"{0}\" care record section for config patient \"{1}\"", code, patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 106
  testRunner.And(string.Format("I set a time period parameter start date to \"{0}\" and end date to \"{1}\"", startDateTime, endDateTime), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 107
 testRunner.When("I request the FHIR \"gpc.getcarerecord\" Patient Type operation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 108
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 109
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 110
  testRunner.And("the JSON response should be a Bundle resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 111
  testRunner.And(string.Format("the response html should contain the applied date range text \"{0}\" to \"{1}\"", textStartDate, textEndDate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("sections should contain the all data items section banner")]
        [NUnit.Framework.TestCaseAttribute("ADM", "PWTP2", new string[0])]
        [NUnit.Framework.TestCaseAttribute("CLI", "PWTP2", new string[0])]
        [NUnit.Framework.TestCaseAttribute("ENC", "PWTP2", new string[0])]
        [NUnit.Framework.TestCaseAttribute("SUM", "PWTP2", new string[0])]
        [NUnit.Framework.TestCaseAttribute("REF", "PWTP2", new string[0])]
        [NUnit.Framework.TestCaseAttribute("ALL", "PWTP2", new string[0])]
        [NUnit.Framework.TestCaseAttribute("IMM", "PWTP2", new string[0])]
        [NUnit.Framework.TestCaseAttribute("MED", "PWTP2", new string[0])]
        [NUnit.Framework.TestCaseAttribute("OBS", "PWTP2", new string[0])]
        [NUnit.Framework.TestCaseAttribute("PRB", "PWTP2", new string[0])]
        public virtual void SectionsShouldContainTheAllDataItemsSectionBanner(string code, string patient, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("sections should contain the all data items section banner", exampleTags);
#line 132
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 133
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 134
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:operation:gpc.getcarer" +
                    "ecord\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 135
  testRunner.And(string.Format("I author a request for the \"{0}\" care record section for config patient \"{1}\"", code, patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 136
 testRunner.When("I request the FHIR \"gpc.getcarerecord\" Patient Type operation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 137
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 138
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 139
  testRunner.And("the JSON response should be a Bundle resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 140
  testRunner.And("the response html should contain the all data items text", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("filtered sections should return no data available html banner")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        [NUnit.Framework.TestCaseAttribute("ADM", "PWTP2", "2014-05-03", "2016-09-14", "03-May-2014", "14-Sep-2016", "Administrative Items", new string[0])]
        [NUnit.Framework.TestCaseAttribute("CLI", "PWTP2", "2014-02-03", "2016-01-24", "04-Feb-2014", "24-Jan-2016", "Clinical Items", new string[0])]
        [NUnit.Framework.TestCaseAttribute("ENC", "PWTP2", "1982-10-05", "2016-09-01", "05-Oct-1982", "01-Sep-2016", "Encounters", new string[0])]
        [NUnit.Framework.TestCaseAttribute("SUM", "PWTP2", "2014-03-21", "2016-12-14", "21-Mar-2014", "14-Dec-2016", "Active Problems and Issues", new string[0])]
        [NUnit.Framework.TestCaseAttribute("SUM", "PWTP2", "2014-03-21", "2016-12-14", "21-Mar-2014", "14-Dec-2016", "Current Medication Issues", new string[0])]
        [NUnit.Framework.TestCaseAttribute("SUM", "PWTP2", "2014-03-21", "2016-12-14", "21-Mar-2014", "14-Dec-2016", "Current Repeat Medications", new string[0])]
        [NUnit.Framework.TestCaseAttribute("SUM", "PWTP2", "2014-03-21", "2016-12-14", "21-Mar-2014", "14-Dec-2016", "Current Allergies and Adverse Reactions", new string[0])]
        [NUnit.Framework.TestCaseAttribute("SUM", "PWTP2", "2014-03-21", "2016-12-14", "21-Mar-2014", "14-Dec-2016", "Encounters", new string[0])]
        [NUnit.Framework.TestCaseAttribute("REF", "PWTP2", "2014-03-21", "2016-12-14", "21-Mar-2014", "14-Dec-2016", "Referrals", new string[0])]
        public virtual void FilteredSectionsShouldReturnNoDataAvailableHtmlBanner(string code, string patient, string startDateTime, string endDateTime, string textStartDate, string textEndDate, string section, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "ignore"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("filtered sections should return no data available html banner", @__tags);
#line 157
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 158
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 159
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:operation:gpc.getcarer" +
                    "ecord\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 160
  testRunner.And(string.Format("I author a request for the \"{0}\" care record section for config patient \"{1}\"", code, patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 161
  testRunner.And(string.Format("I set a time period parameter start date to \"{0}\" and end date to \"{1}\"", startDateTime, endDateTime), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 162
 testRunner.When("I request the FHIR \"gpc.getcarerecord\" Patient Type operation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 163
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 164
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 165
  testRunner.And("the JSON response should be a Bundle resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 166
  testRunner.And(string.Format("the response html should contain the applied date range text \"{0}\" to \"{1}\"", textStartDate, textEndDate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 167
  testRunner.And(string.Format("the response html should contain the no data available html banner in section \"{0" +
                        "}\"", section), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("sections should return no data available html banner")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        [NUnit.Framework.TestCaseAttribute("ADM", "PWTP2", "Administrative Items", new string[0])]
        [NUnit.Framework.TestCaseAttribute("CLI", "PWTP2", "Clinical Items", new string[0])]
        [NUnit.Framework.TestCaseAttribute("ENC", "PWTP2", "Encounters", new string[0])]
        [NUnit.Framework.TestCaseAttribute("SUM", "PWTP2", "Active Problems and Issues", new string[0])]
        [NUnit.Framework.TestCaseAttribute("SUM", "PWTP2", "Current Medication Issues", new string[0])]
        [NUnit.Framework.TestCaseAttribute("SUM", "PWTP2", "Current Repeat Medications", new string[0])]
        [NUnit.Framework.TestCaseAttribute("SUM", "PWTP2", "Current Allergies and Adverse Reactions", new string[0])]
        [NUnit.Framework.TestCaseAttribute("SUM", "PWTP2", "Encounters", new string[0])]
        [NUnit.Framework.TestCaseAttribute("REF", "PWTP2", "Referrals", new string[0])]
        [NUnit.Framework.TestCaseAttribute("ALL", "PWTP2", "Current Allergies and Adverse Reactions", new string[0])]
        [NUnit.Framework.TestCaseAttribute("ALL", "PWTP2", "Historical Allergies and Adverse Reactions", new string[0])]
        [NUnit.Framework.TestCaseAttribute("IMM", "PWTP2", "Immunisations", new string[0])]
        [NUnit.Framework.TestCaseAttribute("MED", "PWTP2", "Current Medication Issues", new string[0])]
        [NUnit.Framework.TestCaseAttribute("MED", "PWTP2", "Current Repeat Medications", new string[0])]
        [NUnit.Framework.TestCaseAttribute("MED", "PWTP2", "Past Medications", new string[0])]
        [NUnit.Framework.TestCaseAttribute("OBS", "PWTP2", "Observations", new string[0])]
        [NUnit.Framework.TestCaseAttribute("PRB", "PWTP2", "Active Problems and Issues", new string[0])]
        [NUnit.Framework.TestCaseAttribute("PRB", "PWTP2", "Inactive Problems and Issues", new string[0])]
        public virtual void SectionsShouldReturnNoDataAvailableHtmlBanner(string code, string patient, string section, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "ignore"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("sections should return no data available html banner", @__tags);
#line 183
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 184
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 185
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:operation:gpc.getcarer" +
                    "ecord\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 186
  testRunner.And(string.Format("I author a request for the \"{0}\" care record section for config patient \"{1}\"", code, patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 187
 testRunner.When("I request the FHIR \"gpc.getcarerecord\" Patient Type operation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 188
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 189
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 190
  testRunner.And("the JSON response should be a Bundle resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 191
  testRunner.And("the response html should contain the all data items text", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 192
  testRunner.And("the response html should contain the no data available html banner", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Check html for non html formatting")]
        [NUnit.Framework.TestCaseAttribute("ADM", new string[0])]
        [NUnit.Framework.TestCaseAttribute("ALL", new string[0])]
        [NUnit.Framework.TestCaseAttribute("CLI", new string[0])]
        [NUnit.Framework.TestCaseAttribute("ENC", new string[0])]
        [NUnit.Framework.TestCaseAttribute("IMM", new string[0])]
        [NUnit.Framework.TestCaseAttribute("MED", new string[0])]
        [NUnit.Framework.TestCaseAttribute("OBS", new string[0])]
        [NUnit.Framework.TestCaseAttribute("PRB", new string[0])]
        [NUnit.Framework.TestCaseAttribute("REF", new string[0])]
        [NUnit.Framework.TestCaseAttribute("SUM", new string[0])]
        public virtual void CheckHtmlForNonHtmlFormatting(string code, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check html for non html formatting", exampleTags);
#line 216
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 217
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 218
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:operation:gpc.getcarer" +
                    "ecord\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 219
  testRunner.And(string.Format("I author a request for the \"{0}\" care record section for config patient \"PWTP2\"", code), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 220
 testRunner.When("I request the FHIR \"gpc.getcarerecord\" Patient Type operation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 221
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 222
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 223
  testRunner.And("the JSON response should be a Bundle resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 224
  testRunner.And("the html should not contain \"\\n\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 225
  testRunner.And("the html should not contain \"\\r\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 226
  testRunner.And("the html should not contain \"\\t\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
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
#line 244
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Check dates are in decending order within the results tables")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        [NUnit.Framework.CategoryAttribute("Manual")]
        public virtual void CheckDatesAreInDecendingOrderWithinTheResultsTables()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check dates are in decending order within the results tables", new string[] {
                        "ignore",
                        "Manual"});
#line 248
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
