Feature: CreateTeacherAssessment
	This feature describes CreateTeacherAssessment Functionality and page validation
@CreateAssessmentPageValidation
Scenario Outline:1-CreateAssessment-PageValidation
Given I navigate to application URL "https://web.test.apt.fft.local/Home/"
	And I login with Username as "<Username>" and Password as "<Password>"
	And  I navigate to the Create Assessment page
	Then the CreateAssessment page should be displayed
		Examples:
| Username                | Password     |
| nsmall@themill-tkat.org | testpassword |

@CreateTeacherAssessment
Scenario Outline:2-Create TeacherAssessment
	Given I navigate to application URL "https://web.test.apt.fft.local/Home/"
	And I login with Username as "<Username>" and Password as "<Password>"
	And I navigate to the Create Assessment page
	Then I enter the Assessment Name as "<AssessmentName>" 
	And AcademicYear as "<AcademicYear>" 
	And Month as "<Month>" 
	And Keystage as "<KS>"
	And Yeargroup as "<Year>"
	And TeacherAssessment as "<TAName>"
	And Subject as "<Subject>"
	And Click on Create Assessment button
	Then The assessment should be created and it should be shown in the Edit assessment page

	Examples:
| Username                | Password     | AssessmentName | AcademicYear | Month    | KS  | Year  | TAName                 | Subject     |
| nsmall@themill-tkat.org | testpassword | TestAssessment | 2020/21      | December | KS1 | Year1 | DFE Teacher assessment | Mathematics |

@CheckUniquenessofAssessmentName
Scenario Outline:3-Test the Uniqueness of Assessment Name
Given I navigate to application URL "https://web.test.apt.fft.local/Home/"
	And I login with Username as "<Username>" and Password as "<Password>"
	And I navigate to the Create Assessment page
	Then I enter the Assessment Name as "<AssessmentName>" 
	Then It should display the validation Message
	Examples:
| Username                | Password     | AssessmentName | 
| nsmall@themill-tkat.org | testpassword | TestAssessment |