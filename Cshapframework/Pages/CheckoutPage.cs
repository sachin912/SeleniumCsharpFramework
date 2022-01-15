using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharpframework.Pages
{
    public class CheckoutPage
    {
        private IWebDriver driver;
        public CheckoutPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.CssSelector, Using = "h4 a")]
        private IList<IWebElement> checkoutCardslist;

        [FindsBy(How = How.CssSelector, Using = ".btn-success")]
        private IWebElement checkoutbtn;
        public ConfirmationPage ClickCheckout()
        {
            checkoutbtn.Click();
            return new ConfirmationPage(driver);
        }
        public IList<IWebElement> getCheckoutCardsList()
        {
            return checkoutCardslist;
        }
    }
}
