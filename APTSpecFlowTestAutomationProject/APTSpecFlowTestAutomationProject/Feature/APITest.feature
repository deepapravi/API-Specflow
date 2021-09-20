Feature:  APIapplication

@APITesting
Scenario: Get API respose using given endpoint
	Given I have a endpoint /10864/0
	When I call get method of api
	Then I get API response in json format

	
@APITesting
Scenario: Get API respose data using given endpoint
	Given I have a endpoint /10864/0
	When I call get method of api
	Then I will get org information