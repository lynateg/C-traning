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
            app.Groups.Create(new GroupData("xxx", "zzz", "yyy"), driver);
        }
        [TestCase(TestName = "Firefox Добавление пустой группы контактов")]
        public void EmptyGroupCreationTestFirefox()
        {            
            app.Groups.Create(new GroupData("", "", ""), driver);
        }

        [TestCase(TestName = "Chrome Добавление группы контактов")]
        //[Test]
        public void GroupCreationTestChrome()
        {       
            app.Groups.Create(new GroupData("aaa", "bbb", "ccc"), driver2);
        }

        [TestCase(TestName = "Chrome Добавление пустой группы контактов")]
        public void EmptyGroupCreationTestChrome()
        {
            app.Groups.Create(new GroupData("", "", ""), driver2);
        }

    }
}
