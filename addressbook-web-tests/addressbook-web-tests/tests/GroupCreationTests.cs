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
            app.Navigator.GoToLoginPage();
            app.Auth.Login(new AccountData ("admin", "secret"));
            app.Navigator.GoToGroupsPage();
            app.Groups.CreateGroup();
            GroupData group = new GroupData("g1");
            group.Footer = "f1";
            group.Header = "h1";
            app.Groups.FillInGroupForm(group);
            app.Groups.ConfirmGroupCreation();
            app.Navigator.GoToGroupsPage();
            app.Navigator.Logout();
        }
    }
}
