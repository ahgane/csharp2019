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
            navigator.GoToLoginPage();
            loginHelper.Login(new AccountData ("admin", "secret"));
            navigator.GoToGroupsPage();
            CreateGroup();
            GroupData group = new GroupData("g1");
            group.Footer = "f1";
            group.Header = "h1";
            FillInGroupForm(group);
            ConfirmGroupCreation();
            navigator.GoToGroupsPage();
            Logout();
        }
    }
}
