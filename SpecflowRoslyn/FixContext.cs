using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;

namespace Specflow.Roslyn
{
    public class FixContext
    {
        public Solution Solution { get; set; }

        public CodeFixProvider CodeFixProvider { get; set; }
    }
}