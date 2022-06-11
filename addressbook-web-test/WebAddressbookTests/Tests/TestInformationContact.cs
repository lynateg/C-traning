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
        [TestCase(TestName = "Метод обратных проверок с формы редактирования")]
        public void TestContactInformation()
        {
            UserData fromTable = app.Contacts.GetContactInformationFromTable(1);
            UserData fromForm = app.Contacts.GetContactInformationFromEditForm(1);
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);

        }
        [TestCase(TestName = "Метод обратных проверок с формы деталей")]
        public void ContactInformationDetailsTest()
        {
            UserData fromDetails = app.Contacts.GetContactInformationFromDetails(1);
            UserData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromForm.AllContactData, fromDetails.AllContactData);
        }
    }
}
