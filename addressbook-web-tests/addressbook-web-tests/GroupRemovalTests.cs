using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace Addressbook_Web_Tests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            GoToLoginPage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            RemoveGroup(1);
            GoToGroupsPage();
            Logout();
        }
    }
}
