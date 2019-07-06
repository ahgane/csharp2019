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

            foreach (ContactData person in oldContacts)
            {
                System.Console.WriteLine(person.Name + " " + person.Surname);
            }

            newContacts.Sort();

            foreach (ContactData person in newContacts)
            {
                System.Console.WriteLine(person.Name + " " + person.Surname);
            }

            Assert.AreEqual(oldContacts, newContacts);

        }
    }
}
