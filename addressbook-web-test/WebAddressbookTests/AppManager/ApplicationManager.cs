using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
namespace WebAddressbookTests
{
    public class ApplicationManager
    {
        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;

        protected IWebDriver driver;
        protected string baseURL;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();
        public ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook/";

            loginHelper = new LoginHelper(this, baseURL);
            navigator = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
                       
        }
        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstace = new ApplicationManager();
                newInstace.Navigator.OpenHomePage();
                app.Value = newInstace;
            }

            return app.Value;
        }
        public void Stop()
        {
            driver.Quit();
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
        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }
    }
}
