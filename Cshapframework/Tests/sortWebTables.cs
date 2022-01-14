using Csharpframework.ReQUtilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumFrameworkincsharp.Basics
{
    public class sortWebTables : @base
    {
       

        [Test]
        public void sortTableTest()
        {
            ArrayList a= new ArrayList();
            SelectElement dropDown = new SelectElement(driver.FindElement(By.Id("page-menu")));
            dropDown.SelectByValue("20");
            IList<IWebElement> productList = driver.FindElements(By.XPath("//td[1]"));
            foreach(IWebElement product in productList)
            {
                a.Add(product.Text);
            }
            a.Sort();
            driver.FindElement(By.XPath("(//th[@role='columnheader']) [1]")).Click();
            productList = driver.FindElements(By.XPath("//td[1]"));
            int i = 0;
            foreach (IWebElement veggie in productList)
            {
                Assert.AreEqual(a[i],veggie.Text);
                i++;
            }
        }
       
    }
}
