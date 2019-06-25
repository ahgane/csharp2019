using System;
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
            if (driver.Url == baseURL)
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL);
        }
        public void GoToGroupsPage()
        {
            if (driver.Url == baseURL + "/group.php"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }
            else
            {
                driver.FindElement(By.LinkText("groups")).Click();
            }
        }
        public void GoToHomePage()
        {
            if (driver.Url == baseURL
                && IsElementPresent(By.LinkText("home")))
            {
                return;
            }
            else
            {
                driver.FindElement(By.LinkText("home")).Click();
            }
        }
    }
}
