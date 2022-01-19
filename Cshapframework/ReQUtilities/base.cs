
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Csharpframework.ReQUtilities
{
    public class @base
    {
        //public IWebDriver driver;
        public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
        string browserName;
        public ExtentReports extent;
        public ExtentTest test;
        [OneTimeSetUp]
        public void Setup()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string reportPath = projectDirectory + "//index.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "Local host");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("UserName", "Sachin");
        }
        [SetUp]
        public void setup()
        {
            //new WebDriverManager.DriverManager.SetUpDriver(new ChromeConfig());
            //implicit wait
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            browserName = TestContext.Parameters["browserName"];
            if(browserName==null)
            browserName = ConfigurationManager.AppSettings["browser"];
            browserInit(browserName);
            driver.Value.Url = "https://rahulshettyacademy.com/loginpagePractise";
        }
        public IWebDriver getdriver()
        {
            return driver.Value;
        }
        public void browserInit(string browserName)
        {
            switch (browserName)
            {
                case "Chrome":
                    driver.Value = new ChromeDriver();
                    driver.Value.Manage().Window.Maximize();
                    break;
                case "firefox":
                    driver.Value = new FirefoxDriver();
                    driver.Value.Manage().Window.Maximize();
                    break;
                default:
                    driver.Value = new ChromeDriver();
                    driver.Value.Manage().Window.Maximize();
                    break;
            }
        }
        public static jsonReader getParser()
        {
            return new jsonReader();
        }

        [TearDown]
        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;
            DateTime dateTime = DateTime.Now;
            string filename = "Screenshot" + dateTime.ToString("h_mm_ss") + ".png";
            if (status == TestStatus.Failed)
            {
                test.Fail("Test Failed", captureScreensshot(driver.Value, filename));
                test.Log(Status.Fail, "test failed with logtrace:" + stackTrace);

            }
            extent.Flush();
            driver.Value.Quit();
        }
              public MediaEntityModelProvider captureScreensshot(IWebDriver driver,string screenshotName)
            {
                ITakesScreenshot ts = (ITakesScreenshot)driver;
                var screenshot =ts.GetScreenshot().AsBase64EncodedString;
                return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenshotName).Build();
            }
    }
}
