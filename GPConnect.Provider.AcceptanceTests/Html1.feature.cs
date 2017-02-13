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
                        "patient4",
                        "9000000004"});
            table1.AddRow(new string[] {
                        "patient5",
                        "9000000005"});
            table1.AddRow(new string[] {
                        "patient6",
                        "9000000006"});
            table1.AddRow(new string[] {
                        "patient7",
                        "9000000007"});
            table1.AddRow(new string[] {
                        "patient8",
                        "9000000008"});
            table1.AddRow(new string[] {
                        "patient9",
                        "9000000009"});
            table1.AddRow(new string[] {
                        "patient10",
                        "9000000010"});
            table1.AddRow(new string[] {
                        "patient11",
                        "9000000011"});
            table1.AddRow(new string[] {
                        "patient12",
                        "9000000012"});
            table1.AddRow(new string[] {
                        "patient13",
                        "9000000013"});
            table1.AddRow(new string[] {
                        "patient14",
                        "9000000014"});
            table1.AddRow(new string[] {
                        "patient15",
                        "9000000015"});
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
#line 24
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 25
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 26
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:operation:gpc.getcarer" +
                    "ecord\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
  testRunner.And(string.Format("I author a request for the \"{0}\" care record section for config patient \"patient2" +
                        "\"", code), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
 testRunner.When("I request the FHIR \"gpc.getcarerecord\" Patient Type operation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 29
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 30
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
  testRunner.And("the JSON response should be a Bundle resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
  testRunner.And("the html should be valid xhtml", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
  testRunner.And("the html should not contain \"head\" tags", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
  testRunner.And("the html should not contain \"body\" tags", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
  testRunner.And("the html should not contain \"script\" tags", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
  testRunner.And("the html should not contain \"style\" tags", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
  testRunner.And("the html should not contain \"iframe\" tags", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
  testRunner.And("the html should not contain \"form\" tags", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
  testRunner.And("the html should not contain \"a\" tags", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
  testRunner.And("the html should not contain any attributes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("html section headers present")]
        [NUnit.Framework.TestCaseAttribute("patient2", "ADM", "Administrative Items", new string[0])]
        [NUnit.Framework.TestCaseAttribute("patient2", "ALL", "Current Allergies and Adverse Reactions,Historical Allergies and Adverse Reaction" +
            "s", new string[0])]
        [NUnit.Framework.TestCaseAttribute("patient2", "CLI", "Clinical Items", new string[0])]
        [NUnit.Framework.TestCaseAttribute("patient2", "ENC", "Encounters", new string[0])]
        [NUnit.Framework.TestCaseAttribute("patient2", "IMM", "Immunisations", new string[0])]
        [NUnit.Framework.TestCaseAttribute("patient2", "MED", "Current Medication Issues,Current Repeat Medications,Past Medications", new string[0])]
        [NUnit.Framework.TestCaseAttribute("patient2", "OBS", "Observations", new string[0])]
        [NUnit.Framework.TestCaseAttribute("patient2", "PRB", "Active Problems and Issues,Inactive Problems and Issues", new string[0])]
        [NUnit.Framework.TestCaseAttribute("patient2", "REF", "Referrals", new string[0])]
        [NUnit.Framework.TestCaseAttribute("patient2", "SUM", "Active Problems and Issues,Current Medication Issues,Current Repeat Medications,C" +
            "urrent Allergies and Adverse Reactions,Encounters", new string[0])]
        public virtual void HtmlSectionHeadersPresent(string patient, string code, string headers, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("html section headers present", exampleTags);
#line 56
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 57
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 58
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:operation:gpc.getcarer" +
                    "ecord\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
  testRunner.And(string.Format("I author a request for the \"{0}\" care record section for config patient \"{1}\"", code, patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
 testRunner.When("I request the FHIR \"gpc.getcarerecord\" Patient Type operation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 61
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 62
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
  testRunner.And("the JSON response should be a Bundle resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
  testRunner.And(string.Format("the html should contain headers in coma seperated list \"{0}\"", headers), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("html table headers present and in order that is expected")]
        [NUnit.Framework.TestCaseAttribute("patient2", "ADM", "Date,Entry,Details", "1", new string[0])]
        [NUnit.Framework.TestCaseAttribute("patient2", "ALL", "Start Date,Details", "1", new string[0])]
        [NUnit.Framework.TestCaseAttribute("patient2", "ALL", "Start Date,End Date,Details", "2", new string[0])]
        [NUnit.Framework.TestCaseAttribute("patient2", "CLI", "Date,Entry,Details", "1", new string[0])]
        [NUnit.Framework.TestCaseAttribute("patient2", "ENC", "Date,Title,Details", "1", new string[0])]
        [NUnit.Framework.TestCaseAttribute("patient2", "IMM", "Date,Vaccination,Part,Contents,Details", "1", new string[0])]
        [NUnit.Framework.TestCaseAttribute("patient2", "MED", "Start Date,Medication Item,Type,Scheduled End Date,Days Duration,Details", "1", new string[0])]
        [NUnit.Framework.TestCaseAttribute("patient2", "MED", "Last Issued,Medication Item,Start Date,Review Date,Number Issued,Max Issues,Detai" +
            "ls", "2", new string[0])]
        [NUnit.Framework.TestCaseAttribute("patient2", "MED", "Start Date,Medication Item,Type,Last Issued,Review Date,Number Issued,Max Issued," +
            "Details", "3", new string[0])]
        [NUnit.Framework.TestCaseAttribute("patient2", "OBS", "Date,Entry,Value,Details", "1", new string[0])]
        [NUnit.Framework.TestCaseAttribute("patient2", "PRB", "Start Date,Entry,Significance,Details", "1", new string[0])]
        [NUnit.Framework.TestCaseAttribute("patient2", "PRB", "Start Date,End Date,Entry,Significance,Details", "2", new string[0])]
        [NUnit.Framework.TestCaseAttribute("patient2", "REF", "Date,From,To,Priority,Details", "1", new string[0])]
        [NUnit.Framework.TestCaseAttribute("patient2", "SUM", "Start Date,Entry,Significance,Details", "1", new string[0])]
        [NUnit.Framework.TestCaseAttribute("patient2", "SUM", "Start Date,Medication Item,Type,Scheduled End Date,Days Duration,Details", "2", new string[0])]
        [NUnit.Framework.TestCaseAttribute("patient2", "SUM", "Last Issued,Medication Item,Start Date,Review Date,Number Issued,Max Issues,Detai" +
            "ls", "3", new string[0])]
        [NUnit.Framework.TestCaseAttribute("patient2", "SUM", "Start Date,Details", "4", new string[0])]
        [NUnit.Framework.TestCaseAttribute("patient2", "SUM", "Date,Title,Details", "5", new string[0])]
        public virtual void HtmlTableHeadersPresentAndInOrderThatIsExpected(string patient, string code, string headers, string pageSectionIndex, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("html table headers present and in order that is expected", exampleTags);
#line 82
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 83
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 84
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:operation:gpc.getcarer" +
                    "ecord\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 85
  testRunner.And(string.Format("I author a request for the \"{0}\" care record section for config patient \"{1}\"", code, patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
 testRunner.When("I request the FHIR \"gpc.getcarerecord\" Patient Type operation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 87
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 88
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 89
  testRunner.And("the JSON response should be a Bundle resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 90
  testRunner.And(string.Format("the html should contain table headers in coma seperated list order \"{0}\" for the " +
                        "\"{1}\"", headers, pageSectionIndex), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("filtered sections should contain date range section banner")]
        [NUnit.Framework.TestCaseAttribute("ADM", "patient2", "2014-05-03", "2016-09-14", "03-May-2014", "14-Sep-2016", new string[0])]
        [NUnit.Framework.TestCaseAttribute("CLI", "patient2", "2014-02-03", "2016-01-24", "04-Feb-2014", "24-Jan-2016", new string[0])]
        [NUnit.Framework.TestCaseAttribute("ENC", "patient2", "1982-10-05", "2016-09-01", "05-Oct-1982", "01-Sep-2016", new string[0])]
        [NUnit.Framework.TestCaseAttribute("SUM", "patient2", "2014-03-21", "2016-12-14", "21-Mar-2014", "14-Dec-2016", new string[0])]
        [NUnit.Framework.TestCaseAttribute("REF", "patient2", "2014-03-21", "2016-12-14", "21-Mar-2014", "14-Dec-2016", new string[0])]
        [NUnit.Framework.TestCaseAttribute("ADM", "patient2", "2014-05", "2016-09", "01-May-2014", "01-Sep-2016", new string[0])]
        [NUnit.Framework.TestCaseAttribute("CLI", "patient2", "2014-02", "2016-01", "01-Feb-2014", "01-Jan-2016", new string[0])]
        [NUnit.Framework.TestCaseAttribute("ENC", "patient2", "2014-10", "2016-09", "01-Oct-2014", "01-Sep-2016", new string[0])]
        [NUnit.Framework.TestCaseAttribute("SUM", "patient2", "2014-03", "2016-12", "01-Mar-2014", "01-Dec-2016", new string[0])]
        [NUnit.Framework.TestCaseAttribute("REF", "patient2", "2014-03", "2016-12", "01-Mar-2014", "01-Dec-2016", new string[0])]
        [NUnit.Framework.TestCaseAttribute("ADM", "patient2", "1992", "2016", "01-Jan-1992", "01-Jan-2016", new string[0])]
        [NUnit.Framework.TestCaseAttribute("CLI", "patient2", "2014", "2017", "01-Jan-2014", "01-Jan-2017", new string[0])]
        [NUnit.Framework.TestCaseAttribute("ENC", "patient2", "2012", "2014", "01-Jan-2012", "01-Jan-2014", new string[0])]
        [NUnit.Framework.TestCaseAttribute("SUM", "patient2", "2015", "2015", "01-Jan-2015", "01-Jan-2015", new string[0])]
        [NUnit.Framework.TestCaseAttribute("REF", "patient2", "2016", "2016", "01-Jan-2016", "01-Jan-2016", new string[0])]
        public virtual void FilteredSectionsShouldContainDateRangeSectionBanner(string code, string patient, string startDateTime, string endDateTime, string textStartDate, string textEndDate, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("filtered sections should contain date range section banner", exampleTags);
#line 114
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 115
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 116
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:operation:gpc.getcarer" +
                    "ecord\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 117
  testRunner.And(string.Format("I author a request for the \"{0}\" care record section for config patient \"{1}\"", code, patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 118
  testRunner.And(string.Format("I set a time period parameter start date to \"{0}\" and end date to \"{1}\"", startDateTime, endDateTime), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 119
 testRunner.When("I request the FHIR \"gpc.getcarerecord\" Patient Type operation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 120
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 121
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 122
  testRunner.And("the JSON response should be a Bundle resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 123
  testRunner.And(string.Format("the response html should contain the applied date range text \"{0}\" to \"{1}\"", textStartDate, textEndDate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("sections should contain the all data items section banner")]
        [NUnit.Framework.TestCaseAttribute("ADM", "patient2", new string[0])]
        [NUnit.Framework.TestCaseAttribute("CLI", "patient2", new string[0])]
        [NUnit.Framework.TestCaseAttribute("ENC", "patient2", new string[0])]
        [NUnit.Framework.TestCaseAttribute("SUM", "patient2", new string[0])]
        [NUnit.Framework.TestCaseAttribute("REF", "patient2", new string[0])]
        [NUnit.Framework.TestCaseAttribute("ALL", "patient2", new string[0])]
        [NUnit.Framework.TestCaseAttribute("IMM", "patient2", new string[0])]
        [NUnit.Framework.TestCaseAttribute("MED", "patient2", new string[0])]
        [NUnit.Framework.TestCaseAttribute("OBS", "patient2", new string[0])]
        [NUnit.Framework.TestCaseAttribute("PRB", "patient2", new string[0])]
        public virtual void SectionsShouldContainTheAllDataItemsSectionBanner(string code, string patient, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("sections should contain the all data items section banner", exampleTags);
#line 144
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 145
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 146
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:operation:gpc.getcarer" +
                    "ecord\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 147
  testRunner.And(string.Format("I author a request for the \"{0}\" care record section for config patient \"{1}\"", code, patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 148
 testRunner.When("I request the FHIR \"gpc.getcarerecord\" Patient Type operation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 149
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 150
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 151
  testRunner.And("the JSON response should be a Bundle resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 152
  testRunner.And("the response html should contain the all data items text", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("filtered sections should return no data available html banner")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        [NUnit.Framework.TestCaseAttribute("ADM", "patient2", "2014-05-03", "2016-09-14", "03-May-2014", "14-Sep-2016", "Administrative Items", new string[0])]
        [NUnit.Framework.TestCaseAttribute("CLI", "patient2", "2014-02-03", "2016-01-24", "04-Feb-2014", "24-Jan-2016", "Clinical Items", new string[0])]
        [NUnit.Framework.TestCaseAttribute("ENC", "patient2", "1982-10-05", "2016-09-01", "05-Oct-1982", "01-Sep-2016", "Encounters", new string[0])]
        [NUnit.Framework.TestCaseAttribute("SUM", "patient2", "2014-03-21", "2016-12-14", "21-Mar-2014", "14-Dec-2016", "Active Problems and Issues", new string[0])]
        [NUnit.Framework.TestCaseAttribute("SUM", "patient2", "2014-03-21", "2016-12-14", "21-Mar-2014", "14-Dec-2016", "Current Medication Issues", new string[0])]
        [NUnit.Framework.TestCaseAttribute("SUM", "patient2", "2014-03-21", "2016-12-14", "21-Mar-2014", "14-Dec-2016", "Current Repeat Medications", new string[0])]
        [NUnit.Framework.TestCaseAttribute("SUM", "patient2", "2014-03-21", "2016-12-14", "21-Mar-2014", "14-Dec-2016", "Current Allergies and Adverse Reactions", new string[0])]
        [NUnit.Framework.TestCaseAttribute("SUM", "patient2", "2014-03-21", "2016-12-14", "21-Mar-2014", "14-Dec-2016", "Encounters", new string[0])]
        [NUnit.Framework.TestCaseAttribute("REF", "patient2", "2014-03-21", "2016-12-14", "21-Mar-2014", "14-Dec-2016", "Referrals", new string[0])]
        public virtual void FilteredSectionsShouldReturnNoDataAvailableHtmlBanner(string code, string patient, string startDateTime, string endDateTime, string textStartDate, string textEndDate, string section, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "ignore"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("filtered sections should return no data available html banner", @__tags);
#line 169
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 170
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 171
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:operation:gpc.getcarer" +
                    "ecord\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 172
  testRunner.And(string.Format("I author a request for the \"{0}\" care record section for config patient \"{1}\"", code, patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 173
  testRunner.And(string.Format("I set a time period parameter start date to \"{0}\" and end date to \"{1}\"", startDateTime, endDateTime), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 174
 testRunner.When("I request the FHIR \"gpc.getcarerecord\" Patient Type operation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 175
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 176
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 177
  testRunner.And("the JSON response should be a Bundle resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 178
  testRunner.And(string.Format("the response html should contain the applied date range text \"{0}\" to \"{1}\"", textStartDate, textEndDate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 179
  testRunner.And(string.Format("the response html should contain the no data available html banner in section \"{0" +
                        "}\"", section), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("sections should return no data available html banner")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        [NUnit.Framework.TestCaseAttribute("ADM", "patient2", "Administrative Items", new string[0])]
        [NUnit.Framework.TestCaseAttribute("CLI", "patient2", "Clinical Items", new string[0])]
        [NUnit.Framework.TestCaseAttribute("ENC", "patient2", "Encounters", new string[0])]
        [NUnit.Framework.TestCaseAttribute("SUM", "patient2", "Active Problems and Issues", new string[0])]
        [NUnit.Framework.TestCaseAttribute("SUM", "patient2", "Current Medication Issues", new string[0])]
        [NUnit.Framework.TestCaseAttribute("SUM", "patient2", "Current Repeat Medications", new string[0])]
        [NUnit.Framework.TestCaseAttribute("SUM", "patient2", "Current Allergies and Adverse Reactions", new string[0])]
        [NUnit.Framework.TestCaseAttribute("SUM", "patient2", "Encounters", new string[0])]
        [NUnit.Framework.TestCaseAttribute("REF", "patient2", "Referrals", new string[0])]
        [NUnit.Framework.TestCaseAttribute("ALL", "patient2", "Current Allergies and Adverse Reactions", new string[0])]
        [NUnit.Framework.TestCaseAttribute("ALL", "patient2", "Historical Allergies and Adverse Reactions", new string[0])]
        [NUnit.Framework.TestCaseAttribute("IMM", "patient2", "Immunisations", new string[0])]
        [NUnit.Framework.TestCaseAttribute("MED", "patient2", "Current Medication Issues", new string[0])]
        [NUnit.Framework.TestCaseAttribute("MED", "patient2", "Current Repeat Medications", new string[0])]
        [NUnit.Framework.TestCaseAttribute("MED", "patient2", "Past Medications", new string[0])]
        [NUnit.Framework.TestCaseAttribute("OBS", "patient2", "Observations", new string[0])]
        [NUnit.Framework.TestCaseAttribute("PRB", "patient2", "Active Problems and Issues", new string[0])]
        [NUnit.Framework.TestCaseAttribute("PRB", "patient2", "Inactive Problems and Issues", new string[0])]
        public virtual void SectionsShouldReturnNoDataAvailableHtmlBanner(string code, string patient, string section, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "ignore"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("sections should return no data available html banner", @__tags);
#line 195
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 196
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 197
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:operation:gpc.getcarer" +
                    "ecord\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 198
  testRunner.And(string.Format("I author a request for the \"{0}\" care record section for config patient \"{1}\"", code, patient), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 199
 testRunner.When("I request the FHIR \"gpc.getcarerecord\" Patient Type operation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 200
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 201
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 202
  testRunner.And("the JSON response should be a Bundle resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 203
  testRunner.And("the response html should contain the all data items text", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 204
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
#line 228
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 229
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 230
  testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:operation:gpc.getcarer" +
                    "ecord\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 231
  testRunner.And(string.Format("I author a request for the \"{0}\" care record section for config patient \"patient2" +
                        "\"", code), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 232
 testRunner.When("I request the FHIR \"gpc.getcarerecord\" Patient Type operation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 233
 testRunner.Then("the response status code should indicate success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 234
  testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 235
  testRunner.And("the JSON response should be a Bundle resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 236
  testRunner.And("the html should not contain \"\\n\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 237
  testRunner.And("the html should not contain \"\\r\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 238
  testRunner.And("the html should not contain \"\\t\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Patients flag as sensitive should return any information within the HTML which ma" +
            "y allow for identification of contact information or address")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        [NUnit.Framework.CategoryAttribute("Manual")]
        public virtual void PatientsFlagAsSensitiveShouldReturnAnyInformationWithinTheHTMLWhichMayAllowForIdentificationOfContactInformationOrAddress()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Patients flag as sensitive should return any information within the HTML which ma" +
                    "y allow for identification of contact information or address", new string[] {
                        "ignore",
                        "Manual"});
#line 256
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
#line 260
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
#line 264
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
