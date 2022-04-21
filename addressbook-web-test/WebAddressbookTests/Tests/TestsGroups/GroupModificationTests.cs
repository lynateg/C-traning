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
            app.Groups.Modify(1, new GroupData("ooo", "ppp", "jjj"), driver);
        }
        [TestCase(TestName = "Chrome Модификация группы контактов")]
        public void GroupModificationTestChrome()
        {          
            app.Groups.Modify(1, new GroupData("ooo", "ppp", "jjj"), driver2);
        }
    } 
}
