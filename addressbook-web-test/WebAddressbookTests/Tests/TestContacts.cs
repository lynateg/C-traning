using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactsTests : AuthTestBase
    {
        [TestCase(TestName = "Добавление контакта"),Order(1)]
        public void ContactAddNew()
        {
            app.Contacts.New(new UserData("Nail", "Hummer", "Imagine", "Pegasus"));
        }
        [TestCase(TestName = "Удаление контакта"),Order(3)]
        public void DeleteContact()
        {
            if (!app.Contacts.IsContactExist(1))
            {
                app.Contacts.New(new UserData("OLO", "BBQ", "gg", "eagle"));
            }
            app.Contacts.Delete(1);
        }
        [TestCase(TestName = "Изменение контакта"),Order(2)]
        
        public void ModifyContact()
        {
            if (!app.Contacts.IsContactExist(2))
            {
                app.Contacts.New(new UserData("modifyname", "modifymidname", "modifylastname", "modifynickname"));
            }
            app.Contacts.Modify(new UserData("Tram", "Pam", "Pam", "Ikarus"));
        }

    }
}
