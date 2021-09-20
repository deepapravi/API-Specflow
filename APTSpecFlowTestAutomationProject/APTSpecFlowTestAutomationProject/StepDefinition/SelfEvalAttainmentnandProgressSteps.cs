using APTSpecFlowTestAutomationProject.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace APTSpecFlowTestAutomationProject.StepDefinition
{
    [Binding]
    class SelfEvalAttainmentnandProgressSteps
    {
        HomePage homepage = new HomePage();

        SelfEvalAttainmentProgressPage AttainmentReport = new SelfEvalAttainmentProgressPage();


        [Given(@"I select SelfEvalAttainmentReport for KS(.*)")]
        public void GivenISelectSelfEvalAttainmentReportForKS(int p0)
        {
            homepage.SelectSelfEvalAttainmentReport();

            Assert.That(AttainmentReport.IsAttainmentAndProgressReportOPens(), Is.True, "SelfEvalAttainmentAndProgressReport is not Shown");

        }

        [Given(@"I get the Attainment value from ODS Dev for org ""(.*)"" and indicator ""(.*)""")]
        public void GivenIGetTheAttainmentValueFromODSDevForOrgAndIndicator(int orgId, int IndicatorId)
        {
            AttainmentReport.ConnectODSAndExecuteQuery(orgId.ToString(), IndicatorId.ToString());
        }

        [Then(@"I compare the ODSDev Attainment value with frontend data and it should match")]
        public void ThenICompareTheODSDevAttainmentValueWithFrontendDataAndItShouldMatch()
        {
            Assert.That(AttainmentReport.CompareAttainmentData(), Is.True, "The Attainment Data does not match");
        }

    

    }
}
