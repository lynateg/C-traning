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
        
        public NavigationHelper(ApplicationManager manager)
            : base(manager)
        { }
        public void OpenHomePage(IWebDriver webDriver)
        {
            webDriver.Navigate().GoToUrl(this._baseURL);
        }
        public void GoToGroupsPage(IWebDriver webDriver)
        {
            webDriver.FindElement(By.LinkText("groups")).Click();
        }
    }
}
