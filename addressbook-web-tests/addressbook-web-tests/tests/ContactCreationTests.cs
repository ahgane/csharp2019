using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace Addressbook_Web_Tests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("name", "surname");
            contact.Address = "London";
            contact.Mobile = "9876546";
            app.Contacts
                .CreateNewContact()
                .FillInContactForm(contact)
                .ConfirmContactCreation();
            app.Navigator.GoToHomePage();
            app.Navigator.Logout();
        }
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("", "");
            contact.Address = "";
            contact.Mobile = "";
            app.Contacts.NewContact(contact);
            app.Navigator.GoToHomePage();
            app.Navigator.Logout();
        }
    }
}
