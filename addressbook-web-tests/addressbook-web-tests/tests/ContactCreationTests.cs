using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace Addressbook_Web_Tests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("Test1", "surname");
            contact.Address = "London";
            contact.Mobile = "9876546";

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.NewContact(contact);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            app.Contacts.CompareTo(oldContacts, newContacts);


        }
        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("", "");
            contact.Address = "";
            contact.Mobile = "";

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.NewContact(contact);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            app.Contacts.CompareTo(oldContacts, newContacts);


        }
    }
}
