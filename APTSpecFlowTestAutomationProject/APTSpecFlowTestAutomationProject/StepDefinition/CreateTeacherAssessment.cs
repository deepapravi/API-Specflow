using APTSpecFlowTestAutomationProject.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace APTSpecFlowTestAutomationProject.StepDefinition
{
    [Binding]
    class CreateTeacherAssessment
    {

        CreateAssessmentPageObjects CreateAssessmentPage = new CreateAssessmentPageObjects();


        [Then(@"the CreateAssessment page should be displayed")]
        public void ThenTheCreateAssessmentPageShouldBeDisplayed()
        {
            Assert.That(CreateAssessmentPage.IsCreateAssessmentPageExist, Is.True, "Create Assessment Page is not Shown");

        }


        [Then(@"I enter the Assessment Name as ""(.*)""")]
        public void ThenIEnterTheAssessmentNameAs(string p0)
        {
           // ScenarioContext.Current.Pending();
        }

        [Then(@"AcademicYear as ""(.*)""")]
        public void ThenAcademicYearAs(string p0)
        {
           // ScenarioContext.Current.Pending();
        }

        [Then(@"Month as ""(.*)""")]
        public void ThenMonthAs(string p0)
        {
           // ScenarioContext.Current.Pending();
        }

        [Then(@"Keystage as ""(.*)""")]
        public void ThenKeystageAs(string p0)
        {
           // ScenarioContext.Current.Pending();
        }
        [Then(@"Yeargroup as ""(.*)""")]
        public void ThenYeargroupAs(string p0)
        {
          //  ScenarioContext.Current.Pending();
        }


        [Then(@"TeacherAssessment as ""(.*)""")]
        public void ThenTeacherAssessmentAs(string p0)
        {
           // ScenarioContext.Current.Pending();
        }

        [Then(@"Subject as ""(.*)""")]
        public void ThenSubjectAs(string p0)
        {
           // ScenarioContext.Current.Pending();
        }

        [Then(@"Click on Create Assessment button")]
        public void ThenClickOnCreateAssessmentButton()
        {
           // ScenarioContext.Current.Pending();
        }

        [Then(@"The assessment should be created and it should be shown in the Edit assessment page")]
        public void ThenTheAssessmentShouldBeCreatedAndItShouldBeShownInTheEditAssessmentPage()
        {
            //ScenarioContext.Current.Pending();
        }
        [Then(@"It should display the validation Message")]
        public void ThenItShouldDisplayTheValidationMessage()
        {
          //  ScenarioContext.Current.Pending();
        }


    }
}
