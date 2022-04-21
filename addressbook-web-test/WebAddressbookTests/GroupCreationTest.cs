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
            OpenHomePage(driver);
            Login(new AccountData("admin", "secret"), driver);
            GoToGroupsPage(driver);
            InitGroupCreation(driver);
            FillGroupForm(new GroupData("xxx", "zzz", "yyy"), driver);
            SubmitGroupCreation(driver);
            GoToGroupsPage(driver);
            Logout(driver);
        }
        [TestCase(TestName = "Chrome Добавление группы контактов")]
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
                    
    }
}
