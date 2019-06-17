using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addressbook_Web_Tests
{
   public class ContactData
    {
        private string name;
        private string surname;
        private string address = "";
        private string mobile = "";

        public ContactData(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
            }
        }
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        public string Mobile
        {
            get
            {
                return mobile;
            }
            set
            {
                mobile = value;
            }
        }

    }
}
