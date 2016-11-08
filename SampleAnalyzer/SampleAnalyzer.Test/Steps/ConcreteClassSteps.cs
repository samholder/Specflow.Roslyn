using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Specflow.Roslyn;
using TechTalk.SpecFlow;

namespace SampleAnalyzer.Test.Steps
{
    [Binding]
    public class ConcreteClassSteps
    {
        private readonly DiagnosticContext diagnosticContext;
        private readonly FixContext fixContext;

        public ConcreteClassSteps(DiagnosticContext diagnosticContext, FixContext fixContext)
        {
            this.diagnosticContext = diagnosticContext;
            this.fixContext = fixContext;
        }

        [Given(@"I'm using the capitalise type name analyser and fix")]
        public void GivenIAmUsingTheCapitaliseTypeNameAnalyser()
        {
            diagnosticContext.Analyzer = new SampleAnalyzerAnalyzer();
            fixContext.CodeFixProvider = new SampleAnalyzerCodeFixProvider();
        }
    }
}
