using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharpframework.Pages
{
    public class LoginPage
    {
       private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement userName;
        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement passWord;
        [FindsBy(How = How.Id, Using = "terms")]
        private IWebElement checkbox;
        public IWebElement getCheckBox()
        {
            return checkbox;
        }
        [FindsBy(How = How.Id, Using = "signInBtn")]
        private IWebElement signIn;
        public IWebElement getSignin()
        {
            return signIn;
        }

        public ProductsPage validLogin(string user, string pass)
        {
            userName.SendKeys(user);
            passWord.SendKeys(pass);
            checkbox.Click();
            signIn.Click();
            return new ProductsPage(driver);
        } 
        public IWebElement getUserName()
        {
            return userName;
        }
        public IWebElement getPassword()
        {
            return passWord;
        } 

    }
}
