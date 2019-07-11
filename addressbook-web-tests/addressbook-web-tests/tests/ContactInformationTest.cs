using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Addressbook_Web_Tests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            int i = 0;
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(i);
            ContactData fromEditForm = app.Contacts.GetContactInformationEditForm(i);
            Assert.AreEqual(fromTable, fromEditForm);
            Assert.AreEqual(fromTable.Address, fromEditForm.Address);
            Assert.AreEqual(fromTable.Email, fromEditForm.Email);
            Assert.AreEqual(fromTable.AllPhones, fromEditForm.AllPhones);

        }
    }
}
