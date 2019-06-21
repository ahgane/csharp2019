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
    public class NavigationHelper : HelperBase
    {
        private string baseURL;
        public NavigationHelper(ApplicationManager manager) : base(manager)
        {
            baseURL = manager.BaseURL;
        }
        public void GoToLoginPage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }
        public void GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }
        public void GoToHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }
        public void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}