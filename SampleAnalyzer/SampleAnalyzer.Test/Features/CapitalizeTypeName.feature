Feature: CapitalizeTypeName


Scenario: Capitalize type name
	Given I have a default solution with a default project
	And I have the file "Test0.cs" with the content
	"""
    namespace ConsoleApplication1
    {
        class TypeName
        {   
        }
    }
	"""
	And I'm using the capitalise type name analyser and fix
	When I analyze the solution with the diagnostic analyzer
	Then I should get the diagnostic analysis results 
	| Id             | Message                                         | Severity | Locations      |
	| SampleAnalyzer | Type name 'TypeName' contains lowercase letters | Warning  | Test0.cs,3,14 |
	When I apply the fix 
	Then the default project should have the file "Test0.cs" with the content
	"""
    namespace ConsoleApplication1
    {
        class TYPENAME
        {   
        }
    }
	"""

Scenario: Capitalize type name in classes
	Given I have a default solution with a default project
	And I have the file "Test0.cs" with the content
	"""
    namespace ConsoleApplication1
    {
        class TypeName
        {   
        }

        class TypeName2
        {   
        }
    }
	"""
	And I'm using the capitalise type name analyser and fix
	When I analyze the solution with the diagnostic analyzer
	Then I should get the diagnostic analysis results 
	| Id             | Message                                          | Severity | Locations      |
	| SampleAnalyzer | Type name 'TypeName' contains lowercase letters  | Warning  | Test0.cs,3,14 |
	| SampleAnalyzer | Type name 'TypeName2' contains lowercase letters | Warning  | Test0.cs,7,14 |
	When I apply the first fix 
	And I apply the second fix 
	Then the default project should have the file "Test0.cs" with the content
	"""
    namespace ConsoleApplication1
    {
        class TYPENAME
        {   
        }

        class TYPENAME2
        {   
        }
    }
	"""