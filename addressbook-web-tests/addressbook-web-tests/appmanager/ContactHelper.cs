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
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
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
            InitContactModification();
            FillInContactForm(newContact);
            SubmitContactModification();

            manager.Navigator.GoToHomePage();

            return this;
        }

        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.CssSelector("img[alt=\"Edit\"]")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
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
            return this;
        }

        public ContactHelper FillInContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Name);
            Type(By.Name("lastname"), contact.Surname);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("mobile"), contact.Mobile);

            return this;
        }
        public ContactHelper ConfirmContactRemoval()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }

        public List<ContactData> GetContactList()
        {
            manager.Navigator.GoToHomePage();
            List<ContactData> contacts = new List<ContactData>();
            foreach (int a in .Count)
            {
                ICollection<IWebElement> surnames = driver.FindElement(((By.XPath("//table[@id='maintable']/tbody/tr["+int+"]/td[2]"))));
            }
            ICollection<IWebElement> names = driver.FindElements(((By.XPath("//table[@id='maintable']/tbody/tr/td[3]"))));
            foreach (IWebElement element in surnames)
            {
                contacts.Add(new ContactData(null,element.Text));
            }
 /*           foreach (IWebElement element in names)
            {
                contacts.Add(new ContactData(element.Text,null));
            }
            */
            return contacts;
        }

    }
}
