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
using System.Threading.Tasks;

namespace Csharpframework.ReQUtilities
{
    public class @base
    {
       public IWebDriver driver;
        [SetUp]
        public void setup()
        {
            //new WebDriverManager.DriverManager.SetUpDriver(new ChromeConfig());
            //implicit wait
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            string browserName = ConfigurationManager.AppSettings["browser"];
            browserInit(browserName);
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise";
        }

        public void browserInit(string browserName)
        {
            switch (browserName)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    driver.Manage().Window.Maximize();
                    break;
                case "firefox":
                    driver = new FirefoxDriver();
                    driver.Manage().Window.Maximize();
                    break;
                default:
                    driver = new ChromeDriver();
                    driver.Manage().Window.Maximize();
                    break;
            }
        }

        [TearDown]
        public void QuitWindow()
        {
            driver.Quit();
        }
    }
}
