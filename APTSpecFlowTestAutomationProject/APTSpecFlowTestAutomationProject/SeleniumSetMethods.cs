using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace APTSpecFlowTestAutomationProject
{
    class SeleniumSetMethods:DriverHelper
    {
        public static void EnterText(IWebElement element,string value)
        {

            element.SendKeys(value);

        }

        public static void Click(IWebElement element)

        {

            element.Click();


        }


        public static void SelectDropdown(IWebElement element, string value)
        {

            
     
              new SelectElement(element).SelectByText(value);
          
              

        }

        public static void hoverElement(IWebElement element)
        {

           

            Actions action = new Actions(Driver);
            action.MoveToElement(element).Perform();

        }

    }
}
