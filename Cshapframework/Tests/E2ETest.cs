using Csharpframework.Pages;
using Csharpframework.ReQUtilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Csharpframework.Tests
{
    public class E2ETest : @base
    {
       
        [Test]
        public void Test()
        {
            string[] expectedProducts = { "iphone X", "Blackberry" };
            string[] actualProducts = new string[2];
            LoginPage login = new LoginPage(getdriver());
            ProductsPage productPage= login.validLogin("rahulshettyacademy", "learning");
            productPage.waitforPagetoDisplayed();
            IList<IWebElement> products = productPage.getCardsList();
            //login.getUserName().SendKeys("rahulshettyacademy");
            //driver.FindElement(By.CssSelector("#username")).SendKeys("rahulshettyacademy");
            //driver.FindElement(By.CssSelector("#password")).SendKeys("learning");
            //driver.FindElement(By.CssSelector("#terms")).Click();
            //driver.FindElement(By.CssSelector("#signInBtn")).Click();
            //explicit wait
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            //Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));
            //IList<IWebElement> products = driver.FindElements(By.TagName("app-card"));
            foreach (IWebElement product in products)
            {
                if (expectedProducts.Contains(product.FindElement(productPage.getCardTitle()).Text))
                {
                    product.FindElement(productPage.getCardButton()).Click();
                }
                TestContext.Progress.WriteLine(product.FindElement(productPage.getCardTitle()).Text);
            }
            //driver.FindElement(By.PartialLinkText("Checkout")).Click();
            CheckoutPage checkoutPage = productPage.ClickonCheckout();
            //IList<IWebElement> checkoutCards = driver.FindElements(By.CssSelector("h4 a"));
            IList<IWebElement> checkoutCards = checkoutPage.getCheckoutCardsList();
            for (int i = 0; i < checkoutCards.Count; i++)
            {
                actualProducts[i] = checkoutCards[i].Text;
            }
            Assert.AreEqual(expectedProducts, actualProducts);
            //driver.FindElement(By.CssSelector(".btn-success")).Click();
            ConfirmationPage confirmationPage = checkoutPage.ClickCheckout();
            confirmationPage.selectCountryDropdown("ind", "India");
            //driver.FindElement(By.Id("country")).SendKeys("ind");
            //Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));
            //driver.FindElement(By.LinkText("India")).Click();
            confirmationPage.EnableTerms();
            confirmationPage.Purchase();
            string confirmText = confirmationPage.getAlertText();
            //driver.FindElement(By.XPath("//label[@for='checkbox2']")).Click();
            //driver.FindElement(By.CssSelector("[value='Purchase']")).Click();
            //string confirmText = driver.FindElement(By.CssSelector(".alert-success")).Text;
            StringAssert.Contains("Success", confirmText);

        }
    }
}