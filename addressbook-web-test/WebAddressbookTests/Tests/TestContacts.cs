using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactsTests : AuthTestBase
    {
        [TestCase(TestName = "Добавление контакта")]
        public void ContactAddNew()
        {
            app.Contacts.New(new UserData("Nail", "Hummer", "Imagine", "Pegasus"));
        }
        [TestCase(TestName = "Удаление контакта")]
        public void DeleteContact()
        {
            app.Contacts.Delete(1);
        }
        [TestCase(TestName = "Изменение контакта")]
        public void ModifyContact()
        {
            app.Contacts.Modify(new UserData("Tram", "Pam", "Pam", "Ikarus"));
        }

    }
}
