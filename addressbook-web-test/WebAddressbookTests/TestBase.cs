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
        protected void Logout(IWebDriver webDriver)
        {
            webDriver.FindElement(By.LinkText("Logout")).Click();
        }
        protected void SubmitGroupCreation(IWebDriver webDriver)
        {
            webDriver.FindElement(By.Name("submit")).Click();
        }
        protected void FillGroupForm(GroupData groupInfo, IWebDriver webDriver)
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
        protected void InitGroupCreation(IWebDriver webDriver)
        {
            webDriver.FindElement(By.Name("new")).Click();
        }
        protected void GoToGroupsPage(IWebDriver webDriver)
        {
            webDriver.FindElement(By.LinkText("groups")).Click();
        }
        protected void Login(AccountData account, IWebDriver webDriver)
        {
            webDriver.FindElement(By.Name("user")).Click();
            webDriver.FindElement(By.Name("user")).Clear();
            webDriver.FindElement(By.Name("user")).SendKeys(account.Username);
            webDriver.FindElement(By.Name("pass")).Clear();
            webDriver.FindElement(By.Name("pass")).SendKeys(account.Password);
            webDriver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }
        protected void OpenHomePage(IWebDriver webDriver)
        {
            webDriver.Navigate().GoToUrl(baseURL);
        }
        protected void FillNewContactData(UserData userData, IWebDriver webDriver)
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
        protected void DeleteGroup(IWebDriver webDriver)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[5]")).Click();
        }
        protected void SelectGroup(int index, IWebDriver webDriver)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
        }
    }
}
