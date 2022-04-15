using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class AddNewContact
    {
        private IWebDriver driver;
        private IWebDriver driver2;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
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
                driver.Quit();
                driver2.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        [TestCase(TestName = "Firefox Добавление контакта")]
        //[Test]
        public void AddNewContactFirefox()
        {
            OpenHomePage(driver);
            Login(new AccountData("admin", "secret"), driver);               
            FillNewContactData(new UserData("Nail", "Hummer", "Imagine", "Pegasus"),driver);
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            OpenHomePage(driver);
            Logout(driver);

        }
        [TestCase(TestName = "Chrome Добавление контакта")]
        //[Test]
        public void AddNewContactChrome()
        {
            OpenHomePage(driver2);
            Login(new AccountData("admin", "secret"), driver2);
            FillNewContactData(new UserData("Lans", "Won", "DIWon", "Wolwerine"), driver2);
            driver2.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            OpenHomePage(driver2);
            Logout(driver2);

        }

        private void FillNewContactData(UserData userData, IWebDriver webDriver)
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

        private void Login(AccountData account, IWebDriver webDriver)
        {
            webDriver.FindElement(By.Name("user")).Click();
            webDriver.FindElement(By.Name("user")).Clear();
            webDriver.FindElement(By.Name("user")).SendKeys(account.Username);
            webDriver.FindElement(By.Name("pass")).Clear();
            webDriver.FindElement(By.Name("pass")).SendKeys(account.Password);
            webDriver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        private void OpenHomePage(IWebDriver webDriver)
        {
            //open page
            webDriver.Navigate().GoToUrl(baseURL);
        }
        private void Logout(IWebDriver webDriver)
        {
            webDriver.FindElement(By.LinkText("Logout")).Click();
        }
        private bool IsElementPresent(By by, IWebDriver webDriver)
        {
            try
            {
                webDriver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent(IWebDriver webDriver)
        {
            try
            {
                webDriver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText(IWebDriver webDriver)
        {
            try
            {
                IAlert alert = webDriver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
