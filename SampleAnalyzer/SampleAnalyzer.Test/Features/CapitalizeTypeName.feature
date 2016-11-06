Feature: CapitalizeTypeName


Scenario: Capitalize type name
	Given I have a default solution with a default project
	And I have the file "Test0.cs" with the content
	"""
	using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Diagnostics;

    namespace ConsoleApplication1
    {
        class TypeName
        {   
        }
    }
	"""
	And I'm using the capitalise type name analyser
	When process this class with the code analyzer "SampleAnalyzer.SampleAnalyzerAnalyzer"
	Then I should get the diagnostic analysis results 
	| Id             | Message                                         | Severity | Locations      |
	| SampleAnalyzer | Type name 'TypeName' contains lowercase letters | Warning  | Test0.cs,11,15 |
	When I apply the fix "SampleAnalyzerCodeFixProvider"
	Then the default project should have the file "Test0.cs" with the content
	"""
	using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Diagnostics;

    namespace ConsoleApplication1
    {
        class TYPENAME
        {   
        }
    }
	"""