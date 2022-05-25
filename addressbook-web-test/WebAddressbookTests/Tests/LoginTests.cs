using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class LoginTest : TestBase
    {
        [TestCase(TestName = "Логин с неверными данными")]
        public void LoginWithInvalidCredintals()
        {
            //prep
            app.Auth.Logout();
            //act
            AccountData account = new AccountData("admin", "12345678");
            app.Auth.Login(account);
            //test
            Assert.IsFalse(app.Auth.IsLoggedIn(account));
        }
        [TestCase(TestName = "Логин с верными данными")]
        public void LoginWithValidCredintals()
        {
            //prep
            app.Auth.Logout();
            //act
            AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(account);
            //test
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }

    }
}
