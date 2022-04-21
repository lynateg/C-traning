using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests.Tests
{
    class ModifyContact : TestBase
    {
        [TestCase(TestName = "Firefox Изменение контакта")]
        //[Test]
        public void ModifyContactFirefox()
        {
            app.Navigator.OpenHomePage(driver, baseURL);
            app.Auth.Login(new AccountData("admin", "secret"), driver);
            app.Contacts.InitModification(driver);
            app.Contacts.FillNewContactData(new UserData("Tram", "Pam", "Pam", "Ikarus"), driver);
            app.Contacts.UpdateModification(driver);
            app.Contacts.GoToHomePage(driver);
            app.Auth.Logout(driver);

        }
        [TestCase(TestName = "Chrome Изменение контакта")]
        //[Test]
        public void ModifyContactChrome()
        {
            app.Navigator.OpenHomePage(driver2, baseURL);
            app.Auth.Login(new AccountData("admin", "secret"), driver2);
            app.Contacts.InitModification(driver2);
            app.Contacts.FillNewContactData(new UserData("Pam", "Tram", "Pam", "Gig"), driver2);
            app.Contacts.UpdateModification(driver2);
            app.Contacts.GoToHomePage(driver2);
            app.Auth.Logout(driver2);

        }
    }
}
