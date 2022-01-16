using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        [SetUp]
        public void setup()
        {
            //new WebDriverManager.DriverManager.SetUpDriver(new ChromeConfig());
            //implicit wait
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
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
        public void QuitWindow()
        {
            driver.Value.Quit();
        }
    }
}
