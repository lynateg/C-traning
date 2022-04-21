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
    public class LoginHelper : HelperBase
    {
        public LoginHelper(IWebDriver webDriver)
            : base(webDriver) { }
        public void Login(AccountData account, IWebDriver webDriver)
        {
            webDriver.FindElement(By.Name("user")).Click();
            webDriver.FindElement(By.Name("user")).Clear();
            webDriver.FindElement(By.Name("user")).SendKeys(account.Username);
            webDriver.FindElement(By.Name("pass")).Clear();
            webDriver.FindElement(By.Name("pass")).SendKeys(account.Password);
            webDriver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }
        public void Logout(IWebDriver webDriver)
        {
            webDriver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}