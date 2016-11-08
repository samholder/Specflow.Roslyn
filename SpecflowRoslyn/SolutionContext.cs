using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;

namespace Specflow.Roslyn
{
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