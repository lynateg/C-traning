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
            OpenHomePage(driver);
            Login(new AccountData("admin", "secret"), driver);
            GoToGroupsPage(driver);
            SelectGroup(1,driver);
            DeleteGroup(driver);
            GoToGroupsPage(driver);
            Logout(driver);
        }

        [TestCase(TestName = "Chrome Удаление группы 1")]
        //[Test]
        public void RemoveGroupChrome()
        {
            OpenHomePage(driver2);
            Login(new AccountData("admin", "secret"), driver2);
            GoToGroupsPage(driver2);
            SelectGroup(1, driver2);
            DeleteGroup(driver2);
            GoToGroupsPage(driver2);
            Logout(driver2);
        }

    }
}
