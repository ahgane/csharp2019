using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace addressbook_web_tests.tests
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            string[] s = new string[] {"test", "I", "Want", "to", "sleep", "foreach"};
            foreach (string element in s)
            {
                System.Console.Out.Write(element + "\n");
            }
        }
    }
}
