using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactsTests : TestBase
    {
        [TestCase(TestName = "Добавление контакта")]
        public void ContactAddNew()
        {
            app.Contacts.New(new UserData("Nail", "Hummer", "Imagine", "Pegasus"), driver);
        }
        [TestCase(TestName = "Удаление контакта")]
        public void DeleteContact()
        {
            app.Contacts.Delete(driver);
        }
        [TestCase(TestName = "Изменение контакта")]
        public void ModifyContact()
        {
            app.Contacts.Modify(new UserData("Tram", "Pam", "Pam", "Ikarus"), driver);
        }

    }
}
