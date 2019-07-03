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

//            app.Navigator.GoToGroupsPage();

            if (!app.Groups.GroupExist())
            {
                GroupData group = new GroupData("g1 created to modify");
                group.Footer = "f1";
                group.Header = "h1";

                app.Groups.New(group);
            }

            GroupData newData = new GroupData("modified group 2");
            newData.Footer = "just modified 2";
            newData.Header = null;

            app.Groups.Modify (1, newData);

            }

    }
}
