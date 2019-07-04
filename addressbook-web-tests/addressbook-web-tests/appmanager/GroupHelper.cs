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
        public GroupHelper(ApplicationManager manager) : base (manager)
        {
        }

        public GroupHelper Remove(int v)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(v);
            RemoveGroup(v);
            manager.Navigator.GoToGroupsPage();
            return this;
        }

        public List<GroupData> GetGroupList()
        {
            manager.Navigator.GoToGroupsPage();
            List<GroupData> groups = new List<GroupData>();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            foreach (IWebElement element in elements)
            {
                groups.Add(new GroupData(element.Text));              
            }

            return groups;
        }

        public GroupHelper Modify(int v, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(v);
            InitGroupModification();
            FillInGroupForm(newData);
            SubmitGroupModification();
            manager.Navigator.GoToGroupsPage();

            return this;
        }

        public GroupHelper New(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();

            CreateGroup();
            FillInGroupForm(group);
            ConfirmGroupCreation();
            manager.Navigator.GoToGroupsPage();

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
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper RemoveGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='delete'])[" + (index+1) + "]")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//span[@class='group'])[" + (index+1) + "]")).Click();

            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public bool GroupExist()
        {
            return (driver.Url == "http://localhost:8080/addressbook/group.php"
                && IsElementPresent(By.Name("selected[]")));
        }


    }
}
