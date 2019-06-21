﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Addressbook_Web_Tests
{
    public class HelperBase
    {
        protected IWebDriver driver;
        public HelperBase (IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}