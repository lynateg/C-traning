using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System;
using System.Text;

namespace WebAddressbookTests
{
    [TestFixture]

    public class GroupCreationTests
    {
        private IWebDriver driver;
        private IWebDriver driver2;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        public GroupCreationTests()
        {
            
        }

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver(@"C:\geckodriver-v0.31.064\");
            driver2 = new ChromeDriver(@"C:\Users\Lynateg\.nuget\packages\selenium.webdriver.chromedriver\100.0.4896.6000\driver\win32");
            baseURL = "http://localhost/addressbook";
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
        [TestCase(TestName = "Firefox проверка")]
        //[Test]
        public void GroupCreationTestFirefox()
        {
            OpenHomePage(driver);
            Login(new AccountData("admin", "secret"), driver);
            GoToGroupsPage(driver);
            InitGroupCreation(driver);
            FillGroupForm(new GroupData("xxx", "zzz", "yyy"), driver);
            SubmitGroupCreation(driver);
            GoToGroupsPage(driver);
            Logout(driver);
        }
        [TestCase(TestName = "Chrome проверка")]
        //[Test (Type="Жопа")]
        public void GroupCreationTestChrome()
        {
            OpenHomePage(driver2);
            Login(new AccountData("admin", "secret"), driver2);
            GoToGroupsPage(driver2);
            InitGroupCreation(driver2);
            FillGroupForm(new GroupData("aaa", "bbbb", "ccc"), driver2);
            SubmitGroupCreation(driver2);
            GoToGroupsPage(driver2);
            Logout(driver2);
        }
        private void Logout(IWebDriver webDriver)
        {
            webDriver.FindElement(By.LinkText("Logout")).Click();
        }

        private void SubmitGroupCreation(IWebDriver webDriver)
        {
            webDriver.FindElement(By.Name("submit")).Click();
        }

        private void FillGroupForm(GroupData groupInfo, IWebDriver webDriver)
        {
            webDriver.FindElement(By.Name("group_name")).Click();
            webDriver.FindElement(By.Name("group_name")).Clear();
            webDriver.FindElement(By.Name("group_name")).SendKeys(groupInfo.GroupName);
            webDriver.FindElement(By.Name("group_header")).Click();
            webDriver.FindElement(By.Name("group_header")).Clear();
            webDriver.FindElement(By.Name("group_header")).SendKeys(groupInfo.GroupHeader);
            webDriver.FindElement(By.Name("group_footer")).Click();
            webDriver.FindElement(By.Name("group_footer")).Clear();
            webDriver.FindElement(By.Name("group_footer")).SendKeys(groupInfo.GroupFooter);
        }

        private void InitGroupCreation(IWebDriver webDriver)
        {
            webDriver.FindElement(By.Name("new")).Click();
        }

        private void GoToGroupsPage(IWebDriver webDriver)
        {
            webDriver.FindElement(By.LinkText("groups")).Click();
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
