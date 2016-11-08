using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Specflow.Roslyn
{
    [Binding]
    public class DiagnosticSteps
    {
        private readonly SolutionContext solutionContext;
        private readonly DiagnosticContext diagnosticContext;
        private readonly FixContext fixContext;

        public DiagnosticSteps(SolutionContext solutionContext, DiagnosticContext diagnosticContext, FixContext fixContext)
        {
            this.solutionContext = solutionContext;
            this.diagnosticContext = diagnosticContext;
            this.fixContext = fixContext;
        }

        [When(@"I analyze the solution with the diagnostic analyzer")]
        public void WhenProcessThisClassWithTheCodeAnalyzer()
        {
            diagnosticContext.AnalyzeSolution(solutionContext.Solution);
            fixContext.Solution = solutionContext.Solution;
        }

        


        [Then(@"I should get the diagnostic analysis results")]
        public void ThenIShouldGetTheDiagnosticAnalysisResults(List<DiagnosticResult> expectedDiagnostics)
        {
            diagnosticContext.VerifyDiagnosticResults(expectedDiagnostics.ToArray());            
        }        
    }
}
