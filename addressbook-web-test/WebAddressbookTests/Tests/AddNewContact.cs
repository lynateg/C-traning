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
            app.Navigator.OpenHomePage(driver, baseURL);
            app.Auth.Login(new AccountData("admin", "secret"), driver);
            app.Contacts.FillNewContactData(new UserData("Nail", "Hummer", "Imagine", "Pegasus"), driver);
            app.Contacts.ConfirmCreationNewContact(driver);
            app.Navigator.OpenHomePage(driver, baseURL);
            app.Auth.Logout(driver);
        }
        [TestCase(TestName = "Chrome Добавление контакта")]
        //[Test]
        public void AddNewContactChrome()
        {
            app.Navigator.OpenHomePage(driver2, baseURL);
            app.Auth.Login(new AccountData("admin", "secret"), driver2);
            app.Contacts.FillNewContactData(new UserData("Nail", "Hummer", "Imagine", "Pegasus"), driver2);
            app.Contacts.ConfirmCreationNewContact(driver2);
            app.Navigator.OpenHomePage(driver2, baseURL);
            app.Auth.Logout(driver2);
        }
    }
}
