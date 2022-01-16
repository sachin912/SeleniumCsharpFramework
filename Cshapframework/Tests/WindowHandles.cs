using Csharpframework.ReQUtilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFrameworkincsharp.Basics
{
   public class WindowHandles : @base
    {
      
        [Test, Category("Smoke")]
        public void WindowHandleTest()
        {
            string nameEmail = "mentor@rahulshettyacademy.com";
            string parentWindow = driver.Value.CurrentWindowHandle;
            driver.Value.FindElement(By.ClassName("blinkingText")).Click();
            Assert.AreEqual(2, driver.Value.WindowHandles.Count);
            driver.Value.SwitchTo().Window(driver.Value.WindowHandles[1]);
            string mailText = driver.Value.FindElement(By.CssSelector(".red")).Text;
            string[] splittedText = mailText.Split("at");
            string[] trimmedString = splittedText[1].Trim().Split(" ");
            Assert.AreEqual(nameEmail, trimmedString[0]);
            driver.Value.SwitchTo().Window(parentWindow);
        }

    }
}
