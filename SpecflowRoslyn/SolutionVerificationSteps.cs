using System.Linq;
using TechTalk.SpecFlow;

namespace Specflow.Roslyn
{
    [Binding]
    public class SolutionVerificationSteps
    {
        private readonly FixContext fixContext;

        public SolutionVerificationSteps(FixContext fixContext)
        {
            this.fixContext = fixContext;
        }

        [Then(@"the default project should have the file ""(.*)"" with the content")]
        public void ThenTheDefaultProjectShouldHaveTheFileWithTheContent(string filename, string multilineText)
        {
            var document =
                fixContext.Solution.Projects.First(p => p.Name == SolutionContext.DefaultProjectName)
                    .Documents.First(d => d.Name == filename);
            if (document.TextRepresentation() != multilineText)
            {
                throw new ValidationException(string.Format("The file {0} did not contain the expected text. Expected to find {1} but contents were {2}", filename, multilineText, document.TextRepresentation()));
            }
        }
    }
}
