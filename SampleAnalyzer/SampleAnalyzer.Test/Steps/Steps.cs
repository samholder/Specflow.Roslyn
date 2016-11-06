using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAnalyzer.Test.Steps
{
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.Diagnostics;
    using Microsoft.CodeAnalysis.Text;
    using TechTalk.SpecFlow;
    using TestHelper;

    [Binding]
    public class Steps
    {
        private readonly SolutionContext solutionContext;
        private readonly DiagnosticContext diagnosticContext;

        public Steps(SolutionContext solutionContext, DiagnosticContext diagnosticContext)
        {
            this.solutionContext = solutionContext;
            this.diagnosticContext = diagnosticContext;
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
            diagnosticContext.AnalyzeProjects(solutionContext.Solution.Projects.SelectMany(p=>p.Documents).ToList());
        }

        [Given(@"I'm using the capitalise type name analyser")]
        public void GivenIMUsingTheCapitaliseTypeNameAnalyser()
        {
            diagnosticContext.Analyzer = new SampleAnalyzerAnalyzer();
        }


        [Then(@"I should get the diagnostic analysis results")]
        public void ThenIShouldGetTheDiagnosticAnalysisResults(List<Diagnostic> expectedDiagnostics)
        {
            ScenarioContext.Current.Pending();
        }

        [StepArgumentTransformation]
        public List<DiagnosticResult> TransformToDiagnostic(Table table)
        {
            List<DiagnosticResult> diagnostics = new List<DiagnosticResult>();
            foreach (var tableRow in table.Rows)
            {
                diagnostics.Add(new DiagnosticResult()
                {
                    Id = tableRow["Id"],
                    Message = tableRow["Message"],
                    Severity = (DiagnosticSeverity)Enum.Parse(typeof(DiagnosticSeverity),tableRow["Severity"]),
                    Locations = GetLocations(tableRow["Locations"])
                });
            }
            return diagnostics;
        }

        private DiagnosticResultLocation[] GetLocations(string locations)
        {
            List<DiagnosticResultLocation> resultLocations = new List<DiagnosticResultLocation>();
            foreach (var singleLocation in locations.Split(';'))
            {
                var locationParts = singleLocation.Split(',');
                resultLocations.Add(new DiagnosticResultLocation(locationParts[0],int.Parse(locationParts[1]),int.Parse(locationParts[2])));
            }

            return resultLocations.ToArray();
        }

        [When(@"I apply the fix ""(.*)""")]
        public void WhenIApplyTheFix(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the default project should have the file ""(.*)"" with the content")]
        public void ThenTheDefaultProjectShouldHaveTheFileWithTheContent(string filename, string multilineText)
        {
            ScenarioContext.Current.Pending();
        }

    }

    public class SolutionContext
    {
        private readonly Dictionary<string, ProjectId> projectIds = new Dictionary<string, ProjectId>();
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
            var projectId = GetProjectId(projectName);
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

        public void AddDocumentToProject(string documentName, string content, string projectName)
        {
            ProjectId projectId = GetProjectId(projectName);
            var documentId = DocumentId.CreateNewId(projectId, debugName: documentName);
            Solution = Solution.AddDocument(documentId, documentName, SourceText.From(content));
        }

        private ProjectId GetProjectId(string projectName)
        {
            if (!projectIds.ContainsKey(projectName))
            {
                projectIds.Add(projectName, ProjectId.CreateNewId(projectName));
            }
            return projectIds[projectName];
        }
    }
}
