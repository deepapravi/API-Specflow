using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
//using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;

using System.Linq;
using System.Threading;
using APTSpecFlowTestAutomationProject.Helpers;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace APTSpecFlowTestAutomationProject
{
    class LoginPageObject
    {

        public LoginPageObject()
        {
            PageFactory.InitElements(DriverHelper.Driver, this);


        }


        [FindsBy(How=How.XPath,Using = "//*[@id='Username']")]
        public IWebElement txtUserName { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='Password']")]
        public IWebElement txtPassword { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='login-btn']")]
        public IWebElement btnLogin { get; set; }


        public void Login(string userName, string password)
        {

            //SeleniumSetMethods.EnterText(txtUserName, userName);
            //SeleniumSetMethods.EnterText(txtUserName, password);
            txtUserName.SendKeys(userName);
            txtPassword.SendKeys(password);


        }


        public void Click()

        {

            // btnLogin.Click();
            SeleniumSetMethods.Click(btnLogin);
            var user = ConfigurationManager.AppSettings.Get("User");
            Thread.Sleep(3000);

        }

       
    }


 

}
