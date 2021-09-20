Feature: SelfEvalKS2DataChecks
	This feature performs Datavalidation for Self Eval KS2 data
@SelfEvalKS2DataChecks
Scenario Outline:1-SelfEvalKS2DataChecks
Given I navigate to application URL "https://aspiretest.fft.local/"
	And I login with Username as "<Username>" and Password as "<Password>"
	And  I select the given "<DFENumber>" from then main Org Selector
	And I select SelfEvalAttainmentReport for KS2
	And I get the Attainment value from ODS Dev for org "<OrganisationId>" and indicator "<IndicatorId>"
	Then I compare the ODSDev Attainment value with frontend data and it should match

Examples:
| Username                | Password     | DFENumber | OrganisationId | IndicatorId |
| stephen.turp@fft.org.uk | testpassword | 9382020   | 51765          | 12039       |
| stephen.turp@fft.org.uk | testpassword | 9382139   | 51833          | 12039       |
| stephen.turp@fft.org.uk | testpassword | 9253096	 | 47019          | 12039       |
| stephen.turp@fft.org.uk | testpassword | 9253330	 | 47082          | 12039       |