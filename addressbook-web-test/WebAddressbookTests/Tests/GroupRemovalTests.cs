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
            app.Navigator.OpenHomePage(driver, baseURL);
            app.Auth.Login(new AccountData("admin", "secret"), driver);
            app.Navigator.GoToGroupsPage(driver);
            app.Groups.SelectGroup(1,driver);
            app.Groups.DeleteGroup(driver);
            app.Navigator.GoToGroupsPage(driver);
            app.Auth.Logout(driver);
        }

        [TestCase(TestName = "Chrome Удаление группы 1")]
        //[Test]
        public void RemoveGroupChrome()
        {
            app.Navigator.OpenHomePage(driver2, baseURL);
            app.Auth.Login(new AccountData("admin", "secret"), driver2);
            app.Navigator.GoToGroupsPage(driver2);
            app.Groups.SelectGroup(1, driver2);
            app.Groups.DeleteGroup(driver2);
            app.Navigator.GoToGroupsPage(driver2);
            app.Auth.Logout(driver2);
        }

    }
}
