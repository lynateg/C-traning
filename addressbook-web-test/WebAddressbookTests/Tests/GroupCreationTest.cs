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
            app.Navigator.OpenHomePage(driver,baseURL);
            app.Auth.Login(new AccountData("admin", "secret"), driver);
            app.Navigator.GoToGroupsPage(driver);
            app.Groups.InitGroupCreation(driver);
            app.Groups.FillGroupForm(new GroupData("xxx", "zzz", "yyy"), driver);
            app.Groups.SubmitGroupCreation(driver);
            app.Navigator.GoToGroupsPage(driver);
            app.Auth.Logout(driver);
        }
        [TestCase(TestName = "Chrome Добавление группы контактов")]
        //[Test (Type="Жопа")]
        public void GroupCreationTestChrome()
        {
            app.Navigator.OpenHomePage(driver2, baseURL);
            app.Auth.Login(new AccountData("admin", "secret"), driver2);
            app.Navigator.GoToGroupsPage(driver2);
            app.Groups.InitGroupCreation(driver2);
            app.Groups.FillGroupForm(new GroupData("xxx", "zzz", "yyy"), driver2);
            app.Groups.SubmitGroupCreation(driver2);
            app.Navigator.GoToGroupsPage(driver2);
            app.Auth.Logout(driver2);
        }
                    
    }
}
