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
    public class AddNewContact : TestBase
    {                      
        [TestCase(TestName = "Firefox Добавление контакта")]
        //[Test]
        public void AddNewContactFirefox()
        {
            navigator.OpenHomePage(driver, baseURL);
            loginHelper.Login(new AccountData("admin", "secret"), driver);
            contactHelper.FillNewContactData(new UserData("Nail", "Hummer", "Imagine", "Pegasus"), driver);
            contactHelper.ConfirmCreationNewContact(driver);
            navigator.OpenHomePage(driver, baseURL);
            loginHelper.Logout(driver);
        }
        [TestCase(TestName = "Chrome Добавление контакта")]
        //[Test]
        public void AddNewContactChrome()
        {
            navigator.OpenHomePage(driver2,baseURL);
            loginHelper.Login(new AccountData("admin", "secret"), driver2);
            contactHelper.FillNewContactData(new UserData("Lans", "Won", "DIWon", "Wolwerine"), driver2);
            contactHelper.ConfirmCreationNewContact(driver2);
            navigator.OpenHomePage(driver2, baseURL);
            loginHelper.Logout(driver2);
        }
    }
}
