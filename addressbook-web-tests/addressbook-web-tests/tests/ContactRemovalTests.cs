using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Addressbook_Web_Tests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {

            app.Navigator.GoToHomePage();

            if (!app.Contacts.ContactExist())
            {
                ContactData contact = new ContactData("ToDelete", "Deleted");
                contact.Address = "NoAddress";
                contact.Mobile = "9876546";

                app.Contacts.NewContact(contact);
            }

            app.Contacts.Remove(1);
        }
    }
}
