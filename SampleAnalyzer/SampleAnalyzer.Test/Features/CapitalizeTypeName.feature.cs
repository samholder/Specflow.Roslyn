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
namespace SampleAnalyzer.Test.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("CapitalizeTypeName")]
    public partial class CapitalizeTypeNameFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CapitalizeTypeName.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CapitalizeTypeName", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("Capitalize type name")]
        public virtual void CapitalizeTypeName()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Capitalize type name", ((string[])(null)));
#line 4
this.ScenarioSetup(scenarioInfo);
#line 5
 testRunner.Given("I have a default solution with a default project", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 6
 testRunner.And("I have the file \"Test0.cs\" with the content", "using System;\r\n   using System.Collections.Generic;\r\n   using System.Linq;\r\n   us" +
                    "ing System.Text;\r\n   using System.Threading.Tasks;\r\n   using System.Diagnostics;" +
                    "\r\n\r\n   namespace ConsoleApplication1\r\n   {\r\n       class TypeName\r\n       {   \r\n" +
                    "       }\r\n   }", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.When("process this class with the code analyzer \"SampleAnalyzerAnalyzer\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Message",
                        "Severity",
                        "Locations"});
            table1.AddRow(new string[] {
                        "SampleAnalyzer",
                        "Type name \'TypeName\' contains lowercase letters",
                        "Warning",
                        "Test0.cs,11,15"});
#line 23
 testRunner.Then("I should get the diagnostic analysis results", ((string)(null)), table1, "Then ");
#line 26
 testRunner.When("I apply the fix \"SampleAnalyzerCodeFixProvider\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 27
 testRunner.Then("I should have the file \"Test0.cs\" with the content", "using System;\r\n   using System.Collections.Generic;\r\n   using System.Linq;\r\n   us" +
                    "ing System.Text;\r\n   using System.Threading.Tasks;\r\n   using System.Diagnostics;" +
                    "\r\n\r\n   namespace ConsoleApplication1\r\n   {\r\n       class TYPENAME\r\n       {   \r\n" +
                    "       }\r\n   }", ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
