using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAnalyzer.Test.Steps
{
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.Text;
    using TechTalk.SpecFlow;

    [Binding]
    public class Steps
    {
        private readonly SolutionContext solutionContext;

        public Steps(SolutionContext solutionContext)
        {
            this.solutionContext = solutionContext;
        }

        [Given(@"I have a default solution with a default project")]
        public void GivenIHaveADefaultSolution()
        {
            solutionContext.CreateDefaultSolution();
            solutionContext.AddDefaultProject();
        }

        [Given(@"I have the file ""(.*)"" with the content")]
        public void GivenIHaveTheFileWithTheContent(string documentName, string content)
        {
            solutionContext.AddDocumentToProject(documentName, content, SolutionContext.DefaultProjectName);
        }

        [When(@"process this class with the code analyzer ""(.*)""")]
        public void WhenProcessThisClassWithTheCodeAnalyzer(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should get the diagnostic analysis results")]
        public void ThenIShouldGetTheDiagnosticAnalysisResults(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I apply the fix ""(.*)""")]
        public void WhenIApplyTheFix(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should have the file ""(.*)"" with the content")]
        public void ThenIShouldHaveTheFileWithTheContent(string p0, string multilineText)
        {
            ScenarioContext.Current.Pending();
        }

    }

    public class SolutionContext
    {
        private static readonly MetadataReference CorlibReference = MetadataReference.CreateFromFile(typeof(object).Assembly.Location);
        private static readonly MetadataReference SystemCoreReference = MetadataReference.CreateFromFile(typeof(Enumerable).Assembly.Location);
        private static readonly MetadataReference CSharpSymbolsReference = MetadataReference.CreateFromFile(typeof(CSharpCompilation).Assembly.Location);
        private static readonly MetadataReference CodeAnalysisReference = MetadataReference.CreateFromFile(typeof(Compilation).Assembly.Location);
        public const string DefaultProjectName = "DefaultProject";
        public Solution Solution { get; private set; }

        public void CreateDefaultSolution()
        {
            Solution = new AdhocWorkspace().CurrentSolution;               
        }

        public void AddProject(string projectName)
        {
            var projectId = ProjectId.CreateNewId(projectName);
            Solution = Solution.AddProject(projectId, projectName, projectName, LanguageNames.CSharp)
               .AddMetadataReference(projectId, CorlibReference)
               .AddMetadataReference(projectId, SystemCoreReference)
               .AddMetadataReference(projectId, CSharpSymbolsReference)
               .AddMetadataReference(projectId, CodeAnalysisReference);
        }

        public void AddDefaultProject()
        {
            AddProject(DefaultProjectName);
        }

        public void AddDocumentToProject(string documentName, string content, string defaultProjectName)
        {
            ProjectId projectId = GetProjectId(defaultProjectName);
            var documentId = DocumentId.CreateNewId(projectId, debugName: documentName);
            solution = solution.AddDocument(documentId, newFileName, SourceText.From(source));
        }
    }
}
