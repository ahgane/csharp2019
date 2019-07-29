using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Addressbook_Web_Tests
{
    [TestFixture]
    public class ContactCreationTests : GroupTestBase
    {

        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();

            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                {
                    Address = GenerateRandomString(100),
                    HomePhone = GenerateRandomString(10),
                    Email = GenerateRandomString(100)
                });
            }

            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromXMLFile()
        {
            List<ContactData> groups = new List<ContactData>();

           return (List<ContactData>) 
                new XmlSerializer(typeof(List<ContactData>))
                .Deserialize(new StreamReader(@"contacts.xml"));

        }

        public static IEnumerable<ContactData> ContactDataFromJSONFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(File.ReadAllText(@"contacts.json"));
        }

        [Test, TestCaseSource("ContactDataFromXMLFile")]
        public void ContactCreationTest(ContactData contact)
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.NewContact(contact);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
