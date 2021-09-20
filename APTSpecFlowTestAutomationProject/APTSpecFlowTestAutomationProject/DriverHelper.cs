using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace APTSpecFlowTestAutomationProject
{
    enum PropertyType
    {
        Id,
        Name,
        LinkText,
        CssName,
        XPath


    }

   public class DriverHelper
    {
        public static IWebDriver Driver { get; set; }
    }
}
