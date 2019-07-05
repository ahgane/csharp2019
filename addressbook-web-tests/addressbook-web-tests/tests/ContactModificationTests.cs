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

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Modify(newContact);

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts[0].Name = newContact.Name;
            oldContacts[0].Surname = newContact.Surname;
            oldContacts.Sort();

            for (int a = 0; a < 2; a++)
            {
                System.Console.WriteLine(oldContacts[a].Name + " " + oldContacts[a].Surname);
            }
            newContacts.Sort();
            for (int a = 0; a < 2; a++)
            {
                System.Console.WriteLine(newContacts[a].Name + " " + newContacts[a].Surname);
            }
      //      Assert.AreEqual(oldContacts, newContacts);

        }
    }
}
