using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactDelete : TestBase
    {
        [TestCase(TestName = "Firefox Удаление контакта")]
        //[Test]
        public void DeleteContactFirefox()
        {
            app.Contacts.Delete(driver);
        }
        [TestCase(TestName = "Chrome Удаление контакта")]
        //[Test]
        public void DeleteContactChrome()
        {
            app.Contacts.Delete(driver2);
        }
    }
}
