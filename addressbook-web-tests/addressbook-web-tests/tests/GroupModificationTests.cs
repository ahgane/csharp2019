using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Addressbook_Web_Tests
{
    [TestFixture]
        public class GroupModificationTests : TestBase
        {
            [Test]

           public void GroupModificationTest()
            {

                GroupData newData = new GroupData("g new");
                newData.Footer = "f2";
                newData.Header = "h3";

                app.Groups.Modify (1, newData);

            }
        }
}
