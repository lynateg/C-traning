using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactAddNew : TestBase
    {                      
        [TestCase(TestName = "Firefox Добавление контакта")]
        public void ContactAddNewFirefox()
        {
            app.Contacts.New(new UserData("Nail", "Hummer", "Imagine", "Pegasus"), driver);
        }
        [TestCase(TestName = "Chrome Добавление контакта")]
        public void ContactAddNewChrome()
        {
            app.Contacts.New(new UserData("Nail", "Hummer", "Imagine", "Pegasus"), driver2);
        }
    }
}
