using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace Addressbook_Web_Tests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.Navigator.GoToGroupsPage();

            if (!app.Groups.GroupExist())
            {
                GroupData group = new GroupData("g1");
                group.Footer = "f1";
                group.Header = "h1";

                app.Groups.New(group);
            }
            List<GroupData> oldGroups = GroupData.GetAll();

            GroupData toBeRemoved = oldGroups[0];
            app.Groups.Remove(toBeRemoved);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}
