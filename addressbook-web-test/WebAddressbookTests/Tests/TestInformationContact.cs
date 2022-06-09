using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class TestInformationContact : AuthTestBase
    {
        [TestCase(TestName = "Информация на главной странице соответствует информации, представленной в форме редактирования контакта")]
        public void TestContactInformation()
        {
            UserData fromTable = app.Contacts.GetContactInformationFromTable(1);
            UserData fromForm = app.Contacts.GetContactInformationFromEditForm(1);
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);

        }
    }
}
