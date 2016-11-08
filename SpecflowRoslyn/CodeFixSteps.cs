using System.Linq;
using TechTalk.SpecFlow;

namespace Specflow.Roslyn
{
    [Binding]
    public class CodeFixSteps
    {
        private readonly FixContext fixContext;
        private readonly DiagnosticContext diagnosticContext;

        public CodeFixSteps(FixContext fixContext, DiagnosticContext diagnosticContext)
        {
            this.fixContext = fixContext;
            this.diagnosticContext = diagnosticContext;
        }

        [When(@"I apply the fix")]
        public void WhenIApplyTheFix()
        {
            fixContext.Solution = fixContext.CodeFixProvider.Apply(diagnosticContext.Results.Single(), fixContext.Solution);
        }

        [When(@"I apply the first fix")]
        public void WhenIApplyTheFirstFix()
        {
            ApplyFix(0);
        }

        [When(@"I apply the second fix")]
        public void WhenIApplyTheSecondFix()
        {
            ApplyFix(1);
        }

        private void ApplyFix(int fixIndex)
        {
            fixContext.Solution = fixContext.CodeFixProvider.Apply(diagnosticContext.Results.ElementAt(fixIndex), fixContext.Solution);
        }
    }
}
