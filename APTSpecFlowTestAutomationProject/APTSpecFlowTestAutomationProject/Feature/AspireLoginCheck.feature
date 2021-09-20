Feature: AspireLoginCheck
Login to Aspire
@Login
Scenario Outline:1-Loging to Aspire 
	Given I navigate to application URL "https://aspiretest.fft.local/"
	And I enter Username as "<Username>" and Password as "<Password>"
	And I click Login
	Then I should see user logged in to the application
Examples:
| Username                | Password     |
| stephen.turp@fft.org.uk | testpassword |