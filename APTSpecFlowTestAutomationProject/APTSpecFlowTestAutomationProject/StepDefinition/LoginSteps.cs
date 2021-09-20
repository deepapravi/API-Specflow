using APTSpecFlowTestAutomationProject.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace APTSpecFlowTestAutomationProject.StepDefinition
{
    [Binding]
    class LoginSteps:DriverHelper

    {
        LoginPageObject login = new LoginPageObject();
       

        [Given(@"I navigate to application URL ""(.*)""")]
        public void GivenINavigateToApplicationURL(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }



        //[Given(@"I enter username and password")]
        //public void GivenIEnterUsernameAndPassword(Table table)
        //{
        //    dynamic data = table.CreateDynamicInstance();
        //    loginPage.EnterUserNameAndPassword(data.UserName, data.Password);
        //}
        [Given(@"I login with Username as ""(.*)"" and Password as ""(.*)""")]
        public void GivenILoginWithUsernameAsAndPasswordAs(string username, string password)
        {
            login.Login(username, password);
            login.Click();
        }



        [Given(@"I enter Username as ""(.*)"" and Password as ""(.*)""")]
        public void GivenIEnterUsernameAsAndPasswordAs(string userName, string Password)
        {
            

            login.Login(userName, Password);
        }



        [Given(@"I click Login")]
        public void GivenIClickLogin()
        {

            login.Click();

          //  login.Connect();
        }

    

    }



}







