using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Addressbook_Web_Tests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]

        public void ContactModificationTest()
        {

            ContactData newContact = new ContactData("Test", "Test");
            newContact.Address = "Test";
            newContact.Mobile = "Test";

            app.Contacts.Modify(newContact);

        }
    }
}
