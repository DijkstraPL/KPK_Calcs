Feature: CalculateFrame
	In order to calculate frame survability
	As a designer
	I want to get proper static results

@frame
Scenario: Calculate frame
	Given I have entered Nodes positions
		And I have entered Materials
		And I have entered Sections
		And I have entered Spans
		And I have entered Loads
	When I press calculate
	Then the result should be correct
