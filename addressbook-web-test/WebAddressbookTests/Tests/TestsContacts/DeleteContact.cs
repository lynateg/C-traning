using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests.Tests
{
    [TestFixture]
    public class DeleteContact : TestBase
    {
        [TestCase(TestName = "Firefox Удаление контакта")]
        //[Test]
        public void DeleteContactFirefox()
        {
            app.Navigator.OpenHomePage(driver, baseURL);
            app.Auth.Login(new AccountData("admin", "secret"), driver);
            app.Contacts.SelectContact(driver);
            app.Contacts.InitDeleteContact(driver);
            app.Contacts.CloseAlertWindow(driver); 
            app.Auth.Logout(driver);
        }
        [TestCase(TestName = "Chrome Удаление контакта")]
        //[Test]
        public void DeleteContactChrome()
        {
            app.Navigator.OpenHomePage(driver2, baseURL);
            app.Auth.Login(new AccountData("admin", "secret"), driver2);
            app.Contacts.SelectContact(driver2);
            app.Contacts.InitDeleteContact(driver2);
            app.Contacts.CloseAlertWindow(driver2);
            app.Auth.Logout(driver2);
        }
    }
}
