using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Addressbook_Web_Tests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]

        public void ContactModificationTest()
        {
            if (!app.Contacts.ContactExist())
            {
                ContactData contact = new ContactData("ToModify", "Modify in test");
                contact.Address = "some address";
                contact.Mobile = "9876546";

                app.Contacts.NewContact(contact);
            }


            ContactData newContact = new ContactData("Modified", "Contact");
            newContact.Address = "Modified address";
            newContact.Mobile = "Modified Mobile";

            app.Contacts.Modify(newContact);

        }
    }
}
