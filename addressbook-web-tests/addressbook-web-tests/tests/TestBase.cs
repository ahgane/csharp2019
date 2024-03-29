﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Addressbook_Web_Tests
{
    public class TestBase
    {
        protected ApplicationManager app;
        public static bool PERFORM_LONG_UI_CHECKS = true;

        [SetUp]

        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }

        public static Random rnd = new Random();

        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(Convert.ToInt32(32+rnd.NextDouble() * 65)));
            }
            return builder.ToString();
        }

 /*       public static int GenerateRandomInteger(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            int builder = 0;
            for (int i = 0; i < l; i++)
            {
                builder=builder +Convert.ToInt32(32 + rnd.NextDouble() * 223);
            }
            return builder;
        }*/
    }
}
