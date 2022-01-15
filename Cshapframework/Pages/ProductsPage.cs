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
    public class ProductsPage
    {
        private IWebDriver driver;
        private By cardTitle = By.CssSelector(".card-title a");
        private By cardBtn = By.CssSelector(".card-footer button");

        public ProductsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.TagName, Using = "app-card")]
        private IList<IWebElement> cards;
        public IList<IWebElement> getCardsList()
        {
            return cards;
        }
       
        [FindsBy(How = How.PartialLinkText, Using = "Checkout")]
        private IWebElement checkout;
        public CheckoutPage ClickonCheckout()
        {
            checkout.Click();
            return new CheckoutPage(driver);
        } 
        public void waitforPagetoDisplayed()
        {
            WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));
        }

        public By getCardTitle()
        {
            return cardTitle;
        }

        public By getCardButton()
        {
            return cardBtn;
        }
    }
}
