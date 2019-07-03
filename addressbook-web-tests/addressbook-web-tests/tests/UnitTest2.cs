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
            string[] s = new string[] {"test", "I", "Want", "to", "sleep" };
            for (int i = 0; i < s.Length; i = i + 1)
            {
                System.Console.Out.Write(s[i] + "\n");
            }
        }
    }
}
