using TechTalk.SpecFlow;

namespace Specflow.Roslyn
{
    [Binding]
    public class SolutionSetUpSteps
    {
        private readonly SolutionContext solutionContext;

        public SolutionSetUpSteps(SolutionContext solutionContext)
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
    }
}
