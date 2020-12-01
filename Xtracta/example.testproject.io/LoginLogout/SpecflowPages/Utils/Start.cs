using MarsQA_1.Helpers;
using MarsQA_1.Pages;
using MarsQA_1.SpecflowPages.Pages;
using NUnit.Framework;
using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using static MarsQA_1.Helpers.CommonMethods;

using NUnit.Framework.Interfaces;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Gherkin.Model;
using TechTalk.SpecFlow.Bindings;
using OpenQA.Selenium;
using System.IO;

namespace MarsQA_1.Utils
{
    [Binding]
    public class Start : Driver
    {

        private static ScenarioContext _scenarioContext;
        //private static FeatureContext _featureContext;
        private static ExtentReports _extentReports;
        private static ExtentHtmlReporter _extentHtmlReporter;
        private static ExtentTest feature;
        private static ExtentTest _scenario;
        

        

        public static Boolean signin = true;

       

        [BeforeTestRun]

        public static void Beforerun()
        {


            _extentHtmlReporter = new ExtentHtmlReporter(@"C:\Xtracta\example.testproject.io\LoginLogout\TestReports\Report1.html");
            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(_extentHtmlReporter);

            Start._extentHtmlReporter.Configuration().Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;

        }

        [BeforeScenario]
        public void Setup(ScenarioContext scenarioContext)
        {
            //launch the browser
            Initialize();
           

            if (null != scenarioContext)
            {
                _scenarioContext = scenarioContext;
                _scenario = feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title, scenarioContext.ScenarioInfo.Description);
            }
  }

        [BeforeFeature]
        
        public static void TearDownReportIn(FeatureContext featureContext)
        {
            if (null != featureContext)
            {
                feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title, featureContext.FeatureInfo.Description);
            }
        }
       

        

    [AfterStep]
    public void AfterEachStep()
    {
        ScenarioBlock scenarioBlock = _scenarioContext.CurrentScenarioBlock;
        switch (scenarioBlock)
        {
            case ScenarioBlock.Given:
                CreateNode<Given>();
                break;
            case ScenarioBlock.When:
                CreateNode<When>();
                break;
            case ScenarioBlock.Then:
                CreateNode<Then>();
                break;
            default:
                CreateNode<And>();
                break;
        }
    }
    public void CreateNode<T>() where T : IGherkinFormatterModel
    {
        if (_scenarioContext.TestError != null)
        {
            string name = @"C:\Xtracta\example.testproject.io\LoginLogout\TestReports" + _scenarioContext.ScenarioInfo.Title.Replace(" ", "") + ".jpeg";
            CommonMethods.TakeScreenshot(driver, name);
            _scenario.CreateNode<T>(_scenarioContext.StepContext.StepInfo.Text).Fail
                (_scenarioContext.TestError.Message + "\n" + _scenarioContext.TestError.StackTrace).AddScreenCaptureFromPath(name);
        }
        else
        {
            string name = @"C:\Xtracta\example.testproject.io\LoginLogout\TestReports\Screenshots" + _scenarioContext.ScenarioInfo.Title.Replace(" ", "") + ".jpeg";
            CommonMethods.TakeScreenshot(driver, name);
            _scenario.CreateNode<T>(_scenarioContext.StepContext.StepInfo.Text).Pass("").AddScreenCaptureFromPath(name);
        }
    }
    [AfterTestRun]
    public static void AfterTestRun()
    {
        //Flush report once test completes
        _extentReports.Flush();
    }
    [AfterScenario]
    public void TearDown()
    {
        Driver.driver.Quit();
    }








}
}
