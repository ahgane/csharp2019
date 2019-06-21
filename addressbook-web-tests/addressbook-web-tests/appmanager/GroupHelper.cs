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
    public class GroupHelper : HelperBase
    {
        public GroupHelper(IWebDriver driver) : base (driver)
        {
        }

        public GroupHelper New(GroupData group)
        {
            CreateGroup();
            FillInGroupForm(group);
            ConfirmGroupCreation();
            return this;
        }

        public GroupHelper ConfirmGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
        public GroupHelper CreateGroup()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper FillInGroupForm(GroupData group)
        {
            driver.FindElement(By.Name("group_name")).Click();
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Click();
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Click();
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
            return this;
        }
        public GroupHelper RemoveGroup(int index)
        {
            driver.FindElement(By.Name("selected[]")).Click();
            driver.FindElement(By.XPath("(//input[@name='delete'])[" + index + "]")).Click();
            return this;
        }

    }
}
