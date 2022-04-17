using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {

        [TestCase(TestName = "Firefox Удаление группы 1")]
        //[Test]
        public void RemoveGroupFirefox()
        {
            navigator.OpenHomePage(driver, baseURL);
            loginHelper.Login(new AccountData("admin", "secret"), driver);
            navigator.GoToGroupsPage(driver);
            groupHelper.SelectGroup(1,driver);
            groupHelper.DeleteGroup(driver);
            navigator.GoToGroupsPage(driver);
            loginHelper.Logout(driver);
        }

        [TestCase(TestName = "Chrome Удаление группы 1")]
        //[Test]
        public void RemoveGroupChrome()
        {
            navigator.OpenHomePage(driver2, baseURL);
            loginHelper.Login(new AccountData("admin", "secret"), driver2);
            navigator.GoToGroupsPage(driver2);
            groupHelper.SelectGroup(1, driver2);
            groupHelper.DeleteGroup(driver2);
            navigator.GoToGroupsPage(driver2);
            loginHelper.Logout(driver2);
        }

    }
}
