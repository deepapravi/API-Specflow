using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.SecretsManager;
using AventStack.ExtentReports;

using Amazon.SecretsManager.Model;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Threading;
using System.IO;
using MongoDB.Bson.IO;
using RestSharp.Serialization.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TechTalk.SpecFlow;
using BoDi;

namespace APTSpecFlowTestAutomationProject
{

    [Binding]
  public  class Webconnector:DriverHelper
    {
        public IWebDriver driver = null;
        public ExtentReports rep = ExtentManager.getInstance();
        public ExtentTest test;
        public int errcount = 0;
        private readonly IObjectContainer objectContainer;
        public Webconnector(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;



        }

     
        public static string testCaseName = null;

        public void startTest(string testName)
        {

            test = rep.CreateTest(testName);


        }




        public void openBrowser(string bType)
        {

            test.Log(Status.Info, "Opening the Browser" + bType);

            if (bType.Equals("Chrome"))
            {
                //String dir = AppDomain.CurrentDomain.BaseDirectory;
                //FileInfo fileInfo = new FileInfo(dir);
                //DirectoryInfo currentDir = fileInfo.Directory.Parent.Parent;
                //string parentDirName = currentDir.FullName;
                //// string filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);

                //driver = new ChromeDriver(parentDirName + "\\Chrome");
                ////  options.AddArgument("--start-maximized");
                ////  driver = new ChromeDriver(options);
                //driver.Manage().Window.Maximize();


                ChromeOptions options = new ChromeOptions();
                options.AddArgument("--start-maximized");
                driver = new ChromeDriver(options);
                objectContainer.RegisterInstanceAs<IWebDriver> (driver);

            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            //test.Log(Status.Info, "Browser has opened successfully :" + bType);

        }

        public IWebDriver getDriver()
        {

            return driver;

        }
        public MediaEntityModelProvider CaptureScreenshotAndReturnModel(string Name)
        {
          //  Thread.Sleep(2000);
          //  var screenshot=((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
          //return  MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot,Name).Build();



            String dir = AppDomain.CurrentDomain.BaseDirectory;
            FileInfo fileInfo = new FileInfo(dir);
            DirectoryInfo currentDir = fileInfo.Directory.Parent.Parent;
            string parentDirName = currentDir.FullName;
            Screenshot file = ((ITakesScreenshot)DriverHelper.Driver).GetScreenshot();
            string screenshotFile = DateTime.Now.ToString().Replace("/", "_").Replace(":", "_").Replace(" ", "_") + ".png";
            ITakesScreenshot screenshotDriver = DriverHelper.Driver as ITakesScreenshot;



            // file.SaveAsFile(@"\\mercury\Development\Testresults\Screenshots\" + screenshotFile, ScreenshotImageFormat.Png);

            file.SaveAsFile(@"\\mimas.fft.local\tfs-build-reports\Testresults\Screenshots\" + screenshotFile, ScreenshotImageFormat.Png);

            // test.Log(Status.Info, "Screenshot-", MediaEntityBuilder.CreateScreenCaptureFromPath(parentDirName + "\\Reports\\Screenshots\\" + screenshotFile).Build());

      return MediaEntityBuilder.CreateScreenCaptureFromPath(@"\\mimas.fft.local\tfs-build-reports\Testresults\Screenshots\" + screenshotFile,Name).Build();

       


        }

        public void navigate(string urlKey)
        {
            //   test.Log(Status.Info, "Navigating to " + ConfigurationManager.AppSettings[urlKey]);
            // driver.Url = ConfigurationManager.AppSettings[urlKey];

            driver.Url = "https://web.test.apt.fft.local/Home/";



        }

        public void click(string xpathExpKey)
        {
            try
            {
                driver.FindElement(By.XPath("//*[@id='login-btn']")).Click();
            }
            catch (Exception ex)
            {

                //fail test and report the error
                //  reportFailure(ex.Message);
                //  Assert.Fail("Fail the Test-" + ex.Message);



                Assert.Fail("Fail the Test-" + ex.Message);

            }


        }

        public void type(string xpathExpKey, string data)
        {
            driver.FindElement(By.XPath("//*[@id='Username']")).SendKeys(data);
        }

        public IWebElement getElement(string locatorkey)
        {
            IWebElement e = null;
            try
            {
                if (locatorkey.EndsWith("_Xpath"))
                {
                    e = driver.FindElement(By.XPath(ConfigurationManager.AppSettings[locatorkey]));

                }
                else if (locatorkey.EndsWith("_Id"))
                {
                    e = driver.FindElement(By.Id(ConfigurationManager.AppSettings[locatorkey]));

                }
                else if (locatorkey.EndsWith("_name"))
                {
                    e = driver.FindElement(By.Name(ConfigurationManager.AppSettings[locatorkey]));

                }
                else if (locatorkey.EndsWith("_link"))
                {

                    e = driver.FindElement(By.LinkText(ConfigurationManager.AppSettings[locatorkey]));
                }
                else if (locatorkey.EndsWith("_Class"))
                {

                    e = driver.FindElement(By.ClassName(ConfigurationManager.AppSettings[locatorkey]));
                }
                else
                {

                    reportFailure("Locator is not correct" + locatorkey);
                    Assert.Fail("Locator not correct" + locatorkey);

                }
            }
            catch (Exception ex)
            {

                //fail test and report the error
                reportFailure(ex.Message);
                Assert.Fail("Fail the Test-" + ex.Message);

            }
            return e;
        }

        public void hoverElement(string locatorkey)
        {

            try
            {

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(ConfigurationManager.AppSettings[locatorkey])));

                Actions action = new Actions(driver);
                action.MoveToElement(element).Perform();
            }
            catch (Exception ex)
            {

                //fail test and report the error
                reportFailure(ex.Message);
                Assert.Fail("Fail the Test-" + ex.Message);

            }

        }

        /********************Validation Funcions*****************/

        public bool verifyTitle()

        {
            return false;

        }


        public bool IsElementVisible(string locatorkey)

        {
            IWebElement element = getElement(locatorkey);

            bool b = element.Displayed;
            if (b.Equals(true))
            {
                return true;
            }

            return false;
        }

        public bool isElementPresent(string locatorkey)
        {
            IList<IWebElement> elementList = null;
            try
            {


                if (locatorkey.EndsWith("_Xpath"))
                {
                    elementList = driver.FindElements(By.XPath(ConfigurationManager.AppSettings[locatorkey]));

                }
                else if (locatorkey.EndsWith("_Id"))
                {
                    elementList = driver.FindElements(By.Id(ConfigurationManager.AppSettings[locatorkey]));

                }
                else if (locatorkey.EndsWith("_name"))
                {
                    elementList = driver.FindElements(By.Name(ConfigurationManager.AppSettings[locatorkey]));

                }
                else if (locatorkey.EndsWith("_link"))
                {
                    elementList = driver.FindElements(By.LinkText(ConfigurationManager.AppSettings[locatorkey]));

                }
                else if (locatorkey.EndsWith("_Class"))
                {
                    elementList = driver.FindElements(By.ClassName(ConfigurationManager.AppSettings[locatorkey]));

                }
                else
                {

                    reportFailure("Locator is not correct" + locatorkey);
                    Assert.Fail("Locator not correct" + locatorkey);

                }
            }
            catch (Exception ex)
            {

                //fail test and report the error
                reportFailure(ex.Message);
                // Assert.Fail("Fail the Test-" + ex.Message);

            }

            if (elementList.Count == 0)

                return false;
            else
                return true;
        }





        public bool CheckforElement(string locatorkey)
        {
            try
            {
                IList<IWebElement> elementList = null;
                if (locatorkey.EndsWith("_Xpath"))
                {
                    elementList = driver.FindElements(By.XPath(ConfigurationManager.AppSettings[locatorkey]));

                }
                else if (locatorkey.EndsWith("_Id"))
                {
                    elementList = driver.FindElements(By.Id(ConfigurationManager.AppSettings[locatorkey]));

                }
                else if (locatorkey.EndsWith("_name"))
                {
                    elementList = driver.FindElements(By.Name(ConfigurationManager.AppSettings[locatorkey]));

                }
                else if (locatorkey.EndsWith("_link"))
                {
                    elementList = driver.FindElements(By.LinkText(ConfigurationManager.AppSettings[locatorkey]));

                }
                else if (locatorkey.EndsWith("_Class"))
                {
                    elementList = driver.FindElements(By.ClassName(ConfigurationManager.AppSettings[locatorkey]));

                }
                //else
                //{

                //    reportFailure("Locator is not correct" + locatorkey);
                //    Assert.Fail("Locator not correct" + locatorkey);

                //}
                if (elementList.Count == 0)

                    return false;
                else
                    return true;
            }
            catch (Exception e)
            {

                throw e;
            }


        }

        public bool verifyText(string locatorKey, string expectedTextKey)
        {
            string actualText = getElement(locatorKey).Text;
            string expectedTest = expectedTextKey;
            if (actualText.Equals(expectedTest))
                return true;
            else
                return false;


        }

        public void clickAndWait(string locator_clicked, string locator_present)
        {
            test.Log(Status.Info, "Clicking on -" + locator_clicked + "waiting for-" + locator_present);
            int count = 5;
            for (int i = 0; i < count; i++)
            {

                getElement(locator_clicked).Click();
                Thread.Sleep(5000);
                isElementPresent(locator_present);
                break;

            }

        }

        public void explicitWait(string locator)
        {
            try
            {

                WebDriverWait waitForElement = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                // waitForElement.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator)));
                waitForElement.Until(
                    ExpectedConditions.ElementIsVisible(By.XPath(ConfigurationManager.AppSettings[locator])));
            }

            catch (Exception e)
            {
                reportFailure(e.Message);
                // Assert.Fail("Fail the Test-" + e.Message);

            }
        }


        public bool waitforElementPresent(string locator)

        {
            try
            {

                WebDriverWait waitForElement = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
                // waitForElement.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator)));
                waitForElement.Until(
                    ExpectedConditions.ElementIsVisible(By.XPath(ConfigurationManager.AppSettings[locator])));
            }

            catch (Exception e)
            {
                return false;

            }

            return true;
        }


        public string getText(string locatorKey)
        {
            test.Log(Status.Info, "Getting the text from" + locatorKey);
            return getElement(locatorKey).Text;

        }

        /******************Reporting Functions********************/

        public void reportPass(string msg)
        {
            test.Log(Status.Pass, msg);

        }

        public void reportFailure(String msg)
        {
            test.Log(Status.Fail, msg);
            takeScreenshot();
            errcount = 1;
            Assert.Fail(msg);

        }


        public void takeScreenshot()
        {
            //filename of the screenshot
            //string screenshotFile = DateTime.Now.ToString().Replace("/", "_").Replace(":", "_").Replace(" ", "_") + ".gif";
            //ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
            //Screenshot screenshot = screenshotDriver.GetScreenshot();
            //string filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            //filePath = Directory.GetParent(Directory.GetParent(filePath).FullName).FullName;
            //screenshot.SaveAsFile(filePath + ".\\Reports\\Screenshots\\" + screenshotFile, ScreenshotImageFormat.Gif);

            //string screenshotPath = filePath + ".\\Reports\\Screenshots\\" + screenshotFile;
            //test.Log(Status.Info, "Screenshot-", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
            //test.AddScreenCaptureFromPath(screenshotPath);
            //-----------------------------------------------------------------------------------------------


            //string screenshotFile = DateTime.Now.ToString().Replace("/", "_").Replace(":", "_").Replace(" ", "_") + ".gif";
            //ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
            //Screenshot screenshot = screenshotDriver.GetScreenshot();
            //string screenshotPath =  ".\\Reports\\Screenshots\\" + screenshot+".png";


            //test.Log(Status.Info, "Screenshot-", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());

            //string screenshotname = Appscreenshots.getscreenhot(name);


            //-----------------------------------------------------------------------

            //filename of the screenshot
            String dir = AppDomain.CurrentDomain.BaseDirectory;
            FileInfo fileInfo = new FileInfo(dir);
            DirectoryInfo currentDir = fileInfo.Directory.Parent.Parent;
            string parentDirName = currentDir.FullName;
            Screenshot file = ((ITakesScreenshot)driver).GetScreenshot();
            string screenshotFile = DateTime.Now.ToString().Replace("/", "_").Replace(":", "_").Replace(" ", "_") + ".png";
            ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;



            // file.SaveAsFile(@"\\mercury\Development\Testresults\Screenshots\" + screenshotFile, ScreenshotImageFormat.Png);

            file.SaveAsFile(@"\\mimas.fft.local\tfs-build-reports\Testresults\Screenshots\" + screenshotFile, ScreenshotImageFormat.Png);

            // test.Log(Status.Info, "Screenshot-", MediaEntityBuilder.CreateScreenCaptureFromPath(parentDirName + "\\Reports\\Screenshots\\" + screenshotFile).Build());

            test.Log(Status.Info, "Screenshot-", MediaEntityBuilder.CreateScreenCaptureFromPath(@"\\mimas.fft.local\tfs-build-reports\Testresults\Screenshots\" + screenshotFile).Build());

            test.AddScreenCaptureFromPath(@"\\mimas.fft.local\tfs-build-reports\Testresults\Screenshots\" + screenshotFile);

            // test.AddScreenCaptureFromPath(parentDirName + "\\Reports\\Screenshots\\" + screenshotFile);










        }



        //public void TakeFullScreenshot()
        //{
        //    //  ChromeDriver driver = new ChromeDriver();

        //    String dir = AppDomain.CurrentDomain.BaseDirectory;
        //    FileInfo fileInfo = new FileInfo(dir);
        //    DirectoryInfo currentDir = fileInfo.Directory.Parent.Parent;
        //    string parentDirName = currentDir.FullName;

        //    Dictionary<string, Object> metrics = new Dictionary<string, Object>();
        //    metrics["width"] = driver.ExecuteScript("return Math.max(window.innerWidth,document.body.scrollWidth,document.documentElement.scrollWidth)");
        //    metrics["height"] = driver.ExecuteScript("return Math.max(window.innerHeight,document.body.scrollHeight,document.documentElement.scrollHeight)");
        //    metrics["deviceScaleFactor"] = (double)driver.ExecuteScript("return window.devicePixelRatio");
        //    metrics["mobile"] = driver.ExecuteScript("return typeof window.orientation !== 'undefined'");
        //    driver.ExecuteChromeCommand("Emulation.setDeviceMetricsOverride", metrics);
        //    Screenshot file = ((ITakesScreenshot)driver).GetScreenshot();
        //    string screenshotFile = DateTime.Now.ToString().Replace("/", "_").Replace(":", "_").Replace(" ", "_") + ".png";



        //    //Execute the emulation Chrome Command to change browser to a custom device that is the size of the entire page

        //    ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;




        //    file.SaveAsFile(@"\\mimas.fft.local\tfs-build-reports\Testresults\Screenshots\" + screenshotFile, ScreenshotImageFormat.Png);


        //    driver.ExecuteChromeCommand("Emulation.clearDeviceMetricsOverride", new Dictionary<string, Object>());
        //    test.Log(Status.Info, "Screenshot-", MediaEntityBuilder.CreateScreenCaptureFromPath(@"\\mimas.fft.local\tfs-build-reports\Testresults\Screenshots\" + screenshotFile).Build());

        //    test.AddScreenCaptureFromPath(@"\\mimas.fft.local\tfs-build-reports\Testresults\Screenshots\" + screenshotFile);





        //}




        /******************Application Functions*****************************/

        public bool doLogin(string username, string password)
        {
            test.Log(Status.Info, "Trying to login with " + username + " , " + password);
            //navigate("appurl");
            type("Username_Id", username);
            type("Password_Id", password);
            click("Login_Id");
            if (isElementPresent("Homepage_Xpath"))
            {
                test.Log(Status.Info, "Login Success");
                return true;
            }
            else
            {
                test.Log(Status.Info, "Login Failed");

                return false;

            }
        }

        public bool iselementExist(string locatorkey)
        {
            IList<IWebElement> elementList = null;
            try
            {
                elementList = driver.FindElements(By.XPath(locatorkey));
            }
            catch (Exception e)
            {
                reportFailure(e.Message);
            }



            if (elementList.Count == 0)

                return false;
            else
                return true;
        }

        public void PerformActionClick(string locatorkey)
        {
            //IWebElement element = driver.FindElement(By.XPath(locatorkey));
            IWebElement element = getElement(locatorkey);
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Click().Perform();


        }
        public void scrolldown(string locatorkey)
        {
            // IWebElement s = driver.FindElement(By.XPath(locatorkey)); 
            IWebElement s = getElement(locatorkey);
            IJavaScriptExecutor je = (IJavaScriptExecutor)driver;
            je.ExecuteScript("arguments[0].scrollIntoView(true);", s);
            //return this;
        }


        //public string GetPassword(string username)
        //{
        //    try
        //    {

        //        var secretClient = new AmazonSecretsManagerClient();
        //       var value = secretClient.GetSecretValue(new GetSecretValueRequest
        //        {
        //            SecretId = ConfigurationManager.AppSettings["secretId"]
        //        });

        //        var deserial = new JsonDeserializer();
        //        var userDictionary = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(value.SecretString);


        //        var password = userDictionary[username]; // this is where we read the value from AWS Secrets Manager
        //        return password;

        //    }

        //    catch (Exception e)
        //    {

        //        // Assert.Fail("Fail the Test-");
        //        reportFailure("The key is not present in the AWS Secrets Manager ");
        //        return null;

        //    }



        //}




        //[AfterScenario]
        //public void quit()
        //{

        //    rep.Flush();
        //    if (driver != null)
        //        Thread.Sleep(1000);
        //        driver.Quit();
        //}

        //[AfterFeature]
        //public static void email()
        //{

        //    Email.sendMail();



        //}


    }
}
