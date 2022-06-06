using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactsTests : AuthTestBase
    {
        private UserData contactinfo;
        [TestCase(TestName = "Добавление контакта"),Order(1)]
        public void ContactAddNew()
        {
            List<UserData> oldContact = app.Contacts.GetContactList();

            app.Contacts.New(new UserData("Nail", "Hummer", "Imagine", "Pegasus"));
            contactinfo = new UserData("Nail", "Hummer", "Imagine", "Pegasus");

            List<UserData> newContact = app.Contacts.GetContactList();
            oldContact.Add(contactinfo);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
        }
        [TestCase(TestName = "Удаление контакта"),Order(3)]
        public void DeleteContact()
        {
            
            if (!app.Contacts.IsContactExist(1))
            {
                app.Contacts.New(new UserData("OLO", "BBQ", "gg", "eagle"));
            }
            List<UserData> oldContact = app.Contacts.GetContactList();
            UserData ContactRemoved = oldContact[1];
            app.Contacts.Delete(1);
            List<UserData> newContact = app.Contacts.GetContactList();           
            oldContact.RemoveAt(1);
            Assert.AreEqual(oldContact, newContact);
        }
        [TestCase(TestName = "Изменение контакта"),Order(2)]
        
        public void ModifyContact()
        {

            if (!app.Contacts.IsContactExist(2))
            {
                app.Contacts.New(new UserData("modifyname", "modifymidname", "modifylastname", "modifynickname"));
            }
            List<UserData> oldContact = app.Contacts.GetContactList();
            
            app.Contacts.Modify(new UserData("Tram", null, null, null));
            contactinfo = new UserData("Tram", null, null, null);
            
            List<UserData> newContact = app.Contacts.GetContactList();

            oldContact[2]._firstname = contactinfo._firstname;
            oldContact.Sort();
            newContact.Sort();
            Assert.AreNotEqual(oldContact, newContact);

        }

    }
}
