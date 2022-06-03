using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    class ContactModify : TestBase
    {
        [TestCase(TestName = "Firefox Изменение контакта")]    
        public void ModifyContactFirefox()
        {           
            app.Contacts.Modify(new UserData("Tram", "Pam", "Pam", "Ikarus"), driver);   
        }
        [TestCase(TestName = "Chrome Изменение контакта")]        
        public void ModifyContactChrome()
        {
            app.Contacts.Modify(new UserData("Pam", "Tram", "Pam", "Gig"), driver2);
        }
    }
}
