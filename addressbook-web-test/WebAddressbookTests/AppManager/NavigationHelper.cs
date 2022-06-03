using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {
        protected string baseURL;
        public NavigationHelper(ApplicationManager manager, string baseURL)
            : base(manager)
        { this.baseURL = baseURL;   }
        public void OpenHomePage()
        {            
            if (driver.Url == baseURL)
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL);
        }
        public void GoToGroupsPage()
        {
            if (driver.Url == baseURL + "group.php"
               && IsElementPresent(By.Name("group page")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }
        public void GoToNewContactPage()
        {
            if (driver.Url == baseURL + "edit.php"
                && IsElementPresent(By.XPath("//*[@id='content']/form/input[7]")))
            {
                return;
            }
            driver.FindElement(By.LinkText("add new")).Click();
        }
    }
}
