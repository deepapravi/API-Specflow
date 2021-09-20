using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace APTSpecFlowTestAutomationProject.Pages
{
   public class HomePage
    {

        public HomePage()
        {
            PageFactory.InitElements(DriverHelper.Driver, this);


        }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'User')]")]
        public IWebElement ProfileIcon { get; set; }


        [FindsBy(How = How.XPath, Using = "//span[@id='orgSelector']")]
        public IWebElement OrgSelect { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='organisationSearchText']")]
        public IWebElement OrgSelectInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//header/nav[@id='global-nav']/ul[@id='nav-menu']/li[4]/ul[1]/li[1]/ul[1]/li[1]/ul[1]/div[4]/ul[1]/li[1]/a[1]")]
        public IWebElement OrgSelectSubMenu { get; set; }

        [FindsBy(How = How.XPath, Using = "//h1[contains(text(),'Welcome to Aspire')]")]
        public IWebElement WelcomePath { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'self-evaluation')]")]
        public IWebElement SelfEvalMainMenuLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Attainment & progress')]")]
          public IWebElement SelfEvalAttainmentSubMenuLink { get; set; }


        [FindsBy(How=How.XPath,Using ="//span[contains(text(),'Administration')]")]
        public IWebElement spannerIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Assessment tracker')]")]
        public IWebElement AssesssmentTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Create new assessment')]")]
        public IWebElement CreateAssessmentTab { get; set; }


        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='Transition Service']")]
        public IWebElement TransitionServiceBtn { get; set; }


        public bool IsHomepageTransitionServiceButtonExist()
        {
          if(  SeleniumGetMethods.IsElementDisplayed(TransitionServiceBtn).Equals(true))
                return true;
            return false;


        }

        public void ClickCreateAssessmentSpannerLink()
        {
            Thread.Sleep(3000);
            SeleniumSetMethods.Click(spannerIcon);
            Thread.Sleep(1000);
            SeleniumSetMethods.Click(AssesssmentTab);
            Thread.Sleep(1000);
            SeleniumSetMethods.Click(CreateAssessmentTab);


        }

        public void SelectOrgFromMainOrgSelector(string DFENumber)
        {

            SeleniumSetMethods.Click(OrgSelect);
            Thread.Sleep(1000);
            SeleniumSetMethods.EnterText(OrgSelectInput, DFENumber);
            Thread.Sleep(1000);
            SeleniumSetMethods.Click(OrgSelectSubMenu);
            Thread.Sleep(2000);

        }
        
        public void SelectSelfEvalAttainmentReport()
        {
            //SeleniumSetMethods.Click(SelfEvalMainMenuLink);
            SeleniumSetMethods.hoverElement(SelfEvalMainMenuLink);
            Thread.Sleep(1000);
            SeleniumSetMethods.Click(SelfEvalAttainmentSubMenuLink);
            Thread.Sleep(4000);

        }


    }
}
