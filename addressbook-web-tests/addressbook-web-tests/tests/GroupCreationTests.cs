using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace Addressbook_Web_Tests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    { 
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("g1");
            group.Footer = "f1";
            group.Header = "h1";

            app.Navigator.GoToGroupsPage();
            app.Groups.New(group);
            app.Navigator.GoToGroupsPage();
            app.Navigator.Logout();
        }

        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("g1");
            group.Footer = "f1";
            group.Header = "h1";


            app.Navigator.GoToGroupsPage();
            app.Groups.New(group);
            app.Navigator.GoToGroupsPage();
            app.Navigator.Logout();
        }
    }
}
