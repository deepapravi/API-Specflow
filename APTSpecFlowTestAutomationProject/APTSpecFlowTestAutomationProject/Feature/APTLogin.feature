Feature:APTLogin
Test for APT login Functionality

@Login
Scenario Outline:1-Loging to Aspire
	Given I navigate to application URL "https://test.aspire.fft.local/Home/"
	And I enter Username as "<Username>" and Password as "<Password>"
	And I click Login
	Then I should see the Transition Service button in the Home page
Examples:
| Username                | Password     |
|m.neta@khalsasecondaryacademy.com | testpassword |