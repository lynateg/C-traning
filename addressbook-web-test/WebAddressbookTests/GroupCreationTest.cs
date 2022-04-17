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
            navigator.OpenHomePage(driver,baseURL);
            loginHelper.Login(new AccountData("admin", "secret"), driver);
            navigator.GoToGroupsPage(driver);
            groupHelper.InitGroupCreation(driver);
            groupHelper.FillGroupForm(new GroupData("xxx", "zzz", "yyy"), driver);
            groupHelper.SubmitGroupCreation(driver);
            navigator.GoToGroupsPage(driver);
            loginHelper.Logout(driver);
        }
        [TestCase(TestName = "Chrome Добавление группы контактов")]
        //[Test (Type="Жопа")]
        public void GroupCreationTestChrome()
        {
            navigator.OpenHomePage(driver2,baseURL);
            loginHelper.Login(new AccountData("admin", "secret"), driver2);
            navigator.GoToGroupsPage(driver2);
            groupHelper.InitGroupCreation(driver2);
            groupHelper.FillGroupForm(new GroupData("aaa", "bbbb", "ccc"), driver2);
            groupHelper.SubmitGroupCreation(driver2);
            navigator.GoToGroupsPage(driver2);
            loginHelper.Logout(driver2);
        }
                    
    }
}
