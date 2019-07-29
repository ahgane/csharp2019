using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace Addressbook_Web_Tests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
 
        private string allPhones;
        private string allEmails;

        public ContactData()
        {
        }


        public ContactData(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return Name == other.Name && Surname == other.Surname;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return "Name: " + Name + "Surname: " + Surname + "\nAddress: " + Address + "\nHomePhone:  " + HomePhone+ "\nEmail: " + Email;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            int temp = Surname.CompareTo(other.Surname);
            if (temp == 0)
                {
                    return (Name.CompareTo(other.Name));
                }
            else
                {
                return temp;
            }
   
        }

       
        [Column (Name = "firstname")]
        public string Name { get; set; }
        [Column(Name = "lastname")]
        public string Surname { get; set; }
        [Column(Name = "address")]
        public string Address { get; set; }

        [Column(Name = "home")]

        public string HomePhone { get; set; } 

        public string MobilePhone { get; set; }

        [Column(Name = "email")]
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string WorkPhone { get; set; }

        [Column(Name = "id"), PrimaryKey]
        public string Id { get; set; }

        [Column (Name = "deprecated")]
        public string Deprecated { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUpEmail(Email) + CleanUpEmail(Email2) + CleanUpEmail(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "H:M:W:[ -()]", "")+ "\r\n";
        }

        private string CleanUpEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return Regex.Replace(email, "[ -()]mailto:", "") + "\r\n";
        }

        public static List<ContactData> GetAll()
        {
            using (AddressBookBD db = new AddressBookBD())
            {
                return (from c in db.Contacts.Where (x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }

        }

    }
}
