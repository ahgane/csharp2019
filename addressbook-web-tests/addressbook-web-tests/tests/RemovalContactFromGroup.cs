using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Addressbook_Web_Tests
{
    public class RemovalContactFromGroup : AuthTestBase
    {
        [Test]
        public void TestRemovalContactFromGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
    //        ContactData contact = ContactData.GetAll().Except(oldList).First();

            app.Contacts.RemoveContactFromGroup(oldList[0], group);


            List<ContactData> newList = group.GetContacts();
            oldList.Remove(oldList[0]);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);



        }
    }
}
