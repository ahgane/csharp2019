using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Addressbook_Web_Tests
{
    [TestFixture]
   public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            //prepare
            app.Auth.Logout();

            //action
            AccountData account = new AccountData("admin", "secret");

            //verification
            app.Auth.Login(account);
            Assert.IsTrue(app.Auth.IsLoggedIn());

        }

        [Test]
        public void LoginWithInValidCredentials()
        {
            //prepare
            app.Auth.Logout();

            //action
            AccountData account = new AccountData("admin", "wrong");

            //verification
            app.Auth.Login(account);
            Assert.IsFalse(app.Auth.IsLoggedIn());

        }

    }
}
