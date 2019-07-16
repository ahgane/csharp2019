using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

namespace Addressbook_Web_Tests
{
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        internal ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;
            string allEmails = cells[4].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails
            };
        }

        internal ContactData GetContactInformationEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(0);

            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };
        }

        public bool ContactExist()
        {
            return (driver.Url == "http://localhost:8080/addressbook/"
                && IsElementPresent(By.Name("selected[]")));
        }

        internal void Remove(int v)
        {
            manager.Navigator.GoToHomePage();

            SelectContact(v);
            ConfirmContactRemoval();

            manager.Navigator.GoToHomePage();

        }

        public ContactHelper Modify(ContactData newContact)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(0);
            FillInContactForm(newContact);
            SubmitContactModification();

            manager.Navigator.GoToHomePage();

            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            //           driver.FindElement(By.CssSelector("img[alt=\"Edit\"]")).Click();
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper NewContact (ContactData contact)
        {
            manager.Navigator.GoToHomePage();

            CreateNewContact();
            FillInContactForm(contact);
            ConfirmContactCreation();

            manager.Navigator.GoToHomePage();

            return this;
        }

        public ContactHelper CreateNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactHelper ConfirmContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper FillInContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Name);
            Type(By.Name("lastname"), contact.Surname);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("mobile"), contact.MobilePhone);

            return this;
        }
        public ContactHelper ConfirmContactRemoval()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }

        private List<ContactData> contactCache = null;
        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                List<ContactData> contacts = new List<ContactData>();
                List<IWebElement> cells = new List<IWebElement>();
                ICollection<IWebElement> contactstable = driver.FindElements(By.Name("entry"));

                foreach (IWebElement element in contactstable)
                {
                    cells = element.FindElements((By.TagName("td"))).ToList();
                            
                    contactCache.Add(new ContactData(cells[2].Text, cells[1].Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
            
            return new List<ContactData>(contactCache);
        }

        public bool CompareTo(List<ContactData> oldContactslist, List<ContactData> newContactslist)
        {
            if (oldContactslist.Count != newContactslist.Count)
            {
                return false;
            }
            else
            {

                for (int i = 0; i < oldContactslist.Count; i++)
                {
                    if (oldContactslist[i].Surname == newContactslist[i].Surname)
                    {
                        return (oldContactslist[i].Name == newContactslist[i].Name);
                    }
                    else
                    {
                        return (oldContactslist[i].Surname == newContactslist[i].Surname);
                    }

                }
                return true;
            }
        }


        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }

    }
}
