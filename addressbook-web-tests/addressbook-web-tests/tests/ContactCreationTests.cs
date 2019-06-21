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
            app.Navigator.GoToLoginPage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Contacts.CreateNewContact();
            ContactData contact = new ContactData("name","surname" );
            contact.Address = "London";
            contact.Mobile = "9876546";
            app.Contacts.FillInContactForm(contact);
            app.Contacts.ConfirmContactCreation();
            app.Navigator.GoToHomePage();
            app.Navigator.Logout();
        }
    }
}
