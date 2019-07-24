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
            Assert.AreEqual(fromTable.AllEmails, fromEditForm.AllEmails);
            Assert.AreEqual(fromTable.AllPhones, fromEditForm.AllPhones);

        }

        [Test]
        public void TestContactInformation2()
        {
            int i = 3;
            String fromContactDetails = app.Contacts.GetContactInformationFromContactDetails(i);
            ContactData fromEditForm = app.Contacts.GetContactInformationEditForm(i);
            String fromContactFormStr = MakeStringOutofContactData(fromEditForm);
            Assert.AreEqual(fromContactDetails, fromContactFormStr);
        }
    
        private string MakeStringOutofContactData(ContactData fromEditForm)
        {
            string reply = "";
            string reply2 = ""; 
            string reply3 = "";
            string reply4 = "";
            string reply5 = "";

            if (fromEditForm.Name != "")
            {
                reply = fromEditForm.Name;
            }

            if (fromEditForm.Surname != "")
            {
                reply2 = " " + fromEditForm.Surname + "\r\n";
            }

            if (fromEditForm.Address != "")
            {

                reply3 = fromEditForm.Address + "\r\n\r\n";
            }

            if (fromEditForm.AllPhones != "")
            {
                reply4 = fromEditForm.AllPhones + "\r\n";
            }

            if (fromEditForm.AllEmails != "")
                {
                reply5 = fromEditForm.AllEmails + "\r\n";
                }

            if (reply + reply2 + reply3 + reply4 + reply5 == "")
            {
                return "\r\n";
            }
            else
            {
                if (fromEditForm.AllEmails != "" && fromEditForm.AllPhones != "")
                {
                    return reply + reply2 + reply3 + reply4 +"\r\n"+ reply5;
                }
                else
                {
                    return reply + reply2 + reply3 + reply4 + reply5;
                }
            }
        }
    }
}
