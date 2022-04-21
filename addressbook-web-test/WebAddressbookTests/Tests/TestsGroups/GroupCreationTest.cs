using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System;
using System.Text;

namespace WebAddressbookTests
{
    [TestFixture]

    public class GroupCreationTests : TestBase
    {
        [TestCase(TestName = "Firefox Добавление группы контактов")]
        //[Test]
        public void GroupCreationTestFirefox() 
        {
            app.Navigator.OpenHomePage(driver, baseURL);
            app.Auth.Login(new AccountData("admin", "secret"), driver);
            app.Navigator.GoToGroupsPage(driver);
            app.Groups.Create(new GroupData("xxx", "zzz", "yyy"), driver);
            app.Auth.Logout(driver);
        }
        [TestCase(TestName = "Firefox Добавление пустой группы контактов")]
        public void EmptyGroupCreationTestFirefox()
        {
            app.Navigator.OpenHomePage(driver, baseURL);
            app.Auth.Login(new AccountData("admin", "secret"), driver);
            app.Navigator.GoToGroupsPage(driver);
            app.Groups.Create(new GroupData("", "", ""), driver);
            app.Auth.Logout(driver);
        }

        [TestCase(TestName = "Chrome Добавление группы контактов")]
        //[Test]
        public void GroupCreationTestChrome()
        {
            app.Navigator.OpenHomePage(driver2, baseURL);
            app.Auth.Login(new AccountData("admin", "secret"), driver2);
            app.Navigator.GoToGroupsPage(driver2);
            app.Groups.Create(new GroupData("aaa", "bbb", "ccc"), driver2);
            app.Auth.Logout(driver2);
        }

        [TestCase(TestName = "Chrome Добавление пустой группы контактов")]
        public void EmptyGroupCreationTestChrome()
        {
            app.Navigator.OpenHomePage(driver2, baseURL);
            app.Auth.Login(new AccountData("admin", "secret"), driver2);
            app.Navigator.GoToGroupsPage(driver2);
            app.Groups.Create(new GroupData("", "", ""), driver2);
            app.Auth.Logout(driver2);
        }

    }
}
