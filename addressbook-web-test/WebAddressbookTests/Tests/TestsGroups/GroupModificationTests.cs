using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System;
using System.Text;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    { 
        [TestCase(TestName = "Firefox Модификация группы контактов")]

        public void GroupModificationTestFirefox()
        {
            app.Navigator.OpenHomePage(driver, baseURL);
            app.Auth.Login(new AccountData("admin", "secret"), driver);
            app.Navigator.GoToGroupsPage(driver);
            app.Groups.Modify(1, new GroupData("ooo", "ppp", "jjj"), driver);
            app.Auth.Logout(driver);
        }



        [TestCase(TestName = "Chrome Модификация группы контактов")]

        public void GroupModificationTestChrome()
        {
            app.Navigator.OpenHomePage(driver2, baseURL);
            app.Auth.Login(new AccountData("admin", "secret"), driver2);
            app.Navigator.GoToGroupsPage(driver2);
            app.Groups.Modify(1, new GroupData("ooo", "ppp", "jjj"), driver2);
            app.Auth.Logout(driver2);
        }
    } 
}
