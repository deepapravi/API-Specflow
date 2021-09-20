using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
//using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;

namespace APTSpecFlowTestAutomationProject.Pages
{
   public class CreateAssessmentPageObjects
    {
        public CreateAssessmentPageObjects()
        {
            PageFactory.InitElements(DriverHelper.Driver, this);


        }


        [FindsBy(How = How.XPath, Using = "//h1[contains(text(),'Create an assessment')]")]
        public IWebElement CreateAssessmentLabel { get; set; }

        public bool IsCreateAssessmentPageExist()
        {
            try
            {
                SeleniumGetMethods.explicitWait(CreateAssessmentLabel);
                if (SeleniumGetMethods.IsElementDisplayed(CreateAssessmentLabel).Equals(true))
                    return true;
            }

            catch (Exception e)
            {
               
            
            }
            return false;
        }
    }
}
