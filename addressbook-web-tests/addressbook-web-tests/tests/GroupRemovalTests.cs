using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace Addressbook_Web_Tests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
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

            app.Groups.Remove(1);
        }
    }
}
