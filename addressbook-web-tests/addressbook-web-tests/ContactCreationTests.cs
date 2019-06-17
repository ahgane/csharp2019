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
            GoToLoginPage();
            Login(new AccountData("admin", "secret"));
            CreateNewContact();
            ContactData contact = new ContactData("name","surname" );
            contact.Address = "London";
            contact.Mobile = "9876546";
            FillInContactForm(contact);
            ConfirmContactCreation();
            GoToHomePage();
            Logout();
        }
    }
}
