using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace Addressbook_Web_Tests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    { 
        [Test]
        public void GroupCreationTest()
        {
            
            GroupData group = new GroupData("g1");
            group.Footer = "f1";
            group.Header = "h1";

            app.Groups.New(group);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Footer = "";
            group.Header = "";

            app.Groups.New(group);

        }
    }
}
