using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace APTSpecFlowTestAutomationProject
{
    class SeleniumGetMethods:DriverHelper
    {

        public static string GetText(IWebElement element)
        {


           // return element.GetAttribute("value");
            return element.Text;

            

        }

        public static bool IsElementDisplayed(IWebElement element)
        {

            if (element.Displayed.Equals(true))

                return true;
            return false;


        }

        public static void explicitWait(IWebElement element)
        {
            try
            {

                WebDriverWait waitForElement = new WebDriverWait(DriverHelper.Driver, TimeSpan.FromSeconds(10));

                //waitForElement.Until(
                //    ExpectedConditions.ElementExists(By.XPath(element)));

                //waitForElement.Until(
                //   ExpectedConditions.ElementExists((By)element));

                waitForElement.Until(ExpectedConditions.ElementToBeClickable(element));
            }

            catch (Exception e)
            {
                Assert.Fail();

            }
        }

    }
}
