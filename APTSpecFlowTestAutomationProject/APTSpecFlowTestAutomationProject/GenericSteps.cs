using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace APTSpecFlowTestAutomationProject
{
    [Binding]
   public class GenericSteps
    {
        public readonly Webconnector web;
        public GenericSteps(Webconnector web)
        {
            this.web = web;

        }

        [When(@"I click on \""(.*)""")]
        public void WhenIClickOn(string obj)
        {

            web.click(obj);
        }

    }
}
