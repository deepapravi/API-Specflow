using APTSpecFlowTestAutomationProject.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using TechTalk.SpecFlow;

namespace APTSpecFlowTestAutomationProject.StepDefinition
{
    [Binding]
    class HomepageSteps
    {
        HomePage homepage = new HomePage();
       


        [Then(@"I should see the Transition Service button in the Home page")]
        public void ThenIShouldSeeTheTransitionServiceButtonInTheHomePage()
        {
            Assert.That(homepage.IsHomepageTransitionServiceButtonExist, Is.True, "Transition service button has not Shown in the Home page");
        }


        [Given(@"I select the given ""(.*)"" from then main Org Selector")]
        public void GivenISelectTheGivenFromThenMainOrgSelector(int DFENumber)
        {
           
            homepage.SelectOrgFromMainOrgSelector((DFENumber).ToString());
        }


        [Given(@"I navigate to the Create Assessment page")]
        public void GivenINavigateToTheCreateAssessmentPage()
        {
            homepage.ClickCreateAssessmentSpannerLink();
          
        }

    }
}
