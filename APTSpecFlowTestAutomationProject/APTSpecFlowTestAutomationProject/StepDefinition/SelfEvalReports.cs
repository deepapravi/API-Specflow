using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace APTSpecFlowTestAutomationProject.StepDefinition
{
    [Binding]
    class SelfEvalReports
    {
        [Given(@"I click and select each Self Eval Reports for ""(.*)""")]
        public void GivenIClickAndSelectEachSelfEvalReportsFor(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the Report should open display the data")]
        public void ThenTheReportShouldOpenDisplayTheData()
        {
            ScenarioContext.Current.Pending();
        }



    }
}
