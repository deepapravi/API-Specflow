Feature: SelfEvalReportsSchoolLevel2020
	Verify that the School Self Eval reports returning data for 2020

@smoke
Scenario Outline:1-SelfEval SchoolLevel Report Checks for 2020
Given I navigate to application URL "https://aspiretest.fft.local/"
	And I login with Username as "<Username>" and Password as "<Password>"
	And  I select the given "<DFENumber>" from then main Org Selector
	And I click and select each Self Eval Reports for "<KS>"
	Then the Report should open display the data
	Examples:
| Username                | Password     | DFENumber | KS  |
| stephen.turp@fft.org.uk | testpassword | 3036907   | KS4 |