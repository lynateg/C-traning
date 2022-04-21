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
        public ContactHelper(ApplicationManager manager) 
            : base(manager) {}
        public ContactHelper FillNewContactData(UserData userData, IWebDriver webDriver)
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
            return this;
        }

        public ContactHelper UpdateModification(IWebDriver webDriver)
        {
            webDriver.FindElement(By.XPath("//*[@id='content']/form[1]/input[1]")).Click();
            return this;
        }

        public ContactHelper InitModification(IWebDriver webDriver)
        {
            webDriver.FindElement(By.XPath("/html/body/div[1]/div[4]/form[2]/table/tbody/tr[4]/td[8]/a/img")).Click();
            return this;
        }

        public ContactHelper GoToHomePage(IWebDriver webDriver)
        {
            webDriver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

        public ContactHelper InitDeleteContact(IWebDriver webDriver)
        {
            webDriver.FindElement(By.XPath("//*[@id='content']/form[2]/div[2]/input")).Click();
            return this;
        }

        public ContactHelper SelectContact(IWebDriver webDriver)
        {
            webDriver.FindElement(By.XPath("/html/body/div[1]/div[4]/form[2]/table/tbody/tr[3]/td[1]/input")).Click();
            return this;
        }
        public ContactHelper CloseAlertWindow(IWebDriver webDriver)
        {
            webDriver.SwitchTo().Alert().Accept();
            return this;
        }
        public ContactHelper ConfirmCreationNewContact(IWebDriver webDriver)
        {
            webDriver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            return this;
        }
        public ContactHelper Delete(IWebDriver webDriver)
        {
            webDriver.FindElement(By.XPath("//*[@id='content']/form[2]/div[2]/input")).Click();
            return this;
        }




    }
}
