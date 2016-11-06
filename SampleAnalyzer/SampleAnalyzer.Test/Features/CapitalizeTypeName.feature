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
	And I'm using the capitalise type name analyser and fix
	When I analyzer the solution with the diagnostic analyzer
	Then I should get the diagnostic analysis results 
	| Id             | Message                                         | Severity | Locations      |
	| SampleAnalyzer | Type name 'TypeName' contains lowercase letters | Warning  | Test0.cs,10,14 |
	When I apply the fix 
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