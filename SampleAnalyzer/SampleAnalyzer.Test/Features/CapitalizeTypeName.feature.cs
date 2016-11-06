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
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class CapitalizeTypeNameFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CapitalizeTypeName.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CapitalizeTypeName", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "CapitalizeTypeName")))
            {
                SampleAnalyzer.Test.Features.CapitalizeTypeNameFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
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
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Capitalize type name")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CapitalizeTypeName")]
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
 testRunner.And("I\'m using the capitalise type name analyser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.When("process this class with the code analyzer \"SampleAnalyzer.SampleAnalyzerAnalyzer\"" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
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
#line 24
 testRunner.Then("I should get the diagnostic analysis results", ((string)(null)), table1, "Then ");
#line 27
 testRunner.When("I apply the fix \"SampleAnalyzerCodeFixProvider\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 28
 testRunner.Then("the default project should have the file \"Test0.cs\" with the content", "using System;\r\n   using System.Collections.Generic;\r\n   using System.Linq;\r\n   us" +
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
