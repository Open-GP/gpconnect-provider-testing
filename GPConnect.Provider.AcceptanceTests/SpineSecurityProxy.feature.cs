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
    [NUnit.Framework.DescriptionAttribute("SpineSecurityProxy")]
    [NUnit.Framework.CategoryAttribute("ssp")]
    public partial class SpineSecurityProxyFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "SpineSecurityProxy.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "SpineSecurityProxy", null, ProgrammingLanguage.CSharp, new string[] {
                        "ssp"});
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
        [NUnit.Framework.DescriptionAttribute("SSP TraceID header not included in request")]
        public virtual void SSPTraceIDHeaderNotIncludedInRequest()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("SSP TraceID header not included in request", ((string[])(null)));
#line 4
this.ScenarioSetup(scenarioInfo);
#line 5
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 6
 testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:metadata\" in" +
                    "teraction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 7
 testRunner.And("I do not send header \"Ssp-TraceID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 8
 testRunner.When("I make a GET request to \"/metadata\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 9
 testRunner.Then("the response status code should indicate failure", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 10
 testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("SSP From header not included in request")]
        public virtual void SSPFromHeaderNotIncludedInRequest()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("SSP From header not included in request", ((string[])(null)));
#line 12
this.ScenarioSetup(scenarioInfo);
#line 13
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 14
 testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:metadata\" in" +
                    "teraction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.And("I do not send header \"Ssp-From\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.When("I make a GET request to \"/metadata\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
 testRunner.Then("the response status code should indicate failure", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 18
 testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("SSP To header not included in request")]
        public virtual void SSPToHeaderNotIncludedInRequest()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("SSP To header not included in request", ((string[])(null)));
#line 20
this.ScenarioSetup(scenarioInfo);
#line 21
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 22
 testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:metadata\" in" +
                    "teraction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.And("I do not send header \"Ssp-To\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.When("I make a GET request to \"/metadata\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
 testRunner.Then("the response status code should indicate failure", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 26
 testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("SSP InteractionId header not included in request")]
        public virtual void SSPInteractionIdHeaderNotIncludedInRequest()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("SSP InteractionId header not included in request", ((string[])(null)));
#line 28
this.ScenarioSetup(scenarioInfo);
#line 29
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 30
 testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:metadata\" in" +
                    "teraction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
 testRunner.And("I do not send header \"Ssp-InteractionId\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
 testRunner.When("I make a GET request to \"/metadata\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 33
 testRunner.Then("the response status code should indicate failure", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 34
 testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Authorization header not included in request")]
        public virtual void AuthorizationHeaderNotIncludedInRequest()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Authorization header not included in request", ((string[])(null)));
#line 36
this.ScenarioSetup(scenarioInfo);
#line 37
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 38
 testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:rest:read:metadata\" in" +
                    "teraction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
 testRunner.And("I do not send header \"Authorization\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
 testRunner.When("I make a GET request to \"/metadata\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 41
 testRunner.Then("the response status code should indicate failure", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 42
 testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Mismatched interactionId and endpoint in request")]
        public virtual void MismatchedInteractionIdAndEndpointInRequest()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Mismatched interactionId and endpoint in request", ((string[])(null)));
#line 44
this.ScenarioSetup(scenarioInfo);
#line 45
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 46
 testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:operation:gpc.getcarer" +
                    "ecord\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
 testRunner.When("I make a GET request to \"/metadata\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 48
 testRunner.Then("the response status code should indicate failure", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 49
 testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("invalid interactionId in request")]
        public virtual void InvalidInteractionIdInRequest()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("invalid interactionId in request", ((string[])(null)));
#line 51
this.ScenarioSetup(scenarioInfo);
#line 52
 testRunner.Given("I am using the default server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 53
 testRunner.And("I am performing the \"urn:nhs:names:services:gpconnect:fhir:operation:gpc.invalido" +
                    "peration\" interaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
 testRunner.When("I make a GET request to \"/metadata\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 55
 testRunner.Then("the response status code should indicate failure", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 56
 testRunner.And("the response body should be FHIR JSON", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Send to endpoint with incorrect To asid for the provider endpoint")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        public virtual void SendToEndpointWithIncorrectToAsidForTheProviderEndpoint()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Send to endpoint with incorrect To asid for the provider endpoint", new string[] {
                        "ignore"});
#line 59
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
