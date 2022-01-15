using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharpframework.Pages
{
    public class ConfirmationPage
    {
        private IWebDriver driver;
        public ConfirmationPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How =How.Id,Using = "country")]
        private IWebElement countryField;
        [FindsBy(How =How.XPath, Using = "//label[@for='checkbox2']")]
        private IWebElement TermsCheckbox;
        [FindsBy(How =How.CssSelector, Using = "[value='Purchase']")]
        private IWebElement purchaseButton;
        [FindsBy(How =How.CssSelector, Using = ".alert-success")]
        private IWebElement alertSuccess;

        public string getAlertText()
        {
            return alertSuccess.Text;
        }
        public void EnableTerms()
        {
            TermsCheckbox.Click();
        }
        public void Purchase()
        {
            purchaseButton.Click();
        }
        public void selectCountryDropdown(string inputCountry, string countryFullName)
        {
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            countryField.SendKeys(inputCountry);
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText(countryFullName)));
            driver.FindElement(By.LinkText(countryFullName)).Click();
        }
    }
}
