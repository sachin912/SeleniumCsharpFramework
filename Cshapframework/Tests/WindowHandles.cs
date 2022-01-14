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
      
        [Test]
        public void WindowHandleTest()
        {
            string nameEmail = "mentor@rahulshettyacademy.com";
            string parentWindow = driver.CurrentWindowHandle;
            driver.FindElement(By.ClassName("blinkingText")).Click();
            Assert.AreEqual(2, driver.WindowHandles.Count);
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            string mailText = driver.FindElement(By.CssSelector(".red")).Text;
            string[] splittedText = mailText.Split("at");
            string[] trimmedString = splittedText[1].Trim().Split(" ");
            Assert.AreEqual(nameEmail, trimmedString[0]);
            driver.SwitchTo().Window(parentWindow);
        }

    }
}
