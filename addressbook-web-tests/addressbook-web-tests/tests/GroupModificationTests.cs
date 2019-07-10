using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Addressbook_Web_Tests
{
    [TestFixture]
        public class GroupModificationTests : AuthTestBase
    {
            [Test]

           public void GroupModificationTest()
            {

            app.Navigator.GoToGroupsPage();

            if (!app.Groups.GroupExist())
            {
                GroupData group = new GroupData("g1 created to modify");
                group.Footer = "f1";
                group.Header = "h1";

                app.Groups.New(group);
            }

            GroupData newData = new GroupData("modified group 3");
            newData.Header = null;
            newData.Footer = "new just modified 3";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Modify (0, newData);
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }

    }
}
