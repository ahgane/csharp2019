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

        internal void Remove(int v)
        {
            manager.Navigator.GoToHomePage();

            SelectContact(v);
            ConfirmContactRemoval(v);

            manager.Navigator.GoToHomePage();

        }

        public ContactHelper Modify(int v, ContactData newContact)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(v);
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
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
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
        public ContactHelper ConfirmContactRemoval(int v)
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

    }
}
