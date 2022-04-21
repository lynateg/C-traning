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
        protected string baseURL;

        public ApplicationManager()
        {
            baseURL = "http://localhost/addressbook/";
            loginHelper = new LoginHelper(this);
            navigator = new NavigationHelper(this);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);

        }
        public IWebDriver Driver 
        {
            get
            {
                return driver;
            }
        }
        public IWebDriver Driver2
        {
            get
            {
                return driver2;
            }
        }
        public string BaseURL
        {
            get
            {
                return baseURL;
            }
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
