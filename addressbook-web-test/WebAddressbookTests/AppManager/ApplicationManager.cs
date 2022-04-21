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
    public class ApplicationManager
    {
        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;
        protected IWebDriver driver;
        protected IWebDriver driver2;
        private StringBuilder verificationErrors;
        protected string baseURL;

        public ApplicationManager()
        {

            loginHelper = new LoginHelper(driver);
            navigator = new NavigationHelper(driver, baseURL);
            groupHelper = new GroupHelper(driver, baseURL);
            contactHelper = new ContactHelper(driver);
            loginHelper = new LoginHelper(driver2);
            navigator = new NavigationHelper(driver2, baseURL);
            groupHelper = new GroupHelper(driver2, baseURL);
            contactHelper = new ContactHelper(driver2);
        }
        public void Stop(IWebDriver webDriver)
        {
            webDriver.Quit();
        }
        public LoginHelper Auth
        {
            get { return loginHelper; }
        }
        public NavigationHelper Navigator
        {
            get { return navigator; }
        }
        public GroupHelper Groups
        {
            get { return groupHelper; }
        }
        public ContactHelper Contacts
        {
            get { return contactHelper; }
        }
    }
}
