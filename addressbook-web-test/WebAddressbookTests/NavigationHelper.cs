using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {
        protected object _baseURL;
         
        public NavigationHelper(IWebDriver webDriver, string baseURL)
            : base(webDriver)
        {
            _baseURL = baseURL;
        }
        public void OpenHomePage(IWebDriver webDriver, string baseURL)
        {
            webDriver.Navigate().GoToUrl(baseURL);
        }
        public void GoToGroupsPage(IWebDriver webDriver)
        {
            webDriver.FindElement(By.LinkText("groups")).Click();
        }
    }
}
