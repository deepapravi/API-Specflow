using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace APTSpecFlowTestAutomationProject
{
    [Binding]
    public class Hooks1: DriverHelper
    {
        Webconnector web;
        public Hooks1(Webconnector web)
        {
            this.web = web;

        }
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeTestRun]

        public static void InitializeReport()
        {


            string reportFile = DateTime.Now.ToString().Replace("/", "_").Replace(":", "_").Replace(" ", "_") + ".html";
            //  var htmlReporter = new ExtentHtmlReporter(@"C:\Deepa\Reports\" + reportFile);
           var htmlReporter = new ExtentV3HtmlReporter(@"C:\Deepa\Reports\" + reportFile);

            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;

            extent = new ExtentReports();

            extent.AttachReporter(htmlReporter);


        }

        [AfterTestRun]

        public static void TeardownReort()
        {

            extent.Flush();

        }

        [BeforeFeature]
       
        public static void BeforeFeature()
        {

           // featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
            featureName = extent.CreateTest<Scenario>(FeatureContext.Current.FeatureInfo.Title);


        }


        [AfterStep]

        public void InsertReportingSteps()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            if (ScenarioContext.Current.TestError == null)
            {

                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "When")

                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);

            }

            else if (ScenarioContext.Current.TestError != null)
            {
                var mediaEntity = web.CaptureScreenshotAndReturnModel(ScenarioContext.Current.ScenarioInfo.Title.Trim());
                scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message,mediaEntity);
            }

        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArguments("start-maximized");
          //  new DriverManager().SetUpDriver(new ChromeConfig());
           
            Driver = new ChromeDriver(option);
            scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
            Driver.Quit();
        }
    }
}
