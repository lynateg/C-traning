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
        protected ApplicationManager app;

        [SetUp]       
        public void SetupTest()
        {
            app = new ApplicationManager();
            driver = new FirefoxDriver();
            driver2 = new ChromeDriver();
            baseURL = "http://localhost/addressbook/";
            verificationErrors = new StringBuilder();

        }
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                app.Stop(driver);
                app.Stop(driver2);
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
    }
}
