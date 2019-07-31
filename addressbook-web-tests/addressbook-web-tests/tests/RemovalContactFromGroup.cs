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
            List<GroupData> groups = GroupData.GetAll();

            if (groups != null)
            {
                for (int i = 0; i < groups.Count; i++)
                {
                    GroupData group = groups[i];
                    List<ContactData> oldList = group.GetContacts();


                    if (oldList.Count != 0)
                    {
                        ContactData contactToRemove = oldList[0];
                        app.Contacts.RemoveContactFromGroup(contactToRemove, group);

                        List<ContactData> newList = group.GetContacts();
                        oldList.Remove(contactToRemove);
                        newList.Sort();
                        oldList.Sort();

                        Assert.AreEqual(oldList, newList);

                        i = groups.Count;
                    }
                }
            }
            else
            {
                System.Console.Out.Write("Группы еще не созданы. Создайте группу с контактами и повторите тест.");
            }
        }
    }
}
