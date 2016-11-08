using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;

namespace Specflow.Roslyn
{
    public static class CodeFixProviderExtensions
    {
        public static Solution Apply(this CodeFixProvider codeFixProvider, Diagnostic diagnostic, Solution solution, int fixActionIndex = 0)
        {
            Solution updatedSolution = solution;
            List<Document> documents = solution.Projects.SelectMany(p => p.Documents).ToList();
            foreach (var document in documents)
            {
                var actions = new List<CodeAction>();
                var context = new CodeFixContext(document, diagnostic, (a, d) => actions.Add(a), CancellationToken.None);
                codeFixProvider.RegisterCodeFixesAsync(context).Wait();
                var fixedDocument = ApplyFix(document, actions.ElementAt(fixActionIndex));
                updatedSolution = updatedSolution.WithDocumentSyntaxRoot(document.Id,
                    fixedDocument.GetSyntaxRootAsync().Result);
            }
            return updatedSolution;
        }

        private static Document ApplyFix(Document document, CodeAction codeAction)
        {
            var operations = codeAction.GetOperationsAsync(CancellationToken.None).Result;
            var solution = operations.OfType<ApplyChangesOperation>().Single().ChangedSolution;
            return solution.GetDocument(document.Id);
        }
    }
}