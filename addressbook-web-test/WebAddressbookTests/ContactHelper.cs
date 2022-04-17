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
    public class ContactHelper : HelperBase
    {
        protected object _baseURL;
        public ContactHelper(IWebDriver webDriver) 
            : base(webDriver)
        {}
        public void FillNewContactData(UserData userData, IWebDriver webDriver)
        {
            webDriver.FindElement(By.LinkText("add new")).Click();
            webDriver.FindElement(By.Name("firstname")).Click();
            webDriver.FindElement(By.Name("firstname")).Clear();
            webDriver.FindElement(By.Name("firstname")).SendKeys(userData.Firstname);
            webDriver.FindElement(By.Name("middlename")).Click();
            webDriver.FindElement(By.Name("middlename")).Clear();
            webDriver.FindElement(By.Name("middlename")).SendKeys(userData.Middlename);
            webDriver.FindElement(By.Name("lastname")).Click();
            webDriver.FindElement(By.Name("lastname")).Clear();
            webDriver.FindElement(By.Name("lastname")).SendKeys(userData.Lastname);
            webDriver.FindElement(By.Name("nickname")).Click();
            webDriver.FindElement(By.Name("nickname")).Clear();
            webDriver.FindElement(By.Name("nickname")).SendKeys(userData.Nickname);
        }
        public void ConfirmCreationNewContact(IWebDriver webDriver)
        {
            webDriver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
        }
    }
}
