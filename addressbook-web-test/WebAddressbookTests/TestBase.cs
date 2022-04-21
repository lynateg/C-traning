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
    public class TestBase
    {
        protected IWebDriver driver;
        protected IWebDriver driver2;
        private StringBuilder verificationErrors;
        protected string baseURL;
        private bool acceptNextAlert = true;
        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;

        [SetUp]       
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            driver2 = new ChromeDriver();
            baseURL = "http://localhost/addressbook/";
            verificationErrors = new StringBuilder();
            loginHelper = new LoginHelper(driver);
            navigator = new NavigationHelper(driver, baseURL);
            groupHelper = new GroupHelper(driver, baseURL);
            contactHelper = new ContactHelper(driver);
            loginHelper = new LoginHelper(driver2);
            navigator = new NavigationHelper(driver2, baseURL);
            groupHelper = new GroupHelper(driver2, baseURL);
            contactHelper = new ContactHelper(driver2);
        }
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
                driver2.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
    }
}
